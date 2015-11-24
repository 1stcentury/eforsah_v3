using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Themes;

namespace eforsah_v1
{
	public	partial class TestViewController : CategoryBaseController
	{
		public TestViewController (IntPtr handle) : base (handle)
		{
		}
		public override string CategoryId {
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
			List<TableItem> tblitems ;
			tblitems = new List<TableItem> {
				new TableItem(){Heading="head head",SubHeading="sub",ImageName="bell70.png"},
				new TableItem(){Heading="head",SubHeading="sub",ImageName="bell70.png"},
				new TableItem(){Heading="head",SubHeading="sub",ImageName="bell70.png"},
				new TableItem(){Heading="head",SubHeading="sub",ImageName="bell70.png"}


			};
			tblSubCat.Source = new CategorySource (tblitems,this);
			lblParentCatName.Text= this.CategoryId;
		}
	}
}
