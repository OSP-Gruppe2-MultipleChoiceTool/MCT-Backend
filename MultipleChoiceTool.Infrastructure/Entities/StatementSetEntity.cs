namespace MultipleChoiceTool.Infrastructure.Entities;

internal record StatementSetEntity
{
    public Guid Id { get; init; }

    public string? Explaination { get; set; }

    public string? StatementImage { get; set; }

    public Guid QuestionaireId { get; init; }
    public QuestionaireEntity Questionaire { get; init; } = null!;

    public Guid StatementTypeId { get; init; }
    public StatementTypeEntity StatementType { get; init; } = null!;

    public ICollection<StatementEntity> Statements { get; init; } = null!;
}
