
namespace BikeRentalAppLibrary.DataAccess;

public interface ITypeData
{
	Task CreateType(TypeModel type);
	Task<List<TypeModel>> GetAllTypes();
	Task<Dictionary<TypeModel, int>> GetOrderDictionary();
}