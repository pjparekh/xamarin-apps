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
			Console.WriteLine (this.GetType ().Name);
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
			btnLogin.Enabled = true;

		}
			

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			btnLogin.Enabled = true;
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
			btnLogin.Enabled = false;
			string username = txtUsername.Text;
			string password = txtPassword.Text;
			txtUsername.ResignFirstResponder();
			txtPassword.ResignFirstResponder();

			if (!KinveyService.getClient ().User ().isUserLoggedIn ()) {
				Console.WriteLine ("Before user login...");
				KinveyService.login (username, password, new KinveyDelegate<User> {
					//login success
					onSuccess = (user) => {

						Console.WriteLine ("Logged in user: " + user.UserName);
						afterLogin();

					},
					//login error
					onError = (error) => {
						Console.WriteLine ("Error logging in user: " + error.Message);
					}
				});
			} else {
				Console.WriteLine ("User " + KinveyService.getClient().User().UserName + " is already logged in...");
				afterLogin();
			}

		}

		private void afterLogin() {
			Console.WriteLine ("Retrieving customers using logged in user: " + KinveyService.getClient ().User().UserName);
			List<CustomerEntity> customerList = new List<CustomerEntity> ();
			KinveyService.getCustomers (new KinveyDelegate<CustomerEntity[]> {
				// get customer success
				onSuccess = (customers) => {
					Console.WriteLine ("Retrieved customers from backend...");
					for (int i = 0; i < customers.Length; i++) {
						customerList.Add (customers [i]);
						Console.WriteLine ("Customer " + i + ": " + customers [i].getFullName ());
					}

					try {
						InvokeOnMainThread(() => {
							CustomerListController customerListController = this.Storyboard.InstantiateViewController("CustomerListController") as CustomerListController;
							if (customerListController != null) {
								customerListController.customerList = customerList;
								this.NavigationController.PushViewController (customerListController, true);

							}
						});
					} catch (Exception e) {
						Console.WriteLine("Error changing views..." + e.Message);
					}

				},
				// get customer error
				onError = (error) => Console.WriteLine ("Error in getting customers from backend - " + error.Message)
			});

		}

		#endregion
	}
}

