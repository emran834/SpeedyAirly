using Newtonsoft.Json;
using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Interfaces;

namespace SpeedyAirly.DataAccess;

public class JsonFlightRepository(string filePath) : IFlightRepository
{
    public List<Flight> GetFlights()
    {
        string json = File.ReadAllText(filePath);
        List<Flight>? flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        return flights ?? [];
    }
}