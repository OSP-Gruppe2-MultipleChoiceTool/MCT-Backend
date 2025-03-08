using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

/// <summary>
/// Represents a query to retrieve all statement types.
/// </summary>
/// <returns>A collection of statement type models.</returns>
public class GetAllStatementTypesQuery() : IRequest<IEnumerable<StatementTypeModel>>;
