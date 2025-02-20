namespace MultipleChoiceTool.Infrastructure.Entities;

internal record StatementEntity : EntityBase
{
    public bool IsCorrect { get; set; }

    public string Statement { get; set; } = null!;

    public Guid StatementSetId { get; set; }
    public StatementSetEntity StatementSet { get; set; } = null!;
}
