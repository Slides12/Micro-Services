var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Booking> bookings = new List<Booking>()
{
    new Booking { Id = "1", Date = DateTime.Now, Location = "Frankfurt", Status = "Active" },
    new Booking { Id = "2", Date = DateTime.Now, Location = "Luxembourg", Status = "Active" },
    new Booking { Id = "3", Date = DateTime.Now, Location = "Stockholm", Status = "Active" },
    new Booking { Id = "4", Date = DateTime.Now, Location = "Paris", Status = "Active" },
    new Booking { Id = "5", Date = DateTime.Now, Location = "Barcelona", Status = "Active" }
};

app.MapGet("/GetAllBookings", () => bookings);

app.MapGet("/GetBookingById/{id}", (string id) => bookings.FirstOrDefault(x => x.Id == id));

app.MapPost("/CreateBooking", (Booking booking) =>
{
    bookings.Add(booking);
    return booking;
});

app.MapPut("/UpdateBooking", (Booking booking) =>
{
    var existingBooking = bookings.FirstOrDefault(x => x.Id == booking.Id);
    existingBooking.Date = booking.Date;
    existingBooking.Location = booking.Location;
    existingBooking.Status = booking.Status;
    return existingBooking;
});

app.MapDelete("/DeleteBooking/{id}", (string id) =>
{
    var booking = bookings.FirstOrDefault(x => x.Id == id);
    bookings.Remove(booking);
    return booking;
});

app.Run();

class Booking
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
}