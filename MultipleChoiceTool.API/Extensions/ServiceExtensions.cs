using MultipleChoiceTool.API.Mappings;
using MultipleChoiceTool.API.Settings;

namespace MultipleChoiceTool.API.Extensions;

public static class ServiceExtensions
{
    public static void AddMultipleChoiceToolApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(ApiMappings));
        services.AddMultipleChoiceToolCors(configuration);
    }

    private static void AddMultipleChoiceToolCors(this IServiceCollection services, IConfiguration configuration)
    {
        var corsSettings = configuration.GetSection("Cors")?.Get<CorsSettings>();

        services.AddCors(options =>
        {
            options.AddPolicy(CorsSettings.PolicyName, builder =>
            {
                builder.WithOrigins(corsSettings?.AllowedOrigins ?? ["*"])
                       .WithMethods(corsSettings?.AllowedMethods ?? ["*"])
                       .WithHeaders(corsSettings?.AllowedHeaders ?? ["*"]);
                
                if (corsSettings?.AllowCredentials == true)
                {
                    builder.AllowCredentials();
                }
            });
        });
    }
}
