namespace MultipleChoiceTool.API.Dtos.Requests;

public record CreateStatementTypeRequestDto
{
    public string Title { get; init; } = null!;
}
