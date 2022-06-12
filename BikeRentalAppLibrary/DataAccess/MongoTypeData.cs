using Microsoft.Extensions.Caching.Memory;

namespace BikeRentalAppLibrary.DataAccess;
public class MongoTypeData : ITypeData
{
	private readonly IMemoryCache _cache;
	private readonly IMongoCollection<TypeModel> _types;
	private const string CacheName = "CategoryData";

	public MongoTypeData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
		_types = db.TypeCollection;
	}

	public async Task<List<TypeModel>> GetAllTypes()
	{
		var output = _cache.Get<List<TypeModel>>(CacheName);
		if (output == null)
		{
			var results = await _types.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output, TimeSpan.FromDays(1));
		}

		return output;
	}
	public async Task<Dictionary<TypeModel, int>> GetOrderDictionary()
	{
		var types = await _types.FindAsync(_ => true);
		var typesList = types.ToList();
		Dictionary<TypeModel, int> result = new Dictionary<TypeModel, int>();

		foreach (var type in typesList)
		{
			result.Add(type, 0);
		}
		
		return result;
	}
	public Task CreateType(TypeModel type)
	{
		return _types.InsertOneAsync(type);
	}
}
