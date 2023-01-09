using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(opts =>
{
    opts.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
});

WebApplication app = builder.Build();

app.Use(async (context, next) =>
{
    Endpoint? end = context.GetEndpoint();
    if (end != null)
    {
        await context.Response.WriteAsync($"{end.DisplayName} selected\n");
    }
    else
    {
        await context.Response.WriteAsync("no endpoint selected\n");
    }

    await next();
});

app
    .Map("{number:int}", async context =>
    {
        await context.Response.WriteAsync("Routed to the int endpoint\n");
    })
    .WithDisplayName("Int Endpoint")
    .Add(b => ((RouteEndpointBuilder)b).Order = 1);
app
    .Map("{number:double}",
        async context =>
        {
            await context.Response.WriteAsync("Routed to the double endpoint\n");
        })
    .WithDisplayName("Double Endpoint")
    .Add(b => ((RouteEndpointBuilder)b).Order = 2);

app.MapFallback(async context =>
{
    await context.Response.WriteAsync("Routed to fallback endpoint\n");
});

app.Run();