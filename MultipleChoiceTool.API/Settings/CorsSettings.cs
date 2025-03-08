namespace MultipleChoiceTool.API.Settings;

/// <summary>
/// Represents the settings for configuring CORS (Cross-Origin Resource Sharing).
/// </summary>
public record CorsSettings
{
    /// <summary>
    /// The name of the default CORS policy.
    /// </summary>
    public const string PolicyName = "DefaultPolicy";

    /// <summary>
    /// Gets the list of allowed origins for CORS.
    /// </summary>
    public string[] AllowedOrigins { get; init; } = [];

    /// <summary>
    /// Gets the list of allowed methods for CORS.
    /// </summary>
    public string[] AllowedMethods { get; init; } = [];

    /// <summary>
    /// Gets the list of allowed headers for CORS.
    /// </summary>
    public string[] AllowedHeaders { get; init; } = [];
 
    /// <summary>
    /// Gets a value indicating whether credentials are allowed in CORS requests.
    /// </summary>
    public bool AllowCredentials { get; init; }
}
