WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapFallback(async context => await context.Response.WriteAsync("Hello World"));

app.Run();