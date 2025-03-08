namespace MultipleChoiceTool.Core.Models;

/// <summary>
/// Represents a questionnaire.
/// </summary>
public record QuestionaireModel
{
    /// <summary>
    /// Gets the unique identifier of the questionnaire.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets the title of the questionnaire.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets the collection of statement sets in this questionnaire.
    /// </summary>
    public ICollection<StatementSetModel> StatementSets { get; init; }

    /// <summary>
    /// Gets the collection of links associated with this questionnaire.
    /// </summary>
    public ICollection<QuestionaireLinkModel> Links { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionaireModel"/> class.
    /// This constructor is only for serialization purposes.
    /// </summary>
    [Obsolete("Only for serialization", true)]
    private QuestionaireModel()
    {
        Title = null!;
        StatementSets = null!;
        Links = null!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionaireModel"/> class with the specified title.
    /// </summary>
    /// <param name="title">The title of the questionnaire.</param>
    public QuestionaireModel(string title)
    {
        Title = title;
        StatementSets = [];
        Links = [];
    }
}
