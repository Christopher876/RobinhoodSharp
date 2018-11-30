using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Web;

namespace Robinhood
{

	class Parameters
	{
		private Dictionary<string, string> withAuthentication;

		public Dictionary<string, string> WithAuthentication
		{
			get
			{
				return withAuthentication = new Dictionary<string, string>();
			}
		}
	}

	class RHttpClient
	{
		//POST Request
		public static string RHttpClientPost(Dictionary<string,string>parameters, string url)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://api.robinhood.com");
			var toPost = new FormUrlEncodedContent(parameters);
			return client.PostAsync(url, toPost).Result.Content.ReadAsStringAsync().Result;
		}

		//Get Request with no parameters
		public static string RHttpClientGet(string url)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://api.robinhood.com");
			return client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
		}

		//GET Request with parameters
		public static string RHttpClientGetParams(string url,Dictionary<string,string>parameters)
		{
			HttpClient client = new HttpClient();
			var query = HttpUtility.ParseQueryString(string.Empty);
			foreach(var item in parameters)
			{
				query[item.Key] = item.Value;
			}

			UriBuilder builder = new UriBuilder("https://api.robinhood.com" + url)
			{
				Port = -1,
				Query = query.ToString()
			};

			return client.GetAsync(builder.ToString()).Result.Content.ReadAsStringAsync().Result; ;
		}

		//Get Request with Headers for authentication
		public static string RHttpClientGetWithAuthenticationHeader(string url,string accessToken)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri ("https://api.robinhood.com");
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
			return client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
		}
	}
}
