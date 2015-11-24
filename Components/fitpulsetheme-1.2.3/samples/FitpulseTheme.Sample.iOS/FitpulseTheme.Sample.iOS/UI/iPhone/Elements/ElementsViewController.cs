using System;
using Xamarin.Controls.iOS.ProgressBar;
using Xamarin.Themes;
using ThemeSample.UI.Common;

#if __UNIFIED__
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.ObjCRuntime;

using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace ThemeSample.UI.iPhone {
	sealed partial class ElementsViewController : UIViewController {
		UIScrollView scrollView;
		UITextField textField;
		UISlider slider;
		PercentageProgressBar progressBar;

		public ElementsViewController ()
		{
			Title = "Elements";

			var barItem = new UIBarButtonItem () {
				Title = "Item",
				Style = UIBarButtonItemStyle.Bordered
			};

			barItem.Clicked += (sender, e) => {
				var alert = new UIAlertView ("Bar button clicked", string.Empty, null, "Close", null);
				alert.Show ();
			};

			NavigationItem.SetRightBarButtonItem (barItem, false);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitSubviews ();
		}

		private void InitSubviews ()
		{
			FitpulseTheme.Apply (View);

			scrollView = new UIScrollView (UIScreen.MainScreen.Bounds);
			Add (scrollView);

			if (UISwitch.Appearance.RespondsToSelector (new Selector ("onImage"))) {
			} else {
				bool showSwitchText = !UIDevice.CurrentDevice.CheckSystemVersion (7, 0);
				var onRect = new CGRect (72, 20, 76, 42);
				var offRect = new CGRect (176, 20, 76, 42);

				if (!showSwitchText) {
				  onRect.X += 20;
				  onRect.Width -= 20;
				  offRect.Width -= 20;
				}

				var onSwitch = new SwitchOnOff (onRect);
				onSwitch.SetOn (true);

				var offSwitch = new SwitchOnOff (offRect);
				offSwitch.SetOn (false);

				onSwitch.ShowText (showSwitchText);
				offSwitch.ShowText (showSwitchText);

				scrollView.AddSubviews (onSwitch, offSwitch);
			}

			progressBar = new PercentageProgressBar (new CGRect (20, 68, 280, 24));
			progressBar.Progress = 0.5f;

			scrollView.Add (progressBar);

			var loadingLabel = new UILabel (new CGRect (118, 91, 84, 19));
			loadingLabel.Text = "Loading...";
			loadingLabel.Font = UIFont.BoldSystemFontOfSize (15);
			loadingLabel.TextColor = UIColor.FromRGB (135, 141, 138);
			loadingLabel.BackgroundColor = UIColor.Clear;
			loadingLabel.TextAlignment = UITextAlignment.Center;

			scrollView.Add (loadingLabel);		

			slider = new UISlider (new CGRect (18, 121, 284, 23));
			slider.MinValue = 0;
			slider.MaxValue = 1;
			slider.Value = 0.5f;
			slider.ValueChanged += (sender, e) => {
				progressBar.Progress = slider.Value; };

			scrollView.Add (slider);	

			var uiSegmentedControl = new UISegmentedControl (new [] {"Yes", "No", "Maybe"}) {
				SelectedSegment = 0
			};

			FitpulseTheme.Apply (uiSegmentedControl);
			uiSegmentedControl.SetWidth (80.0f, 0);
			uiSegmentedControl.SetWidth (80.0f, 1);				
			
			uiSegmentedControl.Frame = new CGRect (26, 161, 268, 44);

			scrollView.Add (uiSegmentedControl);

			textField = new UITextField (new CGRect (20, 221, 280, 31));
			textField.LeftView = new UIView (new CGRect (0, 0, 5, 31));
			textField.LeftViewMode = UITextFieldViewMode.Always;
			textField.Font = UIFont.SystemFontOfSize (14);
			textField.TextColor = UIColor.White;
			textField.Background = UIImage.FromFile ("text-input.png");
			textField.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			textField.Placeholder = "Text";
			FitpulseTheme.Apply (textField);

			textField.Delegate = new TextFieldDelegate ();

			scrollView.Add (textField);

			var leftTopButton = Buttons.ElementsButton ("Button", FitpulseTheme.SharedTheme.GrayButtonImage);
			var rightTopButton = Buttons.ElementsButton ("Button", FitpulseTheme.SharedTheme.GrayPressedButtonImage);

			var leftBottomButton = Buttons.ElementsButton ("Button", FitpulseTheme.SharedTheme.BlueButtonImage);
			var rightBottomButton = Buttons.ElementsButton ("Button", FitpulseTheme.SharedTheme.BluePressedButtonImage);

			leftBottomButton.SetTitleColor (UIColor.White, UIControlState.Normal);
			leftBottomButton.SetTitleColor (UIColor.DarkGray, UIControlState.Highlighted);
			rightBottomButton.SetTitleColor (UIColor.White, UIControlState.Normal);
			rightBottomButton.SetTitleColor (UIColor.DarkGray, UIControlState.Highlighted);

			leftBottomButton.SetTitleShadowColor (UIColor.DarkGray, UIControlState.Normal);
			leftBottomButton.SetTitleShadowColor (UIColor.Gray, UIControlState.Highlighted);
			rightBottomButton.SetTitleShadowColor (UIColor.DarkGray, UIControlState.Normal);
			rightBottomButton.SetTitleShadowColor (UIColor.Gray, UIControlState.Highlighted);

			leftTopButton.Frame = new CGRect (20, 268, 126, 42);
			leftBottomButton.Frame = new CGRect (20, 318, 126, 42);
			rightTopButton.Frame = new CGRect (174, 268, 126, 42);
			rightBottomButton.Frame = new CGRect (174, 318, 126, 42);

			scrollView.AddSubviews (leftTopButton, leftBottomButton, rightTopButton, rightBottomButton);
			
		}

		sealed class TextFieldDelegate : UITextFieldDelegate {
			const float AnimationDuration = 0.3f;
			const float MinScrollFraction = 0.1f;
			const float MaxScrollFraction = 0.9f;
			const float PortraitKeyboardHeight = 216;
			const float LandscapeKeyboardHeight = 140;
			float _animatedDistance;

			public override bool ShouldReturn (UITextField textField)
			{
				textField.ResignFirstResponder ();

				return true;
			}

			public override void EditingStarted (UITextField textField)
			{
				var textFieldRect = textField.Superview.Window.ConvertRectFromView (textField.Frame, textField);
				var viewRect = textField.Superview.Window.ConvertRectFromView (textField.Superview.Bounds, textField.Superview);
				
				var midLine = textFieldRect.Y + 0.5f * textFieldRect.Height;
				var numerator = midLine - viewRect.Y - MinScrollFraction * viewRect.Height;
				var denominator = (MaxScrollFraction - MinScrollFraction) * viewRect.Height;
				var heightFraction = numerator / denominator;
				
				if (heightFraction < 0.0f) 
					heightFraction = 0;
				
				if (heightFraction > 1.0f)
					heightFraction = 1;
				
				var statusBarOrientation = UIApplication.SharedApplication.StatusBarOrientation;
				var portraitOrientation = statusBarOrientation == UIInterfaceOrientation.Portrait || statusBarOrientation == UIInterfaceOrientation.PortraitUpsideDown;
				
				if (portraitOrientation)
					_animatedDistance = (float)Math.Floor (PortraitKeyboardHeight * heightFraction);
				else
					_animatedDistance = (float)Math.Floor (LandscapeKeyboardHeight * heightFraction);
				
				var viewFrame = textField.Superview.Frame;
				viewFrame.Y -= _animatedDistance;
				
				UIView.Animate (AnimationDuration, 0, UIViewAnimationOptions.BeginFromCurrentState, () => {
					textField.Superview.Frame = viewFrame;
				}, null);
			}

			public override void EditingEnded (UITextField textField)
			{
				var viewFrame = textField.Superview.Frame;
				viewFrame.Y += _animatedDistance;
				
				UIView.Animate (AnimationDuration, 0, UIViewAnimationOptions.BeginFromCurrentState, () => {
					textField.Superview.Frame = viewFrame;
				}, null);
			}

			public override bool ShouldBeginEditing (UITextField textField)
			{
				return true;
			}

			public override bool ShouldEndEditing (UITextField textField)
			{
				return true;
			}
		}
	}
}

