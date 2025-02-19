public interface IBookingRepository
{
    IEnumerable<Booking> GetAllBookings();
    Booking? GetBookingById(string id);
    void CreateBooking(Booking booking);
    void UpdateBooking(Booking booking);
    void DeleteBooking(string id);
}