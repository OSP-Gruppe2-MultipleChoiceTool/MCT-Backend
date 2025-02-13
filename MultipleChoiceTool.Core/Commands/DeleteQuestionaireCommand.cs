using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record DeleteQuestionaireCommand(Guid QuestionaireId) : IRequest<QuestionaireModel?>;
