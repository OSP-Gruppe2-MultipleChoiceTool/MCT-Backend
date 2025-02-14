namespace MultipleChoiceTool.Core.Models;

public record QuestionaireModel
{
    public Guid Id { get; init; }

    public string Title { get; set; }

    public ICollection<StatementSetModel> StatementSets { get; init; }

    public ICollection<QuestionaireLinkModel> Links { get; init; }

    [Obsolete("Only for serialization", true)]
    private QuestionaireModel()
    {
        Title = null!;
        StatementSets = null!;
        Links = null!;
    }

    public QuestionaireModel(string title)
    {
        Title = title;
        StatementSets = [];
        Links = [];
    }
}
