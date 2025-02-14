using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record DeleteStatementCommand(Guid StatementId) : IRequest<StatementModel?>;
