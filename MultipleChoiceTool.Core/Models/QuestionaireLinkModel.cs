namespace MultipleChoiceTool.Core.Models;

public record QuestionaireLinkModel
{
    public Guid Id { get; init; }

    public Guid QuestionaireId { get; set; }

    public DateOnly ExpirationDate { get; set; }
}
