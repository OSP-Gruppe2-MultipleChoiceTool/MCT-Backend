namespace MultipleChoiceTool.Core.Models;

public record StatementModel
{
    public Guid Id { get; init; }

    public bool IsCorrect { get; set; }

    public string Statement { get; set; } = null!;
}
