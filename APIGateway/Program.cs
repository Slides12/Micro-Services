using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
 config.DocumentName = "Minimal API";
 config.Title = "MinimalAPI v1";
 config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
 app.UseOpenApi();
 app.UseSwaggerUi(config =>
 {
  config.DocumentTitle = "MinimalAPI";
  config.Path = "/swagger";
  config.DocumentPath = "/swagger/{documentName}/swagger.json";
  config.DocExpansion = "list";
 });
}

// OrderService = 5189 (customer)
// ProductService = 5141 (booking)

var httpClient = new HttpClient();

//Get all Customers
app.MapGet("/gateway/GetAllCustomers", async () => {
    return await httpClient.GetStringAsync("http://localhost:5189/orders");
});
//Get all Customer by id
app.MapGet("/gateway/GetCustomerById/{id}", async (int id) => {
    return await httpClient.GetStringAsync($"http://localhost:5189/orders/{id}");
});

app.MapPost("/gateway/AddCustomer", async (HttpContext context) => {
    var customer = await context.Request.ReadFromJsonAsync<object>();
    var json = JsonSerializer.Serialize(customer);
    var content = new StringContent(json, Encoding.UTF8, "application/json");
    return await httpClient.PostAsync($"http://localhost:5189/orders",content);
});

app.MapPut("/gateway/UpdateCustomer/{id}", async (HttpContext context, int id) => {
    var customer = await context.Request.ReadFromJsonAsync<object>();
    var json = JsonSerializer.Serialize(customer);
    var content = new StringContent(json, Encoding.UTF8, "application/json");
    return await httpClient.PostAsync($"http://localhost:5189/orders", content);
});


//Get all bookings
app.MapGet("/gateway/GetAllBookings", async () => {
    return await httpClient.GetStringAsync("http://localhost:5141/GetAllBookings");
});

//Get all bookings
app.MapGet("/gateway/GetBookingById/{id}", async (int id) => {
    return await httpClient.GetStringAsync($"http://localhost:5141/GetBookingById/{id}");
});

//Add bookings
// app.MapPost("/gateway/CreateBooking/{object}", async (object) => {
//     return await httpClient.PostAsync($"http://localhost:5141/AddBooking/{object}");
// });

//Delete booking
app.MapDelete("/gateway/DeleteBooking/{id}", async (int id) => {
    return await httpClient.DeleteAsync($"http://localhost:5141/DeleteBooking/{id}");
});

app.Run();
 