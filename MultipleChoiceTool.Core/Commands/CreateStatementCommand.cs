using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateStatementCommand(
    Guid StatementSetId,
    bool IsCorrect,
    string Content
) : IRequest<StatementModel?>;
