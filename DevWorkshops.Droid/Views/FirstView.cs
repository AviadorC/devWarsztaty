using Android.App;
using Android.OS;
using DevWorkshops.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using FFImageLoading;
using Android.Widget;
using FFImageLoading.Helpers;
using System;
using Android.Graphics;

namespace DevWorkshops.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : BaseView
    {
        public FirstViewModel CurrentViewModel => ViewModel as FirstViewModel;

        protected override int LayoutResource => Resource.Layout.FirstView;

        private MvxPropertyChangedListener weatherImageListener = null;

        private FFImageLoading.Cross.MvxImageLoadingView backgroundImage;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

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
