namespace BikeRentalAppLibrary.Models;

public class TypeModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string ObjectIdentifier { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public double Price { get; set; }
}
