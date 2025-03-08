using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

/// <summary>
/// Represents a query to retrieve all statement sets for a specific questionnaire.
/// </summary>
/// <param name="QuestionaireId">The ID of the questionnaire.</param>
/// <returns>A collection of statement set models.</returns>
public record GetAllStatementSetsQuery(Guid QuestionaireId) : IRequest<IEnumerable<StatementSetModel>?>;
