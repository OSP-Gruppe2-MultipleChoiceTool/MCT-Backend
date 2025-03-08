namespace MultipleChoiceTool.API.Dtos.Responses;

/// <summary>
/// Represents a response DTO for a statement type.
/// </summary>
public record StatementTypeResponseDto
{
    /// <summary>
    /// Gets the unique identifier of the statement type.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the title of the statement type.
    /// </summary>
    public string Title { get; init; } = null!;
}
