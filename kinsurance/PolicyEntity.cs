using System;
using KinveyXamarin;
using System.Collections.Generic;
using Newtonsoft.Json;
using MonoTouch.UIKit;

namespace kinsurance
{
	[JsonObject(MemberSerialization.OptIn)]
	public class PolicyEntity
	{
		public PolicyEntity ()
		{
		}

		[JsonProperty("_id")]
		public string ID;

		[JsonProperty("_kmd")]
		public KinveyMetaData kmd;

		[JsonProperty(AccessControlList.JSON_FIELD_NAME)]
		public AccessControlList acl;

		[JsonProperty("customerid")]
		public string customerid;

		[JsonProperty("type")]
		public string policytype;

		[JsonProperty("startdate")]
		public string startdate;

		[JsonProperty("enddate")]
		public string enddate;

		[JsonProperty("monthlypremium")]
		public string monthlypremium;

		[JsonProperty("deductible")]
		public string deductible;

		[JsonProperty("yearlybenefitlimit")]
		public string yearlybenefitlimit;

		public UIImage getPolicyTypeImage() {
			switch (policytype) {
			case "home":
				return UIImage.FromBundle ("home63");
			case "auto": 	
				return UIImage.FromBundle ("auto4");
			case "umbrella":
				return UIImage.FromBundle ("rain54");
			case "life":
				return UIImage.FromBundle ("familiar17");
			default:
				return UIImage.FromBundle ("shield84");
			}	
		}
	}
}

