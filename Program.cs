using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager servicesConfig = builder.Configuration;
builder.Services.Configure<MessageOptions>(servicesConfig.GetSection("Location"));

WebApplication app = builder.Build();
IConfiguration pipelineConfig = app.Configuration;

app.UseMiddleware<LocationMiddleware>();
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