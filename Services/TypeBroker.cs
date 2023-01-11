namespace Platform.Services
{
    public static class TypeBroker
    {
        private static readonly IResponseFormatter formatter = new TextResponseFormatter();
        public static IResponseFormatter Formatter => formatter;
    }
}
