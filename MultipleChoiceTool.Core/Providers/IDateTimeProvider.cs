namespace MultipleChoiceTool.Core.Providers;

/// <summary>
/// Provides an interface for accessing the current date and time.
/// This interface is used for mocking purposes in unit tests.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Gets the current local date and time.
    /// </summary>
    public DateTime Now { get; }

    /// <summary>
    /// Gets the current UTC date and time.
    /// </summary>
    public DateTime UtcNow { get; }
}
