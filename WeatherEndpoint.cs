namespace Platform;

using Services;

public  class WeatherEndpoint
{
    public async Task Endpoint(HttpContext context, IResponseFormatter formatter)
    {
        await formatter.Format(context, "Middleware Class: It is cloudy in Milan.");
    }
}