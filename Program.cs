using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;
using Platform;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(opts =>
{
    opts.LoggingFields = HttpLoggingFields.RequestMethod |
                         HttpLoggingFields.RequestPath |
                         HttpLoggingFields.ResponseStatusCode;
});

WebApplication app = builder.Build();

app.UseHttpLogging();
IWebHostEnvironment env = app.Environment;
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider($"{env.ContentRootPath}/staticFiles"),
    RequestPath = "/files"
});

app.MapGet("population/{city?}", Population.Endpoint);

app.Run();