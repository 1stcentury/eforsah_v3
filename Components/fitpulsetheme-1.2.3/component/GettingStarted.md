## Applying the Theme

To style your app with this theme, call
`FitpulseTheme.Apply` from your AppDelegate's `FinishedLaunching` method:


	using Xamarin.Themes;
	...
	
	public override bool FinishedLaunching (UIApplication app, NSDictionary options)
	{
		...
		FitpulseTheme.Apply();
	}


You can also selectively apply the theme to specific views. To apply the
theme to views of a specific class, call `Apply` with the `Appearance`
value for the class you'd like to theme:


	FitpulseTheme.Apply (UIProgressView.Appearance);


To apply the theme to specific view classes only when they are contained
within other specific view classes, use `AppearanceWhenContainedIn`. In
the following example, we apply `FitpulseTheme` to `UIProgressView` only
when `UIProgressView` is a child of `UINavigationBar`:


	FitpulseTheme.Apply (UIProgressView.AppearanceWhenContainedIn (typeof (UINavigationBar)));

Finally, to apply the theme to a specific view instance:

	UITableView tableView;
	...
	
	FitpulseTheme.Apply (tableView);


When applying a theme to a TableView, you still need to apply the theme to the cells.


	public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
	{
		UITableViewCell cell;
		...
		FitpulseTheme.Apply (cell);
		return cell;
	}


Applying the theme to specific view instances is especially useful for `UIButton`,
`UILabel`, and `UIView`, since these classes are not themed automatically when
calling the parameterless version of `Apply`.

**Navigation Font Size**

As of version 1.2.3 you can explicitly set the font size that is used in the navigation title.  To do this simply send a value to `FitpulseTheme.NavigationFontSize` before you apply the theme.
	
	public override bool FinishedLaunching (UIApplication app, NSDictionary options)
	{
		//ste the naviagtion font size
		FitpulseTheme.NavigationFontSize = 16;
		
		//Now apply the theme
		FitpulseTheme.Apply ();
	}