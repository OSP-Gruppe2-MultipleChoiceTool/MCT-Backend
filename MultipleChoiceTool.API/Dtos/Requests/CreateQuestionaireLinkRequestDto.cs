namespace MultipleChoiceTool.API.Dtos.Requests;

/// <summary>
/// DTO for creating a new questionnaire link.
/// </summary>
public record CreateQuestionaireLinkRequestDto
{
    /// <summary>
    /// Gets or sets the expiration date of the questionnaire link.
    /// </summary>
    public DateOnly ExpirationDate { get; init; }
}
