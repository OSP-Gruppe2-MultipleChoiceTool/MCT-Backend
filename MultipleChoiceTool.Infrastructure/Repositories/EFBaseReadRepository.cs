using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Infrastructure.Extensions;

namespace MultipleChoiceTool.Infrastructure.Repositories;

/// <summary>
/// Base repository for reading entities from the database.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TModel">The type of the model.</typeparam>
internal class EFBaseReadRepository<TEntity, TModel> : IBaseReadRepository<TModel>
    where TEntity : class
    where TModel : class
{
    protected readonly DbContext _dbContext;
    protected readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="EFBaseReadRepository{TEntity, TModel}"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    /// <param name="mapper">The mapper.</param>
    public EFBaseReadRepository(
        DbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TModel>> FindAllAsync(bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        
        if (autoInclude)
        {
            foreach (var entity in entities)
            {
                await _dbContext.AutoIncludeRecursiveAsync(entity, cancellationToken);
            }
        }

        return _mapper.Map<IEnumerable<TModel>>(entities);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TModel>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        return await FindAllAsync(autoInclude: false, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TModel?> FindByIdAsync(Guid id, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync([id], cancellationToken);

        if (entity != null && autoInclude)
        {
            await _dbContext.AutoIncludeRecursiveAsync(entity, cancellationToken);
        }

        return _mapper.Map<TModel?>(entity);
    }

    /// <inheritdoc />
    public async Task<TModel?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await FindByIdAsync(id, autoInclude: false, cancellationToken);
    }
}
