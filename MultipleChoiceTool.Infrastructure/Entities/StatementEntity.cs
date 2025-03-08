namespace MultipleChoiceTool.Infrastructure.Entities;

/// <summary>
/// Represents a statement within a statement set.
/// </summary>
internal record StatementEntity : EntityBase
{
    /// <summary>
    /// Gets or sets a value indicating whether the statement is correct.
    /// </summary>
    public bool IsCorrect { get; set; }

    /// <summary>
    /// Gets or sets the text of the statement.
    /// </summary>
    public string Statement { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier of the associated statement set.
    /// </summary>
    public Guid StatementSetId { get; set; }

    /// <summary>
    /// Gets or sets the associated statement set entity.
    /// </summary>
    public StatementSetEntity StatementSet { get; set; } = null!;
}
