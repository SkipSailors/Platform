using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("{first:alpha:length(3)}/{second:bool}", async (context) =>
{
    await context.Response.WriteAsync("Request was routed\n");
    foreach (KeyValuePair<string, object?> kvp in context.Request.RouteValues)
    {
        await context.Response.WriteAsync($"{kvp.Key}:{kvp.Value}\n");
    }
});
app.MapGet("capital/{country:regex(^uk|france|monaco$)}", Capital.Endpoint);
app
    .MapGet("size/{city?}", Population.Endpoint)
    .WithMetadata(new RouteNameMetadata("population"));

app.Run();