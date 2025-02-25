using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Repositories;

public interface IStatementSetReadRepository : IBaseReadRepository<StatementSetModel>
{
    Task<IEnumerable<StatementSetModel>> FindStatementSetsByTypeIdAsync(Guid typeId, bool autoInclude = false, CancellationToken cancellationToken = default);

    Task<IEnumerable<StatementSetModel>> FindStatementSetsByTypeIdAsync(Guid typeId, CancellationToken cancellationToken = default);
}
