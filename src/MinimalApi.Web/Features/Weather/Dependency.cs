﻿namespace MinimalApi.Web.Features.Weather
{
    public static class Dependency
    {
        public static void Configure(WebApplication app, RouteGroupBuilder builder)
        {
            ConfigureEndpoints(builder);
            AddServices(app.Services);
            ConfigureMappings(app);            
        }

        public static void ConfigureEndpoints(RouteGroupBuilder builder)
        {
            var group = builder.MapGroup("/weatherforecast");
            group.MapGet("/", EndpointBehaviour.Get);
        }

        public static void AddServices(IServiceProvider services)
        {
            
        }

        public static void ConfigureMappings(WebApplication app)
        {

        }
    }
}
