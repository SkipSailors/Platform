namespace Platform;

public class LocationMiddleware
{
    private readonly RequestDelegate next;
    private readonly MessageOptions options;

    public LocationMiddleware(RequestDelegate nextDelegate, MessageOptions opts)
    {
        next = nextDelegate;
        options = opts;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/location")
        {
            await context.Response.WriteAsync($"{options.CityName}, {options.CountryName}");
        }
        else
        {
            await next(context);
        }
    }
}