using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

/// <summary>
/// Represents a query to retrieve all links for a specific questionnaire.
/// </summary>
/// <param name="QuestionaireId">The ID of the questionnaire.</param>
/// <returns>A collection of questionnaire link models.</returns>
public record GetAllLinksQuery(Guid QuestionaireId) : IRequest<IEnumerable<QuestionaireLinkModel>?>;
