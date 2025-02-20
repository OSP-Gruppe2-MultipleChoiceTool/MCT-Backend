using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Infrastructure.Entities;
using MultipleChoiceTool.Infrastructure.Extensions;

namespace MultipleChoiceTool.Infrastructure.Repositories;

internal class EFStatementTypeReadRepository : EFBaseReadRepository<StatementTypeEntity, StatementTypeModel>, IStatementTypeReadRepository
{
    public EFStatementTypeReadRepository(
        DbContext dbContext, 
        IMapper mapper) 
        : base(dbContext, mapper)
    {
    }

    public async Task<StatementTypeModel?> FindStatementTypeByTitleAsync(string title, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<StatementTypeEntity>()
            .FirstOrDefaultAsync(x => x.Title == title, cancellationToken);

        if (entity != null && autoInclude)
        {
            await _dbContext.AutoIncludeRecursiveAsync(entity, cancellationToken);
        }

        return _mapper.Map<StatementTypeModel?>(entity);
    }

    public async Task<StatementTypeModel?> FindStatementTypeByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await FindStatementTypeByTitleAsync(title, autoInclude: false, cancellationToken);
    }
}
