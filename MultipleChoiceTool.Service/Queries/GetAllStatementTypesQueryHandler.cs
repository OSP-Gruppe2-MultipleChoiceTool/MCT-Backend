using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

/// <summary>
/// Handles the retrieval of all statement types.
/// </summary>
internal class GetAllStatementTypesQueryHandler : IRequestHandler<GetAllStatementTypesQuery, IEnumerable<StatementTypeModel>>
{
    private readonly IStatementTypeReadRepository _statementTypeReadRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllStatementTypesQueryHandler"/> class.
    /// </summary>
    /// <param name="statementTypeReadRepository">The repository to read statement types from.</param>
    public GetAllStatementTypesQueryHandler(
        IStatementTypeReadRepository statementTypeReadRepository)
    {
        _statementTypeReadRepository = statementTypeReadRepository;
    }

    /// <summary>
    /// Handles the request to retrieve all statement types.
    /// </summary>
    /// <param name="request">The request to retrieve all statement types.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A collection of statement type models.</returns>
    public Task<IEnumerable<StatementTypeModel>> Handle(GetAllStatementTypesQuery request, CancellationToken cancellationToken)
    {
        return _statementTypeReadRepository.FindAllAsync(true, cancellationToken);
    }
}
