namespace SpeedyAirly.Domain.Entitities;

public class Flight
{
    public int FlightNumber { get; set; }
    public string Departure { get; set; } = "";
    public string Arrival { get; set; } = "";
    public int Day { get; set; }
    public int Capacity { get; set; } 

    public override string ToString()
    {
        return $"Flight: {FlightNumber}, departure: {Departure}, arrival: {Arrival}, day: {Day}";
    }
}

 