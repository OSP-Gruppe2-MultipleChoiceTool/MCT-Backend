using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateStatementCommand(
    Guid StatementId,
    StatementModel Statement
) : IRequest<StatementModel?>;
