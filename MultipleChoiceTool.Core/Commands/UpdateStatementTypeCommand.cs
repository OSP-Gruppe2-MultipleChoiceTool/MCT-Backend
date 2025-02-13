using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateStatementTypeCommand(
    Guid StatementTypeId,
    StatementTypeModel StatementType
) : IRequest<StatementTypeModel?>;
