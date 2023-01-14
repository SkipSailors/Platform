namespace Platform.Services;

public class TimeResponseFormatter : IResponseFormatter
{
    private readonly ITimeStamper stamper;
    
    public TimeResponseFormatter(ITimeStamper timeStamper)
    {
        stamper = timeStamper;
    }

    public async Task Format(HttpContext context, string content)
    {
        await context.Response.WriteAsync($"{stamper.TimeStamp}: {content}");
    }
}