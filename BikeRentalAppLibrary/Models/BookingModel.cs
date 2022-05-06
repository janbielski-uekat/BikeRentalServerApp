namespace BikeRentalAppLibrary.Models;

public class BookingModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public BasicUserModel Renter { get; set; }
	public DateTime DatePlaced { get; set; } = DateTime.UtcNow;
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string StartStationId { get; set; }
	public string EndStationId { get; set; }
	public Dictionary<string , int> Bikes { get; set; }
}
