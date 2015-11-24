// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace eforsah_v1
{
	[Register ("CustomClasifiedCell")]
	partial class CustomClasifiedCell
	{
		[Outlet]
		UIKit.UIImageView imgClassified { get; set; }

		[Outlet]
		UIKit.UILabel lblAddress { get; set; }

		[Outlet]
		UIKit.UILabel lblCategory { get; set; }

		[Outlet]
		UIKit.UILabel lblDate { get; set; }

		[Outlet]
		UIKit.UILabel lblPrice { get; set; }

		[Outlet]
		UIKit.UILabel lblTitle { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (imgClassified != null) {
				imgClassified.Dispose ();
				imgClassified = null;
			}
			if (lblAddress != null) {
				lblAddress.Dispose ();
				lblAddress = null;
			}
			if (lblCategory != null) {
				lblCategory.Dispose ();
				lblCategory = null;
			}
			if (lblDate != null) {
				lblDate.Dispose ();
				lblDate = null;
			}
			if (lblPrice != null) {
				lblPrice.Dispose ();
				lblPrice = null;
			}
			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}
		}
	}
}
