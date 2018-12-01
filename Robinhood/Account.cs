using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Robinhood
{
	//TODO NEED TO IMPLEMENT INSTANT_ELIGIBILITY
	class AccountData
	{

	}

	class AccountID
	{
		public string username;
		public string url;
		public string id;
	}

	class AccountListKeys
	{
		public bool deactivated, withdrawalHalted, sweepEnabled, depositHalted, onlyPositionClosingTrades, isPinnacleAccount;
		public string updatedAt, portfolio, type, user, url, positions, createdAt, accountNumber, canDowngradeToCash, optionLevel;
		public string cashBalances = null;
		public float sma, buyingPower, maxAchEarlyAccessAmount, cashHealdForOrders, cash, smaHealdForOrders, unclearedDeposits, unsettledFunds, unsettledDebit;
	}

	class MarginBalances
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

	class AccountAffiliationInfo
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

	class CashBalances
	{

	}

	class Employment
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

	class AccountBasicInfo
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

	class InvestmentProfileData
	{
		public string annualIncome, investmentExperience, investmentObjective, liquidNetWorth, liquidityNeeds, riskTolerance, sourceOfFunds, taxBracket, timeHorizon, totalNetWorth, updatedAt, user;
		public bool suitabilityVerified;
	}

	class Account
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

		public string GatherInvestmentProfile(string accessToken)
		{
			return RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/investment_profile/", accessToken);
		}
	}
}
