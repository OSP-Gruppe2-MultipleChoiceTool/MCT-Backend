using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultipleChoiceTool.Infrastructure.Databases;

namespace MultipleChoiceTool.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void AddMultipleChoiceToolInfrastructure(this IServiceCollection services)
    {

    }

    public static void AddSqliteDbInfrastructure(this IServiceCollection services, 
        IConfiguration configuration, string connectionStringName)
    {
        var connectionString = configuration.GetRequiredConnectionString(connectionStringName);
        services.AddDbContext<DbContext, SqliteDbContext>(options => options.UseSqlite(connectionString));
    }

    public static void AddSqlServerDbInfrastructure(this IServiceCollection services,
        IConfiguration configuration, string connectionStringName)
    {
        var connectionString = configuration.GetRequiredConnectionString(connectionStringName);
        services.AddDbContext<DbContext, SqlServerDbContext>(options => options.UseSqlServer(connectionString));
    }

    private static string GetRequiredConnectionString(this IConfiguration configuration, string connectionStringName)
    {
        return configuration.GetConnectionString(connectionStringName)
            ?? throw new InvalidOperationException($"There is no connection string with key {connectionStringName}.");
    }
}
