using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetStatementSetsByTypeIdQueryHandler : IRequestHandler<GetStatementSetsByTypeIdQuery, IEnumerable<StatementSetModel>>
{
    private readonly IStatementSetReadRepository _statementSetReadRepository;

    public GetStatementSetsByTypeIdQueryHandler(
        IStatementSetReadRepository statementSetReadRepository)
    {
        _statementSetReadRepository = statementSetReadRepository;
    }

    public async Task<IEnumerable<StatementSetModel>> Handle(GetStatementSetsByTypeIdQuery request, CancellationToken cancellationToken)
    {
        return await _statementSetReadRepository.FindStatementSetsByTypeIdAsync(request.TypeId, true, cancellationToken);
    }
}
