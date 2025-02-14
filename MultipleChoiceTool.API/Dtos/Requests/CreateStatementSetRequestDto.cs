namespace MultipleChoiceTool.API.Dtos.Requests;

public record CreateStatementSetRequestDto
{
    public string? Explaination { get; init; }

    public string? StatementImage { get; init; }

    public Guid? StatementTypeId { get; init; }
}
