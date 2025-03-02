namespace MultipleChoiceTool.API.Dtos.Requests;

public record StatementRequestDto
{
    public bool IsCorrect { get; init; }

    public string Statement { get; init; } = null!;
}
