using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(opts =>
{
    opts.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
});

WebApplication app = builder.Build();

app.Map("{numberr:int}", async context =>
{
    await context.Response.WriteAsync("Routed to the int endpoint\n");
});
app.Map("{numberr:double}", async context =>
{
    await context.Response.WriteAsync("Routed to the double endpoint\n");
});

app.MapFallback(async context =>
{
    await context.Response.WriteAsync("Routed to fallback endpoint\n");
});

app.Run();