using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using KinveyXamarin;
using System.Collections.Generic;

namespace kinsurance
{
	partial class AddPolicyViewController : UITableViewController
	{
		public CustomerEntity customer { get; set; }
		public AddPolicyViewController (IntPtr handle) : base (handle)
		{
			Console.WriteLine ("In the Add Policy View Screen");
			try {
				// done button
				UIBarButtonItem doneBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, EventArgs) => {});
				doneBarButtonItem.Clicked += (object sender, EventArgs e) => savePolicy ();
				NavigationItem.SetRightBarButtonItem(doneBarButtonItem, true);
			} catch (Exception e) {
				Console.WriteLine ("Error in Add Policy Screen: " + e.Message);
			}
		}


		// Save Policy
		private void savePolicy() {

			// construct the policyEntity with new data
			PolicyEntity policyEntity = new PolicyEntity();
			policyEntity.customerid = customer.ID;
			policyEntity.policytype = txtPolicyType.Text;
			policyEntity.startdate = txtStartDate.Text;
			policyEntity.enddate = txtEndDate.Text;
			policyEntity.monthlypremium = txtMonthlyPayment.Text;
			policyEntity.deductible = txtDeductible.Text;
			policyEntity.yearlybenefitlimit = txtYearlyPayoutLimit.Text;

			InvokeOnMainThread (() => {

				KinveyService.savePolicy (policyEntity, new KinveyDelegate<PolicyEntity> {
					onSuccess = (savedPolicyEntity) => {
						Console.WriteLine ("Saved new policy to backend... New Policy ID: " + savedPolicyEntity.ID);


						InvokeOnMainThread(() => { 

							//((PolicyListController)ParentViewController).customer = customer;
							NavigationController.PopViewControllerAnimated(true);
							//DismissViewController (true, null); 
						});

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
					},
					onError = (error) => Console.WriteLine ("Error in saving policy to backend - " + error.Message)
				});

			});

		}
	}
}
