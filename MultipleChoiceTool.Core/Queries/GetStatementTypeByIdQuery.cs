using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

/// <summary>
/// Represents a query to retrieve a statement type by its ID.
/// </summary>
/// <param name="StatementId">The ID of the statement type.</param>
/// <returns>The statement type model if found; otherwise, null.</returns>
public record GetStatementTypeByIdQuery(Guid StatementId) : IRequest<StatementTypeModel?>;
