using SpeedyAirly.Domain.Entitities;
using SpeedyAirly.Domain.Interfaces;

namespace SpeedyAirly.Application;

public class FlightRetrievalService(IFlightRepository flightRepository)
{
    public List<Flight> GetFlights()
    {
        return flightRepository.GetFlights();
    }
}