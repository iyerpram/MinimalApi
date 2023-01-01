using MinimalApi.Web.Features.Weather;

namespace MinimalApi.Web.Configuration
{
    public static class EndpointConfig
    {
        public static void ConfigureEndpoints(this WebApplication app) 
        {
            var group = app.MapGroup("/api").WithOpenApi();
            Endpoints.Configure(group);
        }
    }
}
