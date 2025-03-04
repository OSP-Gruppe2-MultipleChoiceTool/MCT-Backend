namespace MultipleChoiceTool.Core.Providers;

public interface IDateTimeProvider
{
    public DateTime Now { get; }

    public DateTime UtcNow { get; }
}
