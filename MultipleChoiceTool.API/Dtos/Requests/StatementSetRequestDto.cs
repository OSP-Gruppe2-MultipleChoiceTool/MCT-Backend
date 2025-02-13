namespace MultipleChoiceTool.API.Dtos.Requests;

public record StatementSetRequestDto
{
    public string? Explaination { get; init; }

    public string? StatementImage { get; init; }
}
