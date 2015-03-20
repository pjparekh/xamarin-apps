// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace kinsurance
{
	[Register ("PolicyDetailsViewController")]
	partial class PolicyDetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgPolicyType { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblDeductible { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblEndDate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblMonthlyPremium { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblStartDate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblYearlyBenefitLimit { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (imgPolicyType != null) {
				imgPolicyType.Dispose ();
				imgPolicyType = null;
			}
			if (lblDeductible != null) {
				lblDeductible.Dispose ();
				lblDeductible = null;
			}
			if (lblEndDate != null) {
				lblEndDate.Dispose ();
				lblEndDate = null;
			}
			if (lblMonthlyPremium != null) {
				lblMonthlyPremium.Dispose ();
				lblMonthlyPremium = null;
			}
			if (lblStartDate != null) {
				lblStartDate.Dispose ();
				lblStartDate = null;
			}
			if (lblYearlyBenefitLimit != null) {
				lblYearlyBenefitLimit.Dispose ();
				lblYearlyBenefitLimit = null;
			}
		}
	}
}
