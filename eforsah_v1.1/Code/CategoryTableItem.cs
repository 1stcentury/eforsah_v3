using System;
using UIKit;

namespace eforsah_v1 {
	public class CategoryTableItem : TableItem {
 
		public int CategoryId {
			get;
			set;
		}
		public bool HasChilds {
			get;
			set;
		} 

		//protected UITableViewCellAccessory cellAccessory = UITableViewCellAccessory.None;

		public CategoryTableItem () { }
		
		public CategoryTableItem (string heading)
		{ Heading = heading; }
	}
}