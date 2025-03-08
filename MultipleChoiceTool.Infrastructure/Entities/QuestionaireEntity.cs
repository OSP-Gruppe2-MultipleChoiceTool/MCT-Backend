namespace MultipleChoiceTool.Infrastructure.Entities;

/// <summary>
/// Represents a questionnaire with a title and associated statement sets and links.
/// </summary>
internal record QuestionaireEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the title of the questionnaire.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Gets the collection of statement sets within this questionnaire.
    /// </summary>
    public ICollection<StatementSetEntity> StatementSets { get; init; } = null!;

    /// <summary>
    /// Gets the collection of links associated with this questionnaire.
    /// </summary>
    public ICollection<QuestionaireLinkEntity> QuestionaireLinks { get; init; } = null!;
}
