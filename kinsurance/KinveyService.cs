using System;
using KinveyXamarin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kinsurance
{
	public class KinveyService
	{

		private static Client kinveyClient;
		private static AsyncAppData<PolicyEntity> policyAppData;

		private const string appKey = "kid_ZyXRon4-h";
		private const string appSecret = "83534279191047f9bcb0e95ce2272954";
		private const string customer_collection = "customers";
		private const string policy_collection = "policies";

		// get an instance of the Kinvey client
		public static Client getClient(){
			if (kinveyClient == null){
				kinveyClient = new Client.Builder (appKey, appSecret)
					.setLogger (Console.WriteLine).build ();
				Console.WriteLine ("Built a new Kinvey Client...");
			}
			Console.WriteLine ("Returning a Kinvey Client...");
			return kinveyClient;
		}

		// get an instance of the policyAppData
		private static  AsyncAppData<PolicyEntity> getPolicyAppData() {
			if (policyAppData == null) {
				policyAppData = getClient().AppData<PolicyEntity> (policy_collection, typeof(PolicyEntity)); 
				InMemoryCache<PolicyEntity> myCache = new InMemoryCache<PolicyEntity>();
				policyAppData.setCache(myCache, CachePolicy.NETWORK_FIRST);
			}
			return policyAppData;
		}

		// login as a user
		public static void login(string username, string password, KinveyDelegate<User> delegates) {
			logout ();
			Console.WriteLine ("Using Kinvey Client to login User: " + username);
			getClient ().User ().Login (username, password, delegates);

			
		}

		// logout a user
		public static void logout() {
			if (!KinveyService.getClient ().User ().isUserLoggedIn ()) {
				Console.WriteLine ("Logging out user... ID: " + getClient().User().Id + " - Username: " + getClient().User().UserName);
				getClient ().User ().logoutBlocking ();

			}
		}

		// get customers
		public static void getCustomers(KinveyDelegate<CustomerEntity[]> customers) {
			AsyncAppData<CustomerEntity> appData = getClient().AppData<CustomerEntity> (customer_collection, typeof(CustomerEntity));
			appData.Get (customers);
		}
			

		// get policies
		public static void getPolicies(string customerid, KinveyDelegate<PolicyEntity[]> policies) {

			string policyQuery = "{\"customerid\":\"" + customerid + "\"}";
			Console.WriteLine ("policy query " + policyQuery);
			/**
			AsyncAppData<PolicyEntity> appData = getClient().AppData<PolicyEntity> (policy_collection, typeof(PolicyEntity));

			InMemoryCache<PolicyEntity> myCache = new InMemoryCache<PolicyEntity>();
			appData.setCache(myCache, CachePolicy.NETWORK_FIRST);

			appData.Get (policyQuery, policies);
			**/
			getPolicyAppData ().Get (policyQuery, policies);
		}
	
		// add policy
		public static void savePolicy(PolicyEntity policyEntity, KinveyDelegate<PolicyEntity> savedPolicyEntity) {
			try {
				AsyncAppData<PolicyEntity> appData = getClient().AppData<PolicyEntity>(policy_collection, typeof(PolicyEntity));
				appData.Save(policyEntity, savedPolicyEntity);
				Console.WriteLine ("Saved new policy to backend...");
			} catch (Exception e) {
				Console.WriteLine ("Exception saving new policy: " + e.Message);
			}
		}

		public KinveyService ()
		{
		}
	}
}

