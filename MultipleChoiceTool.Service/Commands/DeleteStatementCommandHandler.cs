using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class DeleteStatementCommandHandler : IRequestHandler<DeleteStatementCommand, StatementModel?>
{
    private readonly IBaseReadRepository<StatementModel> _statementReadRepository;
    private readonly IBaseWriteRepository<StatementModel> _statementWriteRepository;

    public DeleteStatementCommandHandler(
        IBaseReadRepository<StatementModel> statementReadRepository,
        IBaseWriteRepository<StatementModel> statementWriteRepository)
    {
        _statementReadRepository = statementReadRepository;
        _statementWriteRepository = statementWriteRepository;
    }

    public async Task<StatementModel?> Handle(DeleteStatementCommand request, CancellationToken cancellationToken)
    {
        var statement = await _statementReadRepository.FindByIdAsync(request.StatementId, cancellationToken);
        if (statement == null)
        {
            return null;
        }

        return await _statementWriteRepository.DeleteAsync(statement, true, cancellationToken);
    }
}
