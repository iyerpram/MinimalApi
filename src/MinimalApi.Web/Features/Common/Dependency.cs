using WeatherApi = MinimalApi.Web.Features.Weather;

namespace MinimalApi.Web.Features.Common
{
    public static class Dependency
    {
        public static void ConfigureApi(this WebApplication app)
        {
            var group = app.MapGroup("/api").WithOpenApi();
            WeatherApi.Dependency.Configure(app, group);
        }
    }
}
