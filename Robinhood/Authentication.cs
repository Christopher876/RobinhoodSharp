using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Robinhood
{
	public class Authentication
	{
		public string CheckRefreshToken(Login login)
		{
			//If expired, we are gonna use refresh token to get a new access token
			if(DateTimeOffset.Now.ToUnixTimeSeconds() > login.TokenExpired)
			{
				using(HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://api.robinhood.com/");
					var parameters = new Dictionary<string, string>
					{
						{"grant_type","refresh_token"},
						{"client_id","c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS"},
						{"refresh_token",login.refreshToken}
					};
					var toPost = new FormUrlEncodedContent(parameters);
					var content = client.PostAsync("oauth2/token/", toPost).Result.Content.ReadAsStringAsync().Result;
					login.AccessToken = JsonParse.ParseAccessToken(content);
					login.refreshToken = JsonParse.ParseRefreshToken(content);
				}
				SaveAccessTokenAndTimeStamp(login.AccessToken, login.refreshToken);
				return "New Token Aquired";
			}
			return "Token not expired";
		}

		public string ReadAccessToken(Login login)
		{
			string accessToken = string.Empty;
			using(StreamReader reader = new StreamReader("access.txt"))
			{
				var allLines = reader.ReadToEnd().Split();
				login.AccessToken = allLines[1];
				login.refreshToken = allLines[4];
				login.TokenReceived = Convert.ToInt32(allLines[7]);
				login.TokenExpired = Convert.ToInt32(allLines[10]);
			}
			return accessToken;
		}

		public string AuthenticateUser(Login login,bool mfa)
		{
			string accessToken = string.Empty;
			using (HttpClient client = new HttpClient()) {
				client.BaseAddress = new Uri("https://api.robinhood.com/");
				var parameters = new Dictionary<string, string>
				{
				{"grant_type","password"},
				{"client_id", "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS"},
				{"username",login.username},
				{"password", login.password}
				};
				var toPost = new FormUrlEncodedContent(parameters);
				var response = client.PostAsync("oauth2/token/", toPost).Result;
				var content = response.Content.ReadAsStringAsync().Result;
				if (!mfa)
				{
					accessToken = JsonParse.ParseAccessToken(content);
					login.refreshToken = JsonParse.ParseRefreshToken(content);
					SaveAccessTokenAndTimeStamp(accessToken, login.refreshToken);
				}
			}
			return accessToken;
		}

		public string AuthenticateUserMfa(Login login, string mfaCode)
		{
			string accessToken = string.Empty;

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://api.robinhood.com/");
				var parameters = new Dictionary<string, string>
					{
						{"grant_type","password"},
						{"client_id", "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS"},
						{"username",login.username},
						{"password", login.password},
						{"mfa_code",mfaCode}
					};
				var toPost = new FormUrlEncodedContent(parameters);
				var response = client.PostAsync("oauth2/token/", toPost).Result;
				var content = response.Content.ReadAsStringAsync().Result;
				accessToken = JsonParse.ParseAccessToken(content);
				login.refreshToken = JsonParse.ParseRefreshToken(content);
				SaveAccessTokenAndTimeStamp(accessToken, login.refreshToken);
			}
			return accessToken;
		}

		private void SaveAccessTokenAndTimeStamp(string accessToken,string refreshToken)
		{
			using(StreamWriter writer = new StreamWriter("access.txt"))
			{
				writer.WriteLine("Token= " + accessToken);
				writer.WriteLine("Refresh_Token= " + refreshToken);
				writer.WriteLine("Received= " + DateTimeOffset.Now.ToUnixTimeSeconds());
				writer.WriteLine("Expires= " + (DateTimeOffset.Now.ToUnixTimeSeconds() + 86400));
				writer.Flush();
			}
		}

		public string LogoutUser()
		{
			return "nothing";
		}
	}
}
