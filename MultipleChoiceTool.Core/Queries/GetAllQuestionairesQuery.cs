using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

public record GetAllQuestionairesQuery() : IRequest<IEnumerable<QuestionaireModel>>
{
}
