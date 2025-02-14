namespace MultipleChoiceTool.API.Dtos.Requests;

public record CreateStatementRequestDto
{
    public bool IsCorrect { get; init; }

    public string Statement { get; init; } = null!;
}
