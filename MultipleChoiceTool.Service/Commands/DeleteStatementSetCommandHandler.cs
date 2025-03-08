using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the deletion of a statement set.
/// </summary>
internal class DeleteStatementSetCommandHandler : IRequestHandler<DeleteStatementSetCommand, StatementSetModel?>
{
    private readonly IStatementSetReadRepository _statementSetReadRepository;
    private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteStatementSetCommandHandler"/> class.
    /// </summary>
    /// <param name="statementSetReadRepository">The repository to read statement sets from.</param>
    /// <param name="statementSetWriteRepository">The repository to write statement sets to.</param>
    public DeleteStatementSetCommandHandler(
        IStatementSetReadRepository statementSetReadRepository,
        IBaseWriteRepository<StatementSetModel> statementSetWriteRepository)
    {
        _statementSetReadRepository = statementSetReadRepository;
        _statementSetWriteRepository = statementSetWriteRepository;
    }

    /// <summary>
    /// Handles the request to delete a statement set.
    /// </summary>
    /// <param name="request">The request containing the details of the statement set to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The deleted statement set model if successful; otherwise, null.</returns>
    public async Task<StatementSetModel?> Handle(DeleteStatementSetCommand request, CancellationToken cancellationToken)
    {
        var statementSet = await _statementSetReadRepository.FindByIdAsync(request.StatementSetId, cancellationToken);
        if (statementSet == null)
        {
            return null;
        }

        return await _statementSetWriteRepository.DeleteAsync(statementSet, true, cancellationToken);
    }
}
