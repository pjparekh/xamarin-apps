using System;
using KinveyXamarin;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace kinsurance
{
	[JsonObject(MemberSerialization.OptIn)]
	public class CustomerEntity
	{

		public CustomerEntity ()
		{
		}


		[JsonProperty("_id")]
		public string ID;

		[JsonProperty("_kmd")]
		public KinveyMetaData kmd;

		[JsonProperty(AccessControlList.JSON_FIELD_NAME)]
		public AccessControlList acl;

		[JsonProperty("title")]
		public string title;

		[JsonProperty("firstname")]
		public string firstname;

		[JsonProperty("lastname")]
		public string lastname;

		[JsonProperty("email")]
		public string email;

		[JsonProperty("mobile")]
		public string mobile;

		public string getFullName() {
			return title + " " + firstname + " " + lastname;
		}
	}
}

