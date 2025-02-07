using Microsoft.EntityFrameworkCore;

namespace MultipleChoiceTool.Infrastructure.Databases;

internal class SqliteDbContext : BaseDbContext<SqliteDbContext>
{
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
        : base(options)
    {
    }
}
