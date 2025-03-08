using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Repositories;

/// <summary>
/// Provides read operations for statement types.
/// </summary>
public interface IStatementTypeReadRepository : IBaseReadRepository<StatementTypeModel>
{
    /// <summary>
    /// Finds a statement type by its title asynchronously.
    /// </summary>
    /// <param name="title">The title of the statement type.</param>
    /// <param name="autoInclude">Whether to automatically include related entities.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the statement type if found; otherwise, null.</returns>
    Task<StatementTypeModel?> FindStatementTypeByTitleAsync(string title, bool autoInclude = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds a statement type by its title asynchronously.
    /// </summary>
    /// <param name="title">The title of the statement type.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the statement type if found; otherwise, null.</returns>
    Task<StatementTypeModel?> FindStatementTypeByTitleAsync(string title, CancellationToken cancellationToken = default);
}
