using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateStatementCommand(
    Guid StatementId,
    bool? IsCorrect,
    string? Content
) : IRequest<StatementModel?>;
