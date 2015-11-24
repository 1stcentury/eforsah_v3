
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ThemeSample
{
	public class SearchCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("SearchCell");
		
		public SearchCell () : base (UITableViewCellStyle.Value1, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = "TextLabel";
		}
	}
}

