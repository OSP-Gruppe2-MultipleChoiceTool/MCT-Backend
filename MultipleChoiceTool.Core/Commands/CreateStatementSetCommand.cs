using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateStatementSetCommand(
    Guid QuestionaireId, 
    StatementSetModel StatementSet
) : IRequest<StatementSetModel?>;
