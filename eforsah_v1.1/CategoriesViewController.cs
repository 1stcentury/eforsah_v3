using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Xamarin.Themes;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using MobileModels;
using CoreGraphics;
namespace eforsah_v1
{
	public partial class CategoriesViewController : CategoryBaseController
	{
		LoadingOverlay loadingOverlay;
		List<CategoryTableItem> tableItems;
		List<Mob_Category> categories = new List<Mob_Category> ();
		public CategoriesViewController (IntPtr handle) : base (handle)
		{
		}
		/// <summary>
		/// Views the did load.
		/// </summary>
		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			#region Animated overlay loader
			// Determine the correct size to start the overlay (depending on device orientation)
			var bounds = UIScreen.MainScreen.Bounds; // portrait bounds
			if (UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeLeft || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeRight) {
				bounds.Size = new CGSize(bounds.Size.Height, bounds.Size.Width);
			}
			// show the loading overlay on the UI thread using the correct orientation sizing
			loadingOverlay = new LoadingOverlay (bounds);
			this.View.Add(loadingOverlay);
			#endregion
			await PopulateCategory ();
			base.ViewWillAppear (false);
			FitpulseTheme.Apply (tableCategory);
		}
		/// <summary>
		/// Populates the category.
		/// </summary>
		/// <returns>The category.</returns>
		public override async Task<bool> PopulateCategory() {
			RestService rest = new RestService ();
			var result = await rest.GetDataAsync(rest.MobileRestURL, "Category");
			if (!string.IsNullOrEmpty (result)) {
				categories = JsonConvert.DeserializeObject <List<Mob_Category>>(result);
			}
			tableItems = new List<CategoryTableItem> ();

			for(int i=0; i < categories.Count ; i++)
			{
				tableItems.Add (new CategoryTableItem (){ Heading = categories[i].NameAr, ImageName= "bell70.png", HasChilds = categories[i].HasChilds, CategoryId = categories[i].CategoryId });
			}
			var classifiedControlle = (ClassifiedsViewController)Storyboard.InstantiateViewController("ClassifiedsViewController");
			var subcategoryController = (SubCatViewController)Storyboard.InstantiateViewController("SubCatViewController");
			if (classifiedControlle != null) {
				tableCategory.Source = new CategoryTableSource(tableItems,this,classifiedControlle,subcategoryController);
			}
			//Hide loading overlay loader
			loadingOverlay.Hide();
			return categories.Count > 0;
		}
		/// <summary>
		/// Prepares for segue.
		/// </summary>
		/// <param name="segue">Segue.</param>
		/// <param name="sender">Sender.</param>
//		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
//		{
//			if (segue.Identifier == "TaskSegue") { // set in Storyboard
// 
//				var navctlr = segue.DestinationViewController as SubCategoryViewController;
//				if (navctlr != null) {
//					var source = tableCategory.Source as TableSource;
//					var rowPath = tableCategory.IndexPathForSelectedRow;
//					//var item = source.GetItem(rowPath.Row);
//					//navctlr.SetTask (this, item); // to be defined on the TaskDetailViewController
//				}
//			}
//		}
		/// <summary>
		/// Views the will appear.
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			//tableCategory.Source = new TableSource(tableItems.ToArray ());
		}
	}
}
