using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

public class GetAllStatementTypesQuery() : IRequest<IEnumerable<StatementTypeModel>>;
