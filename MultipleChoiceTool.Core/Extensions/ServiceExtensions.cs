using Microsoft.Extensions.DependencyInjection;
using MultipleChoiceTool.Core.Providers;

namespace MultipleChoiceTool.Core.Extensions;

/// <summary>
/// Provides extension methods for registering services in the MultipleChoiceTool.Core.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds the core services of the MultipleChoiceTool to the specified IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    public static void AddMultipleChoiceToolCore(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, SystemDateTimeProvider>();
    }
}
