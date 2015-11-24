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
	[Register ("ClassifiedsViewController")]
	partial class ClassifiedsViewController
	{
		[Outlet]
		UIKit.UITableView tblClassifieds { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tblClassifieds != null) {
				tblClassifieds.Dispose ();
				tblClassifieds = null;
			}
		}
	}
}
