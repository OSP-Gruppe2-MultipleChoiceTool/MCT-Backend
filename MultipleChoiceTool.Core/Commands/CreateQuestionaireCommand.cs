using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateQuestionaireCommand(QuestionaireModel Questionaire) : IRequest<QuestionaireModel>;
