using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(opts =>
{
    opts.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
});

WebApplication app = builder.Build();

app.MapGet("capital/{country:countryName}", Capital.Endpoint);
app.MapGet("capital/{country:regex(^uk|france|monaco$)}", Capital.Endpoint);
app
    .MapGet("size/{city?}", Population.Endpoint)
    .WithMetadata(new RouteNameMetadata("population"));
app.MapFallback(async context =>
{
    await context.Response.WriteAsync("Routed to fallback endpoint\n");
});

app.Run();