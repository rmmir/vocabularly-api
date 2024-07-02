using Microsoft.EntityFrameworkCore;

namespace Vocabularly.Persistence;

public class DbService()
{
    public static void InitializeMigration(WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database;

        logger.LogInformation("Migrating database...");

        while (!db.CanConnect())
        {
            logger.LogInformation("Database not ready yet; waiting...");
            Thread.Sleep(1000);
        }

        try
        {
            serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
            logger.LogInformation("Database migrated successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }
}