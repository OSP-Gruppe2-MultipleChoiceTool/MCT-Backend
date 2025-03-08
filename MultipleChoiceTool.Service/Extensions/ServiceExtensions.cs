using Microsoft.Extensions.DependencyInjection;

namespace MultipleChoiceTool.Service.Extensions;

/// <summary>
/// Provides extension methods for registering services in the MultipleChoiceTool application.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds the MultipleChoiceTool services to the specified IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the services to.</param>
    public static void AddMultipleChoiceToolService(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
        });
    }
}
