using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class UpdateStatementTypeCommandHandler : IRequestHandler<UpdateStatementTypeCommand, StatementTypeModel?>
{
    private readonly IBaseReadRepository<StatementTypeModel> _statementTypeReadRepository;
    private readonly IBaseWriteRepository<StatementTypeModel> _statementTypeWriteRepository;

    public UpdateStatementTypeCommandHandler(
        IBaseReadRepository<StatementTypeModel> statementTypeReadRepository,
        IBaseWriteRepository<StatementTypeModel> statementTypeWriteRepository,
        IMediator mediator)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
        _statementTypeWriteRepository = statementTypeWriteRepository;
    }

    public async Task<StatementTypeModel?> Handle(UpdateStatementTypeCommand request, CancellationToken cancellationToken)
    {
        var statementType = await _statementTypeReadRepository.FindByIdAsync(request.StatementTypeId, cancellationToken);
        if (statementType == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            statementType.Title = request.Title;
        }

        return await _statementTypeWriteRepository.UpdateAsync(statementType, true, cancellationToken);
    }
}
