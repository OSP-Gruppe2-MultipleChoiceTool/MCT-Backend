using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the update of a statement type.
/// </summary>
internal class UpdateStatementTypeCommandHandler : IRequestHandler<UpdateStatementTypeCommand, StatementTypeModel?>
{
    private readonly IBaseReadRepository<StatementTypeModel> _statementTypeReadRepository;
    private readonly IBaseWriteRepository<StatementTypeModel> _statementTypeWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateStatementTypeCommandHandler"/> class.
    /// </summary>
    /// <param name="statementTypeReadRepository">The repository to read statement types from.</param>
    /// <param name="statementTypeWriteRepository">The repository to write statement types to.</param>
    public UpdateStatementTypeCommandHandler(
        IBaseReadRepository<StatementTypeModel> statementTypeReadRepository,
        IBaseWriteRepository<StatementTypeModel> statementTypeWriteRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
        _statementTypeWriteRepository = statementTypeWriteRepository;
    }

    /// <summary>
    /// Handles the request to update a statement type.
    /// </summary>
    /// <param name="request">The request containing the details of the statement type to update.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The updated statement type model if successful; otherwise, null.</returns>
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
