﻿using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Repositories;

public interface IStatementReadRepository : IBaseReadRepository<StatementModel>
{
    Task<StatementModel?> FindStatementByContentAsync(string content, bool autoInclude = false, CancellationToken cancellationToken = default);

    Task<StatementModel?> FindStatementByContentAsync(string content, CancellationToken cancellationToken = default);
}
