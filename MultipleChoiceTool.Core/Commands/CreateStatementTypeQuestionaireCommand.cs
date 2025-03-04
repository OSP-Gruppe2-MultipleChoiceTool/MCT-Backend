using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateStatementTypeQuestionaireCommand(string Title, Guid StatementTypeId) : IRequest<QuestionaireModel>;
