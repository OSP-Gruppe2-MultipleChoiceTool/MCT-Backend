using Microsoft.Extensions.DependencyInjection;

namespace MultipleChoiceTool.Service.Extensions;

public static class ServiceExtensions
{
    public static void AddMultipleChoiceToolService(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
        });
    }
}
