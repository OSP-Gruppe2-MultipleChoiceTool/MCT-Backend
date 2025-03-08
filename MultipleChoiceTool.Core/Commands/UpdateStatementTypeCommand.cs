using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to update an existing statement type.
/// </summary>
/// <param name="StatementTypeId">The ID of the statement type to update.</param>
/// <param name="Title">The new title of the statement type.</param>
/// <returns>A <see cref="StatementTypeModel"/> representing the updated statement type, or null if not found.</returns>
public record UpdateStatementTypeCommand(
    Guid StatementTypeId,
    string? Title
) : IRequest<StatementTypeModel?>;
