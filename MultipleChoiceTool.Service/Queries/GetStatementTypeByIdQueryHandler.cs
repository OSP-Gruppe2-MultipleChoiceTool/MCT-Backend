using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

/// <summary>
/// Handles the retrieval of a statement type by its ID.
/// </summary>
internal class GetStatementTypeByIdQueryHandler : IRequestHandler<GetStatementTypeByIdQuery, StatementTypeModel?>
{
    private readonly IStatementTypeReadRepository _statementTypeReadRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetStatementTypeByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="statementTypeReadRepository">The repository to read statement types from.</param>
    public GetStatementTypeByIdQueryHandler(
        IStatementTypeReadRepository statementTypeReadRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
    }

    /// <summary>
    /// Handles the request to retrieve a statement type by its ID.
    /// </summary>
    /// <param name="request">The request containing the statement type ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The statement type model if found; otherwise, null.</returns>
    public async Task<StatementTypeModel?> Handle(GetStatementTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _statementTypeReadRepository.FindByIdAsync(request.StatementId, true, cancellationToken);
    }
}
