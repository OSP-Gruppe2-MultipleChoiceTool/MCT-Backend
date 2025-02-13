namespace MultipleChoiceTool.API.Dtos;

public record StatementSetDto
{
    public Guid Id { get; init; }

    public string? Explaination { get; set; }

    public string? StatementImage { get; set; }

    public StatementTypeDto StatementType { get; init; } = null!;

    public ICollection<StatementDto> Statements { get; init; } = null!;
}
