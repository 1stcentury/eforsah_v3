using System;

namespace ThemeSample.Model {
	public class Workout {
		public string Title { get; set; }
		public string IconFile { get; set; }
		public string Calls { get; private set; }
		public string Duration { get; private set; }
		public string Exercises { get; private set; }
		public string Sets { get; private set; }		
		
		public Workout (string title, string icontTitle)
		{
			Title = title;
			IconFile = icontTitle;

			Calls = "400";
			Duration = "90 min";
			Exercises = "6";
			Sets = "24";
		}
	}
}

