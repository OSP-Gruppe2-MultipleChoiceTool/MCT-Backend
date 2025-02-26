namespace MultipleChoiceTool.API.Settings;

public record CorsSettings
{
    public const string PolicyName = "DefaultPolicy";

    public string[] AllowedOrigins { get; init; } = [];

    public string[] AllowedMethods { get; init; } = [];

    public string[] AllowedHeaders { get; init; } = [];
 
    public bool AllowCredentials { get; init; }
}
