using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Infrastructure.Extensions;

namespace MultipleChoiceTool.Infrastructure.Repositories;

/// <summary>
/// Base repository for writing entities to the database.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TModel">The type of the model.</typeparam>
internal class EFBaseWriteRepository<TEntity, TModel> : IBaseWriteRepository<TModel>
    where TEntity : class
    where TModel : class
{
    protected readonly DbContext _dbContext;
    protected readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="EFBaseWriteRepository{TEntity, TModel}"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    /// <param name="mapper">The mapper.</param>
    public EFBaseWriteRepository(
        DbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<TModel> CreateAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        var result = await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await HandleResultAsync(result, autoInclude, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        return await CreateAsync(model, autoInclude: false, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TModel> DeleteAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        var result = _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await HandleResultAsync(result, autoInclude, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TModel> DeleteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(model, autoInclude: false, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TModel> UpdateAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        var result = _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await HandleResultAsync(result, autoInclude, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        return await UpdateAsync(model, autoInclude: false, cancellationToken: cancellationToken);
    }

    private async Task<TModel> HandleResultAsync(EntityEntry<TEntity> entry, bool autoInclude, CancellationToken cancellationToken)
    {
        var entity = entry.Entity;
        if (autoInclude)
        {
            await _dbContext.AutoIncludeRecursiveAsync(entity, cancellationToken);
        }
        return _mapper.Map<TModel>(entity);
    }
}
