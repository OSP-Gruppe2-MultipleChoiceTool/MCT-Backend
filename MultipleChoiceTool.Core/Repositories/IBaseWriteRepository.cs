﻿namespace MultipleChoiceTool.Core.Repositories;

public interface IBaseWriteRepository<TModel>
    where TModel : class
{
    Task<TModel> CreateAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default);

    Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default);

    Task<TModel> UpdateAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default);

    Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default);

    Task<TModel> DeleteAsync(TModel model, bool autoInclude = false, CancellationToken cancellationToken = default);

    Task<TModel> DeleteAsync(TModel model, CancellationToken cancellationToken = default);
}
