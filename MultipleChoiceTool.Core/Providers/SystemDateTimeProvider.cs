namespace MultipleChoiceTool.Core.Providers;

/// <summary>
/// Provides the current date and time using the system clock.
/// </summary>
internal class SystemDateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc/>
    public DateTime Now => DateTime.Now;

    /// <inheritdoc/>
    public DateTime UtcNow => DateTime.UtcNow;
}
