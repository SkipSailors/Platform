namespace Platform.Services;

class DefaultTimeStamper : ITimeStamper
{
    public string TimeStamp => DateTime.Now.ToShortTimeString();
}