namespace MultipleChoiceTool.Infrastructure.Entities;

/// <summary>
/// Represents a link to a questionnaire with an expiration date.
/// </summary>
internal record QuestionaireLinkEntity : EntityBase
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
    /// Gets or sets the expiration date of the questionnaire link.
    /// </summary>
    public DateOnly ExpirationDate { get; set; }
}
