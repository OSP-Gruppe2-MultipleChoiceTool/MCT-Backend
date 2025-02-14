using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateLinkCommand(
    Guid QuestionaireId,
    QuestionaireLinkModel Link
) : IRequest<QuestionaireLinkModel>;
