using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateQuestionaireCommand(
    Guid QuestionaireId, 
    QuestionaireModel Questionaire
) : IRequest<QuestionaireModel?>;
