using SpeedyAirly.Domain.Entitities;

namespace SpeedyAirly.Domain.Interfaces;

public interface IFlightRepository
{
    List<Flight> GetFlights();
}