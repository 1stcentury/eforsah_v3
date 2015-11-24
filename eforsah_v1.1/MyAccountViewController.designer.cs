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
	[Register ("MyAccountViewController")]
	partial class MyAccountViewController
	{
		[Outlet]
		UIKit.UILabel lblEditeAccount { get; set; }

		[Outlet]
		UIKit.UILabel lblFllowers { get; set; }

		[Outlet]
		UIKit.UILabel lblMessages { get; set; }

		[Outlet]
		UIKit.UILabel lblMyAccount { get; set; }

		[Outlet]
		UIKit.UILabel lblMyClassifieds { get; set; }

		[Outlet]
		UIKit.UILabel lblSignIn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblMyAccount != null) {
				lblMyAccount.Dispose ();
				lblMyAccount = null;
			}

			if (lblEditeAccount != null) {
				lblEditeAccount.Dispose ();
				lblEditeAccount = null;
			}

			if (lblFllowers != null) {
				lblFllowers.Dispose ();
				lblFllowers = null;
			}

			if (lblMyClassifieds != null) {
				lblMyClassifieds.Dispose ();
				lblMyClassifieds = null;
			}

			if (lblMessages != null) {
				lblMessages.Dispose ();
				lblMessages = null;
			}

			if (lblSignIn != null) {
				lblSignIn.Dispose ();
				lblSignIn = null;
			}
		}
	}
}
