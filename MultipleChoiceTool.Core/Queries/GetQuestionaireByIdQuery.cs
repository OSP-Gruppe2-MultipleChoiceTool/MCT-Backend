using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

/// <summary>
/// Represents a query to retrieve a questionnaire by its ID.
/// </summary>
/// <param name="QuestionaireId">The ID of the questionnaire.</param>
/// <returns>The questionnaire model if found; otherwise, null.</returns>
public record GetQuestionaireByIdQuery(Guid QuestionaireId) : IRequest<QuestionaireModel?>;
