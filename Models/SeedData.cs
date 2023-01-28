namespace Platform.Models;

using Microsoft.EntityFrameworkCore;

public class SeedData
{
    private static readonly Dictionary<int, long> data = new()
    {
        { 1, 1 }, { 2, 3 }, { 3, 6 }, { 4, 10 }, { 5, 15 },
        { 6, 21 }, { 7, 28 }, { 8, 36 }, { 9, 45 }, { 10, 55 }
    };

    private readonly CalculationContext context;
    private readonly ILogger<SeedData> logger;

    public SeedData(CalculationContext dataContext, ILogger<SeedData> log)
    {
        context = dataContext;
        logger = log;
    }

    public void SeedDatabase()
    {
        context.Database.Migrate();
        if (context.Calculations?.Count() == 0)
        {
            logger.LogInformation("Preparing to seed database");
            context.Calculations.AddRange(
                data.Select(kvp => new Calculation
                {
                    Count = kvp.Key,
                    Result = kvp.Value
                }));
            context.SaveChanges();
            logger.LogInformation("Database seeded");
        }
        else
        {
            logger.LogInformation("Database not seeded");
        }
    }
}