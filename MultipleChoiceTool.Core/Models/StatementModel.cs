namespace MultipleChoiceTool.Core.Models;

public record StatementModel
{
    public Guid Id { get; init; }

    public bool IsCorrect { get; set; }

    public string Content { get; set; } = null!;

    public Guid StatementSetId { get; set; }
}
