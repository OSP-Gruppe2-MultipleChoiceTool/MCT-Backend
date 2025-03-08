namespace MultipleChoiceTool.Infrastructure.Entities;

/// <summary>
/// Represents a type of statement with a title and associated statement sets.
/// </summary>
internal record StatementTypeEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the title of the statement type.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Gets the collection of statement sets associated with this statement type.
    /// </summary>
    public ICollection<StatementSetEntity> StatementSets { get; init; } = null!;
}
