using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Interfaces;

namespace SpeedyAirly.Domain.Strategies;

public class PrioritySchedulingStrategy : ISchedulingStrategy
{
    public List<ScheduledOrder> ScheduleOrders(List<Order> orders, List<Flight> flights)
    {
        List<ScheduledOrder> scheduledOrders = [];

        foreach (Order order in orders)
        {
            Flight? availableFlight = flights
                .FirstOrDefault(f => f.Arrival == order.Destination && f.Capacity > 0);

            if (availableFlight != null)
            {
                ScheduledOrder scheduledOrder = new ScheduledOrder(order, availableFlight.FlightNumber, availableFlight.Day, availableFlight.Departure);
                scheduledOrders.Add(scheduledOrder);
                availableFlight.Capacity--;
            }
        }

        return scheduledOrders;
    }
}