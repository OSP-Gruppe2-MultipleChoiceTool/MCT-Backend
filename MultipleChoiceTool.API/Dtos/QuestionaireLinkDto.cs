namespace MultipleChoiceTool.API.Dtos;

public record QuestionaireLinkDto
{
    public Guid Id { get; init; }

    public DateOnly ExpirationDate { get; set; }
}
