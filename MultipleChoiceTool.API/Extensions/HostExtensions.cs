using MultipleChoiceTool.API.Settings;

namespace MultipleChoiceTool.API.Extensions;

/// <summary>
/// Provides extension methods for IApplicationBuilder to configure the API.
/// </summary>
public static class HostExtensions
{
    /// <summary>
    /// Configures the application to use the MultipleChoiceTool API.
    /// </summary>
    /// <param name="app">The application builder.</param>
    public static void UseMultipleChoiceToolApi(this IApplicationBuilder app)
    {
        app.UseCors(CorsSettings.PolicyName);
    }
}
