namespace MultipleChoiceTool.API.Dtos.Requests;

/// <summary>
/// DTO for updating a statement type.
/// </summary>
public record UpdateStatementTypeRequestDto
{
    /// <summary>
    /// Gets or sets the title of the statement type.
    /// </summary>
    public string? Title { get; init; }
}
