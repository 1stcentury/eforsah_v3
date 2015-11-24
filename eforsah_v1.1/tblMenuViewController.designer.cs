// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace eforsah_v1
{
	[Register ("tblMenuViewController")]
	partial class tblMenuViewController
	{
		[Outlet]
		UIKit.UIImageView imgProfile { get; set; }

		[Outlet]
		UIKit.UILabel lblCountery { get; set; }

		[Outlet]
		UIKit.UILabel lblMyAccount { get; set; }

		[Outlet]
		UIKit.UILabel lblSettings { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblMyAccount != null) {
				lblMyAccount.Dispose ();
				lblMyAccount = null;
			}

			if (lblCountery != null) {
				lblCountery.Dispose ();
				lblCountery = null;
			}

			if (lblSettings != null) {
				lblSettings.Dispose ();
				lblSettings = null;
			}

			if (imgProfile != null) {
				imgProfile.Dispose ();
				imgProfile = null;
			}
		}
	}
}
