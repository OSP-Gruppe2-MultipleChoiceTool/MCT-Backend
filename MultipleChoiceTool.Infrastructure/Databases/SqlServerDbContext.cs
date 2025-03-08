using Microsoft.EntityFrameworkCore;

namespace MultipleChoiceTool.Infrastructure.Databases;

/// <summary>
/// SQL Server specific database context.
/// </summary>
internal class SqlServerDbContext : BaseDbContext<SqlServerDbContext>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SqlServerDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
        : base(options)
    {
    }
}
