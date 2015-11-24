using System;
using Xamarin.Themes;
using ThemeSample.UI.Common;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace ThemeSample.UI.iPad {
	public partial class DetailViewController : UIViewController {

		public DetailViewController ()
		{
			Title = "Item";
			NavigationItem.Title = "Detail";
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitSubviews ();
			FitpulseTheme.Apply (View);
		}

		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate (fromInterfaceOrientation);
		}

		private void InitSubviews ()
		{
			var backgroundFrameImageView = new UIImageView (UIImage.FromFile ("workout-header-frame.png"));
			backgroundFrameImageView.Frame = new CGRect (13, 20, 676, 251);
			
			Add (backgroundFrameImageView);

			var backgroundImageView = new UIImageView (UIImage.FromFile ("workout-header.png"));
			backgroundImageView.Frame = new CGRect (19, 25, 665, 238);

			Add (backgroundImageView);

			var headerLabel1 = new UILabel (new CGRect (51, 60, 280, 62));
			headerLabel1.Text = "Killer";
			headerLabel1.Font = FitpulseTheme.SharedTheme.HelveticaNeueBoldFont (46);
			headerLabel1.TextColor = UIColor.White;
			headerLabel1.BackgroundColor = UIColor.Clear;

			Add (headerLabel1);

			var headerLabel2 = new UILabel (new CGRect (51, 109, 280, 62));
			headerLabel2.Text = "Biceps";
			headerLabel2.Font = FitpulseTheme.SharedTheme.HelveticaNeueBoldFont (46);
			headerLabel2.TextColor = UIColor.Yellow;
			headerLabel2.BackgroundColor = UIColor.Clear;
			
			Add (headerLabel2);

			var headerLabel3 = new UILabel (new CGRect (51, 157, 280, 62));
			headerLabel3.Text = "Workout";
			headerLabel3.Font = FitpulseTheme.SharedTheme.HelveticaNeueBoldFont (46);
			headerLabel3.TextColor = UIColor.Yellow;
			headerLabel3.BackgroundColor = UIColor.Clear;
			
			Add (headerLabel3);

			var stepOneImageView = new UIImageView (UIImage.FromFile ("workout-step1.png"));
			stepOneImageView.Frame = new CGRect (19, 448, 102, 104);
			
			Add (stepOneImageView);

			var stepTwoImageView = new UIImageView (UIImage.FromFile ("workout-step2.png"));
			stepTwoImageView.Frame = new CGRect (279, 448, 102, 104);
			
			Add (stepTwoImageView);

			var uiTextView = new UITextView (new CGRect (13, 279, 676, 161));
			uiTextView.Editable = false;
			uiTextView.Text = Strings.WorkoutDescription;
			uiTextView.Font = UIFont.SystemFontOfSize (13);
			uiTextView.BackgroundColor = UIColor.Clear;
			Add (uiTextView);

			var label1 = new UILabel (new CGRect (129, 453, 54, 21));
			label1.Text = "Step 1:";
			label1.BackgroundColor = UIColor.Clear;
			label1.Font = FitpulseTheme.SharedTheme.HelveticaNeueBoldFont (15);
			label1.TextColor = UIColor.DarkGray;

			var label1Description = new UITextView (new CGRect (120, 473, 115, 87));
			label1Description.Editable = false;
			label1Description.Text = Strings.WorkoutStepOne;
			label1Description.Font = FitpulseTheme.SharedTheme.HelveticaNeueFont (13);
			label1Description.BackgroundColor = UIColor.Clear;
			
			Add (label1);
			Add (label1Description);

			var label2 = new UILabel (new CGRect (389, 453, 54, 21));
			label2.Text = "Step 2:";
			label2.BackgroundColor = UIColor.Clear;
			label2.Font = FitpulseTheme.SharedTheme.HelveticaNeueBoldFont (15);
			label2.TextColor = UIColor.DarkGray;

			var label2Description = new UITextView (new CGRect (379, 473, 115, 187));
			label2Description.Editable = false;
			label2Description.Text = Strings.WorkoutStepTwo;
			label2Description.Font = FitpulseTheme.SharedTheme.HelveticaNeueFont (13);
			label2Description.BackgroundColor = UIColor.Clear;

			Add (label2);
			Add (label2Description);

			var label3 = new UILabel (new CGRect (553, 453, 54, 21));
			label3.Text = "Step 3:";
			label3.BackgroundColor = UIColor.Clear;
			label3.Font = FitpulseTheme.SharedTheme.HelveticaNeueBoldFont (15);
			label3.TextColor = UIColor.DarkGray;

			var label3Description = new UITextView (new CGRect (545, 473, 115, 87));
			label3Description.Editable = false;
			label3Description.Text = Strings.WorkoutStepThree;
			label3Description.Font = FitpulseTheme.SharedTheme.HelveticaNeueFont (13);
			label3Description.BackgroundColor = UIColor.Clear;

			Add (label3);
			Add (label3Description);

			var background = FitpulseTheme.SharedTheme.NavigationBackgroundForIPadAndOrientation (UIApplication.SharedApplication.StatusBarOrientation);
			NavigationController.NavigationBar.SetBackgroundImage (background, UIBarMetrics.Default);
		}

		public override void WillRotate (UIInterfaceOrientation orientation, double duration)
		{
			var background = FitpulseTheme.SharedTheme.NavigationBackgroundForIPadAndOrientation (orientation);
			NavigationController.NavigationBar.SetBackgroundImage (background, UIBarMetrics.Default);
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}

