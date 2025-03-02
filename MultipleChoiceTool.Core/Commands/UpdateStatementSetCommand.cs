using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateStatementSetCommand(
    Guid StatementSetId,
    string? Explaination,
    string? StatementImage,
    Guid? StatementTypeId,
    IEnumerable<StatementModel>? Statements
) : IRequest<StatementSetModel?>;
