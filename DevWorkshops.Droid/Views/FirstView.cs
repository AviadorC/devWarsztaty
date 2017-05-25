using Android.App;
using Android.OS;
using DevWorkshops.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using FFImageLoading;
using Android.Widget;
using Android.Graphics;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Analytics;

namespace DevWorkshops.Droid.Views
{
    [Activity]
    public class FirstView : BaseView
    {
        public FirstViewModel CurrentViewModel => ViewModel as FirstViewModel;

        protected override int LayoutResource => Resource.Layout.FirstView;

        private MvxPropertyChangedListener weatherImageListener = null;

        private FFImageLoading.Cross.MvxImageLoadingView backgroundImage;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MobileCenter.Start("86557c94-0938-4ebf-8143-76b852ef0191",
                   typeof(Analytics), typeof(Crashes));

            var title = FindViewById<TextView>(Resource.Id.weather_status_main);
            var subtitle = FindViewById<TextView>(Resource.Id.weather_status_subtitle);

            Typeface tf = Typeface.CreateFromAsset(Assets, "Fonts/Montserrat-ExtraLight.otf");
            title.SetTypeface(tf, TypefaceStyle.Normal);
            subtitle.SetTypeface(tf, TypefaceStyle.Normal);

            backgroundImage = FindViewById<FFImageLoading.Cross.MvxImageLoadingView>(Resource.Id.background_image);

            weatherImageListener =
                new MvxPropertyChangedListener(CurrentViewModel).Listen(
                    () => CurrentViewModel.WeatherStatus,
                    (sender, e) => 
                    {
                        if (!string.IsNullOrWhiteSpace(CurrentViewModel.WeatherStatus))
                            ImageService.Instance
                                        .LoadCompiledResource(CurrentViewModel.WeatherStatus)
                                        .Into(backgroundImage);
                        else
                            backgroundImage.SetImageDrawable(null);
                    });
        }
    }
}
