using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to create a new statement set.
/// </summary>
/// <param name="QuestionaireId">The ID of the questionnaire associated with the statement set.</param>
/// <param name="Explaination">The explanation for the statement set.</param>
/// <param name="StatementImage">The image for the statement set.</param>
/// <param name="StatementTypeId">The ID of the statement type associated with the statement set.</param>
/// <param name="Statements">The collection of statements in the statement set.</param>
/// <returns>A <see cref="StatementSetModel"/> representing the created statement set, or null if creation failed.</returns>
public record CreateStatementSetCommand(
    Guid QuestionaireId,
    string? Explaination,
    string? StatementImage,
    Guid? StatementTypeId,
    IEnumerable<StatementModel> Statements
) : IRequest<StatementSetModel?>;
