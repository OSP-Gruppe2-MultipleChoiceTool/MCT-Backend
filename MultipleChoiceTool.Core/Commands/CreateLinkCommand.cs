using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateLinkCommand(
    Guid QuestionaireId,
    DateOnly ExpirationDate
) : IRequest<QuestionaireLinkModel>;
