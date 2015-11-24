using System;
using ThemeSample.Model;
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

namespace ThemeSample.UI.iPhone {
	public class ProfileCategoryDetailController : UIViewController {
		public UILabel TitleLabel { get; private set;}
		public UITextView DescriptionText { get; private set;}		
		public UIImageView Icon { get; private set; }
		public UIImageView IconFrame { get; private set; }	

		public ProfileCategoryDetailController (CGRect frame)
		{
			View.Frame = frame;

			InitSubviews();
			ApplyStyles();
		}

		void InitSubviews() 
		{
			TitleLabel = new UILabel (new CGRect (74, 7, 226, 22)) {
				Font = UIFont.FromName ("HelveticaNeue-Bold", 16),
				TextColor = FitpulseTheme.SharedTheme.MainColor,
				BackgroundColor = UIColor.Clear
			};

			DescriptionText = new UITextView(new CGRect (70, 30, 226, View.Frame.Height * 0.85f)) { 
				BackgroundColor = UIColor.Clear,
				Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam condimentum facilisis risus, ut convallis lectus vestibulum sit amet. Aliquam erat volutpat. Quisque magna est, tristique id consequat eu, rutrum vel velit. Integer semper pretium hendrerit. Fusce a lacus lorem, eget sagittis eros. Pellentesque volutpat mauris at risus cursus faucibus. In aliquet varius diam, ac tincidunt felis imperdiet ut. Nulla sed dui metus, a varius metus. Maecenas lorem velit, hendrerit et sollicitudin ac, ullamcorper ut purus. Donec id lacus tortor, in convallis libero. Ut interdum purus egestas eros pharetra scelerisque. Aenean semper varius rutrum. Nullam semper nulla gravida enim dapibus volutpat. Maecenas dignissim ipsum et eros tincidunt congue sit amet egestas est. Nunc eleifend adipiscing mattis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
				TextColor = FitpulseTheme.SharedTheme.SecondaryColor,
				Font = UIFont.FromName ("HelveticaNeue", 12)				
			};

			IconFrame = new UIImageView (new CGRect (12, 9, 54, 54)) {
				Image = UIImage.FromFile ("list-item-frame.png")
			};		

			Icon = new UIImageView (new CGRect (13, 10, 52, 52));
									
			View.AddSubviews (Icon, IconFrame, TitleLabel, DescriptionText);
		}

		void ApplyStyles() 
		{
			View.BackgroundColor = UIColor.FromPatternImage(FitpulseTheme.SharedTheme.ViewBackground);
		}

		public void BindTo (Category category)
		{
			if (category == null) 
				return;
			TitleLabel.Text = category.Title;
			Title = category.Title;

			Icon.Image = UIImage.FromFile (category.IconFile);
		}
	}
}

