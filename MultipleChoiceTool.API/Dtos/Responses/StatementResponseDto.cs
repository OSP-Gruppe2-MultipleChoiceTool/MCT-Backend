namespace MultipleChoiceTool.API.Dtos.Responses;

/// <summary>
/// Represents a response DTO for a statement.
/// </summary>
public record StatementResponseDto
{
    /// <summary>
    /// Gets the unique identifier of the statement.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets a value indicating whether the statement is correct.
    /// </summary>
    public bool IsCorrect { get; init; }

    /// <summary>
    /// Gets the content of the statement.
    /// </summary>
    public string Statement { get; init; } = null!;
}
