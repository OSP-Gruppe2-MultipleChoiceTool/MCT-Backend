using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

public record GetAllLinksQuery(
    Guid QuestionaireId
) : IRequest<IEnumerable<QuestionaireLinkModel>?>;
