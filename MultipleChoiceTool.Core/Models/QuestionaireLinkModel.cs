namespace MultipleChoiceTool.Core.Models;

public record QuestionaireLinkModel
{
    public Guid Id { get; init; }

    public DateOnly ExpirationDate { get; set; }
}
