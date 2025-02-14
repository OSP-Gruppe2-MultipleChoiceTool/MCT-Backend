using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class UpdateStatementSetCommandHandler : IRequestHandler<UpdateStatementSetCommand, StatementSetModel?>
{
    private readonly IBaseReadRepository<StatementSetModel> _statementSetReadRepository;
    private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;

    public UpdateStatementSetCommandHandler(
        IBaseReadRepository<StatementSetModel> statementSetReadRepository, 
        IBaseWriteRepository<StatementSetModel> statementSetWriteRepository)
    {
        _statementSetReadRepository = statementSetReadRepository;
        _statementSetWriteRepository = statementSetWriteRepository;
    }

    public async Task<StatementSetModel?> Handle(UpdateStatementSetCommand request, CancellationToken cancellationToken)
    {
        var statementSet = await _statementSetReadRepository.FindByIdAsync(request.StatementSetId, cancellationToken);
        if (statementSet == null)
        {
            return null;
        }

        if (request.StatementSet.StatementTypeId != null)
        {
            statementSet.StatementTypeId = request.StatementSet.StatementTypeId;
        }

        if (!string.IsNullOrWhiteSpace(request.StatementSet.Explaination))
        {
            statementSet.Explaination = request.StatementSet.Explaination;
        }

        if (!string.IsNullOrWhiteSpace(request.StatementSet.StatementImage))
        {
            statementSet.StatementImage = request.StatementSet.StatementImage;
        }

        return await _statementSetWriteRepository.UpdateAsync(request.StatementSet, cancellationToken);
    }
}
