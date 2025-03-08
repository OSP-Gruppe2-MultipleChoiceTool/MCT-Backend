using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to update an existing statement set.
/// </summary>
/// <param name="StatementSetId">The ID of the statement set to update.</param>
/// <param name="Explaination">The new explanation for the statement set.</param>
/// <param name="StatementImage">The new image for the statement set.</param>
/// <param name="StatementTypeId">The new statement type ID for the statement set.</param>
/// <param name="Statements">The new collection of statements for the statement set.</param>
/// <returns>A <see cref="StatementSetModel"/> representing the updated statement set, or null if not found.</returns>
public record UpdateStatementSetCommand(
    Guid StatementSetId,
    string? Explaination,
    string? StatementImage,
    Guid? StatementTypeId,
    IEnumerable<StatementModel>? Statements
) : IRequest<StatementSetModel?>;
