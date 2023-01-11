namespace Platform.Services
{
    public static class TypeBroker
    {
        public static IResponseFormatter Formatter { get; } = new HtmlResponseFormatter();
    }
}
