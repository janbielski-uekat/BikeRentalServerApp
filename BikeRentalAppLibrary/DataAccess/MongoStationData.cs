using Microsoft.Extensions.Caching.Memory;

namespace BikeRentalAppLibrary.DataAccess;
public class MongoStationData : IStationData
{
	private readonly IMongoCollection<StationModel> _stations;
	private readonly IMemoryCache _cache;
	private const string CacheName = "StatusData";

	public MongoStationData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
		_stations = db.StationCollection;
	}

	public async Task<List<StationModel>> GetAllStations()
	{
		var output = _cache.Get<List<StationModel>>(CacheName);
		if (output == null)
		{
			var results = await _stations.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output, TimeSpan.FromDays(1);
		}

		return output;
	}

	public Task CreateStation(StationModel station)
	{
		return _stations.InsertOneAsync(station);
	}
}
