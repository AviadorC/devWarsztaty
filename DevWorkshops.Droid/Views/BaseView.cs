using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace DevWorkshops.Droid.Views
{
    public abstract class BaseView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(LayoutResource);
        }

        protected abstract int LayoutResource { get; }
    }
}
