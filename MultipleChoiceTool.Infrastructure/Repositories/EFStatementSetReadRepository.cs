using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Infrastructure.Entities;
using MultipleChoiceTool.Infrastructure.Extensions;

namespace MultipleChoiceTool.Infrastructure.Repositories;

/// <summary>
/// Repository for reading statement sets from the database.
/// </summary>
internal class EFStatementSetReadRepository : EFBaseReadRepository<StatementSetEntity, StatementSetModel>, IStatementSetReadRepository
{
    public EFStatementSetReadRepository(
        DbContext dbContext, 
        IMapper mapper) 
        : base(dbContext, mapper)
    {
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public async Task<IEnumerable<StatementSetModel>> FindStatementSetsByTypeIdAsync(Guid typeId, CancellationToken cancellationToken = default)
    {
        return await FindStatementSetsByTypeIdAsync(typeId, autoInclude: false, cancellationToken);
    }
}
