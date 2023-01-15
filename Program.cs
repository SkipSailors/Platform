using Microsoft.AspNetCore.HttpLogging;
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

app.MapGet("population/{city?}", Population.Endpoint);

app.Run();