namespace MultipleChoiceTool.API.Dtos.Requests;

/// <summary>
/// DTO for updating a questionnaire.
/// </summary>
public record UpdateQuestionaireRequestDto
{
    /// <summary>
    /// Gets or sets the title of the questionnaire.
    /// </summary>
    public string? Title { get; init; }
}
