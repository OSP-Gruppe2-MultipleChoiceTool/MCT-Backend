using Microsoft.EntityFrameworkCore;

namespace MultipleChoiceTool.Infrastructure.Databases;

/// <summary>
/// SQLite specific database context.
/// </summary>
internal class SqliteDbContext : BaseDbContext<SqliteDbContext>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SqliteDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
        : base(options)
    {
    }
}
