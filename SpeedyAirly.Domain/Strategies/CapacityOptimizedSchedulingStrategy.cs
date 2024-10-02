using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Interfaces;

namespace SpeedyAirly.Domain.Strategies;

public class CapacityOptimizedSchedulingStrategy : ISchedulingStrategy
{
    public List<ScheduledOrder> ScheduleOrders(List<Order> orders, List<Flight> flights)
    {
        List<ScheduledOrder> scheduledOrders = [];

        foreach (Order order in orders)
        {
            // Find the flight with the required destination that has the most available capacity
            Flight? availableFlight = flights
                .Where(f => f.Arrival == order.Destination && f.Capacity > 0)
                .OrderByDescending(f => f.Capacity)
                .FirstOrDefault();

            if (availableFlight != null)
            {
                ScheduledOrder scheduledOrder = new ScheduledOrder(
                    order,
                    availableFlight.FlightNumber,
                    availableFlight.Day,
                    availableFlight.Departure
                );

                scheduledOrders.Add(scheduledOrder);

                availableFlight.Capacity--;
            }
        }

        return scheduledOrders;
    }
}