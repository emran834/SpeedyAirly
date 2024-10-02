namespace SpeedyAirly.Domain.Entitities;

public class ScheduledOrder(Order order, int flightNumber, int day, string departure)
{
    public Order Order { get; } = order ?? throw new ArgumentNullException(nameof(order));
    public int FlightNumber { get; } = flightNumber;
    public int Day { get; } = day;
    public string Departure { get; } = departure;
    public string Arrival => Order.Destination;

    public override string ToString()
    {
        return $"Order: {Order.OrderId}, Flight: {FlightNumber}, Day: {Day}, Departure: {Departure}, Arrival: {Arrival}";
    }
}