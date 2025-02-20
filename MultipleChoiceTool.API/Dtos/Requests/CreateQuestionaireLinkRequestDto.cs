namespace MultipleChoiceTool.API.Dtos.Requests;

public record CreateQuestionaireLinkRequestDto
{
    public DateOnly ExpirationDate { get; init; }
}
