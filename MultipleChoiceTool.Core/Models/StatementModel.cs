namespace MultipleChoiceTool.Core.Models;

/// <summary>
/// Represents a statement within a statement set.
/// </summary>
public record StatementModel
{
    /// <summary>
    /// Gets the unique identifier of the statement.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the statement is correct.
    /// </summary>
    public bool IsCorrect { get; set; }

    /// <summary>
    /// Gets or sets the content of the statement.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the statement set.
    /// </summary>
    public Guid StatementSetId { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StatementModel"/> class.
    /// This constructor is only for serialization purposes.
    /// </summary>
    [Obsolete("Only for serialization", true)]
    private StatementModel()
    {
        Content = null!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StatementModel"/> class with the specified parameters.
    /// </summary>
    /// <param name="isCorrect">A value indicating whether the statement is correct.</param>
    /// <param name="content">The content of the statement.</param>
    /// <param name="statementSetId">The unique identifier of the statement set.</param>
    public StatementModel(
        bool isCorrect, 
        string content, 
        Guid statementSetId)
    {
        IsCorrect = isCorrect;
        Content = content;
        StatementSetId = statementSetId;
    }
}
