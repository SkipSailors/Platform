using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();

app.UseHttpLogging();

// ILogger logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Pipeline");

// logger.LogDebug("pipeline configuration starting");

app.MapGet("population/{city?}", Population.Endpoint);

// logger.LogDebug("pipeline configuration complete");

app.Run();