using MultipleChoiceTool.API.Mappings;
using MultipleChoiceTool.API.Settings;

namespace MultipleChoiceTool.API.Extensions;

/// <summary>
/// Provides extension methods for IServiceCollection to add API services.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds the API services for the MultipleChoiceTool.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddMultipleChoiceToolApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(ApiMappings));
        services.AddMultipleChoiceToolCors(configuration);
    }

    /// <summary>
    /// Adds the CORS settings for the MultipleChoiceTool.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
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
