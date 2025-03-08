namespace MultipleChoiceTool.API.Dtos.Requests;

/// <summary>
/// DTO for a statement.
/// </summary>
public record StatementRequestDto
{
    /// <summary>
    /// Gets or sets a value indicating whether the statement is correct.
    /// </summary>
    public bool IsCorrect { get; init; }

    /// <summary>
    /// Gets or sets the content of the statement.
    /// </summary>
    public string Statement { get; init; } = null!;
}
