namespace SpeedyAirly.Domain.Interfaces;

public interface ISchedulingStrategyFactory
{
    ISchedulingStrategy CreateStrategy(string strategyType);
}