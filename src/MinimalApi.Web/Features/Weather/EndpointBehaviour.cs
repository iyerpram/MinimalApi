namespace MinimalApi.Web.Features.Weather
{
    public class EndpointBehaviour
    {
        public static IResult Get()
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            var forecast = Enumerable.Range(1, 5).Select(index =>
                     new WeatherForecast
                     (
                         DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                         Random.Shared.Next(-20, 55),
                         summaries[Random.Shared.Next(summaries.Length)]
                     ))
                     .ToArray();
            return Results.Ok(forecast);
        }
    }
}
