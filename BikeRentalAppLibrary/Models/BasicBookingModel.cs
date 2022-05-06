namespace BikeRentalAppLibrary.Models;
public class BasicBookingModel
{
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string StartStationId { get; set; }

	public BasicBookingModel()
	{

	}

	public BasicBookingModel(BookingModel booking)
	{
		Id = booking.Id;
		StartDate = booking.StartDate;
		EndDate = booking.EndDate;
		StartStationId = booking.StartStationId;
	}
}
