namespace Platform
{
    public class CountryRouteConstraint: IRouteConstraint
    {
        private static readonly string[] Countries = { "Uk", "france", "monaco" };
        public bool Match(
            HttpContext? httpContext,
            IRouter? route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            string segmentValue = values[routeKey] as string ?? string.Empty;
            return Array.IndexOf(Countries, segmentValue.ToLower()) > -1;
        }
    }
}
