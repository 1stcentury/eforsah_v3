using System;
using System.Drawing;
using Xamarin.Themes;
using ThemeSample.UI.Common;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace ThemeSample.UI.iPhone {
	public class ProfileView : UIView {
		UIView profileDetailsView;
		UIButton workoutButton;
		UIButton cardioButton;
		UIButton journalButton;

		UILabel weightLabel;
		UILabel weightDescriptionLabel;
		UILabel weightStartLabel;
		UILabel weightCurrentLabel;
		UILabel weightStartNumberLabel;
		UILabel weightCurrentNumberLabel;

		UIImageView profileIcon;

		public ProfileController ProfileTableViewController { get; private set; }

		public ProfileView ()
		{
			AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			InitSubviews ();
			ApplyStyles ();
		}

		public void InitSubviews () 
		{
			var image = UIImage.FromFile ("profile-stats-bg.png");

			profileDetailsView = new UIView ();
			profileDetailsView.BackgroundColor = UIColor.FromPatternImage (image);
			profileDetailsView.Frame = new CGRect (profileDetailsView.Frame.Location, image.Size);

			workoutButton = Buttons.ProfileButton ("Workouts", "stats-workout.png");
			cardioButton = Buttons.ProfileButton ("Cardio", "stats-cardio.png");
			journalButton = Buttons.ProfileButton ("Journal", "stats-journal.png");

			cardioButton.ImageEdgeInsets = new UIEdgeInsets (0, 19, 3, 0);
			cardioButton.TitleEdgeInsets = new UIEdgeInsets (0, 34, 3, 0);
			
			journalButton.ImageEdgeInsets = new UIEdgeInsets (0, 9, 3, 0);
			journalButton.TitleEdgeInsets = new UIEdgeInsets (0, 22, 3, 0);
			
			profileIcon = new UIImageView (UIImage.FromFile ("picture.png"));

			profileIcon.Center = new PointF (58, 55);

			profileDetailsView.AddSubviews (profileIcon, workoutButton, cardioButton, journalButton);

			InitLabels ();

			ProfileTableViewController = new ProfileController ();

			var tableFooterImageView = new UIImageView (FitpulseTheme.SharedTheme.TableFooterBackground);
			ProfileTableViewController.TableView.TableFooterView = tableFooterImageView;
			ProfileTableViewController.TableView.ReloadData ();


			Add (ProfileTableViewController.View);
			Add (profileDetailsView);
		}

		private void InitLabels ()
		{
			var mainColor = UIColor.FromRGBA (0.29f, 0.29f, 0.29f, 1);
			var additionalColor = UIColor.FromRGBA (0.53f, 0.53f, 0.53f, 1);

			weightLabel = GetLabel (FitpulseTheme.SharedTheme.DinProBoldFont (40), mainColor);
			weightLabel.Text = "22";
			weightLabel.Center = new PointF (124, 16);
			weightLabel.SizeToFit ();

			weightDescriptionLabel = GetLabel (FitpulseTheme.SharedTheme.DinProCondBoldFont (20), additionalColor);
			weightDescriptionLabel.Text = "kg to go";
			weightDescriptionLabel.Center = new PointF (120, 55);
			weightDescriptionLabel.SizeToFit ();

			weightStartLabel = GetLabel (FitpulseTheme.SharedTheme.DinProCondBoldFont (14), additionalColor);
			weightStartLabel.Text = "Starting weight:";
			weightStartLabel.Center = new PointF (185, 29);
			weightStartLabel.SizeToFit ();

			weightStartNumberLabel = GetLabel (FitpulseTheme.SharedTheme.DinProCondBoldFont (14), mainColor);
			weightStartNumberLabel.Text = "115";
			weightStartNumberLabel.Center = new PointF (268, 29);
			weightStartNumberLabel.SizeToFit ();

			weightCurrentLabel = GetLabel (FitpulseTheme.SharedTheme.DinProCondBoldFont (14), additionalColor);
			weightCurrentLabel.Text = "Current weight:";
			weightCurrentLabel.Center = new PointF (185, 59);
			weightCurrentLabel.SizeToFit ();

			weightCurrentNumberLabel = GetLabel (FitpulseTheme.SharedTheme.DinProCondBoldFont (14), mainColor);
			weightCurrentNumberLabel.Text = "115";
			weightCurrentNumberLabel.Center = new PointF (268, 59);
			weightCurrentNumberLabel.SizeToFit ();

			profileDetailsView.AddSubviews (weightLabel, weightDescriptionLabel, weightStartNumberLabel, weightCurrentNumberLabel, weightStartLabel, weightCurrentLabel);
		}

		private UILabel GetLabel (UIFont font, UIColor color)
		{
			var label = new UILabel ();
			
			FitpulseTheme.Apply (label);			
			
			label.Font = font;
			label.TextColor = color;
			label.BackgroundColor = UIColor.Clear;

			return label;
		}

		private void ApplyStyles ()
		{
			BackgroundColor = UIColor.Green;
		}

		public override void LayoutSubviews ()
		{
			Frame = new CGRect (0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
			profileDetailsView.Frame = new CGRect (0, 0, UIScreen.MainScreen.Bounds.Width, 158);
			ProfileTableViewController.View.Frame = new CGRect (0, profileDetailsView.Frame.Bottom - 6, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - profileDetailsView.Bounds.Height);			

			workoutButton.Frame = new CGRect (0, profileDetailsView.Frame.Bottom - 46, 111, 44);			
			cardioButton.Frame = new CGRect (111, profileDetailsView.Frame.Bottom - 46, 111, 44);			
			journalButton.Frame = new CGRect (222, profileDetailsView.Frame.Bottom - 46, 111, 44);

			base.LayoutSubviews ();
		}
	}
}

