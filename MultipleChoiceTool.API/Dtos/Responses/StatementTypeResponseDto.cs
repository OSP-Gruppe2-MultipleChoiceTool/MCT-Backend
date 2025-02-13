namespace MultipleChoiceTool.API.Dtos.Responses;

public record StatementTypeResponseDto
{
    public Guid Id { get; init; }

    public string Title { get; init; } = null!;
}
