namespace MultipleChoiceTool.Core.Models;

/// <summary>
/// Represents a set of statements within a questionnaire.
/// </summary>
public record StatementSetModel
{
    /// <summary>
    /// Gets the unique identifier of the statement set.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets the unique identifier of the questionnaire.
    /// </summary>
    public Guid QuestionaireId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the statement type.
    /// </summary>
    public Guid? StatementTypeId { get; set; }

    /// <summary>
    /// Gets the statement type associated with this statement set.
    /// </summary>
    public StatementTypeModel? StatementType { get; init; }

    /// <summary>
    /// Gets or sets the explanation for the statement set.
    /// </summary>
    public string? Explaination { get; set; }

    /// <summary>
    /// Gets or sets the image associated with the statement set.
    /// </summary>
    public string? StatementImage { get; set; }

    /// <summary>
    /// Gets the collection of statements in this statement set.
    /// </summary>
    public ICollection<StatementModel> Statements { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StatementSetModel"/> class.
    /// This constructor is only for serialization purposes.
    /// </summary>
    [Obsolete("Only for serialization.", true)]
    public StatementSetModel()
    {
        StatementType = null!;
        Statements = null!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StatementSetModel"/> class with the specified parameters.
    /// </summary>
    /// <param name="questionaireId">The unique identifier of the questionnaire.</param>
    /// <param name="statementTypeId">The unique identifier of the statement type.</param>
    /// <param name="explaination">The explanation for the statement set.</param>
    /// <param name="statementImage">The image associated with the statement set.</param>
    public StatementSetModel(
        Guid questionaireId, 
        Guid? statementTypeId, 
        string? explaination, 
        string? statementImage)
    {
        QuestionaireId = questionaireId;
        StatementTypeId = statementTypeId;
        Explaination = explaination;
        StatementImage = statementImage;
        Statements = [];
    }
}
