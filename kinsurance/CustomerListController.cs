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
			customerList = new List<CustomerEntity> ();
		}

		// remove the back button
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.NavigationItem.SetHidesBackButton (true, false);

			NavigationItem.SetRightBarButtonItem (
				new UIBarButtonItem ("Logout", UIBarButtonItemStyle.Plain, (sender, args) => logout ()),
				true);
		}

		// logout 
		public void logout() {
			KinveyService.logout ();
			InvokeOnMainThread(() => {
				NavigationController.PopViewControllerAnimated(true);
				//DismissViewController(true, null);
				/**
				NavigationController = (UINavigationController)Storyboard.InstantiateInitialViewController();
				LandingPageController mController = (LandingPageController)NavigationController.TopViewController;
				window.RootViewController = NavigationController;
				kinsuranceViewController kiViewController = this.Storyboard.InstantiateViewController("kinsuranceViewController") as kinsuranceViewController;
				NavigationController.PushViewController (loginViewController, true);
				**/
			});

		}

		// internal class
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
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				int row = indexPath.Row;
				cell.TextLabel.Text = controller.customerList[row].getFullName();
				return cell;
			}



			// Row selected
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				CustomerEntity c = (CustomerEntity)controller.customerList.ToArray () [indexPath.Row];
				try {
					InvokeOnMainThread(() => {
						CustomerDetailsViewController customerDetailsViewController = controller.Storyboard.InstantiateViewController("CustomerDetailsViewController") as CustomerDetailsViewController;
						if (customerDetailsViewController != null) {
							customerDetailsViewController.customer = c;
							controller.NavigationController.PushViewController (customerDetailsViewController, true);

						}
					});
				} catch (Exception e) {
					Console.WriteLine("Error changing views..." + e.Message);
				}
				//new UIAlertView("Row Selected", c.getFullName(), null, "OK", null).Show();
				tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
			}

		}


	}
}
