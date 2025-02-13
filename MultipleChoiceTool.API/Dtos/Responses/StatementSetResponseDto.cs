namespace MultipleChoiceTool.API.Dtos.Responses;

public record StatementSetResponseDto
{
    public Guid Id { get; init; }

    public string? Explaination { get; init; }

    public string? StatementImage { get; init; }

    public StatementTypeResponseDto? StatementType { get; init; }

    public ICollection<StatementResponseDto> Statements { get; init; } = null!;
}
