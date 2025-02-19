public class BookingRepository : IBookingRepository
{
    private readonly List<Booking> bookings1 = new List<Booking>()
    {
        new Booking { Id = "1", Date = DateTime.Now, Location = "Frankfurt", Status = "Active" },
        new Booking { Id = "2", Date = DateTime.Now, Location = "Luxembourg", Status = "Active" },
        new Booking { Id = "3", Date = DateTime.Now, Location = "Stockholm", Status = "Active" },
        new Booking { Id = "4", Date = DateTime.Now, Location = "Paris", Status = "Active" },
        new Booking { Id = "5", Date = DateTime.Now, Location = "Barcelona", Status = "Active" }
    };

    public IEnumerable<Booking> GetAllBookings() => bookings1;
    
    public Booking? GetBookingById(string id)
    {
        return bookings1.FirstOrDefault(x => x.Id == id);
    }

    public void CreateBooking(Booking booking)
    {
        bookings1.Add(booking);
    }

    public void DeleteBooking(string id)
    {
        var booking = bookings1.FirstOrDefault(x => x.Id == id);
        bookings1.Remove(booking);
    }

    public void UpdateBooking(Booking booking)
    {
        var existingBooking = bookings1.FirstOrDefault(x => x.Id == booking.Id);
        existingBooking.Date = booking.Date;
        existingBooking.Location = booking.Location;
        existingBooking.Status = booking.Status;
    }
}