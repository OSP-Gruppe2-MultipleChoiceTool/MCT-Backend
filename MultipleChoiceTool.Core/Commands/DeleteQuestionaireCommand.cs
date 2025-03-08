using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to delete an existing questionnaire.
/// </summary>
/// <param name="QuestionaireId">The ID of the questionnaire to delete.</param>
/// <returns>A <see cref="QuestionaireModel"/> representing the deleted questionnaire, or null if not found.</returns>
public record DeleteQuestionaireCommand(Guid QuestionaireId) : IRequest<QuestionaireModel?>;
