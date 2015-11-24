using System;
using System.Collections.Generic;
using System.Linq;


#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif


using Xamarin.FitpulseTheme.Utils.iOS.Common;
using Xamarin.Themes;
using ThemeSample.UI.iPhone;
using ThemeSample.UI.iPad;

namespace ThemeSample {
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		UIWindow window;
		UITabBarController tabBarController;
		UISplitViewController splitViewController;

		public bool IsPhone { 
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			//ste the naviagtion font size
			FitpulseTheme.NavigationFontSize = 16;

			FitpulseTheme.Apply ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			app.StatusBarHidden = true;

			if (IsPhone) {
				InitPhoneRootViewController ();
				window.RootViewController = tabBarController;
			} else {
				InitPadRootViewController ();
				window.RootViewController = splitViewController;
			}

			window.MakeKeyAndVisible ();
			
			return true;
		}

		public void InitPadRootViewController ()
		{
			tabBarController = new UITabBarController ();

			tabBarController.ViewControllers = new UIViewController[] {
				new UINavigationController (new DetailViewController ())			
			};

			for (var i = 0; i < tabBarController.TabBar.Items.Length; i++) {
				var item = tabBarController.TabBar.Items[i];
				FitpulseTheme.Apply (item, (ThemeTab)i);
			}

			splitViewController = new UISplitViewController ();
			var workoutController = new WorkoutController ();

			splitViewController.ViewControllers = new UIViewController[] {
				new UINavigationController (workoutController),
				tabBarController
			};

			splitViewController.Delegate = new SplitViewDelegate (workoutController);
		}

		public void InitPhoneRootViewController ()
		{
			tabBarController = new UITabBarController ();

			tabBarController.ViewControllers = new UIViewController[] {
				new UINavigationController (new ProfileViewController ()),
				new UINavigationController (new WorkoutController ()),
				new UINavigationController (new ElementsViewController ()),
				new ExtraViewController ()
			};

			for (var i = 0; i < tabBarController.TabBar.Items.Length; i++) {
				var item = tabBarController.TabBar.Items[i];
				FitpulseTheme.Apply (item, (ThemeTab)i);
			}
		}
	}
}

