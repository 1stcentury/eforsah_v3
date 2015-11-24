using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace eforsah_v1
{
	partial class CustomClasifiedCell : UITableViewCell
	{
		public CustomClasifiedCell (IntPtr handle) : base (handle)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
		}
		/// <summary>
		/// Load image Froms the URL.
		/// </summary>
		/// <returns>The URL.</returns>
		/// <param name="uri">URI.</param>
		static UIImage ImageFromUrl (string uri)
		{
			using (var url = new NSUrl (uri))
			using (var data = NSData.FromUrl (url))
				return UIImage.LoadFromData (data);
		}
		public void UpdateCell (string name, string image)
		{
			//img_profile.Image = UIImage.FromFile ("Images/" +image);
			//lbl_name.Text = name;
			//img_profile.Image=UIImage.FromFile ("Images/" +image);
			//img_profile.Image=  ImageFromUrl("https://www.google.com.sa/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png");
			//lbl_name.Text=name;

		}
	}
}
