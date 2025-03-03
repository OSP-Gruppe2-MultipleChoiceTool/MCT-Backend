namespace MultipleChoiceTool.Core.Providers;

internal class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;

    public DateTime UtcNow => DateTime.UtcNow;
}
