using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetStatementTypeByIdQueryHandler : IRequestHandler<GetStatementTypeByIdQuery, StatementTypeModel?>
{
    private readonly IStatementTypeReadRepository _statementTypeReadRepository;

    public GetStatementTypeByIdQueryHandler(
        IStatementTypeReadRepository statementTypeReadRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
    }

    public async Task<StatementTypeModel?> Handle(GetStatementTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _statementTypeReadRepository.FindByIdAsync(request.StatementId, true, cancellationToken);
    }
}
