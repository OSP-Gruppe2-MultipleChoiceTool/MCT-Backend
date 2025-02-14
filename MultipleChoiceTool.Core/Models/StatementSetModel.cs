namespace MultipleChoiceTool.Core.Models;

public record StatementSetModel
{
    public Guid Id { get; init; }

    public Guid QuestionaireId { get; set; }

    public Guid? StatementTypeId { get; set; }
    public StatementTypeModel? StatementType { get; init; }

    public string? Explaination { get; set; }

    public string? StatementImage { get; set; }

    public ICollection<StatementModel> Statements { get; init; }

    [Obsolete("Only for serialization.", true)]
    public StatementSetModel()
    {
        StatementType = null!;
        Statements = null!;
    }

    public StatementSetModel(
        Guid questionaireId, 
        Guid? statementTypeId, 
        string? explaination, 
        string? statementImage)
    {
        QuestionaireId = questionaireId;
        StatementTypeId = statementTypeId;
        Explaination = explaination;
        StatementImage = statementImage;
        Statements = [];
    }
}
