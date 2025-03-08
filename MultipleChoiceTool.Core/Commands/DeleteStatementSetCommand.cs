using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to delete an existing statement set.
/// </summary>
/// <param name="StatementSetId">The ID of the statement set to delete.</param>
/// <returns>A <see cref="StatementSetModel"/> representing the deleted statement set, or null if not found.</returns>
public record DeleteStatementSetCommand(Guid StatementSetId) : IRequest<StatementSetModel?>;
