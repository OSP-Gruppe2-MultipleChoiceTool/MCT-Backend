using Microsoft.EntityFrameworkCore;

namespace MultipleChoiceTool.Infrastructure.Extensions;

internal static class DbContextExtensions
{
    public static async Task LoadNavigationsAsync<TEntity>(this DbContext context, TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class
    {
        var entry = context.Entry(entity);
        foreach (var navigation in entry.Navigations)
        {
            if (!navigation.IsLoaded)
            {
                await navigation.LoadAsync(cancellationToken);
            }
        }
    }
}
