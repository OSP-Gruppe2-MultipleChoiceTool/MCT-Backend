using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class DeleteStatementSetCommandHandler : IRequestHandler<DeleteStatementSetCommand, StatementSetModel?>
{
    private readonly IBaseReadRepository<StatementSetModel> _statementSetReadRepository;
    private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;

    public DeleteStatementSetCommandHandler(
        IBaseReadRepository<StatementSetModel> statementSetReadRepository,
        IBaseWriteRepository<StatementSetModel> statementSetWriteRepository)
    {
        _statementSetReadRepository = statementSetReadRepository;
        _statementSetWriteRepository = statementSetWriteRepository;
    }

    public async Task<StatementSetModel?> Handle(DeleteStatementSetCommand request, CancellationToken cancellationToken)
    {
        var statementSet = await _statementSetReadRepository.FindByIdAsync(request.StatementSetId, cancellationToken);
        if (statementSet == null)
        {
            return null;
        }

        return await _statementSetWriteRepository.DeleteAsync(statementSet, true, cancellationToken);
    }
}
