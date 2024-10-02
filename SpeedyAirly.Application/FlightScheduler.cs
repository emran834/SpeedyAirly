using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Interfaces;

namespace SpeedyAirly.Application;

public class FlightScheduler(ISchedulingStrategyFactory strategyFactory)
{
    public List<ScheduledOrder> ScheduleOrders(List<Order> orders, List<Flight> flights, string strategyType)
    {
        ISchedulingStrategy strategy = strategyFactory.CreateStrategy(strategyType);

        return strategy.ScheduleOrders(orders, flights);
    }
}