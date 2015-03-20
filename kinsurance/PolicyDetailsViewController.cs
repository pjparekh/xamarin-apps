using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace kinsurance
{
	partial class PolicyDetailsViewController : UIViewController
	{
		public PolicyEntity policy { get; set; }

		public PolicyDetailsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			imgPolicyType.Image = policy.getPolicyTypeImage();
			lblStartDate.Text = policy.startdate;
			lblEndDate.Text = policy.enddate;
			lblMonthlyPremium.Text = policy.monthlypremium;
			lblDeductible.Text = policy.deductible;
			lblYearlyBenefitLimit.Text = policy.yearlybenefitlimit;
		}
	}
}
