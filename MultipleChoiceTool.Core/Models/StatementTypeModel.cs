namespace MultipleChoiceTool.Core.Models;

/// <summary>
/// Represents a type of statement.
/// </summary>
public record StatementTypeModel
{
    /// <summary>
    /// Gets the unique identifier of the statement type.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets the title of the statement type.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StatementTypeModel"/> class.
    /// This constructor is only for serialization purposes.
    /// </summary>
    [Obsolete("Only for serialization", true)]
    private StatementTypeModel()
    {
        Title = null!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StatementTypeModel"/> class with the specified title.
    /// </summary>
    /// <param name="title">The title of the statement type.</param>
    public StatementTypeModel(string title)
    {
        Title = title;
    }
}
