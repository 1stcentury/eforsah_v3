using System;
using ThemeSample.Model;
using Xamarin.Themes;


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
#endif

namespace ThemeSample.UI.iPhone {
	public class WorkoutDetailController : UIViewController {
		public UIImageView Icon { get; private set; }
		public UIImageView IconFrame { get; private set; }		
		public UILabel TitleLabel { get; private set; }
		public UILabel CallsDescription { get; private set; }
		public UILabel DurationDescription { get; private set; }
		public UILabel ExercisesDescription { get; private set; }
		public UILabel SetsDescription { get; private set; }
		public UILabel Sets { get; private set; }
		public UILabel Calls { get; private set; }
		public UILabel Duration { get; private set; }
		public UILabel Exercises { get; private set; }

		public WorkoutDetailController (CGRect frame)
		{
			View.Frame = frame;
			InitSubviews();
			ApplyStyles();
		}

		void InitSubviews() 
		{	
			Icon = new UIImageView (new CGRect (13, 38, 52, 52));
			IconFrame = new UIImageView (new CGRect (12, 37, 54, 54));
			TitleLabel = new UILabel (new CGRect (13, 6, 260, 22));

			CallsDescription = new UILabel (new CGRect (73, 33, 72, 16));
			DurationDescription = new UILabel (new CGRect (73, 48, 49, 16));
			ExercisesDescription = new UILabel (new CGRect (73, 63, 85, 16));
			SetsDescription = new UILabel (new CGRect (73, 78, 59, 16));
			
			Calls = new UILabel (new CGRect (146, 33, 21, 16));
			Duration = new UILabel (new CGRect (130, 48, 37, 16));
			Exercises = new UILabel (new CGRect (158, 63, 14, 16)) { TextAlignment = UITextAlignment.Right };
			Sets = new UILabel (new CGRect (128, 78, 23, 16)) { TextAlignment = UITextAlignment.Right };
			
			CallsDescription.Text = "Calls burned:";
			DurationDescription.Text = "Duration:";
			ExercisesDescription.Text = "Total Exercises:";
			SetsDescription.Text = "Total sets:";

			IconFrame.Image = UIImage.FromFile ("list-item-frame.png");
			
			View.AddSubviews (Icon, IconFrame, TitleLabel, CallsDescription, DurationDescription, ExercisesDescription, SetsDescription, Calls, Duration, Exercises, Sets);
		}

		void ApplyStyles()
		{
			View.BackgroundColor = UIColor.FromPatternImage(FitpulseTheme.SharedTheme.ViewBackground);

			CallsDescription.BackgroundColor = 
				DurationDescription.BackgroundColor = 
					ExercisesDescription.BackgroundColor =
					TitleLabel.BackgroundColor =
					SetsDescription.BackgroundColor =
					Sets.BackgroundColor =
					Calls.BackgroundColor = 
					Duration.BackgroundColor = 
					Exercises.BackgroundColor = UIColor.Clear;
			
			CallsDescription.Font = 
				DurationDescription.Font = 
					ExercisesDescription.Font = 
					SetsDescription.Font = 
					Sets.Font =
					Calls.Font = 
					Duration.Font = 
					Exercises.Font = UIFont.FromName ("HelveticaNeue", 12);
			
			CallsDescription.TextColor = 
				DurationDescription.TextColor = 
					ExercisesDescription.TextColor = 
					SetsDescription.TextColor =
					Sets.TextColor =
					Calls.TextColor = 
					Duration.TextColor = 
					Exercises.TextColor = UIColor.FromRGB (151, 157, 155);
			
			CallsDescription.HighlightedTextColor = 
				TitleLabel.HighlightedTextColor =				
					DurationDescription.HighlightedTextColor = 
					ExercisesDescription.HighlightedTextColor = 
					SetsDescription.HighlightedTextColor =
					Sets.HighlightedTextColor =
					Calls.HighlightedTextColor = 
					Duration.HighlightedTextColor = 
					Exercises.HighlightedTextColor = UIColor.White;
			
			TitleLabel.Font = UIFont.FromName ("HelveticaNeue-Bold", 16);
		}

		public void BindTo(Workout model)
		{
			if (model == null) 
				return;

			TitleLabel.Text = model.Title;
			Title = model.Title;

			Sets.Text = model.Sets;
			Calls.Text = model.Calls;
			Exercises.Text = model.Exercises;
			Duration.Text = model.Duration;

			Icon.Image = UIImage.FromFile (model.IconFile);
		}
	}
}

