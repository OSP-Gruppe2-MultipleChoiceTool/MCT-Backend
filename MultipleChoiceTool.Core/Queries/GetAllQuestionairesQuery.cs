using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

/// <summary>
/// Represents a query to retrieve all questionnaires.
/// </summary>
/// <returns>A collection of questionnaire models.</returns>
public record GetAllQuestionairesQuery() : IRequest<IEnumerable<QuestionaireModel>>;
