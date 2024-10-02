using SpeedyAirly.Common;
using SpeedyAirly.Domain.Interfaces;
using SpeedyAirly.Domain.Strategies;

namespace SpeedyAirly.Domain.Factories;

public class SchedulingStrategyFactory : ISchedulingStrategyFactory
{
    public ISchedulingStrategy CreateStrategy(string strategyType)
    {
        return strategyType.ToLower() switch
        {
            AppConstants.PriorityStrategy => new PrioritySchedulingStrategy(),
            AppConstants.CapacityStrategy => new CapacityOptimizedSchedulingStrategy(),
            _ => throw new ArgumentException("Invalid strategy type")
        };
    }
}