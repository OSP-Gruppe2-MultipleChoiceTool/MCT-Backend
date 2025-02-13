namespace MultipleChoiceTool.API.Dtos.Responses;

public record StatementResponseDto
{
    public Guid Id { get; init; }

    public bool IsCorrect { get; init; }

    public string Statement { get; init; } = null!;
}
