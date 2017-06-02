using System;
using DevWorkshops.Core.Domain;
using DevWorkshops.Service;
using MvvmCross.Core.ViewModels;
using System.Linq;
using System.ComponentModel;
using DevWorkshops.Core.Common;

namespace DevWorkshops.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel, IMvxNotifyPropertyChanged
    {
        private IWeatherService weatherService;

        private string location = "";
        private string weatherStatusSubtitle;
        private string weatherStatusTitle;
        private string weatherStatus;

        public FirstViewModel(
            IWeatherService weatherService,
            IPlatformSpecific platformSpecific) 
        {
            this.weatherService = weatherService;

            System.Diagnostics.Debug.WriteLine(platformSpecific.From);
        }

        public string Location
        {
            get { return location; }
            set 
            { 
                SetProperty(ref location, value);
                if (location.Length > 2) 
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

        private async void UpdateWeather() 
        {
            var weather = await weatherService.GetWeather(location);

            if (!string.IsNullOrWhiteSpace(weather.Weather))
            {
                var weatherFromLocation = Weathers.AllWeathers[weather.Weather];
                WeatherStatus = weather.Weather;
                WeatherStatusTitle = weatherFromLocation.Title;
                WeatherStatusSubtitle = weatherFromLocation.Subtitle;
            } else 
            {
                WeatherStatus = string.Empty;
                WeatherStatusTitle = string.Empty;
                WeatherStatusSubtitle = string.Empty;
            }
        }
    }
}
