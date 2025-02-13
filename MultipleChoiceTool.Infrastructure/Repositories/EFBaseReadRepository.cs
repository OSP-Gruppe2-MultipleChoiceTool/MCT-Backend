
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Infrastructure.Repositories;

internal class EFBaseReadRepository<TEntity, TModel> : IBaseReadRepository<TModel>
    where TEntity : class
    where TModel : class
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    public EFBaseReadRepository(
        DbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TModel>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<TModel>>(entities);
    }

    public async Task<TModel?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync([id], cancellationToken);
        return _mapper.Map<TModel?>(entity);
    }
}
