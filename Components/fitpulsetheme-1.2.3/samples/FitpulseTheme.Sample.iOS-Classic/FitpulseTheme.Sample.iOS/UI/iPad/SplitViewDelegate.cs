using System;
using ThemeSample.UI.iPhone;

#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif

namespace ThemeSample.UI.iPad {
	public class SplitViewDelegate : UISplitViewControllerDelegate {
		WorkoutController controller;

		public SplitViewDelegate (WorkoutController controller)
		{
			this.controller = controller;
		}

		public override void WillHideViewController (UISplitViewController svc, UIViewController aViewController, UIBarButtonItem barButtonItem, UIPopoverController pc)
		{
			barButtonItem.Title = "Workouts";
			var tabBarViewController = (UITabBarController)svc.ViewControllers[1];			
			var detailsNavController = (UINavigationController)tabBarViewController.SelectedViewController;

			detailsNavController.ViewControllers[0].NavigationItem.SetLeftBarButtonItem (barButtonItem, true);

			controller.Popover = pc;
		}

		public override void WillShowViewController (UISplitViewController svc, UIViewController aViewController, UIBarButtonItem button)
		{
			var tabBarViewController = (UITabBarController)svc.ViewControllers[1];			
			var detailsNavController = (UINavigationController)tabBarViewController.SelectedViewController;

			detailsNavController.ViewControllers[0].NavigationItem.SetLeftBarButtonItem (null, true);

			controller.Popover = null;
		}
	}
}

