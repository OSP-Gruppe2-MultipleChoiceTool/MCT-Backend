using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateLinkCommand(
    Guid LinkId, 
    DateOnly? ExpirationDate
) : IRequest<QuestionaireLinkModel?>;
