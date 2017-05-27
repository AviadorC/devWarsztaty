using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using DevWorkshops.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using FFImageLoading;
using UIKit;
using Foundation;

namespace DevWorkshops.iOS.Views
{
    [MvxFromStoryboard]
    public partial class FirstView : MvxViewController
    {
        public FirstViewModel CurrentViewModel => ViewModel as FirstViewModel;

        private MvxPropertyChangedListener weatherImageListener = null;

        public FirstView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController?.SetNavigationBarHidden(true, false);

            LocationEntry.Layer.BorderColor = UIColor.White.CGColor;

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            //set.Bind(Label).To(vm => vm.Hello);
            set.Bind(LocationEntry).To(vm => vm.Location);
            set.Apply();

            var bundle = NSBundle.MainBundle;

            weatherImageListener =
               new MvxPropertyChangedListener(CurrentViewModel).Listen(
                   () => CurrentViewModel.WeatherStatus,
                   (sender, e) =>
                   {
                       if (!string.IsNullOrWhiteSpace(CurrentViewModel.WeatherStatus))
                       {
                           var resource = bundle.PathForResource(CurrentViewModel.WeatherStatus, ".jpg");
	                       ImageService.Instance
	                               .LoadCompiledResource(resource)
	                               .Into(BackgroundImage);
		               }
                       else
                           BackgroundImage.Image = null;
                   });
        }
    }
}
