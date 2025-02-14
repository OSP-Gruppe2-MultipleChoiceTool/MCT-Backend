using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class CreateStatementTypeCommandHandler : IRequestHandler<CreateStatementTypeCommand, StatementTypeModel>
{
    private readonly IStatementTypeReadRepository _statementTypeReadRepository;
    private readonly IBaseWriteRepository<StatementTypeModel> _statementTypeWriteRepository;

    public CreateStatementTypeCommandHandler(
        IStatementTypeReadRepository statementTypeReadRepository,
        IBaseWriteRepository<StatementTypeModel> statementTypeWriteRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
        _statementTypeWriteRepository = statementTypeWriteRepository;
    }

    public async Task<StatementTypeModel> Handle(CreateStatementTypeCommand request, CancellationToken cancellationToken)
    {
        var statementModel = await _statementTypeReadRepository.FindStatementTypeByTitleAsync(request.Title, cancellationToken);
        if (statementModel != null)
        {
            return statementModel;
        }

        var statementType = new StatementTypeModel(request.Title);
        return await _statementTypeWriteRepository.CreateAsync(statementType, cancellationToken);
    }
}
