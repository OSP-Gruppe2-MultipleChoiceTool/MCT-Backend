namespace MultipleChoiceTool.Core.Repositories;

/// <summary>
/// Provides read operations for the specified model type.
/// </summary>
/// <typeparam name="TModel">The type of the model.</typeparam>
public interface IBaseReadRepository<TModel>
    where TModel : class
{
    /// <summary>
    /// Finds all models asynchronously.
    /// </summary>
    /// <param name="autoInclude">Whether to automatically include related entities.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of models.</returns>
    Task<IEnumerable<TModel>> FindAllAsync(bool autoInclude = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds all models asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of models.</returns>
    Task<IEnumerable<TModel>> FindAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds a model by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the model.</param>
    /// <param name="autoInclude">Whether to automatically include related entities.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the model if found; otherwise, null.</returns>
    Task<TModel?> FindByIdAsync(Guid id, bool autoInclude = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds a model by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the model.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the model if found; otherwise, null.</returns>
    Task<TModel?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
