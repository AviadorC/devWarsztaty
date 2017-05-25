using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DevWorkshops.Service.Model;
using Newtonsoft.Json;

namespace DevWorkshops.Service
{
    public class WeatherService : BaseService, IWeatherService
    {
        protected override string Host => "weatherapidevwarsztaty.azurewebsites.net/api/";

        protected override string Scheme => "http";

        public async Task<WeatherModel> GetWeather(string location)
        {
            var result = new WeatherModel();

            string method = $"weather/{ location }";
            var response = await GetAsync(BuildUri(method));

            if (response.IsSuccess)
            {
                var responseContent = JsonConvert.DeserializeObject<WeatherModel>(response.ResponseContentString);
                result = responseContent;
            }

            return result;
        }
    }
}
