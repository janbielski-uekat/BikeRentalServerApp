using Microsoft.Extensions.Caching.Memory;

namespace BikeRentalAppLibrary.DataAccess;
public class MongoBookingData : IBookingData
{
	private readonly IDbConnection _db;
	private readonly IUserData _userData;
	private readonly IMemoryCache _cache;
	private readonly IMongoCollection<BookingModel> _bookings;
	private const string CacheName = "BookingData";

	public MongoBookingData(IDbConnection db, IUserData userData, IMemoryCache cache)
	{
		_db = db;
		_userData = userData;
		_cache = cache;
		_bookings = db.BookingCollection;
	}

	public async Task<List<BookingModel>> GetAllBookings()
	{
		var output = _cache.Get<List<BookingModel>>(CacheName);
		if (output == null)
		{
			var results = await _bookings.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
		}

		return output;
	}

	public async Task<BookingModel> GetBooking(string id)
	{
		var results = await _bookings.FindAsync(b => b.Id == id);
		return results.FirstOrDefault();
	}

	public async Task UpadateBooking(BookingModel booking)
	{
		await _bookings.ReplaceOneAsync(b => b.Id == booking.Id, booking);
		_cache.Remove(CacheName);
	}

	public async Task CreateBooking(BookingModel booking)
	{
		var client = _db.Client;
		using var session = await client.StartSessionAsync();
		session.StartTransaction();

		try
		{
			var db = client.GetDatabase(_db.DbName);
			var bookingsInTransaction = db.GetCollection<BookingModel>(_db.BookingCollectionName);
			await bookingsInTransaction.InsertOneAsync(booking);

			var usersInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
			var user = await _userData.GetUser(booking.Renter.Id);
			user.Bookings.Add(new BasicBookingModel(booking));
			await usersInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

			await session.CommitTransactionAsync();
			_cache.Remove(CacheName);
		}
		catch (Exception ex)
		{
			await session.AbortTransactionAsync();
			throw;
		}
	}
}
