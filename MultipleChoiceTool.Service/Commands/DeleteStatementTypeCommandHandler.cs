using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class DeleteStatementTypeCommandHandler : IRequestHandler<DeleteStatementTypeCommand, StatementTypeModel?>
{
    private readonly IBaseReadRepository<StatementTypeModel> _statementTypeReadRepository;
    private readonly IBaseWriteRepository<StatementTypeModel> _statementTypeWriteRepository;

    public DeleteStatementTypeCommandHandler(
        IBaseReadRepository<StatementTypeModel> statementTypeReadRepository,
        IBaseWriteRepository<StatementTypeModel> statementTypeWriteRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
        _statementTypeWriteRepository = statementTypeWriteRepository;
    }

    public async Task<StatementTypeModel?> Handle(DeleteStatementTypeCommand request, CancellationToken cancellationToken)
    {
        var statementType = await _statementTypeReadRepository.FindByIdAsync(request.StatementTypeId, cancellationToken);
        if (statementType == null)
        {
            return null;
        }

        return await _statementTypeWriteRepository.DeleteAsync(statementType, cancellationToken);
    }
}
