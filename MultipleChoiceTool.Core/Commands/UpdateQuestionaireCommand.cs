using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateQuestionaireCommand(Guid Id, QuestionaireModel Questionaire) : IRequest<QuestionaireModel?>;
