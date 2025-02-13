namespace MultipleChoiceTool.API.Dtos.Responses;

public record QuestionaireLinkResponseDto
{
    public Guid Id { get; init; }

    public DateOnly ExpirationDate { get; init; }
}
