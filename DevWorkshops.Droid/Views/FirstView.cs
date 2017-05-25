using Android.App;
using Android.OS;
using DevWorkshops.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using FFImageLoading;
using Android.Widget;
using FFImageLoading.Helpers;
using System;

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

            backgroundImage = FindViewById<FFImageLoading.Cross.MvxImageLoadingView>(Resource.Id.background_image);

            weatherImageListener =
                new MvxPropertyChangedListener(CurrentViewModel).Listen(
                    () => CurrentViewModel.WeatherStatus,
                    (sender, e) => 
                    {
                        ImageService.Instance
                                    .LoadCompiledResource(CurrentViewModel.WeatherStatus)
                                    .Into(backgroundImage);
            });
        }
    }
}
