namespace MultipleChoiceTool.Core.Models;

public record StatementTypeModel
{
    public Guid Id { get; init; }

    public string Title { get; set; }

    [Obsolete("Only for serialization", true)]
    private StatementTypeModel()
    {
        Title = null!;
    }

    public StatementTypeModel(string title)
    {
        Title = title;
    }
}
