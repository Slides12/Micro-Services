var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Booking> bookings = new List<Booking>()
{
    new Booking { Id = 1, Date = DateTime.Now, Location = "Frankfurt", Status = "Active" },
    new Booking { Id = 2, Date = DateTime.Now, Location = "Luxembourg", Status = "Active" },
    new Booking { Id = 3, Date = DateTime.Now, Location = "Stockholm", Status = "Active" },
    new Booking { Id = 4, Date = DateTime.Now, Location = "Paris", Status = "Active" },
    new Booking { Id = 5, Date = DateTime.Now, Location = "Barcelona", Status = "Active" }
};

app.MapGet("/GetAllBookings", (IBookingRepository bookingRepository) => bookingRepository.GetAllBookings());

app.MapGet("/GetBookingById/{id}", (int id, IBookingRepository bookingRepository) => bookingRepository.GetBookingById(id));

app.MapPost("/CreateBooking", (Booking booking, IBookingRepository bookingRepository) => bookingRepository.CreateBooking(booking));

app.MapPut("/UpdateBooking", (Booking booking, IBookingRepository bookingRepository) => bookingRepository.UpdateBooking(booking));

app.MapDelete("/DeleteBooking/{id}", (int id, IBookingRepository bookingRepository) => bookingRepository.DeleteBooking(id));

app.Run();

public class Booking
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
}