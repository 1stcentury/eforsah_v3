using System;
using System.Collections.Generic;
using Xamarin.Themes;
using ThemeSample.Model;

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
	public class ProfileSource : UITableViewSource {
		public event Action<Category> CategorySelected;

		List<Category> items;

		public ProfileSource ()
		{
			items = new List<Category> {
				new Category ("Nutrition", "list-item-nutrition.png"),
				new Category ("Workout", "list-item-workout.png"),
				new Category ("Weight", "list-item-weight.png")				
			};
		}
		
		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}
		
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return items.Count;
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (ProfileCell.Key) as ProfileCell;

			if (cell == null)
				cell = new ProfileCell ();

			cell.BackgroundView = new UIImageView (UIImage.FromFile ("list-element.png"));
			cell.Accessory = UITableViewCellAccessory.None;

			var data = items[indexPath.Row];
			cell.TitleLabel.Text = data.Title;
			cell.Icon.Image = UIImage.FromFile (data.IconFile);
			cell.IconFrame.Image = UIImage.FromFile ("list-item-frame.png");

			cell.ProgressBar.Progress = 0.5f;

			AddMarkers (cell, indexPath.Row);

			return cell;
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 72;
		}

		void AddMarkers (ProfileCell cell, int row)
		{
			for (var i = cell.Subviews.Length - 1; i >= 0; i--) {
				var subview = cell.Subviews[i];

				if (subview.Tag == 100)
					subview.RemoveFromSuperview ();
			}

			if (row == 0) {
				var marker1 = new UILabel (new CGRect (73, 50, 30, 16));
				marker1.Text = "1000";

				var marker2 = new UILabel (new CGRect (138, 50, 30, 16));
				marker2.Text = "1500";

				var marker3 = new UILabel (new CGRect (215, 50, 30, 16));
				marker3.Text = "1800";

				var marker4 = new UILabel (new CGRect (278, 50, 30, 16));
				marker4.Text = "2000";

				CustomizeAndAddLabel (cell, marker1);
				CustomizeAndAddLabel (cell, marker2);
				CustomizeAndAddLabel (cell, marker3);
				CustomizeAndAddLabel (cell, marker4);				
			}

			if (row == 1) {
				var marker1 = new UILabel (new CGRect (73, 50, 30, 16));
				marker1.Text = "0";
				
				var marker2 = new UILabel (new CGRect (110, 50, 30, 16));
				marker2.Text = "15";
				
				var marker3 = new UILabel (new CGRect (145, 50, 30, 16));
				marker3.Text = "30";
				
				var marker4 = new UILabel (new CGRect (182, 50, 30, 16));
				marker4.Text = "45";

				var marker5 = new UILabel (new CGRect (223, 50, 30, 16));
				marker5.Text = "60";

				var marker6 = new UILabel (new CGRect (260, 50, 30, 16));
				marker6.Text = "75";

				var marker7 = new UILabel (new CGRect (290, 50, 30, 16));
				marker7.Text = "90";

				CustomizeAndAddLabel (cell, marker1);
				CustomizeAndAddLabel (cell, marker2);
				CustomizeAndAddLabel (cell, marker3);
				CustomizeAndAddLabel (cell, marker4);
				CustomizeAndAddLabel (cell, marker5);
				CustomizeAndAddLabel (cell, marker6);				
				CustomizeAndAddLabel (cell, marker7);
			}

			if (row == 2) {
				var marker1 = new UILabel (new CGRect (73, 50, 30, 16));
				marker1.Text = "87";
				
				var marker2 = new UILabel (new CGRect (182, 50, 30, 16));
				marker2.Text = "80";
				
				var marker3 = new UILabel (new CGRect (290, 50, 30, 16));
				marker3.Text = "75";
				
				CustomizeAndAddLabel (cell, marker1);
				CustomizeAndAddLabel (cell, marker2);
				CustomizeAndAddLabel (cell, marker3);
			}
		}

		void CustomizeAndAddLabel (ProfileCell cell, UILabel label)
		{
			FitpulseTheme.Apply (label);

			label.BackgroundColor = UIColor.Clear;
			label.Font = UIFont.FromName ("HelveticaNeueCE-Roman", 12);
			label.TextAlignment = UITextAlignment.Center;
			label.TextColor = FitpulseTheme.SharedTheme.SecondaryColor;
			label.SizeToFit ();

			label.Tag = 100;
			cell.Add (label);
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (CategorySelected == null)
				return;

			CategorySelected(items[indexPath.Row]);
		}
	}
}

