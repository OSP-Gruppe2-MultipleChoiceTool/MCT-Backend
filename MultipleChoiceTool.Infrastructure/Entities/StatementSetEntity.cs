namespace MultipleChoiceTool.Infrastructure.Entities;

/// <summary>
/// Represents a set of statements within a questionnaire.
/// </summary>
internal record StatementSetEntity : EntityBase
{
    /// <summary>
    /// Gets the unique identifier of the associated questionnaire.
    /// </summary>
    public Guid QuestionaireId { get; init; }

    /// <summary>
    /// Gets the associated questionnaire entity.
    /// </summary>
    public QuestionaireEntity Questionaire { get; init; } = null!;

    /// <summary>
    /// Gets the unique identifier of the associated statement type, if any.
    /// </summary>
    public Guid? StatementTypeId { get; init; }

    /// <summary>
    /// Gets the associated statement type entity, if any.
    /// </summary>
    public StatementTypeEntity? StatementType { get; init; }

    /// <summary>
    /// Gets or sets the explanation for the statement set.
    /// </summary>
    public string? Explaination { get; set; }

    /// <summary>
    /// Gets or sets the image associated with the statement set.
    /// </summary>
    public string? StatementImage { get; set; }

    /// <summary>
    /// Gets the collection of statements within this statement set.
    /// </summary>
    public ICollection<StatementEntity> Statements { get; init; } = null!;
}
