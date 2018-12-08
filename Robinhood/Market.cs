using System;
using System.Collections.Generic;
using System.Text;

namespace Robinhood
{
	public class Market
	{
		public string GatherListofMarkets()
		{
			return RHttpClient.RHttpClientGet("/markets/");
		}
		public string GatherMarketInformation(string market)
		{
			return RHttpClient.RHttpClientGet("/markets/" + market + "/");
		}
		public string GatherMarketHours(string market, DateTime date)
		{
			return RHttpClient.RHttpClientGet("/markets/" + market + "/hours/" + date.ToString(@"yyyy-MM-dd") + "/");
		}
	}
}
