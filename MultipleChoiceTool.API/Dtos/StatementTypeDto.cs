namespace MultipleChoiceTool.API.Dtos;

public record StatementTypeDto
{
    public Guid Id { get; init; }

    public string Title { get; set; } = null!;
}
