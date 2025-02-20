namespace MultipleChoiceTool.API.Dtos.Requests;

public record UpdateQuestionaireLinkRequestDto
{
    public DateOnly? ExpirationDate { get; init; }
}
