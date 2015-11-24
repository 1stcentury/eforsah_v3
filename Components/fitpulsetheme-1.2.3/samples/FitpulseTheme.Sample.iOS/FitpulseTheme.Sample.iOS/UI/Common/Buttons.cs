using System;
using Xamarin.Themes;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace ThemeSample.UI.Common {
	public static class Buttons {
		public static UIButton ProfileButton (string title, string imagePath)
		{
			var image = UIImage.FromFile (imagePath);

			var button = UIButton.FromType (UIButtonType.Custom);
			
			button.SetTitle (title, UIControlState.Normal);
			button.SetTitleColor (FitpulseTheme.SharedTheme.SecondaryColor, UIControlState.Normal);
			button.SetTitleShadowColor (UIColor.White, UIControlState.Normal);
			
			button.SetTitleColor (UIColor.White, UIControlState.Highlighted);
			button.SetTitleShadowColor (FitpulseTheme.SharedTheme.ShadowColor, UIControlState.Highlighted);
			
			button.SetImage (image, UIControlState.Normal);
			
			button.Font = UIFont.SystemFontOfSize (12);			
			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button.AdjustsImageWhenHighlighted = true;			

			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			button.ImageEdgeInsets = new UIEdgeInsets (0, 9, 4, 0);
			button.TitleEdgeInsets = new UIEdgeInsets (0, 19, 4, 0);

			return button;
		}

		public static UIButton ElementsButton (string title, UIImage image)
		{
			var button = UIButton.FromType (UIButtonType.Custom);
			
			button.SetTitle (title, UIControlState.Normal);
			button.SetTitleColor (FitpulseTheme.SharedTheme.MainColor, UIControlState.Normal);
			button.SetTitleShadowColor (UIColor.White, UIControlState.Normal);
			
			button.SetTitleColor (UIColor.White, UIControlState.Highlighted);
			button.SetTitleShadowColor (FitpulseTheme.SharedTheme.ShadowColor, UIControlState.Highlighted);

			button.SetBackgroundImage (image, UIControlState.Normal);

			button.Font = UIFont.BoldSystemFontOfSize (17);			
			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button.AdjustsImageWhenHighlighted = true;

			button.TitleShadowOffset = new CGSize (0, 1);
			
			return button;
		}
	}
}

