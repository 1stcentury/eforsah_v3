using System;

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

namespace ThemeSample.UI.iPhone {
	public class WorkoutCell : UITableViewCell {
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

		public static readonly NSString Key = new NSString ("WorkoutCell");
		
		public WorkoutCell () : base (UITableViewCellStyle.Default, Key)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			InitSubviews ();
			ApplyStyles ();
		}

		private void InitSubviews ()
		{
			Icon = new UIImageView (new CGRect (13, 9, 52, 52));
			IconFrame = new UIImageView (new CGRect (12, 8, 54, 54));
			TitleLabel = new UILabel (new CGRect (74, 6, 260, 22));
			CallsDescription = new UILabel (new CGRect (73, 33, 72, 16));
			DurationDescription = new UILabel (new CGRect (73, 48, 49, 16));
			ExercisesDescription = new UILabel (new CGRect (193, 33, 85, 16));
			SetsDescription = new UILabel (new CGRect (193, 48, 59, 16));

			Calls = new UILabel (new CGRect (146, 33, 21, 16));
			Duration = new UILabel (new CGRect (130, 48, 37, 16));
			Exercises = new UILabel (new CGRect (278, 33, 14, 16)) { TextAlignment = UITextAlignment.Right };
			Sets = new UILabel (new CGRect (248, 48, 23, 16)) { TextAlignment = UITextAlignment.Right };

			CallsDescription.Text = "Calls burned:";
			DurationDescription.Text = "Duration:";
			ExercisesDescription.Text = "Total Exercises:";
			SetsDescription.Text = "Total sets:";

			AddSubviews (Icon, IconFrame, TitleLabel, CallsDescription, DurationDescription, ExercisesDescription, SetsDescription, Calls, Duration, Exercises, Sets);
		}

		private void ApplyStyles ()
		{
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

		public override void SetSelected (bool selected, bool animated)
		{
			base.SetSelected (selected, animated);

			TitleLabel.TextColor = UIColor.FromRGBA (0.29f, 0.29f, 0.29f, 1);

			var yOffset = selected ? 0 : 1;

			var offset = new CGSize (0, yOffset);

			CallsDescription.ShadowOffset = DurationDescription.ShadowOffset =
				ExercisesDescription.ShadowOffset = SetsDescription.ShadowOffset = offset;
		}
	}
}

