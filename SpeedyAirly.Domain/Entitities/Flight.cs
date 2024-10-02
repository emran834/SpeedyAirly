namespace SpeedyAirly.Domain.Entitities;

public class Flight
{
    public int FlightNumber { get; init; }
    public string Departure { get; init; } = "";
    public string Arrival { get; init; } = "";
    public int Day { get; init; }
    public int Capacity { get; set; } 

    public override string ToString()
    {
        return $"Flight: {FlightNumber}, departure: {Departure}, arrival: {Arrival}, day: {Day}";
    }
}

 