using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Robinhood
{
	class Program
	{
		public JToken TesterAuthenication(string accessToken,string testPoint)
		{
			return JToken.Parse(RHttpClient.RHttpClientGetWithAuthenticationHeader(testPoint, accessToken));
		}

		static void Main(string[] args)
		{
			Login login = new Login();
			Authentication authentication = new Authentication();
			Endpoints endpoints = new Endpoints();
			Quotes quotes = new Quotes();
			Fundamentals fundamentals = new Fundamentals();
			Instruments instruments = new Instruments();
			Account account = new Account();
			
			var testDic = new Dictionary<string, string>
			{
				{"query", "Microsoft" }
			};

			using (StreamReader reader = new StreamReader("login.txt"))
			{
				var readFile = reader.ReadToEnd();
				var words = readFile.Split();
				login.username = words[1];
				login.password = words[4];
			}

			//login.AccessToken = authentication.AuthenticateUser(login,true);
			authentication.ReadAccessToken(login);
			authentication.CheckRefreshToken(login);
			/*
			//account.GatherBasicInfo(login.AccessToken);
			//account.GatherAccountID(login.AccessToken);
			//Console.ReadLine();

			
			var quoteData = quotes.GatherData("GOOGL");

			string[] data = new string[]
			{
				"MSFT",
				"GOOGL",
				"AAPL",
				"AMZN",
				"TSLA"
			};

			var content = fundamentals.GatherMultipleFundamentalBySymbol(data); //Returns an array of fudamentalData
			for(int i = 0;i<data.Length;i++)
			{
				Console.WriteLine(content[i].description);
				Console.WriteLine(content[i].high);
				Console.WriteLine(content[i].high52Weeks);
				Console.WriteLine(content[i].low);
				Console.WriteLine(content[i].low52Weeks);
				Console.WriteLine(content[i].marketCap + Environment.NewLine);
			}

			InstrumentData[] instrumentData = instruments.InstrumentsByKeyWord("oil"); //Returns an array of "InstrumentData" after querying the Robinhood server
			Console.WriteLine("-----------------------------------Instruments--------------------------");

			foreach (var item in instrumentData)
			{
				Console.WriteLine(item.name);
				Console.WriteLine(item.simpleName);
				Console.WriteLine(item.listDate);
				Console.WriteLine(item.market);
				Console.WriteLine(item.symbol);
				Console.WriteLine(item.country);
				Console.WriteLine("------------------------------------------------------------------------------");
			}

			Console.WriteLine("----------------------------------Instrument by Symbol------------------------------");
			InstrumentData instrument = instruments.InstrumentsBySymbol("MSFT");
			Console.WriteLine(instrument.simpleName);
			Console.WriteLine(instruments.InstrumentsByID("777c0d30-3f78-4449-8d85-49702ae96a34").name);
	
			Console.WriteLine("----------------------------------ALL------------------------------");
			InstrumentData[] allInstruments = instruments.AllInstruments();
			Console.WriteLine(allInstruments[18].name);
			Console.WriteLine(allInstruments[18].simpleName);
			Console.WriteLine(allInstruments[0].next);

			allInstruments = instruments.AllInstruments("https://api.robinhood.com/instruments/?cursor=cD0xMjk4NQ%3D%3D");
			Console.WriteLine("----------------------------------------------Next Page---------------------------------------");
			Console.WriteLine(allInstruments[0].name);
			Console.WriteLine(allInstruments[0].next);

			Console.WriteLine("----------------------------------------------Splits---------------------------------------");
			SplitData[] splitData = instruments.GatherSplitHistoryForInstrument(instruments.InstrumentsBySymbol("SCO").id); //Gather information for one instrument split
																															//Most times there wont be one
																															//SCO just happened to be one that has a split which I used for testing
			Console.WriteLine(splitData[0].executionDate);
			Console.WriteLine(splitData[0].instrument);
			Console.WriteLine(splitData[0].multiplier);

			Console.WriteLine("----------------------------------------------Single Splits Thing---------------------------------------");
			SplitData splitDataSingle = instruments.GatherSplitHistoryForInstrumentSpecified(splitData[0].url);				//Single stocks get
																															//Get one of the splits information
			Console.WriteLine(splitDataSingle.executionDate);
			Console.WriteLine(splitDataSingle.instrument);

			Console.WriteLine("----------------------------------------------Account---------------------------------------");
			Console.WriteLine(account.GatherListofAccounts(login.AccessToken) + Environment.NewLine);
			Console.WriteLine(account.GatherEmploymentData(login.AccessToken).employerName + Environment.NewLine);
			Console.WriteLine(account.GatherAccountHolderAffliationInfo(login.AccessToken).agreedToRhs + Environment.NewLine);

			Console.WriteLine("----------------------------------------------Account Basic Info---------------------------------------");
			AccountBasicInfo basicInfo = account.GatherBasicInfo(login.AccessToken);
			Console.WriteLine(basicInfo.citizenship);
			Console.WriteLine(basicInfo.countryOfResident);
			Console.WriteLine(basicInfo.phoneNumber);
			Console.WriteLine(basicInfo.state);
			*/

			Console.WriteLine("Account Number: " + account.GatherListofAccounts(login.AccessToken).accountNumber);
			Console.WriteLine(account.GatherMarginBalances(login.AccessToken).updatedAt);
			Console.WriteLine("Start of day overnight buying power = " + account.GatherMarginBalances(login.AccessToken).startOfDayOvernightBuyingPower);

			Console.WriteLine("------------------------------------------------------------------------------Investment----------------------------------------------");
			InvestmentProfileData investmentProfileData = account.GatherInvestmentProfile(login.AccessToken);
			Console.WriteLine("Liquid net Worth: " + investmentProfileData.liquidNetWorth);
			Console.WriteLine("Risk Tolerance: " + investmentProfileData.riskTolerance);
			Console.WriteLine("Investment Objective" + investmentProfileData.investmentObjective);
			Console.WriteLine("\n\n" + account.GatherAccountPositions(login.AccessToken));

			Console.WriteLine("------------------------------------------------------------------------------Test----------------------------------------------");
			Program program = new Program();
			Console.WriteLine(program.TesterAuthenication(login.AccessToken, "/applications/") + Environment.NewLine); //Applications
			Console.WriteLine(program.TesterAuthenication(login.AccessToken, ("/accounts/" + account.GatherListofAccounts(login.AccessToken).accountNumber) + "/recent_day_trades/")); //Recent Day Trades
			Console.WriteLine(program.TesterAuthenication(login.AccessToken, "/settings/margin/" + account.GatherListofAccounts(login.AccessToken).accountNumber + "/")); //Margin Settings
			Console.WriteLine(JToken.Parse(RHttpClient.RHttpClientGet("/markets/"))); //market Info
																					  //Get specific market info: /markets/{mic}/
																					  //Get Market hours /markets/{mic}/hours/{date} WILL RETURN NULL FOR ALL VALUES IF NOT OPEN THAT DAY
			Console.WriteLine(JToken.Parse(RHttpClient.RHttpClientGet("/markets/BATS/hours/2018-12-12")));
			Console.WriteLine(JToken.Parse(RHttpClient.RHttpClientGet("/markets/BATS/hours/2018-12-25")));
			Console.ReadLine();
		}
	}
}
