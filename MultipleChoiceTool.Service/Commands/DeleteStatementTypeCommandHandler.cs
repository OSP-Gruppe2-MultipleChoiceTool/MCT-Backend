using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the deletion of a statement type.
/// </summary>
internal class DeleteStatementTypeCommandHandler : IRequestHandler<DeleteStatementTypeCommand, StatementTypeModel?>
{
    private readonly IBaseReadRepository<StatementTypeModel> _statementTypeReadRepository;
    private readonly IBaseWriteRepository<StatementTypeModel> _statementTypeWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteStatementTypeCommandHandler"/> class.
    /// </summary>
    /// <param name="statementTypeReadRepository">The repository to read statement types from.</param>
    /// <param name="statementTypeWriteRepository">The repository to write statement types to.</param>
    public DeleteStatementTypeCommandHandler(
        IBaseReadRepository<StatementTypeModel> statementTypeReadRepository,
        IBaseWriteRepository<StatementTypeModel> statementTypeWriteRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
        _statementTypeWriteRepository = statementTypeWriteRepository;
    }

    /// <summary>
    /// Handles the request to delete a statement type.
    /// </summary>
    /// <param name="request">The request containing the details of the statement type to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The deleted statement type model if successful; otherwise, null.</returns>
    public async Task<StatementTypeModel?> Handle(DeleteStatementTypeCommand request, CancellationToken cancellationToken)
    {
        var statementType = await _statementTypeReadRepository.FindByIdAsync(request.StatementTypeId, cancellationToken);
        if (statementType == null)
        {
            return null;
        }

        return await _statementTypeWriteRepository.DeleteAsync(statementType, true, cancellationToken);
    }
}
