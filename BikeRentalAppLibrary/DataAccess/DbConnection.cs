using Microsoft.Extensions.Configuration;

namespace BikeRentalAppLibrary.DataAccess;

public class DbConnection : IDbConnection
{
	private readonly IConfiguration _config;
	private readonly IMongoDatabase _db;
	private string _connectionId = "MongoDB";
	public string DbName { get; private set; }
	public string BookingCollectionName { get; private set; } = "bookings";
	public string StationCollectionName { get; private set; } = "stations";
	public string TypeCollectionName { get; private set; } = "types";
	public string UserCollectionName { get; private set; } = "users";

	public MongoClient Client { get; private set; }
	public IMongoCollection<BookingModel> BookingCollection { get; private set; }
	public IMongoCollection<StationModel> StationCollection { get; private set; }
	public IMongoCollection<TypeModel> TypeCollection { get; private set; }
	public IMongoCollection<UserModel> UserCollection { get; private set; }

	public DbConnection(IConfiguration config)
	{
		_config = config;
		Client = new MongoClient(_config.GetConnectionString(_connectionId));
		DbName = _config["DatabaseName"];
		_db = Client.GetDatabase(DbName);

		BookingCollection = _db.GetCollection<BookingModel>(BookingCollectionName);
		StationCollection = _db.GetCollection<StationModel>(StationCollectionName);
		TypeCollection = _db.GetCollection<TypeModel>(TypeCollectionName);
		UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
	}
}
