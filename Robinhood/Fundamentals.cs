using System;
using System.Collections.Generic;
using System.Text;

namespace Robinhood
{

	public class FundamentalData
	{
		public float open;
		public float high;
		public float low;
		public float volume;
		public float averageVolume;
		public float high52Weeks;
		public float low52Weeks;
		public float marketCap;
		public float dividendYield;
		public float peRatio;
		public string description;
		public string instrument;
	}

	public class Fundamentals
	{
		public string GatherFundamentalBySymbol(string symbol)
		{
			return RHttpClient.RHttpClientGet("/fundamentals/" + symbol + "/");
		}

		public FundamentalData[] GatherMultipleFundamentalBySymbol(string[] symbols)
		{
			string[] content = new string[symbols.Length];
			FundamentalData[] fundamentalData = new FundamentalData[symbols.Length];
			for(int i = 0; i<symbols.Length;i++)
			{
				content[i] = RHttpClient.RHttpClientGet("/fundamentals/" + symbols[i] + "/");
				fundamentalData[i] = JsonParse.ParseFundament(content[i]);
			}

			return fundamentalData;
		}

	}
}
