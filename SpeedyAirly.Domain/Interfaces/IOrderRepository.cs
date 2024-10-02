using SpeedyAirly.Domain.Entitities;

namespace SpeedyAirly.Domain.Interfaces;

public interface IOrderRepository
{
    List<Order> GetOrders();
}