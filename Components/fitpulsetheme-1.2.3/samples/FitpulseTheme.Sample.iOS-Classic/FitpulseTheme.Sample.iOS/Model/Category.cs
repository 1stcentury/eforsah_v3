using System;

namespace ThemeSample.Model {
	public class Category {
		public string Title { get; set; }
		public string IconFile { get; set; }

		public Category (string title, string icontTitle)
		{
			Title = title;
			IconFile = icontTitle;
		}
	}
}

