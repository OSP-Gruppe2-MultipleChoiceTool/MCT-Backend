namespace MultipleChoiceTool.Core.Models;

public record QuestionaireLinkModel
{
    public Guid Id { get; init; }

    public Guid QuestionaireId { get; set; }

    public DateOnly ExpirationDate { get; set; }

    [Obsolete("Only for serialization", true)]
    private QuestionaireLinkModel()
    {
    }

    public QuestionaireLinkModel(
        Guid questionaireId, 
        DateOnly expirationDate)
    {
        QuestionaireId = questionaireId;
        ExpirationDate = expirationDate;
    }
}
