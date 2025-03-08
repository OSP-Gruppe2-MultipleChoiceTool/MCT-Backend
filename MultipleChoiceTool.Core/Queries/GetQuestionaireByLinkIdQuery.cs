using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

/// <summary>
/// Represents a query to retrieve a questionnaire by its link ID.
/// </summary>
/// <param name="LinkId">The ID of the link.</param>
/// <param name="IsExam">Indicates whether the questionnaire is an exam.</param>
/// <returns>The questionnaire model if found; otherwise, null.</returns>
public record GetQuestionaireByLinkIdQuery(Guid LinkId, bool IsExam) : IRequest<QuestionaireModel?>;

