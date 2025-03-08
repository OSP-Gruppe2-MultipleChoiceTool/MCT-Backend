namespace MultipleChoiceTool.API.Dtos.Responses;

/// <summary>
/// Represents a response DTO for a questionnaire.
/// </summary>
public record QuestionaireResponseDto
{
    /// <summary>
    /// Gets the unique identifier of the questionnaire.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the title of the questionnaire.
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    /// Gets the collection of statement sets in the questionnaire.
    /// </summary>
    public ICollection<StatementSetResponseDto> StatementSets { get; init; } = null!;

    /// <summary>
    /// Gets the collection of links associated with the questionnaire.
    /// </summary>
    public ICollection<QuestionaireLinkResponseDto> Links { get; init; } = null!;
}
