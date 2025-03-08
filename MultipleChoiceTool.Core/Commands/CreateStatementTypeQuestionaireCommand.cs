using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to create a new statement type questionnaire.
/// </summary>
/// <param name="Title">The title of the questionnaire.</param>
/// <param name="StatementTypeId">The ID of the statement type associated with the questionnaire.</param>
/// <returns>A <see cref="QuestionaireModel"/> representing the created questionnaire.</returns>
public record CreateStatementTypeQuestionaireCommand(string Title, Guid StatementTypeId) : IRequest<QuestionaireModel>;
