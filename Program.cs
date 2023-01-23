using Microsoft.EntityFrameworkCore;
using Platform;
using Platform.Models;
using Platform.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedSqlServerCache(opts =>
{
    opts.ConnectionString = builder.Configuration["ConnectionStrings:CacheConnection"];
    opts.SchemaName = "dbo";
    opts.TableName = "DataCache";
});
builder.Services.AddResponseCaching();
builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
builder.Services.AddDbContext<CalculationContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:CalcConnection"]);
});

WebApplication app = builder.Build();
app.UseResponseCaching();
app.MapEndpoint<SumEndpoint>("/sum/{count:int=1000000000}");
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World");
});

app.Run();
