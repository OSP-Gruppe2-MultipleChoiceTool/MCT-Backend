using Microsoft.EntityFrameworkCore;

namespace MultipleChoiceTool.Infrastructure.Databases;

internal class SqlServerDbContext : BaseDbContext<SqlServerDbContext>
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
        : base(options)
    {
    }
}
