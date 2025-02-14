namespace MultipleChoiceTool.API.Dtos.Requests;

public record CreateQuestionaireRequestDto
{
    public string Title { get; init; } = null!;
}
