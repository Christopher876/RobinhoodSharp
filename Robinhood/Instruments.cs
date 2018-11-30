using System;
using System.Collections.Generic;
using System.IO;

namespace Robinhood
{
	class InstrumentData
	{
		public float? minTickSize;
		public string splits;
		public float marginInitialRatio;
		public string url;
		public string quote;
		public string symbol;
		public string bloomsbergUnique;
		public string listDate;
		public string fundamental;
		public string state;
		public string country;
		public float dayTradeRatio;
		public bool tradeable;
		public float maintenanceRatio;
		public string id;
		public string market;
		public string name;
		public string simpleName;
		public string next;
	}

	class SplitData
	{
		public string url;
		public string instrument;
		public string executionDate;
		public float divisor;
		public float multiplier;
	}

	class Instruments
	{
		public InstrumentData[] InstrumentsByKeyWord(string keyword)
		{
			var find = new Dictionary<string, string>()
			{
				{"query",keyword}
			};

			return JsonParse.ParseInstrument(RHttpClient.RHttpClientGetParams("/instruments/",find));
		}

		public InstrumentData InstrumentsBySymbol(string symbol)
		{
			var find = new Dictionary<string, string>()
			{
				{"query",symbol}
			};

			return JsonParse.ParseInstrumentBySymbol(RHttpClient.RHttpClientGetParams("/instruments/",find));
		}

		public InstrumentData InstrumentsByID(string id)
		{
			return JsonParse.ParseInstrumentByID(RHttpClient.RHttpClientGet("/instruments/"+id+"/"));
		}

		public InstrumentData[] AllInstruments()
		{
			return (JsonParse.ParseAllInstruments(RHttpClient.RHttpClientGet("/instruments/")));
		}

		//For the next value
		public InstrumentData[] AllInstruments(string next)
		{
			return (JsonParse.ParseAllInstruments(RHttpClient.RHttpClientGet(next)));
		}

		public SplitData[] GatherSplitHistoryForInstrument(string id)
		{
			return JsonParse.ParseSplitHistory(RHttpClient.RHttpClientGet("/instruments/"+id+"/splits/"));
		}

		public SplitData GatherSplitHistoryForInstrumentSpecified(string splitId)
		{
			return JsonParse.ParseSplitHistorySingle(RHttpClient.RHttpClientGet(splitId.Replace("https://api.robinhood.com","")));
		}

		public SplitData GatherSplitHistoryForInstrumentSpecified(string id,string splitId)
		{
			return JsonParse.ParseSplitHistorySingle(RHttpClient.RHttpClientGet("/instruments/" + id + "/splits/" + splitId + '/'));
		}
	}
}
