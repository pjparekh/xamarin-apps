using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

using KinveyXamarin;
using System.Threading.Tasks;

namespace kinsurance
{
	public partial class kinsuranceViewController : UIViewController
	{
	
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public kinsuranceViewController (IntPtr handle) : base (handle)
		{
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
			Console.WriteLine ("Segue to Customer List Screen...");
			base.PrepareForSegue (segue, sender);

			// set the View Controller that’s powering the screen we’re
			// transitioning to

			var CustomerListContoller = segue.DestinationViewController as CustomerListController;

			//set the Table View Controller’s list of customers to the list of customers we obtained from an external service
			if (CustomerListContoller != null) {
				Console.WriteLine ("Retrieving customers from backend...");
				CustomerListContoller.customerList = KinveyService.getCustomers();
				Console.WriteLine ("Set CustomerList variable in Customer List Screen...");
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
				onSuccess = (user) => Console.WriteLine(user.UserName),
				onError = (error) => {
					var av = new UIAlertView("Error", error.Message, null, "OK", null);
					av.Show();
				}
			});
		}
		#endregion
	}
}

