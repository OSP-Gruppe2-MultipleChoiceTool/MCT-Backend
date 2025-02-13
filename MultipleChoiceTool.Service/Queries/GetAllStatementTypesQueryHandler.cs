using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetAllStatementTypesQueryHandler : IRequestHandler<GetAllStatementTypesQuery, IEnumerable<StatementTypeModel>>
{
    private readonly IStatementTypeReadRepository _statementTypeReadRepository;

    public GetAllStatementTypesQueryHandler(
        IStatementTypeReadRepository statementTypeReadRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
    }

    public Task<IEnumerable<StatementTypeModel>> Handle(GetAllStatementTypesQuery request, CancellationToken cancellationToken)
    {
        return _statementTypeReadRepository.FindAllAsync(cancellationToken);
    }
}
