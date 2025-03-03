using Microsoft.Extensions.DependencyInjection;
using MultipleChoiceTool.Core.Providers;

namespace MultipleChoiceTool.Core.Extensions;

public static class ServiceExtensions
{
    public static void AddMultipleChoiceToolCore(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, SystemDateTimeProvider>();
    }
}
