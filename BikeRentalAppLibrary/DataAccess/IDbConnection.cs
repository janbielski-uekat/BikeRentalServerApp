using MongoDB.Driver;

namespace BikeRentalAppLibrary.DataAccess;

public interface IDbConnection
{
   IMongoCollection<BookingModel> BookingCollection { get; }
   string BookingCollectionName { get; }
   MongoClient Client { get; }
   string DbName { get; }
   IMongoCollection<StationModel> StationCollection { get; }
   string StationCollectionName { get; }
   IMongoCollection<TypeModel> TypeCollection { get; }
   string TypeCollectionName { get; }
   IMongoCollection<UserModel> UserCollection { get; }
   string UserCollectionName { get; }
}