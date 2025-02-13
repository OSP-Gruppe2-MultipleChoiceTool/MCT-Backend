using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

public record GetQuestionaireByIdQuery(Guid QuestionaireId) : IRequest<QuestionaireModel?>;
