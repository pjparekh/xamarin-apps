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
	[Register ("AddPolicyViewController")]
	partial class AddPolicyViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtDeductible { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtEndDate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtMonthlyPayment { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtPolicyType { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtStartDate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtYearlyPayoutLimit { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (txtDeductible != null) {
				txtDeductible.Dispose ();
				txtDeductible = null;
			}
			if (txtEndDate != null) {
				txtEndDate.Dispose ();
				txtEndDate = null;
			}
			if (txtMonthlyPayment != null) {
				txtMonthlyPayment.Dispose ();
				txtMonthlyPayment = null;
			}
			if (txtPolicyType != null) {
				txtPolicyType.Dispose ();
				txtPolicyType = null;
			}
			if (txtStartDate != null) {
				txtStartDate.Dispose ();
				txtStartDate = null;
			}
			if (txtYearlyPayoutLimit != null) {
				txtYearlyPayoutLimit.Dispose ();
				txtYearlyPayoutLimit = null;
			}
		}
	}
}
