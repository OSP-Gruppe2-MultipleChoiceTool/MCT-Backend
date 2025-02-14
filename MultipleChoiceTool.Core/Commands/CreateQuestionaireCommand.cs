using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateQuestionaireCommand(string Title) : IRequest<QuestionaireModel>;
