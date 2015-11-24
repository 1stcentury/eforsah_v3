using System;
using Xamarin.Themes;
using Xamarin.Controls.iOS.ProgressBar;

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
	public class ProfileCell : UITableViewCell {
		public static readonly NSString Key = new NSString ("ProfileCell");

		public ProgressBar ProgressBar { get; private set; }
		public UILabel TitleLabel { get; private set;}
		public UIImageView Icon { get; private set; }
		public UIImageView IconFrame { get; private set; }		

		public ProfileCell () : base (UITableViewCellStyle.Default, Key)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;

			InitSubviews ();
		}

		private void InitSubviews ()
		{
			ProgressBar = new ProgressBar (new CGRect (74, 29, 230, 20));
			TitleLabel = new UILabel (new CGRect (74, 7, 226, 22));
			Icon = new UIImageView (new CGRect (13, 10, 52, 52));
			IconFrame = new UIImageView (new CGRect (12, 9, 54, 54));

			TitleLabel.Font = UIFont.FromName ("HelveticaNeue-Bold", 16);
			TitleLabel.TextColor = FitpulseTheme.SharedTheme.MainColor;

			TitleLabel.BackgroundColor = UIColor.Clear;

			AddSubviews (Icon, IconFrame, TitleLabel, ProgressBar);
		}
	}
}

