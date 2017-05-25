using System;
using DevWorkshops.Service;
using MvvmCross.Core.ViewModels;

namespace DevWorkshops.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel, IMvxNotifyPropertyChanged
    {
        private IWeatherService weatherService;

        private string location = "";
        private string weatherStatusSubtitle;
        private string weatherStatusTitle;
        private string weatherStatus;

        public FirstViewModel(IWeatherService weatherService) 
        {
            this.weatherService = weatherService;
        }

        public string Location
        {
            get { return location; }
            set 
            { 
                SetProperty(ref location, value); 
                UpdateWeather();
            }
        }

        public string WeatherStatusSubtitle
        {
            get { return weatherStatusSubtitle; }
            set { SetProperty(ref weatherStatusSubtitle, value); }
        }

        public string WeatherStatusTitle
        {
            get { return weatherStatusTitle; }
            set { SetProperty(ref weatherStatusTitle, value); }
        }

        public string WeatherStatus
        {
            get { return weatherStatus; }
            set { SetProperty(ref weatherStatus, value); }
        }

        private void UpdateWeather() 
        {
            var weathers = new[] { "cloudy", "frosty", "rainy", "snowing", "sunny", "windy" };

            var r = new Random();
            WeatherStatus = weathers[r.Next(0, weathers.Length)];
        }
    }
}
