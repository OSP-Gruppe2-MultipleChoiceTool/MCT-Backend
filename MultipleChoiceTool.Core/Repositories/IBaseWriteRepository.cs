namespace MultipleChoiceTool.Core.Repositories;

/// <summary>
/// Provides write operations for the specified model type.
/// </summary>
/// <typeparam name="TModel">The type of the model.</typeparam>
public interface IBaseWriteRepository<TModel>
    where TModel : class
{
    /// <summary>
    /// Creates a new model asynchronously.
    /// </summary>
    /// <param name="model">The model to create.</param>
    /// <param name="autoInclude">Whether to automatically include related entities.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created model.</returns>
    Task<TModel> CreateAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new model asynchronously.
    /// </summary>
    /// <param name="model">The model to create.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created model.</returns>
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing model asynchronously.
    /// </summary>
    /// <param name="model">The model to update.</param>
    /// <param name="autoInclude">Whether to automatically include related entities.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated model.</returns>
    Task<TModel> UpdateAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing model asynchronously.
    /// </summary>
    /// <param name="model">The model to update.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated model.</returns>
    Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing model asynchronously.
    /// </summary>
    /// <param name="model">The model to delete.</param>
    /// <param name="autoInclude">Whether to automatically include related entities.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted model.</returns>
    Task<TModel> DeleteAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing model asynchronously.
    /// </summary>
    /// <param name="model">The model to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted model.</returns>
    Task<TModel> DeleteAsync(TModel model, CancellationToken cancellationToken = default);
}
