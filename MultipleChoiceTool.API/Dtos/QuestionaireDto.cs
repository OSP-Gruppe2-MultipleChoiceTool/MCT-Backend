namespace MultipleChoiceTool.API.Dtos;

public record QuestionaireDto
{
    public Guid Id { get; init; }

    public string Title { get; set; } = null!;

    public ICollection<StatementSetDto> StatementSets { get; init; } = null!;

    public ICollection<QuestionaireLinkDto> Links { get; } = null!;
}
