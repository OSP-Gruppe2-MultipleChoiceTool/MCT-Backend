using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class UpdateStatementTypeCommandHandler : IRequestHandler<UpdateStatementTypeCommand, StatementTypeModel?>
{
    private readonly IBaseWriteRepository<StatementTypeModel> _statementTypeWriteRepository;
    private readonly IMediator _mediator;

    public UpdateStatementTypeCommandHandler(
        IBaseWriteRepository<StatementTypeModel> statementTypeWriteRepository,
        IMediator mediator)
    {
        _statementTypeWriteRepository = statementTypeWriteRepository;
        _mediator = mediator;
    }

    public async Task<StatementTypeModel?> Handle(UpdateStatementTypeCommand request, CancellationToken cancellationToken)
    {
        var statementType = await _mediator.Send(new GetStatementTypeByIdQuery(request.StatementTypeId));
        if (statementType == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(request.StatementType.Title))
        {
            statementType.Title = request.StatementType.Title;
        }

        return await _statementTypeWriteRepository.UpdateAsync(statementType, cancellationToken);
    }
}
