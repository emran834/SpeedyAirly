using NUnit.Framework;
using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Strategies;

namespace DomainTests;

[TestFixture]
public class PrioritySchedulingStrategyTests
{
    private PrioritySchedulingStrategy _strategy;

    [SetUp]
    public void Setup()
    {
        // Initialize the strategy before each test
        _strategy = new PrioritySchedulingStrategy();
    }

    [Test]
    public void ScheduleOrders_ShouldAssignOrderToFlight_WhenFlightHasCapacity()
    {
        // Arrange
        List<Order> orders = [new() { OrderId = "order-001", Destination = "YYZ" }];

        List<Flight> flights = [new() { FlightNumber = 1, Arrival = "YYZ", Departure = "YUL", Day = 1, Capacity = 20 }];

        // Act
        List<ScheduledOrder> scheduledOrders = _strategy.ScheduleOrders(orders, flights);

        Assert.That(scheduledOrders[0].FlightNumber, Is.EqualTo(1), "Order should be assigned to Flight 1");
        Assert.That(scheduledOrders[0].Day, Is.EqualTo(1), "Order should be assigned on Day 1");
        Assert.That(flights[0].Capacity, Is.EqualTo(19), "Flight capacity should be reduced by 1");
    }

    [Test]
    public void ScheduleOrders_ShouldAssignMultipleOrdersToSameFlight_WhenFlightHasEnoughCapacity()
    {
        // Arrange
        List<Order> orders =
        [
            new() { OrderId = "order-001", Destination = "YYZ" },
            new() { OrderId = "order-002", Destination = "YYZ" }
        ];

        List<Flight> flights = [new() { FlightNumber = 1, Arrival = "YYZ", Departure = "YUL", Day = 1, Capacity = 20 }];

        // Act
        List<ScheduledOrder> scheduledOrders = _strategy.ScheduleOrders(orders, flights);

        Assert.That(scheduledOrders[0].FlightNumber, Is.EqualTo(1), "First order should be assigned to Flight 1");
        Assert.That(scheduledOrders[1].FlightNumber, Is.EqualTo(1), "Second order should be assigned to the same Flight 1");
        Assert.That(flights[0].Capacity, Is.EqualTo(18), "Flight capacity should be reduced by 2");
    }

    [Test]
    public void ScheduleOrders_ShouldAssignOrderToNextAvailableFlight_WhenFlightIsFull()
    {
        // Arrange
        List<Order> orders =
        [
            new() { OrderId = "order-001", Destination = "YYZ" },
            new() { OrderId = "order-002", Destination = "YYZ" },
            new() { OrderId = "order-003", Destination = "YYZ" }
        ];

        List<Flight> flights =
        [
            new() { FlightNumber = 1, Arrival = "YYZ", Departure = "YUL", Day = 1, Capacity = 2 },
            new() { FlightNumber = 2, Arrival = "YYZ", Departure = "YUL", Day = 2, Capacity = 20 }
        ];

        // Act
        List<ScheduledOrder> scheduledOrders = _strategy.ScheduleOrders(orders, flights);

        Assert.That(scheduledOrders[0].FlightNumber, Is.EqualTo(1), "First order should be assigned to Flight 1");
        Assert.That(scheduledOrders[1].FlightNumber, Is.EqualTo(1), "Second order should be assigned to Flight 1");
        Assert.That(scheduledOrders[2].FlightNumber, Is.EqualTo(2), "Third order should be assigned to Flight 2");
        Assert.That(flights[0].Capacity, Is.EqualTo(0), "Flight 1 should be full");
        Assert.That(flights[1].Capacity, Is.EqualTo(19), "Flight 2 should have 1 less capacity");
    }

    [Test]
    public void ScheduleOrders_ShouldLeaveOrderUnscheduled_WhenNoFlightsAvailable()
    {
        // Arrange
        List<Order> orders = [new() { OrderId = "order-001", Destination = "YYZ" }];

        List<Flight> flights = []; // No available flights

        // Act
        List<ScheduledOrder> scheduledOrders = _strategy.ScheduleOrders(orders, flights);

        Assert.That(scheduledOrders, Is.Empty, "No orders should be scheduled since no flights are available.");
    }

    [Test]
    public void ScheduleOrders_ShouldNotAssignOrders_WhenFlightCapacityIsZero()
    {
        // Arrange
        List<Order> orders = [ new() { OrderId = "order-001", Destination = "YYZ" }, new() { OrderId = "order-002", Destination = "YYZ" }];

        List<Flight> flights = [new() { FlightNumber = 1, Arrival = "YYZ", Departure = "YUL", Day = 1, Capacity = 0 }];

        // Act
        List<ScheduledOrder> scheduledOrders = _strategy.ScheduleOrders(orders, flights);

        Assert.That(scheduledOrders, Is.Empty, "No orders should be scheduled since the flight capacity is zero.");
    }
}