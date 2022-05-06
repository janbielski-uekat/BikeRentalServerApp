﻿namespace BikeRentalAppLibrary.Models;

public class UserModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string ObjectIdentifier { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string EmailAddress { get; set; }
	public List<BasicBookingModel> Bookings { get; set; } = new();
}
