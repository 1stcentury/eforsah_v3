using System;
using Xamarin.Themes;
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
	public class WorkoutController : UITableViewController {
		public UIPopoverController Popover { get; set; }

		public WorkoutController () : base (UITableViewStyle.Plain)
		{
			Title = "Workouts";
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var source = new WorkoutSource (this);
			source.WorkoutSelected += OnWorkoutSelected;

			var tableFooterImageView = new UIImageView (FitpulseTheme.SharedTheme.TableFooterBackground);

			TableView.Source = source;
			TableView.TableFooterView = tableFooterImageView;
			TableView.ReloadData ();
		}

		void OnWorkoutSelected (Workout workout)
		{
			var workoutDetail = new WorkoutDetailController(View.Bounds);
			workoutDetail.BindTo(workout);

			NavigationController.PushViewController(workoutDetail, true);
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}

