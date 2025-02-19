public interface IBookingRepository
{
    IEnumerable<Booking> GetAllBookings();
    Booking? GetBookingById(int id);
    void CreateBooking(Booking booking);
    void UpdateBooking(Booking booking);
    void DeleteBooking(int id);
}