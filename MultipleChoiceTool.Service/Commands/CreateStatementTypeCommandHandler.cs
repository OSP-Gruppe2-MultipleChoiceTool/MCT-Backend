using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the creation of a new statement type.
/// </summary>
internal class CreateStatementTypeCommandHandler : IRequestHandler<CreateStatementTypeCommand, StatementTypeModel>
{
    private readonly IStatementTypeReadRepository _statementTypeReadRepository;
    private readonly IBaseWriteRepository<StatementTypeModel> _statementTypeWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateStatementTypeCommandHandler"/> class.
    /// </summary>
    /// <param name="statementTypeReadRepository">The repository to read statement types from.</param>
    /// <param name="statementTypeWriteRepository">The repository to write statement types to.</param>
    public CreateStatementTypeCommandHandler(
        IStatementTypeReadRepository statementTypeReadRepository,
        IBaseWriteRepository<StatementTypeModel> statementTypeWriteRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
        _statementTypeWriteRepository = statementTypeWriteRepository;
    }

    /// <summary>
    /// Handles the request to create a new statement type.
    /// </summary>
    /// <param name="request">The request containing the title of the statement type.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The created statement type model.</returns>
    public async Task<StatementTypeModel> Handle(CreateStatementTypeCommand request, CancellationToken cancellationToken)
    {
        var statementModel = await _statementTypeReadRepository.FindStatementTypeByTitleAsync(request.Title, true, cancellationToken);
        if (statementModel != null)
        {
            return statementModel;
        }

        var statementType = new StatementTypeModel(request.Title);
        return await _statementTypeWriteRepository.CreateAsync(statementType, true, cancellationToken);
    }
}
