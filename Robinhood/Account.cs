using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Robinhood
{
	class AccountData
	{

	}

	class AccountListKeys
	{
		public bool deactivated, withdrawalHalted, sweepEnabled, depositHalted, onlyPositionClosingTrades, nummusEnabled;
		public string updatedAt, marginBalances, portfolio, cashBalances, type, user, url, positions, createdAt, accountNumber;
		public float cashAvailableForWithdrawal, sma, buyingPower, maxAchEarlyAccessAmount, cashHealdForOrders, cash, smaHealdForOrders, unclearedDeposits, unsettledFunds;
	}

	class MarginBalances
	{
		public string updatedAt;
		public float goldEquityRequirement;
		public float outstandingInterest;
		public float cashHeldForOptionsCollateral;
		public float unclearedNummusDeposits;
		public float overnightRatio;
		public float dayTradeBuyingPower;
		public float cashAvailableForWithdrawal;
		public float sma;
		public float cashHeldForNummusRestrictions;
		public bool markedPatternDayTraderDate;
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

	class Account
	{

		public string GatherListofAccounts(string accessToken)
		{
			return RHttpClient.RHttpClientGetWithAuthenticationHeader("/accounts/", accessToken);
		}

		public string GatherBasicInfo(string accessToken)
		{
			return RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/basic_info/",accessToken);
		}

		public string GatherAccountID(string accessToken)
		{
			return RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/id/",accessToken);
		}

		public AccountAffiliationInfo GatherAccountHolderAffliationInfo(string accessToken)
		{
			return JsonParse.GetAccountAffiliationInfo(RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/additional_info/", accessToken));
		}

		public Employment GatherEmploymentData(string accessToken)
		{
			return JsonParse.GetEmployment(RHttpClient.RHttpClientGetWithAuthenticationHeader("/user/employment/", accessToken));
		}
	}
}
