using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

public record GetStatementTypeByIdQuery(Guid StatementId) : IRequest<StatementTypeModel?>;
