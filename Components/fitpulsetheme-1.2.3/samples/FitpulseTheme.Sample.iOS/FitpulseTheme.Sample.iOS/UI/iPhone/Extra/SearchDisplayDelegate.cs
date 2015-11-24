using System;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.UIKit;

using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif


namespace ThemeSample.UI.iPhone {
	public class SearchDisplayDelegate : UISearchDisplayDelegate 
	{
		public override bool ShouldReloadForSearchScope(UISearchDisplayController controller, nint forSearchOption)
		{
			((SearchSource)controller.SearchResultsSource).Filter(controller.SearchBar.Text,(int)forSearchOption);

			return true;
		}

		public override bool ShouldReloadForSearchString (UISearchDisplayController controller, string searchString)
		{
			((SearchSource)controller.SearchResultsSource).Filter (searchString, (int)controller.SearchBar.SelectedScopeButtonIndex);

			return true;
		}
	}
}

