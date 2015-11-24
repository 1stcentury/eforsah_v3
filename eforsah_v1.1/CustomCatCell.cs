using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;

namespace eforsah_v1
{
	public class CustomCatCell:UITableViewCell
	{


		public CustomCatCell (IntPtr handle) : base (handle)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
		}



		public void UpdateCell (string name, string image)
		{
			//img_profile.Image = UIImage.FromFile ("Images/" +image);
			//lbl_name.Text = name;
		
		}
	}
}

