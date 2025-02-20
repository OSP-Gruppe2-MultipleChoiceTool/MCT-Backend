
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Infrastructure.Repositories;

internal class EFBaseReadRepository<TEntity, TModel> : IBaseReadRepository<TModel>
    where TEntity : class
    where TModel : class
{
    protected readonly DbContext _dbContext;
    protected readonly IMapper _mapper;

    public EFBaseReadRepository(
        DbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TModel>> FindAllAsync(bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        
        if (autoInclude)
        {
            foreach (var entity in entities)
            {
                await LoadNavigationsAsync(entity, cancellationToken);
            }
        }

        return _mapper.Map<IEnumerable<TModel>>(entities);
    }

    public async Task<IEnumerable<TModel>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        return await FindAllAsync(autoInclude: false, cancellationToken);
    }

    public async Task<TModel?> FindByIdAsync(Guid id, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync([id], cancellationToken);

        if (entity != null && autoInclude)
        {
            await LoadNavigationsAsync(entity, cancellationToken);
        }

        return _mapper.Map<TModel?>(entity);
    }

    public async Task<TModel?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await FindByIdAsync(id, autoInclude: false, cancellationToken);
    }

    protected async Task LoadNavigationsAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var entityType = _dbContext.Model.FindEntityType(typeof(TEntity));
        if (entityType != null)
        {
            foreach (var navigation in entityType.GetNavigations())
            {
                await _dbContext.Entry(entity)
                    .Collection(navigation.Name)
                    .LoadAsync(cancellationToken);
            }
        }
    }
}
