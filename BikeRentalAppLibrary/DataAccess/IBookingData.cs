namespace BikeRentalAppLibrary.DataAccess;

public interface IBookingData
{
	Task CreateBooking(BookingModel booking);
	Task<List<BookingModel>> GetAllBookings();
	Task<BookingModel> GetBooking(string id);
	Task UpadateBooking(BookingModel booking);
}