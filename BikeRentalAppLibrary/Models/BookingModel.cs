namespace BikeRentalAppLibrary.Models;

public class BookingModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public BasicUserModel Renter { get; set; }
	public DateTime DatePlaced { get; set; } = DateTime.UtcNow;
	public DateTime StartDate { get; set; } = DateTime.UtcNow;
	public DateTime EndDate { get; set; } = DateTime.UtcNow;
	public string StartStationId { get; set; }
	public string EndStationId { get; set; }
	public string BikeType { get; set; }
}
