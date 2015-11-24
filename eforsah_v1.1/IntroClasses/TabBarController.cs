using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace eforsah_v1
{
	partial class TabBarController : UITabBarController
	{
		public TabBarController (IntPtr handle) : base (handle)
		{
		}
		// provide access to the sidebar controller to all inheriting controllers
		protected SidebarNavigation.SidebarController SidebarController { 
			get {
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.SidebarController;
			} 
		}

		// provide access to the navigation controller to all inheriting controllers
		protected NavController NavController { 
			get {
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.NavController;
			} 
		}

		// provide access to the storyboard to all inheriting controllers
		public override UIStoryboard Storyboard { 
			get {
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.Storyboard;
			} 
		}

				public override void ViewDidLoad()
				{
					base.ViewDidLoad();
		 
					NavigationItem.SetRightBarButtonItem(
						new UIBarButtonItem(UIImage.FromBundle("threelines")
							, UIBarButtonItemStyle.Plain
							, (sender,args) => {
								SidebarController.ToggleMenu();
							}), true);
				}
	}
}
