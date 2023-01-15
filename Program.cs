using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();

app.Logger.LogDebug("pipeline configuration starting");

app.MapGet("population/{city?}", Population.Endpoint);

app.Logger.LogDebug("pipeline configuration complete");

app.Run();