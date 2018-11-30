using System;
using System.Net.Http;

namespace Robinhood
{
	class QuoteData
	{
		public float askPrice = 0;
		public int askSize = 0;
		public float bidPrice = 0;
		public int bidSize = 0;
		public float lastTradePrice = 0;
		public float? lastExtendedHoursTradePrice;
		public float previousClose = 0;
		public float adjustedPreviousClose = 0;
		public string previousCloseDate = string.Empty;
		public string symbol = string.Empty;
		public bool tradingHalted = false;
		public bool hasTraded = false;
		public string updatedAt = string.Empty;
	}

	class Quotes
	{ 
		public QuoteData GatherData(string symbol)
		{
			string content = string.Empty;
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(Endpoints.baseurl);
				content = client.GetAsync("/quotes/"+symbol+"/").Result.Content.ReadAsStringAsync().Result;
			}
			return JsonParse.ParseQuote(content);
		}

		public QuoteData[] GatherMultipleData(string[] symbols)
		{
			string[] data = new string[symbols.Length];
			QuoteData[] quoteData = new QuoteData[data.Length];

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(Endpoints.baseurl);

				for(int i = 0; i < symbols.Length; i++)
				{
					data[i] = client.GetAsync("/quotes/" + symbols[i] + "/").Result.Content.ReadAsStringAsync().Result;
				}
			}

			for(int i = 0; i < data.Length; i++)
			{
				quoteData[i] = JsonParse.ParseQuote(data[i]);
			}

			return quoteData;
		}
	}
}
