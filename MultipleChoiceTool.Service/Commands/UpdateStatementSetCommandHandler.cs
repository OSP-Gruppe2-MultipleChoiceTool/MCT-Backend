using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class UpdateStatementSetCommandHandler : IRequestHandler<UpdateStatementSetCommand, StatementSetModel?>
{
    private readonly IStatementSetReadRepository _statementSetReadRepository;
    private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;

    public UpdateStatementSetCommandHandler(
        IStatementSetReadRepository statementSetReadRepository, 
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

        if (request.StatementTypeId != null)
        {
            statementSet.StatementTypeId = request.StatementTypeId;
        }

        if (!string.IsNullOrWhiteSpace(request.Explaination))
        {
            statementSet.Explaination = request.Explaination;
        }

        if (!string.IsNullOrWhiteSpace(request.StatementImage))
        {
            statementSet.StatementImage = request.StatementImage;
        }

        return await _statementSetWriteRepository.UpdateAsync(statementSet, true, cancellationToken);
    }
}
