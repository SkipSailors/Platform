namespace Platform;

public static class WeatherEndpoint
{
    public static async Task Endpoint(HttpContext context)
    {
        await context.Response.WriteAsync("Middleware Class: It is cloudy in Milan.");
    }
}