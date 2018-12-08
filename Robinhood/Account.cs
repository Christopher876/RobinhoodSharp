using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Robinhood
{
	//TODO NEED TO IMPLEMENT INSTANT_ELIGIBILITY
	#region Data Classes
	public class AccountData
	{

	}
	public class AccountID
	{
		public string username;
		public string url;
		public string id;
	}
	public class AccountListKeys
	{
		public bool deactivated, withdrawalHalted, sweepEnabled, depositHalted, onlyPositionClosingTrades, isPinnacleAccount;
		public string updatedAt, portfolio, type, user, url, positions, createdAt, accountNumber, canDowngradeToCash, optionLevel;
		public string cashBalances = null;
		public float sma, buyingPower, maxAchEarlyAccessAmount, cashHealdForOrders, cash, smaHealdForOrders, unclearedDeposits, unsettledFunds, unsettledDebit;
	}
	public class MarginBalances
	{
		public string updatedAt;
		public float goldEquityRequirement;
		public float outstandingInterest;
		public float cashHeldForOptionsCollateral;
		public float unclearedNummusDeposits;
		public float overnightRatio;
		public float? dayTradeBuyingPower = null;
		public float cashAvailableForWithdrawal;
		public float sma;
		public float cashHeldForNummusRestrictions;
		public bool? markedPatternDayTraderDate;
		public float unallocatedMarginCash;
		public float startOfDaydtbp;
		public float overnightBuyingPowerHeldForOrders;
		public float dayTradeRatio;
		public float cashHeldForOrders;
		public float unsettledDebit;
		public string createdAt;
		public float cashHeldForDividends;
		public float cash;
		public float startOfDayOvernightBuyingPower;
		public float marginLimit;
		public float overnightBuyingPower;
		public float unclearedDeposits;
		public float unsettledFunds;
		public float dayTradeBuyingPowerHeldForOrders;
	}
	public class AccountAffiliationInfo
	{
		public string securityAffiliatedFirmRelationship;
		public bool securityAffiliatedEmployee;
		public bool agreedToRhsMargin;
		public string securityAffiliatedAddress;
		public bool objectToDisclosure;
		public string updatedAt;
		public bool controlPerson;
		public string stockLoanConsentStatus;
		public bool agreedToRhs;
		public bool sweepConsent;
		public string controlPersonSecuritySymbol;
		public string securityAffiliatedFirmName;
		public string securityAffiliatedPersonName;
	}
	public class CashBalances
	{

	}
	public class Employment
	{
		public int? employerZipCode;
		public string employmentStatus;
		public string employerAddress;
		public string updatedAt;
		public string employerName;
		public int? yearsEmployed;
		public string employerState;
		public string employerCity;
		public string occupation;
	}
	public class AccountBasicInfo
	{
		public string phoneNumber;
		public string city;
		public int numberDependents;
		public string citizenship;
		public string updatedAt;
		public string maritialStatus;
		public int zipcode;
		public string countryOfResident;
		public string state;
		public string dateOfBirth;
		public bool signUpAsRhs;
		public string address;
		public int taxIDSSN;
	}
	public class InvestmentProfileData
	{
		public string understandOptionSpreads, optionTradingExperience, interestedInOptions, annualIncome, investmentExperience, investmentObjective, liquidNetWorth, liquidityNeeds, riskTolerance, sourceOfFunds, taxBracket, timeHorizon, totalNetWorth, updatedAt, user;
		public bool suitabilityVerified, professionalTrader, investmentExperienceCollected;
	}
	public class AccountPosition
	{
		public float sharesHeldForStockGrants, pendingAverageBuyPrice, sharesHeldForOptionsEvents, intraDayAverageBuyPrice, sharesHeldForOptionsCollateral, sharesHeldForBuys, averageBuyPrice, intradayQuantity, sharesHeldForSells, sharesPendingFromOptionsEvents, quantity;
		public string account, url, instrument, createdAt, updatedAt;
	}
	public class Dividends
	{
		public string account;
		public string url;
		public float amount;
		public string payableDate;
		public string instrument;
		public float rate;
		public string recordDate;
		public float position;
		public float withHolding;
		public string id;
		public string paidAt;
		public string next;
	}
	public class Portfolio
	{
		public float unwithdrawableGrants;
		public string account;
		public float excessMaintenanceWithUnclearedDeposits;
		public string url;
		public float excessMaintenance;
		public float marketValue;
		public float withdrawableAmount;
		public float lastCoreMarketValue;
		public float unwithdrawableDeposits;
		public float extendedHoursEquity;
		public float excessMargin;
		public float excessMarginWithUnclearedDeposits;
		public float equity;
		public float lastCoreEquity;
		public float adjustedEquityPreviousClose;
		public float equityPreviousClose;
		public string startDate;
		public float extendedHoursMarketValue;
	}
	#endregion

	public class Account
	{

		public AccountListKeys GatherListofAccounts(string accessToken)
		{
			return JsonParse.ParseListAccounts(RHttpClient.RHttpClientGetWithAuthenticationHeader("/accounts/", accessToken));
		}

		public AccountBasicInfo GatherBasicInfo(string accessToken)
		{
			return JsonParse.ParseAccountBasicInfo(RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/basic_info/",accessToken));
		}

		public AccountID GatherAccountID(string accessToken)
		{
			return JsonParse.ParseAccountID(RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/id/",accessToken));
		}

		public AccountAffiliationInfo GatherAccountHolderAffliationInfo(string accessToken)
		{
			return JsonParse.ParseAccountAffiliationInfo(RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/additional_info/", accessToken));
		}

		public Employment GatherEmploymentData(string accessToken)
		{
			return JsonParse.ParseEmployment(RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/employment/", accessToken));
		}

		public MarginBalances GatherMarginBalances(string accessToken)
		{
			return JsonParse.ParseMarginBalances(RHttpClient.RHttpClientGetWithAuthenticationHeader("/accounts/", accessToken));
		}

		public InvestmentProfileData GatherInvestmentProfile(string accessToken)
		{
			return JsonParse.ParseInvestmentProfile(RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/investment_profile/", accessToken));
		}

		public AccountPosition[] GatherAccountPositions(string accessToken)
		{
			return JsonParse.ParseAccountPosition(RHttpClient.RHttpClientGetWithAuthenticationHeader("/positions/", accessToken));
		}
		
		public Dividends[] GatherAccountDividends(string accessToken)
		{
			return JsonParse.ParseAccountDividends(RHttpClient.RHttpClientGetWithAuthenticationHeader("/dividends/", accessToken));
		}

		public Portfolio GatherAccountPortfolio(string accessToken)
		{
			return JsonParse.ParseAccountPortfolio(RHttpClient.RHttpClientGetWithAuthenticationHeader("/portfolios/", accessToken));
		}
	}
}
