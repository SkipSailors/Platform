namespace Platform;

using Services;

public  class WeatherEndpoint
{
    private IResponseFormatter formatter;

    public WeatherEndpoint(IResponseFormatter responseFormatter)
    {
        formatter = responseFormatter;
    }

    public async Task Endpoint(HttpContext context)
    {
        await formatter.Format(context, "Middleware Class: It is cloudy in Milan.");
    }
}