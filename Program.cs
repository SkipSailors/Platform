using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager servicesConfig = builder.Configuration;
builder.Services.Configure<MessageOptions>(servicesConfig.GetSection("Location"));
IWebHostEnvironment servicesEnvironment = builder.Environment;

WebApplication app = builder.Build();
IConfiguration pipelineConfig = app.Configuration;
IWebHostEnvironment pipelineEnv = app.Environment;

app.UseMiddleware<LocationMiddleware>();
app.MapGet("config", async (HttpContext context, IConfiguration configuration, IWebHostEnvironment env) =>
{
    string defaultDebug = configuration["Logging:LogLevel:Default"];
    await context.Response.WriteAsync($"The config setting is {defaultDebug}\n");
    string environ = configuration["ASPNETCORE_ENVIRONMENT"];
    await context.Response.WriteAsync($"\nThe env setting is {env.EnvironmentName}");
    string wsId = configuration["WebService:Id"];
    string wsKey = configuration["WebService:Key"];
    await context.Response.WriteAsync($"\nThe secret ID setting is {wsId}");
    await context.Response.WriteAsync($"\nThe secret Key setting is {wsKey}");
});

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World");
});

app.Run();