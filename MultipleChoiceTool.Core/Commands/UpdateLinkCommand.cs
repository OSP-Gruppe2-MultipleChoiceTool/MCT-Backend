using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateLinkCommand(
    Guid LinkId, 
    QuestionaireLinkModel Link
) : IRequest<QuestionaireLinkModel?>;
