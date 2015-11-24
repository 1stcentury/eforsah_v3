using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Themes;
namespace eforsah_v1 {
	public class TableSource : UITableViewSource {
		List<TableItem> tableItems;
		string cellIdentifier = "taskcell";
		UIViewController owner = null;
		CategoryBaseController ownerNav = null;
		CategoryBaseController ownerNav2 = null;
		public TableSource (List<TableItem> items, UIViewController owner, CategoryBaseController navCon,CategoryBaseController navCon2)
		{
			tableItems = items;
			this.owner = owner;
			this.ownerNav = navCon;
			this.ownerNav2 = navCon2;
		}
		public TableSource (List<TableItem> items, UIViewController owner)
		{
			tableItems = items;
			this.owner = owner;
		}
		public TableSource ()
		{
			
		}
		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Count;
		}
		public string GetItem(int index){
			return tableItems [index].Heading;
		}
		/// <summary>
		/// Called when a row is touched
		/// </summary>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
//			UIAlertController okAlertController = UIAlertController.Create ("Row Selected", tableItems[indexPath.Row].Heading, UIAlertControllerStyle.Alert);
//			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
//			owner.PresentViewController (okAlertController, true, null);
//			tableView.DeselectRow (indexPath, true);
			if (indexPath.Row == 0) {
 
				//ownerNav2.CategoryId  = tableItems[indexPath.Row].Heading;
				owner.ParentViewController.NavigationController.PushViewController(ownerNav2,true);
				ownerNav2.PushData();
			} else {
				//ownerNav.ParentCategoryId   =  tableItems[indexPath.Row];
				owner.ParentViewController.NavigationController.PushViewController(ownerNav,true);
				ownerNav.PushData();
			}
		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// TODO: UNCOMMENT one of these to use that style
		    var cellStyle = UITableViewCellStyle.Default;
	        //var cellStyle = UITableViewCellStyle.Subtitle;
		    //var cellStyle = UITableViewCellStyle.Value1;
			//var cellStyle = UITableViewCellStyle.Value2;

			// if there are no cells to reuse, create a new one

			if (cell == null) {
				cell = new UITableViewCell (cellStyle, cellIdentifier);
			}
			cell.TextLabel.Text = tableItems[indexPath.Row].Heading;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			cell.ImageView.Image= UIImage.FromFile ("Images/" +tableItems[indexPath.Row].ImageName);
			// Default style doesn't support Subtitle
//			if (cellStyle == UITableViewCellStyle.Subtitle 
//			   || cellStyle == UITableViewCellStyle.Value1
//			   || cellStyle == UITableViewCellStyle.Value2) {
//				cell.DetailTextLabel.Text = tableItems[indexPath.Row].SubHeading;
//			}
			// Value2 style doesn't support an image
			if (cellStyle != UITableViewCellStyle.Value2)
				cell.ImageView.Image = UIImage.FromFile ("Images/" +tableItems[indexPath.Row].ImageName);
			//FitpulseTheme.Apply (cell);

			return cell;
		}
	}
}