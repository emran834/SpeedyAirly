using SpeedyAirly.Domain.Entitities;

namespace SpeedyAirly.Application;

public class ResultDisplayService
{
    public void DisplayFlights(List<Flight> flights)
    {
        Console.WriteLine("Flights:");

        foreach (Flight flight in flights)
        {
            Console.WriteLine(flight);
        }
    }

    public void DisplayScheduledOrders(List<ScheduledOrder> scheduledOrders, List<Order> allOrders)
    {
        Console.WriteLine("Scheduled Orders:");

        Dictionary<string, ScheduledOrder> scheduledOrderDict = scheduledOrders.ToDictionary(o => o.Order.OrderId);

        foreach (Order order in allOrders)
        {
            ScheduledOrder? scheduledOrder = scheduledOrderDict.GetValueOrDefault(order.OrderId);

            Console.WriteLine(scheduledOrder != null
                ? $"order: {scheduledOrder.Order.OrderId}, flightNumber: {scheduledOrder.FlightNumber}, departure: {scheduledOrder.Departure}, arrival: {scheduledOrder.Arrival}, day: {scheduledOrder.Day}"
                : $"order: {order.OrderId}, flightNumber: not scheduled");
        }
    }
}