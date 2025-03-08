namespace MultipleChoiceTool.Core.Models;

/// <summary>
/// Represents a link to a questionnaire with an expiration date.
/// </summary>
public record QuestionaireLinkModel
{
    /// <summary>
    /// Gets the unique identifier of the questionnaire link.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets the unique identifier of the questionnaire.
    /// </summary>
    public Guid QuestionaireId { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the questionnaire link.
    /// </summary>
    public DateOnly ExpirationDate { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionaireLinkModel"/> class.
    /// This constructor is only for serialization purposes.
    /// </summary>
    [Obsolete("Only for serialization", true)]
    private QuestionaireLinkModel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionaireLinkModel"/> class with the specified questionnaire ID and expiration date.
    /// </summary>
    /// <param name="questionaireId">The unique identifier of the questionnaire.</param>
    /// <param name="expirationDate">The expiration date of the questionnaire link.</param>
    public QuestionaireLinkModel(
        Guid questionaireId, 
        DateOnly expirationDate)
    {
        QuestionaireId = questionaireId;
        ExpirationDate = expirationDate;
    }
}
