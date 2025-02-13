namespace MultipleChoiceTool.Core.Models;

public record QuestionaireModel
{
    public Guid Id { get; init; }

    public string Title { get; set; } = null!;
}
