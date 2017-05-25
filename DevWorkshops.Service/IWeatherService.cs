using System;
using System.Threading.Tasks;
using DevWorkshops.Service.Model;

namespace DevWorkshops.Service
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeather(string location);
    }
}
