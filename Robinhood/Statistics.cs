using System;
using System.Collections.Generic;
using System.Text;

namespace Robinhood
{

	class PopularStats
	{

	}

	class Statistics
	{
		public string[] Get100MostPopular()
		{
			return JsonParse.ParsePopular(RHttpClient.RHttpClientGet("/midlands/tags/tag/100-most-popular/"), 100);
		}

		//Is not available on server
		public string[] Get10MostPopular()
		{
			return JsonParse.ParsePopular(RHttpClient.RHttpClientGet("/midlands/tags/tag/10-most-popular/"), 10);
		}
	}
}
