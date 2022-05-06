namespace BikeRentalAppLibrary.Models;

public class StationModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string Name { get; set; }
	public string City { get; set; }
	public string Street { get; set; }
	public int Number { get; set; }
	public string PostalCode { get; set; }
	public double Longitude { get; set; }
	public double Latitude { get; set; }
}
