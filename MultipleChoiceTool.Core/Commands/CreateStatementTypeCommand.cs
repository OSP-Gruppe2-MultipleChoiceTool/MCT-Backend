using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateStatementTypeCommand(StatementTypeModel StatementType) : IRequest<StatementTypeModel>;
