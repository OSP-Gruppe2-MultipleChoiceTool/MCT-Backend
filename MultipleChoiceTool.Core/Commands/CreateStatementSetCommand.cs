using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record CreateStatementSetCommand(
    Guid QuestionaireId,
    string? Explaination,
    string? StatementImage,
    Guid? StatementTypeId,
    IEnumerable<StatementModel> Statements
) : IRequest<StatementSetModel?>;
