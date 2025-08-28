using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ParksService.Data;

public class ParksDbContextFactory : IDesignTimeDbContextFactory<ParksDbContext>
{
    public ParksDbContext CreateDbContext(string[] args)
    {
        // Build config from appsettings + environment
        var basePath = Directory.GetCurrentDirectory();
        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var cs = config.GetConnectionString("ParksDb");

        var options = new DbContextOptionsBuilder<ParksDbContext>()
            .UseNpgsql(cs)
            .Options;

        return new ParksDbContext(options);
    }
}