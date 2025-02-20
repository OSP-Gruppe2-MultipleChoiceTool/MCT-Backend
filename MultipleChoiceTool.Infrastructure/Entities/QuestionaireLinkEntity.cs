namespace MultipleChoiceTool.Infrastructure.Entities;

internal record QuestionaireLinkEntity : EntityBase
{
    public Guid QuestionaireId { get; init; }
    public QuestionaireEntity Questionaire { get; init; } = null!;

    public DateOnly ExpirationDate { get; set; }
}
