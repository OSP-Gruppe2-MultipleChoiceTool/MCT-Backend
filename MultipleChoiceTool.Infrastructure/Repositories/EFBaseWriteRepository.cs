using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Infrastructure.Extensions;

namespace MultipleChoiceTool.Infrastructure.Repositories;

internal class EFBaseWriteRepository<TEntity, TModel> : IBaseWriteRepository<TModel>
    where TEntity : class
    where TModel : class
{
    protected readonly DbContext _dbContext;
    protected readonly IMapper _mapper;

    public EFBaseWriteRepository(
        DbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TModel> CreateAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        var result = await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await HandleResultAsync(result, autoInclude, cancellationToken);
    }

    public async Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        return await CreateAsync(model, autoInclude: false, cancellationToken: cancellationToken);
    }

    public async Task<TModel> DeleteAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        var result = _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await HandleResultAsync(result, autoInclude, cancellationToken);
    }

    public async Task<TModel> DeleteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(model, autoInclude: false, cancellationToken: cancellationToken);
    }

    public async Task<TModel> UpdateAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        var result = _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await HandleResultAsync(result, autoInclude, cancellationToken);
    }

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
