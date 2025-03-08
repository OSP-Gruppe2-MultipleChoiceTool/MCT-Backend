using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to update an existing questionnaire.
/// </summary>
/// <param name="QuestionaireId">The ID of the questionnaire to update.</param>
/// <param name="Title">The new title of the questionnaire.</param>
/// <returns>A <see cref="QuestionaireModel"/> representing the updated questionnaire, or null if not found.</returns>
public record UpdateQuestionaireCommand(
    Guid QuestionaireId, 
    string? Title
) : IRequest<QuestionaireModel?>;
