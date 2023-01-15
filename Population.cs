namespace Platform;

public partial class Population
{
    public static async Task Endpoint(HttpContext context, ILogger<Population> logger)
    {
        // logger.LogDebug($"Started processing for {context.Request.Path}");
        StartingResponse(logger, context.Request.Path);
        string city = context.Request.RouteValues["city"] as string ?? "london";
        int? pop = city.ToLower() switch
        {
            "london" => 8_136_000,
            "paris" => 2_141_000,
            "monaco" => 39_000,
            _ => null
        };

        if (pop.HasValue)
        {
            await context.Response.WriteAsync($"City: {city}, Population: {pop}");
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }

        logger.LogDebug($"Finished processing for {context.Request.Path}");
    }

    [LoggerMessage(0, LogLevel.Debug, "Starting response for {path}")]
    public static partial void StartingResponse(ILogger logger, string path);
}