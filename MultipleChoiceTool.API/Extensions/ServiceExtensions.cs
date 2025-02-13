using MultipleChoiceTool.API.Mappings;

namespace MultipleChoiceTool.API.Extensions;

public static class ServiceExtensions
{
    public static void AddMultipleChoiceToolApi(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApiMappings));
    }
}
