namespace Platform;

using Services;

public class WeatherMiddleware
{
    private readonly RequestDelegate next;

    public WeatherMiddleware(
        RequestDelegate nextDelegate,
        IResponseFormatter respFormatter)
    {
        next = nextDelegate;
    }

    public async Task Invoke(HttpContext context, IResponseFormatter formatter)
    {
        if (context.Request.Path == "/middleware/class")
        {
            await formatter.Format(context, "Middleware Class: It is raining in London.");
        }
        else
        {
            await next(context);
        }
    }
}