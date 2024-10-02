using Microsoft.Extensions.DependencyInjection;
using SpeedyAirly.Application;
using SpeedyAirly.DataAccess;
using SpeedyAirly.Domain.Factories;
using SpeedyAirly.Domain.Interfaces;
using SpeedyAirly.Domain.Strategies;

namespace SpeedAirly.Presentation;

public class ApplicationBootstrapper
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationBootstrapper()
    {
        ServiceCollection serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
      
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ISchedulingStrategyFactory, SchedulingStrategyFactory>() 
            .AddScoped<ISchedulingStrategy, PrioritySchedulingStrategy>()
            .AddScoped<FlightService>()
            .AddScoped<OrderRetrievalService>()
            .AddScoped<FlightRetrievalService>()
            .AddScoped<FlightScheduler>() 
            .AddScoped<ResultDisplayService>()
            .AddScoped<IOrderRepository>(_ => new JsonOrderRepository("AppData/coding-assignment-orders.json"))
            .AddScoped<IFlightRepository>(_ => new JsonFlightRepository("AppData/flightSchedule.json"))
            .AddScoped<ApplicationRunner>();
    }

    public void Run()
    {
        ApplicationRunner? appRunner = _serviceProvider.GetService<ApplicationRunner>();
        appRunner?.Run();
    }
}