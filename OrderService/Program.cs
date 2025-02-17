
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Order> orders = new()
{
    new Order{ Id = 1, Quantity= 1, Status = "Pending"},
    new Order{ Id = 2, Quantity= 3, Status = "Completed"}
};

app.MapGet("/orders", () => orders);
app.MapGet("/orders/{id}", (int id) => 
{
    var order = orders.FirstOrDefault(o => o.Id == id);

    if (order == null)
    {
        return Results.NotFound("Order not found!");
    }

    return Results.Ok(order);
});

app.MapPost("/orders", (Order order) => 
{
    orders.Add(order);
    return Results.Created("/orders/{order.id}", order);
}
);

app.MapPut("/orders/{id}", (int id, Order updatedOrder) =>
{
    var order = orders.FirstOrDefault(o => o.Id == id);
    if (order == null)
    {
    return Results.NotFound("Order not found");
    }

    order.Quantity = updatedOrder.Quantity;
    order.Status = updatedOrder.Status;

    return Results.Ok(order);
});

app.MapDelete("/orders/{id}", (int id) =>
{
    var order = orders.FirstOrDefault(o => o.Id == id);
    if (order == null)
    {
        return Results.NotFound("Order not found");
    }

    orders.Remove(order);
    return Results.NoContent();
});


app.Run();


class Order {
    public int Id { get; set; }
    public int Quantity { get; set; }
    public required string Status { get; set; }
}
