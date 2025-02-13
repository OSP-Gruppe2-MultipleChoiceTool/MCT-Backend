using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Infrastructure.Repositories;

internal class EFBaseWriteRepository<TEntity, TModel> : IBaseWriteRepository<TModel>
    where TEntity : class
    where TModel : class
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    public EFBaseWriteRepository(
        DbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<TModel>(entity);
    }

    public async Task<TModel> DeleteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<TModel>(entity);
    }

    public async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TEntity>(model);
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<TModel>(entity);
    }
}
