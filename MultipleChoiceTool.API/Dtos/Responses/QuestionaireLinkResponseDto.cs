namespace MultipleChoiceTool.API.Dtos.Responses;

/// <summary>
/// Represents a response DTO for a questionnaire link.
/// </summary>
public record QuestionaireLinkResponseDto
{
    /// <summary>
    /// Gets the unique identifier of the questionnaire link.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the expiration date of the questionnaire link.
    /// </summary>
    public DateOnly ExpirationDate { get; init; }
}
