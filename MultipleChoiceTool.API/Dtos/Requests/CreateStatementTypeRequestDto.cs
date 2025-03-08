namespace MultipleChoiceTool.API.Dtos.Requests;

/// <summary>
/// DTO for creating a new statement type.
/// </summary>
public record CreateStatementTypeRequestDto
{
    /// <summary>
    /// Gets or sets the title of the statement type.
    /// </summary>
    public string Title { get; init; } = null!;
}
