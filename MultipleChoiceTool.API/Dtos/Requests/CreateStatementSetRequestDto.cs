namespace MultipleChoiceTool.API.Dtos.Requests;

/// <summary>
/// DTO for creating a new statement set.
/// </summary>
public record CreateStatementSetRequestDto
{
    /// <summary>
    /// Gets or sets the explanation of the statement set.
    /// </summary>
    public string? Explaination { get; init; }

    /// <summary>
    /// Gets or sets the base64 string representation of the image associated with the statement set.
    /// </summary>
    public string? StatementImage { get; init; }

    /// <summary>
    /// Gets or sets the ID of the statement type.
    /// </summary>
    public Guid? StatementTypeId { get; init; }

    /// <summary>
    /// Gets or sets the collection of statements.
    /// </summary>
    public IEnumerable<StatementRequestDto> Statements { get; init; } = null!;
}
