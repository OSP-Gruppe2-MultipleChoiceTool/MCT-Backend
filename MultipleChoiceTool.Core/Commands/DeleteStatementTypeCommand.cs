using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record DeleteStatementTypeCommand(Guid StatementTypeId) : IRequest<StatementTypeModel?>;
