using DevWorkshops.Service;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace DevWorkshops.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            //CreatableTypes()
                //.EndingWith("Service")
                //.AsInterfaces()
                //.RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.FirstViewModel>();

            Mvx.RegisterType<IWeatherService, WeatherService>();
        }
    }
}
