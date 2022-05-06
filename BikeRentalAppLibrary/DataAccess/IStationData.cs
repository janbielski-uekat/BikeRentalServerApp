
namespace BikeRentalAppLibrary.DataAccess;

public interface IStationData
{
	Task CreateStation(StationModel station);
	Task<List<StationModel>> GetAllStations();
}