using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
namespace eforsah_v1
{
	partial class ClassifiedsViewController : CategoryBaseController
	{
		//		public override int CategoryId {
		//			get ;
		//			set ;
		//		}
		public ClassifiedsViewController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad (); 
			PushData ();
		}
		/// <summary>
		/// Pushs the data.
		/// </summary>
		/// <param name="value">Value.</param>
		public override void PushData ()
		{
			base.LoadView ();
			List<TableItem> tblitems ;
			tblitems = new List<TableItem> {
				new TableItem(){Heading="head head",SubHeading="sub",ImageName= "no-image.jpg" },
				new TableItem(){Heading="head",SubHeading="sub",ImageName = "no-image.jpg"},
				new TableItem(){Heading="head",SubHeading="sub",ImageName="no-image.jpg"},
			};
			tblClassifieds.Source = new SubCatSource (tblitems,this);
			//lblCategoryName.Text = this.CategoryName;
		}
	}
}
