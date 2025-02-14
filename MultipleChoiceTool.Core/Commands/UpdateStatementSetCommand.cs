using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateStatementSetCommand(
    Guid StatementSetId,
    StatementSetModel StatementSet
) : IRequest<StatementSetModel?>;
