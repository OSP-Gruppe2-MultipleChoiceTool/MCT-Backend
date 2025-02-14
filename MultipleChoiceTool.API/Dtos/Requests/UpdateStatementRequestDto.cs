namespace MultipleChoiceTool.API.Dtos.Requests;

public record UpdateStatementRequestDto
{
    public bool? IsCorrect { get; init; }

    public string? Statement { get; init; }
}
