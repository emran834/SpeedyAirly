using Newtonsoft.Json;
using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Interfaces;

namespace SpeedyAirly.DataAccess;

public class JsonOrderRepository(string filePath) : IOrderRepository
{
    public List<Order> GetOrders()
    {
        string json = File.ReadAllText(filePath);
        Dictionary<string, Order>? ordersDict = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
      
        return ordersDict?.Select(x => new Order { OrderId = x.Key, Destination = x.Value.Destination }).ToList() ?? [];
    }
}