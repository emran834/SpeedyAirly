using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Interfaces;

namespace SpeedyAirly.Application;

public class OrderRetrievalService(IOrderRepository orderRepository)
{
    public List<Order> GetOrders()
    {
        return orderRepository.GetOrders();
    }
}