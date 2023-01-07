using MinimalApi.Web.Features.Weather;
using WeatherApi = MinimalApi.Web.Features.Weather;

namespace MinimalApi.Web.Features.Common
{
    public static class Dependency
    {
        public static void ConfigureApi(this WebApplication app)
        {
            var group = app.MapGroup("/api").WithOpenApi();
            group.MapPost("/login", LoginEndpointBehaviour.Login).AllowAnonymous();
            WeatherApi.Dependency.Configure(app, group);
        }
    }
}
