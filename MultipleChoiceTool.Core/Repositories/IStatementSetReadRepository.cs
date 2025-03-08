using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Repositories;

/// <summary>
/// Provides read operations for statement sets.
/// </summary>
public interface IStatementSetReadRepository : IBaseReadRepository<StatementSetModel>
{
    /// <summary>
    /// Finds statement sets by their type identifier asynchronously.
    /// </summary>
    /// <param name="typeId">The identifier of the statement type.</param>
    /// <param name="autoInclude">Whether to automatically include related entities.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of statement sets.</returns>
    Task<IEnumerable<StatementSetModel>> FindStatementSetsByTypeIdAsync(Guid typeId, bool autoInclude = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds statement sets by their type identifier asynchronously.
    /// </summary>
    /// <param name="typeId">The identifier of the statement type.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of statement sets.</returns>
    Task<IEnumerable<StatementSetModel>> FindStatementSetsByTypeIdAsync(Guid typeId, CancellationToken cancellationToken = default);
}
