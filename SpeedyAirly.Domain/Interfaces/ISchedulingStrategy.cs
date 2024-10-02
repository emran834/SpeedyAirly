using SpeedyAirly.Domain.Entitities;

namespace SpeedyAirly.Domain.Interfaces;

public interface ISchedulingStrategy
{
    List<ScheduledOrder> ScheduleOrders(List<Order> orders, List<Flight> flights);
}