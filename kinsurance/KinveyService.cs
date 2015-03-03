using System;
using KinveyXamarin;
using System.Collections.Generic;

namespace kinsurance
{
	public class KinveyService
	{

		private static Client kinveyClient;

		private const string appKey = "kid_ZyXRon4-h";
		private const string appSecret = "83534279191047f9bcb0e95ce2272954";
		private const string customer_collection = "customers";

		// get an instance of the Kinvey client
		public static Client getClient(){
			if (kinveyClient == null){
				kinveyClient = new Client.Builder (appKey, appSecret).build ();
				Console.WriteLine ("Got Kinvey Client - Current User is: " + kinveyClient.CurrentUser);
			}
			return kinveyClient;
		}

		// login as a user
		public static void login(string username, string password, KinveyDelegate<User> delegates) {
			getClient ().User ().Login (username, password, delegates);
			Console.WriteLine ("Used Kinvey Client to login User: " + username);
		}

		// get customers
		private static void getCustomers(KinveyDelegate<CustomerEntity[]> customers) {
			AsyncAppData<CustomerEntity> appData = getClient().AppData<CustomerEntity> (customer_collection, typeof(CustomerEntity));
			appData.Get (customers);
		}

		// get customer list
		public static List<CustomerEntity> getCustomers() {
			List<CustomerEntity> customerList = new List<CustomerEntity> ();
			KinveyService.getCustomers (new KinveyDelegate<CustomerEntity[]> {
				onSuccess = (customers) => {
					Console.WriteLine ("Retrieved customers from backend...");
					for (int i = 0; i < customers.Length; i++) {
						customerList.Add (customers [i]);
						Console.WriteLine ("Customer " + i + ": " + customers [i].getFullName ());
					}
				},
				onError = (error) => Console.WriteLine ("Error in getting customers from backend - " + error.Message)
			});
			return customerList;
		}

		public KinveyService ()
		{
		}
	}
}

