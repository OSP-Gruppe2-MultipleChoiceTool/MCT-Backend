using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

public record GetStatementSetsByTypeIdQuery(Guid TypeId) : IRequest<IEnumerable<StatementSetModel>>;
