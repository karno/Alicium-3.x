using System;
using Twitterizer;
using System.Collections.Generic;

namespace Grimoire
{
	public class Account
	{
		public static List<Account> All = new List<Account>();
		string token;
		public Uri BuildAuthUri()
		{
			var res = OAuthUtility.GetRequestToken(Alicium.Consumer_Key,Alicium.Consumer_Secret,"oob");
			token = res.Token;
			return OAuthUtility.BuildAuthorizationUri(token);
		}
		public Account GetAccessToken(string pin)
		{
			var res = OAuthUtility.GetAccessToken(Alicium.Consumer_Key,Alicium.Consumer_Secret,token,pin);
			
		}
	}
}