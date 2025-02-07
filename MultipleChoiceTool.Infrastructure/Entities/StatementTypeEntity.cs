namespace MultipleChoiceTool.Infrastructure.Entities;

internal record StatementTypeEntity
{
    public Guid Id { get; init; }

    public string Title { get; set; } = null!;

    public ICollection<StatementSetEntity> StatementSets { get; init; } = null!;
}
