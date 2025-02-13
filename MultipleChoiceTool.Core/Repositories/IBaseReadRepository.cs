namespace MultipleChoiceTool.Core.Repositories;

public interface IBaseReadRepository<TModel>
    where TModel : class
{
    Task<IEnumerable<TModel>> FindAllAsync(CancellationToken cancellationToken = default);

    Task<TModel?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
