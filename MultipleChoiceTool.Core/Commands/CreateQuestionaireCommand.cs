using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to create a new questionnaire.
/// </summary>
/// <param name="Title">The title of the questionnaire.</param>
/// <returns>A <see cref="QuestionaireModel"/> representing the created questionnaire.</returns>
public record CreateQuestionaireCommand(string Title) : IRequest<QuestionaireModel>;
