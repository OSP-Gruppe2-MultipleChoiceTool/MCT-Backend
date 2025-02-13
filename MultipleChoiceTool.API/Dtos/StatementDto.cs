namespace MultipleChoiceTool.API.Dtos;

public record StatementDto
{
    public Guid Id { get; init; }

    public bool IsCorrect { get; set; }

    public string Statement { get; set; } = null!;
}
