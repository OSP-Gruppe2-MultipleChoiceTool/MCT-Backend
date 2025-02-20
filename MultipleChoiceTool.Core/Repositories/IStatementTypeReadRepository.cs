using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Repositories;

public interface IStatementTypeReadRepository : IBaseReadRepository<StatementTypeModel>
{
    Task<StatementTypeModel?> FindStatementTypeByTitleAsync(string title, bool autoInclude = false, CancellationToken cancellationToken = default);

    Task<StatementTypeModel?> FindStatementTypeByTitleAsync(string title, CancellationToken cancellationToken = default);
}
