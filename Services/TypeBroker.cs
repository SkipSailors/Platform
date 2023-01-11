namespace Platform.Services
{
    public static class TypeBroker
    {
        private static readonly IResponseFormatter formatter = new HtmlResponseFormatter();
        public static IResponseFormatter Formatter => formatter;
    }
}
