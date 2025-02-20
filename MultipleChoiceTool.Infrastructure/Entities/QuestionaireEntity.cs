namespace MultipleChoiceTool.Infrastructure.Entities;

internal record QuestionaireEntity : EntityBase
{
    public string Title { get; set; } = null!;

    public ICollection<StatementSetEntity> StatementSets { get; init; } = null!;

    public ICollection<QuestionaireLinkEntity> QuestionaireLinks { get; init; } = null!;
}
