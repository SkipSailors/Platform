namespace Platform;

using Services;

public static class WeatherEndpoint
{
    public static async Task Endpoint(HttpContext context)
    {
        IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
        await formatter.Format(context, "Middleware Class: It is cloudy in Milan.");
    }
}