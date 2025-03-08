using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the update of a statement set.
/// </summary>
internal class UpdateStatementSetCommandHandler : IRequestHandler<UpdateStatementSetCommand, StatementSetModel?>
{
    private readonly IStatementSetReadRepository _statementSetReadRepository;
    private readonly IBaseWriteRepository<StatementModel> _statementWriteRepository;
    private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateStatementSetCommandHandler"/> class.
    /// </summary>
    /// <param name="statementSetReadRepository">The repository to read statement sets from.</param>
    /// <param name="statementWriteRepository">The repository to write statements to.</param>
    /// <param name="statementSetWriteRepository">The repository to write statement sets to.</param>
    public UpdateStatementSetCommandHandler(
        IStatementSetReadRepository statementSetReadRepository,
        IBaseWriteRepository<StatementModel> statementWriteRepository, 
        IBaseWriteRepository<StatementSetModel> statementSetWriteRepository)
    {
        _statementSetReadRepository = statementSetReadRepository;
        _statementSetWriteRepository = statementSetWriteRepository;
        _statementWriteRepository = statementWriteRepository;
    }

    /// <summary>
    /// Handles the request to update a statement set.
    /// </summary>
    /// <param name="request">The request containing the details of the statement set to update.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The updated statement set model if successful; otherwise, null.</returns>
    public async Task<StatementSetModel?> Handle(UpdateStatementSetCommand request, CancellationToken cancellationToken)
    {
        var statementSet = await _statementSetReadRepository.FindByIdAsync(request.StatementSetId, true, cancellationToken);
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

        if (request.Statements != null)
        {
            foreach (var statement in statementSet.Statements)
            {
                await _statementWriteRepository.DeleteAsync(statement, cancellationToken);
            }

            statementSet.Statements.Clear();
            foreach (var statement in request.Statements)
            {
                statementSet.Statements.Add(statement);
            }
        }

        return await _statementSetWriteRepository.UpdateAsync(statementSet, true, cancellationToken);
    }
}
