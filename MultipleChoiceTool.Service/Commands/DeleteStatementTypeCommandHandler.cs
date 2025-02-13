using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class DeleteStatementTypeCommandHandler : IRequestHandler<DeleteStatementTypeCommand, StatementTypeModel?>
{
    private readonly IBaseWriteRepository<StatementTypeModel> _statementTypeWriteRepository;
    private readonly IMediator _mediator;

    public DeleteStatementTypeCommandHandler(
        IBaseWriteRepository<StatementTypeModel> statementTypeWriteRepository,
        IMediator mediator)
    {
        _statementTypeWriteRepository = statementTypeWriteRepository;
        _mediator = mediator;
    }

    public async Task<StatementTypeModel?> Handle(DeleteStatementTypeCommand request, CancellationToken cancellationToken)
    {
        var statementType = await _mediator.Send(new GetStatementTypeByIdQuery(request.StatementTypeId));
        if (statementType == null)
        {
            return null;
        }

        return await _statementTypeWriteRepository.DeleteAsync(statementType, cancellationToken);
    }
}
