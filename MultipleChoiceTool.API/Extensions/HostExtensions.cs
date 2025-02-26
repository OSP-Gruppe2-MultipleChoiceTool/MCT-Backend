using MultipleChoiceTool.API.Settings;

namespace MultipleChoiceTool.API.Extensions;

public static class HostExtensions
{
    public static void UseMultipleChoiceToolApi(this IApplicationBuilder app)
    {
        app.UseCors(CorsSettings.PolicyName);
    }
}
