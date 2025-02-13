namespace MultipleChoiceTool.Core.Models;

public record StatementSetModel
{
    public Guid Id { get; init; }

    public Guid QuestionaireId { get; set; }

    public Guid? StatementTypeId { get; set; }

    public string? Explaination { get; set; }

    public string? StatementImage { get; set; }

    public ICollection<StatementModel> Statements { get; init; } = null!;
}
