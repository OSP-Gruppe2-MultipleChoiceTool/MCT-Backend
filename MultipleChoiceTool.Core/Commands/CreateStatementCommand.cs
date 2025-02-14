using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateStatementCommand(
    Guid StatementSetId,
    StatementModel Statement
) : IRequest<StatementModel?>;
