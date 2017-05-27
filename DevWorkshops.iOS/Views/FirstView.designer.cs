// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DevWorkshops.iOS.Views
{
    [Register ("FirstView")]
    partial class FirstView
    {
        [Outlet]
        UIKit.UIImageView BackgroundImage { get; set; }

        [Outlet]
        UIKit.UITextField LocationEntry { get; set; }
        
        void ReleaseDesignerOutlets ()
        {
            if (BackgroundImage != null) {
                BackgroundImage.Dispose ();
                BackgroundImage = null;
            }

            if (LocationEntry != null) {
                LocationEntry.Dispose ();
                LocationEntry = null;
            }
        }
    }
}
