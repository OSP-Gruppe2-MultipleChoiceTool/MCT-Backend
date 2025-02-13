using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultipleChoiceTool.Infrastructure.Extensions;

public static class HostExtensions
{
    public static void UseDbInfrastructure(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        dbContext.Database.Migrate();
    }
}
