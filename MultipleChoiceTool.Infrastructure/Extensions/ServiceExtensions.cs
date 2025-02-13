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

public static class ServiceExtensions
{
    public static void AddMultipleChoiceToolInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(InfrastructureMappings));

        services.AddEFBaseRepository<QuestionaireEntity, QuestionaireModel>();
        services.AddEFBaseRepository<QuestionaireLinkEntity, QuestionaireLinkModel>();
        services.AddEFBaseRepository<StatementEntity, StatementModel>();
        services.AddEFBaseRepository<StatementSetEntity, StatementSetModel>();
        services.AddEFBaseRepository<StatementTypeEntity, StatementTypeModel>();
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

    private static void AddEFBaseRepository<TEntity, TModel>(this IServiceCollection services)
        where TEntity : class
        where TModel : class
    {
        services.AddScoped<IBaseReadRepository<TModel>, EFBaseReadRepository<TEntity, TModel>>();
        services.AddScoped<IBaseWriteRepository<TModel>, EFBaseWriteRepository<TEntity, TModel>>();
    }

    private static string GetRequiredConnectionString(this IConfiguration configuration, string connectionStringName)
    {
        return configuration.GetConnectionString(connectionStringName)
            ?? throw new InvalidOperationException($"There is no connection string with key {connectionStringName}.");
    }
}
