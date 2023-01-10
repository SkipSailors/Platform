using Platform;
using Platform.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
app.UseMiddleware<WeatherMiddleware>();
IResponseFormatter formatter = new TextResponseFormatter();
app.MapGet("middleware/function", async (context) =>
{
    await formatter.Format(context, "Middleare Function: It is snowing in Chicago");
});
app.MapGet("middleware/class", WeatherEndpoint.Endpoint);
app.MapGet("endpoint/function", async (context) =>
{
    await formatter.Format(context, "Endpoint Function: It is sunny in LA");
});

app.Run();