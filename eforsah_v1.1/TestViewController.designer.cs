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
	[Register ("TestViewController")]
	partial class TestViewController
	{
		[Outlet]
		UIKit.UILabel lblParentCatName { get; set; }

		[Outlet]
		UIKit.UILabel lblSubCat { get; set; }

		[Outlet]
		UIKit.UITableView tblSubCat { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblParentCatName != null) {
				lblParentCatName.Dispose ();
				lblParentCatName = null;
			}
			if (tblSubCat != null) {
				tblSubCat.Dispose ();
				tblSubCat = null;
			}
		}
	}
}
