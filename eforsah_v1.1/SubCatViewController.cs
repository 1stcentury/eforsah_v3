using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Themes;
using System.Threading.Tasks;
 
using Newtonsoft.Json;
using MobileModels;
using CoreGraphics;

namespace eforsah_v1
{
	public	partial class SubCatViewController : CategoryBaseController
	{
		LoadingOverlay loadingOverlay;
		List<CategoryTableItem> tableItems;
		List<Mob_Category> categories = new List<Mob_Category> ();

		public SubCatViewController (IntPtr handle) : base (handle)
		{
		}
		public override int CategoryId {
			get ;
			set ;
		}
		public override int ParentCategoryId {
			get ;
			set ;
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad (); 
		}
		/// <summary>
		/// Pushs the data.
		/// </summary>
		/// <param name="value">Value.</param>
		public override void PushData ()
		{
			 base.LoadView ();
			 lblParentCatName.Text = this.CategoryName;
		}
		/// <summary>
		/// Populates the category.
		/// </summary>
		/// <returns>The category.</returns>
		public override async Task<bool> PopulateCategory ()
		{
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
			RestService rest = new RestService ();
			var result = await rest.GetDataAsync(rest.MobileRestURL, "Category/"+this.ParentCategoryId+"");
			if (!string.IsNullOrEmpty (result)) {
				categories = JsonConvert.DeserializeObject <List<Mob_Category>>(result);
			}
			tableItems = new List<CategoryTableItem> ();

			for(int i=0; i < categories.Count ; i++)
			{
				tableItems.Add (new CategoryTableItem (){ Heading = categories[i].NameAr, ImageName= "bell70.png", HasChilds = categories[i].HasChilds, CategoryId = categories[i].CategoryId });
			}
			var classifiedControlle = this.Storyboard.InstantiateViewController("ClassifiedsViewController") as ClassifiedsViewController;
			if (classifiedControlle != null) {
				tblSubCat.Source = new SubCategoryTableSource(tableItems, this ,classifiedControlle);
			}
			//base.LoadView ();
			FitpulseTheme.Apply (tblSubCat);
			//Hide loading overlay loader
			loadingOverlay.Hide();
			return categories.Count > 0;
		}
 
	}
}
