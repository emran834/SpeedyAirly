using NUnit.Framework;
using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Strategies;

namespace DomainTests;

[TestFixture]
public class CapacityOptimizedSchedulingStrategyTests
{
    private CapacityOptimizedSchedulingStrategy _strategy;

    [SetUp]
    public void Setup()
    {
        // Initialize the strategy before each test
        _strategy = new CapacityOptimizedSchedulingStrategy();
    }

    [Test]
    public void ScheduleOrders_ShouldAssignOrdersToFlightWithMostCapacity()
    {
        // Arrange
        List<Order> orders = 
        [
            new() { OrderId = "order-001", Destination = "YYZ" },
            new() { OrderId = "order-002", Destination = "YYZ"}
        ];

        List<Flight> flights =
        [
            new() { FlightNumber = 1, Arrival = "YYZ", Departure = "YUL", Day = 1, Capacity = 5 },
            new() { FlightNumber = 2, Arrival = "YYZ", Departure = "YUL", Day = 2, Capacity = 10 }
        ];

        // Act
        List<ScheduledOrder> scheduledOrders = _strategy.ScheduleOrders(orders, flights);

        Assert.That(scheduledOrders[0].FlightNumber, Is.EqualTo(2), "Order should be assigned to Flight 2 (most capacity)");
        Assert.That(scheduledOrders[1].FlightNumber, Is.EqualTo(2), "Second order should be assigned to Flight 2 as well");
        Assert.That(flights[1].Capacity, Is.EqualTo(8), "Flight 2 capacity should be reduced by 2");
    }
}