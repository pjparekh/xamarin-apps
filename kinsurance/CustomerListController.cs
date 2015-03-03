using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace kinsurance
{
	partial class CustomerListController : UITableViewController
	{
		public List<CustomerEntity> customerList { get; set; }
		static NSString customerCellId = new NSString ("customerCell");

		public CustomerListController (IntPtr handle) : base (handle)
		{
			TableView.RegisterClassForCellReuse (typeof(UITableViewCell), customerCellId);
			TableView.Source = new customerDataSource (this);
			//customerList = new List<CustomerEntity> ();
		}
			
		class customerDataSource : UITableViewSource
		{
			CustomerListController controller;

			public customerDataSource (CustomerListController controller)
			{
				this.controller = controller;
			}

			// Returns the number of rows in each section of the table
			public override int RowsInSection (UITableView tableView, int section)
			{
				return controller.customerList.Count;
			}
			//
			// Returns a table cell for the row indicated by row property of the NSIndexPath
			// This method is called multiple times to populate each row of the table.
			// The method automatically uses cells that have scrolled off the screen or creates new ones as necessary.
			//
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (CustomerListController.customerCellId);

				int row = indexPath.Row;
				cell.TextLabel.Text = controller.customerList[row].title + " " + 
					controller.customerList[row].firstname + " " + controller.customerList[row].lastname;
				return cell;
			}
		}


	}
}
