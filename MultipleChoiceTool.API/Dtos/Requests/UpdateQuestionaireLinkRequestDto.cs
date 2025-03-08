namespace MultipleChoiceTool.API.Dtos.Requests;

/// <summary>
/// DTO for updating a questionnaire link.
/// </summary>
public record UpdateQuestionaireLinkRequestDto
{
    /// <summary>
    /// Gets or sets the expiration date of the questionnaire link.
    /// </summary>
    public DateOnly? ExpirationDate { get; init; }
}
