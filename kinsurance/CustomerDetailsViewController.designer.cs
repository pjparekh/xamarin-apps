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
	[Register ("CustomerDetailsViewController")]
	partial class CustomerDetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnClaims { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnPolicies { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgEmailIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgPhoneIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel txtEmail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel txtFullname { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel txtMobile { get; set; }

		[Action ("btnPolicies_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnPolicies_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnClaims != null) {
				btnClaims.Dispose ();
				btnClaims = null;
			}
			if (btnPolicies != null) {
				btnPolicies.Dispose ();
				btnPolicies = null;
			}
			if (imgEmailIcon != null) {
				imgEmailIcon.Dispose ();
				imgEmailIcon = null;
			}
			if (imgPhoneIcon != null) {
				imgPhoneIcon.Dispose ();
				imgPhoneIcon = null;
			}
			if (txtEmail != null) {
				txtEmail.Dispose ();
				txtEmail = null;
			}
			if (txtFullname != null) {
				txtFullname.Dispose ();
				txtFullname = null;
			}
			if (txtMobile != null) {
				txtMobile.Dispose ();
				txtMobile = null;
			}
		}
	}
}
