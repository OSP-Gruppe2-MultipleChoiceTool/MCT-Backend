namespace MultipleChoiceTool.API.Dtos.Responses;

/// <summary>
/// Represents a response DTO for a statement set.
/// </summary>
public record StatementSetResponseDto
{
    /// <summary>
    /// Gets the unique identifier of the statement set.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the explanation for the statement set.
    /// </summary>
    public string? Explaination { get; init; }

    /// <summary>
    /// Gets the base64 representation of the image associated with the statement set.
    /// </summary>
    public string? StatementImage { get; init; }

    /// <summary>
    /// Gets the statement type associated with the statement set.
    /// </summary>
    public StatementTypeResponseDto? StatementType { get; init; }

    /// <summary>
    /// Gets the collection of statements in the statement set.
    /// </summary>
    public ICollection<StatementResponseDto> Statements { get; init; } = null!;
}
