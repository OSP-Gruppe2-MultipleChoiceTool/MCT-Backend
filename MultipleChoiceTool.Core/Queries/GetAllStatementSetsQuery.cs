using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Queries;

public record GetAllStatementSetsQuery(Guid QuestionaireId) : IRequest<IEnumerable<StatementSetModel>?>;
