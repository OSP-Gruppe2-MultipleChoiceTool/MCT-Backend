namespace MultipleChoiceTool.Infrastructure.Entities;

internal record StatementTypeEntity : EntityBase
{
    public string Title { get; set; } = null!;

    public ICollection<StatementSetEntity> StatementSets { get; init; } = null!;
}
