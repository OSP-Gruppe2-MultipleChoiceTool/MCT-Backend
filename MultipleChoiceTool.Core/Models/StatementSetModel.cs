namespace MultipleChoiceTool.Core.Models;

public record StatementSetModel
{
    public Guid Id { get; init; }

    public string? Explaination { get; set; }

    public string? StatementImage { get; set; }
}
