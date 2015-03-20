using System;


using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

using KinveyXamarin;

namespace kinsurance
{
	partial class CustomerDetailsViewController : UIViewController
	{
		public CustomerEntity customer { get; set; }

		public CustomerDetailsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.txtFullname.Text = customer.getFullName ();
			this.txtEmail.Text = customer.email;
			this.txtMobile.Text = customer.mobile;
			this.imgPhoneIcon.Image = UIImage.FromBundle ("Phone-50");
			this.imgEmailIcon.Image = UIImage.FromBundle ("Message-50");
		}
			
		partial void btnPolicies_TouchUpInside (UIButton sender)
		{
		
			/**
			List<PolicyEntity> policyList = new List<PolicyEntity>();
			KinveyService.getPolicies (customer.ID, new KinveyDelegate<PolicyEntity[]> {
				// get policies success
				onSuccess = (policies) => {
					Console.WriteLine ("Retrieved policies from backend...");
					for (int i = 0; i < policies.Length; i++) {
						policyList.Add (policies [i]);
					}

					try {
						InvokeOnMainThread(() => {
							PolicyListController policyListController = this.Storyboard.InstantiateViewController("PolicyListController") as PolicyListController;
							if (policyListController != null) {
								policyListController.customer = customer;
								policyListController.policyList = policyList;
								this.NavigationController.PushViewController (policyListController, true);

							}
						});
					} catch (Exception e) {
						Console.WriteLine("Error changing views..." + e.Message);
					}

				},
				// get customer error
				onError = (error) => Console.WriteLine ("Error in getting policies from backend - " + error.Message)
			});
			**/
			try {
				InvokeOnMainThread(() => {
					PolicyListController policyListController = this.Storyboard.InstantiateViewController("PolicyListController") as PolicyListController;
					if (policyListController != null) {
						policyListController.customer = customer;
						this.NavigationController.PushViewController (policyListController, true);

					}
				});
			} catch (Exception e) {
				Console.WriteLine("Error changing views..." + e.Message);
			}

		}
	}
}
