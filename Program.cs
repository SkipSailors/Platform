using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();

app.MapGet("population/{city?}", Population.Endpoint);

app.Run();