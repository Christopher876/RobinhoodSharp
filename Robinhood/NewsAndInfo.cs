using System;
using System.Collections.Generic;
using System.Text;

namespace Robinhood
{
	public class Movers
	{
		public string instrumentUrl;
		public string symbol;
		public string updatedAt;
		public float marketHoursLastMovementPct;
		public float marketHoursLastPrice;
		public string description;
	}

	public class NewsAndInfo
	{
		public Movers[] GetMoversUp()
		{
			Dictionary<string, string> movers = new Dictionary<string, string>
			{
				{"direction","up" }
			};
			return JsonParse.ParseMovers(RHttpClient.RHttpClientGetParams("/midlands/movers/sp500/",movers));
		}

		public Movers[] GetMoversDown()
		{
			Dictionary<string, string> movers = new Dictionary<string, string>
			{
				{"direction","down" }
			};
			return JsonParse.ParseMovers(RHttpClient.RHttpClientGetParams("/midlands/movers/sp500/",movers));
		}

	}
}
