using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Robinhood
{
	class JsonParse
	{
		public static string ParseAccessToken(string data)
		{
			JToken json = JToken.Parse(data);
			return json["access_token"].ToString();
		}
		public static string ParseRefreshToken(string data)
		{
			return JToken.Parse(data)["refresh_token"].ToString();
		}
		public static QuoteData ParseQuote(string data)
		{
			var settings = new JsonLoadSettings
			{

			};

			JToken json = JToken.Parse(data, settings);

			QuoteData quoteData = new QuoteData();
			quoteData.askPrice = (float)json["ask_price"];
			quoteData.askSize = (int)json["ask_size"];
			quoteData.bidPrice = (float)json["bid_price"];
			quoteData.bidSize = (int)json["bid_size"];
			quoteData.lastTradePrice = (float)json["last_trade_price"];
			quoteData.previousClose = (float)json["previous_close"];
			quoteData.adjustedPreviousClose = (float)json["adjusted_previous_close"];
			quoteData.previousCloseDate = (string)json["previous_close_date"];
			quoteData.symbol = (string)json["symbol"];
			quoteData.tradingHalted = (bool)json["trading_halted"];
			quoteData.hasTraded = (bool)json["has_traded"];
			quoteData.updatedAt = (string)json["updated_at"];

			if (json["last_extended_hours_trade_price"].Type != JTokenType.Null)
			{
				quoteData.lastExtendedHoursTradePrice = (float)json["last_extended_hours_trade_price"];
			}

			return quoteData;
		}
		public static FundamentalData ParseFundament(string data)
		{
			JToken json = JToken.Parse(data);

			FundamentalData fundamentalData = new FundamentalData();
			fundamentalData.open = (float)json["open"];
			fundamentalData.high = (float)json["high"];
			fundamentalData.low = (float)json["low"];
			fundamentalData.volume = (float)json["volume"];
			fundamentalData.averageVolume = (float)json["average_volume"];
			fundamentalData.high52Weeks = (float)json["high_52_weeks"];
			fundamentalData.low52Weeks = (float)json["low_52_weeks"];
			fundamentalData.marketCap = (float)json["market_cap"];
			fundamentalData.dividendYield = (float)json["dividend_yield"];
			fundamentalData.description = (string)json["description"];
			fundamentalData.instrument = (string)json["instrument"];

			if (json["pe_ratio"].Type != JTokenType.Null)
			{
				fundamentalData.peRatio = (float)json["pe_ratio"];
			}

			return fundamentalData;
		}
		public static InstrumentData[] ParseInstrument(string data)
		{
			InstrumentData[] instrumentData;
			JToken json = JToken.Parse(data);

			//Get the length of the amount of data present
			int i = 0;
			while (true)
			{
				try
				{
					var check = json["results"][i];
					i++;
				}
				catch
				{
					instrumentData = new InstrumentData[i];
					break;
				}
			}

			//Iterate and get assign our values
			i = 0;
			while (true)
			{
				try
				{
					instrumentData[i] = new InstrumentData();

					if (json["results"][i]["min_tick_size"].Type != JTokenType.Null)
					{
						instrumentData[i].minTickSize = (float)json["min_tick_size"];
					}

					if (json["results"][i]["tradability"].ToString() == "tradable")
					{
						instrumentData[i].tradeable = true;
					}

					instrumentData[i].splits = (string)json["results"][i]["splits"];
					instrumentData[i].marginInitialRatio = (float)json["results"][i]["margin_initial_ratio"];
					instrumentData[i].url = (string)json["results"][i]["url"];
					instrumentData[i].quote = (string)json["results"][i]["quote"];
					instrumentData[i].symbol = (string)json["results"][i]["symbol"];
					instrumentData[i].bloomsbergUnique = (string)json["bloomsberg_unique"];
					instrumentData[i].listDate = (string)json["results"][i]["list_date"];
					instrumentData[i].fundamental = (string)json["results"][i]["fundamental"];
					instrumentData[i].state = (string)json["results"][i]["state"];
					instrumentData[i].country = (string)json["results"][i]["country"];
					instrumentData[i].dayTradeRatio = (float)json["results"][i]["day_trade_ratio"];
					instrumentData[i].maintenanceRatio = (float)json["results"][i]["maintenance_ratio"];
					instrumentData[i].id = (string)json["results"][i]["id"];
					instrumentData[i].market = (string)json["results"][i]["market"];
					instrumentData[i].name = (string)json["results"][i]["name"];
					instrumentData[i].simpleName = (string)json["results"][i]["simple_name"];
					i++;
				}
				catch
				{
					break;
				}
			}

			return instrumentData;
		}
		public static InstrumentData ParseInstrumentBySymbol(string data)
		{
			JToken json = JToken.Parse(data);
			InstrumentData instrumentData = new InstrumentData();

			if (json["results"][0]["min_tick_size"].Type != JTokenType.Null)
			{
				instrumentData.minTickSize = (float)json["min_tick_size"];
			}

			if (json["results"][0]["tradability"].ToString() == "tradable")
			{
				instrumentData.tradeable = true;
			}

			instrumentData.splits = (string)json["results"][0]["splits"];
			instrumentData.marginInitialRatio = (float)json["results"][0]["margin_initial_ratio"];
			instrumentData.url = (string)json["results"][0]["url"];
			instrumentData.quote = (string)json["results"][0]["quote"];
			instrumentData.symbol = (string)json["results"][0]["symbol"];
			instrumentData.bloomsbergUnique = (string)json["results"][0]["bloomsberg_unique"];
			instrumentData.listDate = (string)json["results"][0]["list_date"];
			instrumentData.fundamental = (string)json["results"][0]["fundamental"];
			instrumentData.state = (string)json["results"][0]["state"];
			instrumentData.country = (string)json["results"][0]["country"];
			instrumentData.dayTradeRatio = (float)json["results"][0]["day_trade_ratio"];
			instrumentData.maintenanceRatio = (float)json["results"][0]["maintenance_ratio"];
			instrumentData.id = (string)json["results"][0]["id"];
			instrumentData.market = (string)json["results"][0]["market"];
			instrumentData.name = (string)json["results"][0]["name"];
			instrumentData.simpleName = (string)json["results"][0]["simple_name"];

			return instrumentData;
		}
		public static InstrumentData ParseInstrumentByID(string data)
		{
			JToken json = JToken.Parse(data);
			InstrumentData instrumentData = new InstrumentData();

			if (json["min_tick_size"].Type != JTokenType.Null)
			{
				instrumentData.minTickSize = (float)json["min_tick_size"];
			}

			if (json["tradability"].ToString() == "tradable")
			{
				instrumentData.tradeable = true;
			}

			instrumentData.splits = (string)json["splits"];
			instrumentData.marginInitialRatio = (float)json["margin_initial_ratio"];
			instrumentData.url = (string)json["url"];
			instrumentData.quote = (string)json["quote"];
			instrumentData.symbol = (string)json["symbol"];
			instrumentData.bloomsbergUnique = (string)json["bloomsberg_unique"];
			instrumentData.listDate = (string)json["list_date"];
			instrumentData.fundamental = (string)json["fundamental"];
			instrumentData.state = (string)json["state"];
			instrumentData.country = (string)json["country"];
			instrumentData.dayTradeRatio = (float)json["day_trade_ratio"];
			instrumentData.maintenanceRatio = (float)json["maintenance_ratio"];
			instrumentData.id = (string)json["id"];
			instrumentData.market = (string)json["market"];
			instrumentData.name = (string)json["name"];
			instrumentData.simpleName = (string)json["simple_name"];

			return instrumentData;
		}
		public static InstrumentData[] ParseAllInstruments(string data) { 
			InstrumentData[] instrumentData;
			JToken json = JToken.Parse(data);

			//Get the length of the amount of data present
			int i = 0;
			int length = 0;
			while (true)
			{
				try
				{
					var check = json["results"][i];
					i++;
				}
				catch
				{
					instrumentData = new InstrumentData[i];
					length = i;
					break;
				}
			}

			for(i = 0; i < length; i++)
			{
				instrumentData[i] = new InstrumentData();

				if (json["results"][i]["min_tick_size"].Type != JTokenType.Null)
				{
					try
					{
						instrumentData[i].minTickSize = (float)json["min_tick_size"];
					}
					catch(Exception e)
					{
						Console.WriteLine(e);
						instrumentData[i].minTickSize = null;
					}
				}

				if (json["results"][i]["tradability"].ToString() == "tradable")
				{
					instrumentData[i].tradeable = true;
				}

				instrumentData[i].splits = (string)json["results"][i]["splits"];
				instrumentData[i].marginInitialRatio = (float)json["results"][i]["margin_initial_ratio"];
				instrumentData[i].url = (string)json["results"][i]["url"];
				instrumentData[i].quote = (string)json["results"][i]["quote"];
				instrumentData[i].symbol = (string)json["results"][i]["symbol"];
				instrumentData[i].bloomsbergUnique = (string)json["bloomsberg_unique"];
				instrumentData[i].listDate = (string)json["results"][i]["list_date"];
				instrumentData[i].fundamental = (string)json["results"][i]["fundamental"];
				instrumentData[i].state = (string)json["results"][i]["state"];
				instrumentData[i].country = (string)json["results"][i]["country"];
				instrumentData[i].dayTradeRatio = (float)json["results"][i]["day_trade_ratio"];
				instrumentData[i].maintenanceRatio = (float)json["results"][i]["maintenance_ratio"];
				instrumentData[i].id = (string)json["results"][i]["id"];
				instrumentData[i].market = (string)json["results"][i]["market"];
				instrumentData[i].name = (string)json["results"][i]["name"];
				instrumentData[i].simpleName = (string)json["results"][i]["simple_name"];
			}

			instrumentData[0].next = json["next"].ToString(); //Next page for the rest of the results

			return instrumentData;
		}
		public static SplitData[] ParseSplitHistory(string data)
		{
			SplitData[] splitData;
			JToken json = JToken.Parse(data);

			int i = 0;
			int length = 0;
			while (true)
			{
				try
				{
					var check = json["results"][i];
					i++;
				}
				catch(Exception e)
				{
					splitData = new SplitData[i];
					length = i;
					break;
				}
			}

			for(i = 0; i < length; i++)
			{
				splitData[i] = new SplitData();
				splitData[i].url = (string)json["results"][i]["url"];
				splitData[i].instrument = (string)json["results"][i]["instrument"];
				splitData[i].executionDate = (string)json["results"][i]["execution_date"];
				splitData[i].divisor = (float)json["results"][i]["divisor"];
				splitData[i].multiplier = (float)json["results"][i]["multiplier"];
			}

			return splitData;
		}
		public static SplitData ParseSplitHistorySingle(string data)
		{
			SplitData splitData;
			JToken json = JToken.Parse(data);


			splitData = new SplitData();
			splitData.url = (string)json["url"];
			splitData.instrument = (string)json["instrument"];
			splitData.executionDate = (string)json["execution_date"];
			splitData.divisor = (float)json["divisor"];
			splitData.multiplier = (float)json["multiplier"];

			return splitData;
		}
		public static Employment ParseEmployment(string data)
		{
			JToken json = JToken.Parse(data);
			Employment employment = new Employment();

			if(json["employer_zipcode"].ToString() != "") employment.employerZipCode = (int)json["employer_zipcode"];

			employment.employmentStatus = (string)json["employment_status"];
			employment.employerAddress = (string)json["employer_address"];
			employment.updatedAt = (string)json["updated_at"];
			employment.employerName = (string)json["employer_name"];

			if (json["years_employed"].Type != JTokenType.Null) employment.yearsEmployed = (int)json["years_employed"];

			employment.employerState = (string)json["employer_state"];
			employment.employerCity = (string)json["employer_city"];
			employment.occupation = (string)json["occupation"];

			return employment;
		}
		public static AccountAffiliationInfo ParseAccountAffiliationInfo(string data)
		{
			AccountAffiliationInfo accountAffiliationInfo = new AccountAffiliationInfo();
			JToken json = JToken.Parse(data);

			accountAffiliationInfo.securityAffiliatedFirmRelationship = (string)json["security_affiliated_firm_relationship"];
			accountAffiliationInfo.securityAffiliatedEmployee = (bool)json["security_affiliated_employee"];
			accountAffiliationInfo.agreedToRhsMargin = (bool)json["agreed_to_rhs_margin"];
			accountAffiliationInfo.securityAffiliatedAddress = (string)json["security_affiliated_address"];
			accountAffiliationInfo.objectToDisclosure = (bool)json["object_to_disclosure"];
			accountAffiliationInfo.updatedAt = (string)json["updated_at"];
			accountAffiliationInfo.controlPerson = (bool)json["control_person"];
			accountAffiliationInfo.stockLoanConsentStatus = (string)json["stock_loan_consent_status"];
			accountAffiliationInfo.agreedToRhs = (bool)json["agreed_to_rhs"];
			accountAffiliationInfo.sweepConsent = (bool)json["sweep_consent"];
			accountAffiliationInfo.controlPersonSecuritySymbol = (string)json["control_person_security_symbol"];
			accountAffiliationInfo.securityAffiliatedFirmName = (string)json["security_affiliated_firm_name"];
			accountAffiliationInfo.securityAffiliatedPersonName = (string)json["security_affiliated_person_name"];
			return accountAffiliationInfo;
		}
		public static AccountID ParseAccountID(string data)
		{
			JToken json = JToken.Parse(data);
			AccountID accountID = new AccountID();

			accountID.id = (string)json["id"];
			accountID.url = (string)json["url"];
			accountID.username = (string)json["username"];
			return accountID;
		}
		public static AccountBasicInfo ParseAccountBasicInfo(string data)
		{
			JToken json = JToken.Parse(data);
			AccountBasicInfo basicInfo = new AccountBasicInfo();
			basicInfo.address = (string)json["address"];
			basicInfo.citizenship = (string)json["citizenship"];
			basicInfo.city = (string)json["city"];
			basicInfo.countryOfResident = (string)json["country_of_residence"];
			basicInfo.dateOfBirth = (string)json["date_of_birth"];
			basicInfo.maritialStatus = (string)json["martial_status"];
			basicInfo.numberDependents = (int)json["number_dependents"];
			basicInfo.phoneNumber = (string)json["phone_number"];
			basicInfo.state = (string)json["state"];
			basicInfo.taxIDSSN = (int)json["tax_id_ssn"];
			basicInfo.updatedAt = (string)json["updated_at"];
			basicInfo.zipcode = (int)json["zipcode"];
			return basicInfo;
		}
		public static AccountListKeys ParseListAccounts(string data)
		{
			AccountListKeys accountData = new AccountListKeys();
			JToken json = JToken.Parse(data);

			accountData.deactivated = (bool)json["results"][0]["deactivated"];
			accountData.updatedAt = (string)json["results"][0]["updated_at"];
			accountData.portfolio = (string)json["results"][0]["portfolio"];

			if (json["results"][0]["cash_balances"].Type != JTokenType.Null) accountData.cashBalances = (string)json["results"][0]["cash_balances"];
			accountData.canDowngradeToCash = (string)json["results"][0]["can_downgrade_to_cash"];
			accountData.withdrawalHalted = (bool)json["results"][0]["withdrawal_halted"];
			accountData.type = (string)json["results"][0]["type"];
			accountData.sma = (float)json["results"][0]["sma"];
			accountData.sweepEnabled = (bool)json["results"][0]["sweep_enabled"];
			accountData.depositHalted = (bool)json["results"][0]["deposit_halted"];
			accountData.buyingPower = (float)json["results"][0]["buying_power"];
			accountData.user = (string)json["results"][0]["user"];
			accountData.maxAchEarlyAccessAmount = (float)json["results"][0]["max_ach_early_access_amount"];
			accountData.optionLevel = (string)json["results"][0]["option_level"];
			accountData.cashHealdForOrders = (float)json["results"][0]["cash_held_for_orders"];
			accountData.onlyPositionClosingTrades = (bool)json["results"][0]["only_position_closing_trades"];
			accountData.url = (string)json["results"][0]["url"];
			accountData.positions = (string)json["results"][0]["positions"];
			accountData.createdAt = (string)json["results"][0]["created_at"];
			accountData.cash = (float)json["results"][0]["cash"];
			accountData.smaHealdForOrders = (float)json["results"][0]["sma_held_for_orders"];
			accountData.unsettledDebit = (float)json["results"][0]["unsettled_debit"];
			accountData.accountNumber = (string)json["results"][0]["account_number"];
			accountData.isPinnacleAccount = (bool)json["results"][0]["is_pinnacle_account"];
			accountData.unclearedDeposits = (float)json["results"][0]["uncleared_deposits"];
			accountData.unsettledFunds = (float)json["results"][0]["unsettled_funds"];

			return accountData;			
		}
		public static MarginBalances ParseMarginBalances(string data)
		{
			MarginBalances marginBalances = new MarginBalances();
			JToken json = JToken.Parse(data);

			marginBalances.updatedAt = (string)json["results"][0]["margin_balances"]["updated_at"];
			marginBalances.goldEquityRequirement = (float)json["results"][0]["margin_balances"]["gold_equity_requirement"];
			marginBalances.outstandingInterest = (float)json["results"][0]["margin_balances"]["outstanding_interest"];
			marginBalances.cashHeldForOptionsCollateral = (float)json["results"][0]["margin_balances"]["cash_held_for_options_collateral"];
			marginBalances.unclearedNummusDeposits = (float)json["results"][0]["margin_balances"]["uncleared_nummus_deposits"];
			marginBalances.overnightRatio = (float)json["results"][0]["margin_balances"]["overnight_ratio"];
			marginBalances.dayTradeBuyingPower = (float)json["results"][0]["margin_balances"]["day_trade_buying_power"];
			marginBalances.cashAvailableForWithdrawal = (float)json["results"][0]["margin_balances"]["cash_available_for_withdrawal"];
			marginBalances.sma = (float)json["results"][0]["margin_balances"]["sma"];
			marginBalances.cashHeldForNummusRestrictions = (float)json["results"][0]["margin_balances"]["cash_held_for_nummus_restrictions"];
			if (json["results"][0]["margin_balances"]["marked_pattern_day_trader_date"].Type != JTokenType.Null) marginBalances.markedPatternDayTraderDate = (bool)json["results"][0]["margin_balances"]["marked_pattern_day_trader_date"];
			marginBalances.unallocatedMarginCash = (float)json["results"][0]["margin_balances"]["unallocated_margin_cash"];
			marginBalances.startOfDaydtbp = (float)json["results"][0]["margin_balances"]["start_of_day_dtbp"];
			marginBalances.overnightBuyingPowerHeldForOrders = (float)json["results"][0]["margin_balances"]["overnight_buying_power_held_for_orders"];
			marginBalances.dayTradeRatio = (float)json["results"][0]["margin_balances"]["day_trade_ratio"];
			marginBalances.cashHeldForOrders = (float)json["results"][0]["margin_balances"]["cash_held_for_orders"];
			marginBalances.unsettledDebit = (float)json["results"][0]["margin_balances"]["unsettled_debit"];
			marginBalances.createdAt = (string)json["results"][0]["margin_balances"]["created_at"];
			marginBalances.cashHeldForDividends = (float)json["results"][0]["margin_balances"]["cash_held_for_dividends"];
			marginBalances.cash = (float)json["results"][0]["margin_balances"]["cash"];
			marginBalances.startOfDayOvernightBuyingPower = (float)json["results"][0]["margin_balances"]["start_of_day_overnight_buying_power"];
			marginBalances.marginLimit = (float)json["results"][0]["margin_balances"]["margin_limit"];
			marginBalances.overnightBuyingPower = (float)json["results"][0]["margin_balances"]["overnight_buying_power"];
			marginBalances.unclearedDeposits = (float)json["results"][0]["margin_balances"]["uncleared_deposits"];
			marginBalances.unsettledFunds = (float)json["results"][0]["margin_balances"]["unsettled_funds"];
			marginBalances.dayTradeBuyingPowerHeldForOrders = (float)json["results"][0]["margin_balances"]["day_trade_buying_power_held_for_orders"];


			return marginBalances;
		}
	}
}
