using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to delete an existing statement type.
/// </summary>
/// <param name="StatementTypeId">The ID of the statement type to delete.</param>
/// <returns>A <see cref="StatementTypeModel"/> representing the deleted statement type, or null if not found.</returns>
public record DeleteStatementTypeCommand(Guid StatementTypeId) : IRequest<StatementTypeModel?>;
