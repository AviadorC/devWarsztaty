using MvvmCross.Core.ViewModels;

namespace DevWorkshops.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private string location = "";
        private string weatherStatusSubtitle;
        private string weatherStatusTitle;

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

        private void UpdateWeather() 
        {
            WeatherStatusSubtitle = "God damn";
            WeatherStatusTitle = "UGLY";
        }
    }
}
