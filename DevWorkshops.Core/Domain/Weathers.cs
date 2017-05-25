using System;
using System.Collections.Generic;

namespace DevWorkshops.Core.Domain
{
    public static class Weathers
    {
        public static Dictionary<String, WeatherDescription> AllWeathers = new Dictionary<string, WeatherDescription>
        {
            { "cloudy", new WeatherDescription() { Title = "Kinda Ugly...", Subtitle="And those clouds" }},
            { "frosty", new WeatherDescription() { Title = "Chill out", Subtitle="There's cold enough" }},
            { "snowing", new WeatherDescription() { Title = "Yup. Gonna snow", Subtitle="Again..." }},
            { "rainy", new WeatherDescription() { Title = "F*** it", Subtitle="I'mma stayin' home" }},
            { "sunny", new WeatherDescription() { Title = "God DAMN!", Subtitle="So beautiful!" }},
            { "windy", new WeatherDescription() { Title = "Blow gently?", Subtitle="Not up there" }}
        };
    }
}
