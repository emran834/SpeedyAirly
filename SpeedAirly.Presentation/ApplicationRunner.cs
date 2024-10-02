using SpeedyAirly.Application;
using SpeedyAirly.Common;

namespace SpeedAirly.Presentation;

public class ApplicationRunner(FlightService flightService)
{
    public void Run()
    {
        flightService.Execute(AppConstants.PriorityStrategy);
    }
}