using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

using KinveyXamarin;

namespace kinsurance
{
	public partial class kinsuranceViewController : UIViewController
	{

		public List<CustomerEntity> customerList { get; set; }

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public kinsuranceViewController (IntPtr handle) : base (handle)
		{
			customerList = new List<CustomerEntity> ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}


		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			// set the View Controller that’s powering the screen we’re
			// transitioning to

			var CustomerListContoller = segue.DestinationViewController as CustomerListController;

			//set the Table View Controller’s list of customers to the
			// list of customers we obtained from Kinvey

			if (CustomerListContoller != null) {
				CustomerListContoller.customerList = customerList;
			}
		}


		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}



		partial void btnLogin_TouchUpInside (UIButton sender)
		{
			string username = txtUsername.Text;
			string password = txtPassword.Text;
			txtUsername.ResignFirstResponder();
			txtPassword.ResignFirstResponder();

			KinveyService.login(username, password, new KinveyDelegate<User> {
				onSuccess = (user) => KinveyService.getCustomers (new KinveyDelegate<CustomerEntity[]> {
					onSuccess = (customers) => {
						for (int i=0; i<customers.Length; i++) {
							customerList.Add(customers[i]);
							Console.WriteLine ("Customer " + i + ": " + customers[i].firstname);
						}
					},
					onError = (error) => Console.WriteLine (error.Message)
				}),
				onError = (error) => {
					var av = new UIAlertView("Error", error.Message, null, "OK", null);
					av.Show();
				}
			});
		}
		#endregion
	}
}

