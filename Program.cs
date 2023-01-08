using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("{first}/{second}/{third}", async (context) =>
{
    await context.Response.WriteAsync("Request was routed\n");
    foreach (KeyValuePair<string, object?> kvp in context.Request.RouteValues)
    {
        await context.Response.WriteAsync($"{kvp.Key}:{kvp.Value}\n");
    }
});
app.MapGet("capital/uk", new Capital().Invoke);
app.MapGet("population/paris", new Population().Invoke);

app.Run();