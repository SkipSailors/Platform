using Platform;
using Platform.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IWebHostEnvironment env = builder.Environment;
if (env.IsDevelopment())
{
    builder.Services.AddScoped<IResponseFormatter, TimeResponseFormatter>();
    builder.Services.AddScoped<ITimeStamper, DefaultTimeStamper>();
}
else
{
    builder.Services.AddScoped<IResponseFormatter, HtmlResponseFormatter>();
}

WebApplication app = builder.Build();
app.UseMiddleware<WeatherMiddleware>();
app.MapGet(
    "middleware/function",
    async (HttpContext context, IResponseFormatter formatter) =>
    {
        await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
    });
app.MapEndpoint<WeatherEndpoint>("endpoint/class");
app.MapGet(
    "endpoint/function",
    async (HttpContext context) =>
    {
        IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
        await formatter.Format(context, "Endpoint Function: It is sunny in LA");
    });

app.Run();