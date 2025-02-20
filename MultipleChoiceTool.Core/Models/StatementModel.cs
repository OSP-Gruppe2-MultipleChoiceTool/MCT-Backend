namespace MultipleChoiceTool.Core.Models;

public record StatementModel
{
    public Guid Id { get; init; }

    public bool IsCorrect { get; set; }

    public string Content { get; set; }

    public Guid StatementSetId { get; set; }

    [Obsolete("Only for serialization", true)]
    private StatementModel()
    {
        Content = null!;
    }

    public StatementModel(
        bool isCorrect, 
        string content, 
        Guid statementSetId)
    {
        IsCorrect = isCorrect;
        Content = content;
        StatementSetId = statementSetId;
    }
}
