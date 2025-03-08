using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultipleChoiceTool.Infrastructure.Extensions;

/// <summary>
/// Provides extension methods for IHost to use database infrastructure.
/// </summary>
public static class HostExtensions
{
    /// <summary>
    /// Applies any pending migrations for the context to the database.
    /// </summary>
    /// <param name="host">The host.</param>
    public static void UseDbInfrastructure(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        dbContext.Database.Migrate();
    }
}
