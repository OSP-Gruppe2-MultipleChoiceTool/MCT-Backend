namespace MultipleChoiceTool.Core.Repositories;

public interface IBaseReadRepository<TModel>
    where TModel : class
{
    Task<IEnumerable<TModel>> FindAllAsync(bool autoInclude = false, CancellationToken cancellationToken = default);

    Task<IEnumerable<TModel>> FindAllAsync(CancellationToken cancellationToken = default);

    Task<TModel?> FindByIdAsync(Guid id, bool autoInclude = false, CancellationToken cancellationToken = default);

    Task<TModel?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
