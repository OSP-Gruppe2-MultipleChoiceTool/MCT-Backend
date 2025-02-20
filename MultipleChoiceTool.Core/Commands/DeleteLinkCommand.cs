using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record DeleteLinkCommand(Guid LinkId) : IRequest<QuestionaireLinkModel?>;
