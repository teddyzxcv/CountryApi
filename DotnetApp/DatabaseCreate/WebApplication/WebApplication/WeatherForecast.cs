using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApplication
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class Country
    {
        public Country(string name, string[] top, string alpha2, string alpha3, string[] call, string capital,
            string region, string subregion, int population, List<string> timezones)
        {
            this.Name = name;
            this.topLevelDomain = top;
            this.alpha2Code = alpha2;
            this.alpha3Code = alpha3;
            this.callingCodes = call;
            this.capital = capital;
            this.region = region;
            this.subregion = subregion;
            this.population = population;
            this.timezones = timezones;
        }

        public string Name { get; set; }
        public string[] topLevelDomain { get; set; }
        public string alpha2Code { get; set; }
        public string alpha3Code { get; set; }
        public string[] callingCodes { get; set; }
        public string capital { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public int population { get; set; }
        public List<string> timezones { get; set; }
    }
}