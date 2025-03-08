using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Infrastructure.Databases;
using MultipleChoiceTool.Infrastructure.Entities;
using MultipleChoiceTool.Infrastructure.Mappings;
using MultipleChoiceTool.Infrastructure.Repositories;

namespace MultipleChoiceTool.Infrastructure.Extensions;

/// <summary>
/// Provides extension methods for IServiceCollection to add infrastructure services.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds the infrastructure services for the MultipleChoiceTool.
    /// </summary>
    /// <param name="services">The service collection.</param>
    public static void AddMultipleChoiceToolInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(InfrastructureMappings));

        services.AddEFBaseRepositories();
        services.AddSpecialEFRepositories();
    }

    /// <summary>
    /// Adds the SQLite database infrastructure.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="connectionStringName">The name of the connection string.</param>
    public static void AddSqliteDbInfrastructure(this IServiceCollection services, 
        IConfiguration configuration, string connectionStringName)
    {
        var connectionString = configuration.GetRequiredConnectionString(connectionStringName);
        services.AddDbContext<DbContext, SqliteDbContext>(options => options.UseSqlite(connectionString));
    }

    /// <summary>
    /// Adds the SQL Server database infrastructure.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="connectionStringName">The name of the connection string.</param>
    public static void AddSqlServerDbInfrastructure(this IServiceCollection services,
        IConfiguration configuration, string connectionStringName)
    {
        var connectionString = configuration.GetRequiredConnectionString(connectionStringName);
        services.AddDbContext<DbContext, SqlServerDbContext>(options => options.UseSqlServer(connectionString));
    }

    /// <summary>
    /// Adds special EF repositories to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    private static void AddSpecialEFRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStatementSetReadRepository, EFStatementSetReadRepository>();
        services.AddScoped<IStatementTypeReadRepository, EFStatementTypeReadRepository>();
    }

    /// <summary>
    /// Adds EF base repositories to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    private static void AddEFBaseRepositories(this IServiceCollection services)
    {
        services.AddEFBaseRepository<QuestionaireEntity, QuestionaireModel>();
        services.AddEFBaseRepository<QuestionaireLinkEntity, QuestionaireLinkModel>();
        services.AddEFBaseRepository<StatementTypeEntity, StatementTypeModel>();
        services.AddEFBaseRepository<StatementSetEntity, StatementSetModel>();
        services.AddEFBaseRepository<StatementEntity, StatementModel>();
    }

    /// <summary>
    /// Adds an EF base repository to the service collection.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <param name="services">The service collection.</param>
    private static void AddEFBaseRepository<TEntity, TModel>(this IServiceCollection services)
        where TEntity : class
        where TModel : class
    {
        services.AddScoped<IBaseReadRepository<TModel>, EFBaseReadRepository<TEntity, TModel>>();
        services.AddScoped<IBaseWriteRepository<TModel>, EFBaseWriteRepository<TEntity, TModel>>();
    }

    /// <summary>
    /// Gets the required connection string from the configuration.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="connectionStringName">The name of the connection string.</param>
    /// <returns>The connection string.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the connection string is not found.</exception>
    private static string GetRequiredConnectionString(this IConfiguration configuration, string connectionStringName)
    {
        return configuration.GetConnectionString(connectionStringName)
            ?? throw new InvalidOperationException($"There is no connection string with key {connectionStringName}.");
    }
}
