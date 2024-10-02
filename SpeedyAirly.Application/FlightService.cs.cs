using SpeedyAirly.Domain.Entitities;

namespace SpeedyAirly.Application;

public class FlightService(
    OrderRetrievalService orderRetrievalService,
    FlightRetrievalService flightRetrievalService,
    FlightScheduler flightScheduler,
    ResultDisplayService resultDisplayService)
{
    public void Execute(string strategyType)
    {
        List<Flight> flights = flightRetrievalService.GetFlights();

        // User Story 1: Display Flights
        resultDisplayService.DisplayFlights(flights);
        
        List<Order> orders = orderRetrievalService.GetOrders();

        List<ScheduledOrder> scheduledOrders = flightScheduler.ScheduleOrders(orders, flights, strategyType);

        // User Story 2: Display Scheduled Orders
        resultDisplayService.DisplayScheduledOrders(scheduledOrders, orders);
    }
}
