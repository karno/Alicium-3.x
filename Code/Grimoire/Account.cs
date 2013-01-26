using System;
using Twitterizer;
using System.Collections.Generic;

namespace Grimoire
{
	public class Account
	{
		public static List<Account> All = new List<Account>();
		static string token;
		public static Uri BuildAuthUri()
		{
			var res = OAuthUtility.GetRequestToken(Alicium.Consumer_Key,Alicium.Consumer_Secret,"oob");
			token = res.Token;
			return OAuthUtility.BuildAuthorizationUri(token);
		}
		public static Account GetAccessToken(string pin)
		{
			var res = OAuthUtility.GetAccessToken(Alicium.Consumer_Key,Alicium.Consumer_Secret,token,pin);
			return new Account()
			{
				Access_Token = res.Token,
				Access_Secret = res.TokenSecret,
				Token = new OAuthTokens(){
					AccessToken = res.Token,
					AccessTokenSecret = res.TokenSecret,
					ConsumerKey = Alicium.Consumer_Key,
					ConsumerSecret = Alicium.Consumer_Secret
				},
				Screen_Name = TwitterAccount.VerifyCredentials(new OAuthTokens(){
					AccessToken = res.Token,
					AccessTokenSecret = res.TokenSecret,
					ConsumerKey = Alicium.Consumer_Key,
					ConsumerSecret = Alicium.Consumer_Secret
				}).ResponseObject.ScreenName
			};
		}
		public static Account New(string ScreenName,string AccessToken,string AccessSecret)
		{
			return new Account()
			{
				Screen_Name = ScreenName,
				Access_Token = AccessToken,
				Access_Secret = AccessSecret,
				Token = new OAuthTokens(){
					AccessToken = AccessToken,
					AccessTokenSecret = AccessSecret,
					ConsumerKey = Alicium.Consumer_Key,
					ConsumerSecret = Alicium.Consumer_Secret
				}
			};
		}
		public OAuthTokens Token;
		public string Screen_Name,Access_Token,Access_Secret;
	}
}