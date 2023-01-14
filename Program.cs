WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();

app.MapGet("config", async (HttpContext context, IConfiguration configuration) =>
{
    string defaultDebug = configuration["Logging:LogLevel:Default"];
    await context.Response.WriteAsync($"The config setting is {defaultDebug}");
});

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World");
});

app.Run();