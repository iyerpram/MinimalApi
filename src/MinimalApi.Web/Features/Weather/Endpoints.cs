namespace MinimalApi.Web.Features.Weather
{
    public class Endpoints
    {
        public static void Configure(RouteGroupBuilder builder)
        {
            var group = builder.MapGroup("/weatherforecast");
            group.MapGet("/", EndpointBehaviour.Get);
        }
    }
}
