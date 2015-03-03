using System;
using KinveyXamarin;

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
				kinveyClient = new Client.Builder(appKey, appSecret)
					.setLogger(delegate(string msg) { Console.WriteLine(msg);})
					.build();
			}
			return kinveyClient;
		}

		// login as a user
		public static void login(string username, string password, KinveyDelegate<User> delegates) {
			getClient ().User ().Login (username, password, delegates);
		}

		// get customers
		public static void getCustomers(KinveyDelegate<CustomerEntity[]> customers) {
			AsyncAppData<CustomerEntity> appData = getClient().AppData<CustomerEntity> (customer_collection, typeof(CustomerEntity));
			appData.Get (customers);
		}

		public KinveyService ()
		{
		}
	}
}

