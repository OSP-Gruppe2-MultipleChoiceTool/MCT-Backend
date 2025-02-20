using MediatR;
using MultipleChoiceTool.Core.Models;


namespace MultipleChoiceTool.Core.Queries;

public record GetQuestionaireByLinkIdQuery(Guid LinkId, bool IsExam) : IRequest<QuestionaireModel?>;

