using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Themes;
namespace eforsah_v1
{
	public class CategorySource : TableSource
	{

		List<TableItem> tableItems;
		string cellIdentifier = "taskcell";
		UIViewController owner = null;
		CategoryBaseController ownerNav = null;
		CategoryBaseController ownerNav2 = null;

		public CategorySource (List<TableItem> items, UIViewController owner, CategoryBaseController navCon,CategoryBaseController navCon2)
		{
			tableItems = items;
			this.owner = owner;
			this.ownerNav = navCon;
			this.ownerNav2 = navCon2;
		}

		public CategorySource (List<TableItem> items, UIViewController owner)
		{
			tableItems = items;
			this.owner = owner;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Count;
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
				//ownerNav.CategoryId  = tableItems[indexPath.Row].Heading;
				owner.ParentViewController.NavigationController.PushViewController(ownerNav,true);
				ownerNav.PushData();
			}
		}



		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 40;
		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier) as CustomCatCell;

			cell.UpdateCell(tableItems[indexPath.Row].Heading.ToString(),tableItems[indexPath.Row].ImageName );
			return cell;
		}
	}
}

