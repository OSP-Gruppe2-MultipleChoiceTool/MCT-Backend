namespace MultipleChoiceTool.API.Dtos.Responses;

public record QuestionaireResponseDto
{
    public Guid Id { get; init; }

    public string Title { get; init; } = null!;

    public ICollection<StatementSetResponseDto> StatementSets { get; init; } = null!;

    public ICollection<QuestionaireLinkResponseDto> Links { get; init; } = null!;
}
