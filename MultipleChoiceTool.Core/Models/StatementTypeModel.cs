namespace MultipleChoiceTool.Core.Models;

public record StatementTypeModel
{
    public Guid Id { get; init; }

    public string Title { get; set; } = null!;
}
