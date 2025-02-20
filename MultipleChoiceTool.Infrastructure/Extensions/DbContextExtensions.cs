using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Infrastructure.Entities;
using System.Reflection;

namespace MultipleChoiceTool.Infrastructure.Extensions;

internal static class DbContextExtensions
{
    public static async Task AutoIncludeRecursiveAsync<TEntity>(this DbContext context, TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class
    {
        await AutoIncludeAsync(context, entity, cancellationToken);

        var entityProperties = typeof(TEntity)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in entityProperties)
        {
            var propertyValue = property.GetValue(entity);
            if (propertyValue is IEnumerable<EntityBase> entityCollection)
            {
                foreach (var entityItem in entityCollection)
                {
                    await AutoIncludeRecursiveAsync(context, entityItem, cancellationToken);
                }
            }
            else if (propertyValue is EntityBase singleEntity)
            {
                await AutoIncludeRecursiveAsync(context, singleEntity, cancellationToken);
            }
        }
    }

    public static async Task AutoIncludeAsync<TEntity>(this DbContext context, TEntity entity, CancellationToken cancellationToken)
        where TEntity : class
    {
        var entityEntry = context.Entry(entity);
        foreach (var navigation in entityEntry.Navigations)
        {
            if (!navigation.IsLoaded)
            {
                await navigation.LoadAsync(cancellationToken);
            }
        }
    }
}
