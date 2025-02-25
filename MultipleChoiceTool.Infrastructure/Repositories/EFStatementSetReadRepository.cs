using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Infrastructure.Entities;
using MultipleChoiceTool.Infrastructure.Extensions;

namespace MultipleChoiceTool.Infrastructure.Repositories;

internal class EFStatementSetReadRepository : EFBaseReadRepository<StatementSetEntity, StatementSetModel>, IStatementSetReadRepository
{
    public EFStatementSetReadRepository(
        DbContext dbContext, 
        IMapper mapper) 
        : base(dbContext, mapper)
    {
    }

    public async Task<IEnumerable<StatementSetModel>> FindStatementSetsByTypeIdAsync(Guid typeId, bool autoInclude = false, CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<StatementSetEntity>()
            .Where(statementSet => statementSet.StatementTypeId == typeId)
            .ToListAsync(cancellationToken);

        if (autoInclude)
        {
            foreach (var entity in entities)
            {
                await _dbContext.AutoIncludeRecursiveAsync(entity, cancellationToken);
            }
        }

        return _mapper.Map<IEnumerable<StatementSetModel>>(entities);
    }

    public async Task<IEnumerable<StatementSetModel>> FindStatementSetsByTypeIdAsync(Guid typeId, CancellationToken cancellationToken = default)
    {
        return await FindStatementSetsByTypeIdAsync(typeId, autoInclude: false, cancellationToken);
    }
}
