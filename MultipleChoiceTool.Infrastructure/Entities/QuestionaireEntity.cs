namespace MultipleChoiceTool.Infrastructure.Entities;

internal record QuestionaireEntity
{
    public Guid Id { get; init; }

    public string Title { get; set; } = null!;

    public ICollection<StatementSetEntity> StatementSets { get; init; } = null!;

    public ICollection<QuestionaireLinkEntity> QuestionaireLinks { get; } = null!;
}
