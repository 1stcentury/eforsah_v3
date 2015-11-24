
using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace eforsah_v1
{
	public partial class CategoryBaseController : UIViewController
	{
		public virtual string CategoryName {
			get ;
			set ;
		}
		public virtual int CategoryId {
			get ;
			set ;
		}
		public virtual int ParentCategoryId {
			get ;
			set ;
		}
//		public virtual string ParentCategoryName {
//			get ;
//			set ;
//		}
		public CategoryBaseController () : base ("CategoryBaseController", null)
		{
		}
		public CategoryBaseController (IntPtr handle) : base (handle)
		{
		}
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		public virtual void PushData ()
		{
			base.LoadView ();
		}
		/// <summary>
		/// Populates the category.
		/// </summary>
		/// <returns>The category.</returns>
		public virtual async Task<bool> PopulateCategory() {
		return true;
		}
	}
}

