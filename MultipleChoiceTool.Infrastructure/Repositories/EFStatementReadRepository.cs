using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Infrastructure.Entities;
using MultipleChoiceTool.Infrastructure.Extensions;

namespace MultipleChoiceTool.Infrastructure.Repositories;

internal class EFStatementReadRepository : EFBaseReadRepository<StatementEntity, StatementModel>, IStatementReadRepository
{
    public EFStatementReadRepository(
        DbContext dbContext, 
        IMapper mapper) 
        : base(dbContext, mapper)
    {
    }

    public async Task<StatementModel?> FindStatementByContentAsync(string content, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<StatementEntity>()
            .FirstOrDefaultAsync(x => x.Statement == content, cancellationToken);

        if (entity != null && autoInclude)
        {
            await _dbContext.LoadNavigationsAsync(entity, cancellationToken);
        }

        return _mapper.Map<StatementModel?>(entity);
    }

    public async Task<StatementModel?> FindStatementByContentAsync(string content, CancellationToken cancellationToken = default)
    {
        return await FindStatementByContentAsync(content, autoInclude: false, cancellationToken);
    }
}
