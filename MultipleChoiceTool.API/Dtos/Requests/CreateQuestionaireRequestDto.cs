namespace MultipleChoiceTool.API.Dtos.Requests;

/// <summary>
/// DTO for creating a new questionnaire.
/// </summary>
public record CreateQuestionaireRequestDto
{
    /// <summary>
    /// Gets or sets the title of the questionnaire.
    /// </summary>
    public string Title { get; init; } = null!;
}
