using System.ComponentModel.DataAnnotations;

namespace BikeRentalServerAppUI.Models;

public class NewBookingModel
{
	public string Id { get; set; }
	public BasicUserModel Renter { get; set; }
	[Required]
	public DateTime DatePlaced { get; set; } = DateTime.UtcNow;
	[Required]
	public DateTime StartDate { get; set; } = DateTime.UtcNow;
	[Required]
	public DateTime EndDate { get; set; } = DateTime.UtcNow;
	[Required]
	public string StartStationId { get; set; }
	[Required]
	public string EndStationId { get; set; }
	[Required]
	public string BikeType { get; set; }
}
