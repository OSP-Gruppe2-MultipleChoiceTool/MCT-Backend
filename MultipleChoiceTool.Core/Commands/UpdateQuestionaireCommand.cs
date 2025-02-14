using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record UpdateQuestionaireCommand(
    Guid QuestionaireId, 
    string? Title
) : IRequest<QuestionaireModel?>;
