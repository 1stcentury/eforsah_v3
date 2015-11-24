using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Themes;
namespace eforsah_v1 {
	public class SubCategoryTableSource : UITableViewSource {
		List<CategoryTableItem> tableItems;
		string cellIdentifier = "taskcell";
		UIViewController owner = null;
		CategoryBaseController ownerNav = null;
		public SubCategoryTableSource (List<CategoryTableItem> items, UIViewController owner, CategoryBaseController navCon)
		{
			tableItems = items;
			this.owner = owner;
			this.ownerNav = navCon;
		}
		public SubCategoryTableSource (List<CategoryTableItem> items, UIViewController owner)
		{
			tableItems = items;
			this.owner = owner;
		}
		public SubCategoryTableSource ()
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
			var x=tableItems[indexPath.Row].CategoryId;
			//ownerNav.CategoryId  = tableItems[indexPath.Row].CategoryId;
			//ownerNav.CategoryName  = tableItems[indexPath.Row].Heading;
			//ownerNav.PushData();
			owner.ParentViewController.NavigationController.PushViewController(ownerNav,false); 
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