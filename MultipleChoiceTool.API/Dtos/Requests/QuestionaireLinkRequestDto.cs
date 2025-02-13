namespace MultipleChoiceTool.API.Dtos.Requests;

public record QuestionaireLinkRequestDto
{
    public DateOnly ExpirationDate { get; init; }
}
