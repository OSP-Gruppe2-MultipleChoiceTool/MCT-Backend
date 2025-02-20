using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class UpdateStatementCommandHandler : IRequestHandler<UpdateStatementCommand, StatementModel?>
{
    private readonly IBaseReadRepository<StatementModel> _statementReadRepository;
    private readonly IBaseWriteRepository<StatementModel> _statementWriteRepository;

    public UpdateStatementCommandHandler(
        IBaseReadRepository<StatementModel> statementReadRepository, 
        IBaseWriteRepository<StatementModel> statementWriteRepository)
    {
        _statementReadRepository = statementReadRepository;
        _statementWriteRepository = statementWriteRepository;
    }

    public async Task<StatementModel?> Handle(UpdateStatementCommand request, CancellationToken cancellationToken)
    {
        var statement = await _statementReadRepository.FindByIdAsync(request.StatementId, cancellationToken);
        if (statement == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(request.Content))
        {
            statement.Content = request.Content;
        }

        if (request.IsCorrect != null)
        {
            statement.IsCorrect = (bool)request.IsCorrect;
        }

        return await _statementWriteRepository.UpdateAsync(statement, cancellationToken);
    }
}
