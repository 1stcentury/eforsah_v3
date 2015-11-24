using System;
using ThemeSample.Model;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
#endif

namespace ThemeSample.UI.iPhone {
	public partial class ProfileViewController : UIViewController {
		ProfileView profileView;	

		public ProfileViewController ()
		{
			Title = "Me";
			NavigationItem.Title = "My profile";		

			View.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			InitSubviews ();
			ApplyStyles ();
		}

		private void InitSubviews ()
		{
			profileView = new ProfileView ();
			profileView.ProfileTableViewController.CategorySelected += HandleCategorySelected;

			View.Add (profileView);
		}

		void HandleCategorySelected (Category category)
		{
			var detailView = new ProfileCategoryDetailController(View.Frame);
			detailView.BindTo(category);

			NavigationController.PushViewController(detailView, true);
		}

		private void ApplyStyles ()
		{
			View.BackgroundColor = UIColor.Red;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}
	}
}

