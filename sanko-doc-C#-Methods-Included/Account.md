# User Information Methods

- [Gather Basic User Info](#gather-basic-user-info)
- [Gather the Account ID](#gather-the-account-id)
- [Gather Basic Information About the Account Holder](#gather-basic-information-about-the-account-holder)
- [Account Holder's Affiliation Information](#account-holders-affiliation-information)
- [Gather Employment Data About the Account Holder](#gather-employment-data-about-account-holder)
- [Gather Investment Profile Data About the Account Holder](#gather-investment-profile-data-about-the-account-holder)
- [Gather Verifiable User Information](#gather-verifiable-user-information)
- [Get the Customer Identification Program Questions](#get-the-customer-identification-program-questions)
- [Answer Customer Identification Program Questions](#answer-customer-identification-program-questions)
- [Update User Information](#update-user-information)
- [Check Ability to Downgrade to Cash Account](#check-ability-to-downgrade-to-cash-account)
- [Check Ability to Downgrade to Cash Account with a Nice Message](#check-ability-to-downgrade-to-cash-account-with-a-nice-message)
- [Gather Account Positions](#gather-account-positions)

---

Now that you're [logged in](Authentication.md#logging-in), you'll probably want to get to know yourself a little bit. Here we go...

Most account API calls require an `account_id` so the service knows which of your accounts to act on. You'll need to [gather the list of accounts](#gather-list-of-accounts) to get their `account_id`.

# Gather List of Accounts

**Account.GatherListofAccounts(string accessToken)**

return type: AccountListKeys which values are as follows:

| Key                           | Type     | Description |
|-------------------------------|----------|-------------|
| deactivated      				| Boolean  | Whether the account has been deactivated |
| updatedAt       				| string   | Last time the account was modified |
| portfolio        				| string   | Endpoint for this portfolio |
| cash_balances    				| string   | See below |
| withdrawlHalted 			    | Boolean  | Has the most recent attempt to withdraw cash been stopped? |
| cashAvailableForWithdrawal    | Float    | Amount of money on hand you may withdrawal to your back via ACH |
| type             				| String   | `cash` for Normal accounts, `margin` for Instant accounts |
| sma 							| Float    | Special memorandum account funds available. `null` for cash accounts |
| sweepEnabled					| Boolean  | |
| depositHalted				    | Boolean  | |
| buyingPower 					| Float    | Amount of cash available to purchase securities (up to your margin limit). On a cash account, it is equal to the amount of settled funds. |
| user 							| String   | Link back to the basic [user data endpoint](#gather-basic-user-info) |
| maxAchEarlyAccessAmount	    | Float    | Amount of cash you may use before the actual transfer completes. Instant accounts have early access to a certain amount of funds, although this also applies to the first $1,000 worth of deposits into the account as well. |
| cashHeldForOrders 			| Float    | Amount of cash in outstanding buy orders. |
| onlyPositionClosingTrades     | Boolean  |  Google 'investopedia close position' |
| String 						| String   | Endpoint where more information about this account may be grabbed |
| positions						| String   | Endpoint where you may grab the past/current positions held by this account |
| createdAt					    | string   | Date this account was created |
| cash 							| Float    | Amount of cash including unsettled funds |
| smaHeldForOrders 			    | Float    | Special memorandum account funds held for orders. `null` for cash accounts |
| accountNumber                 | String   | The alphanumeric string Robinhood uses to identify this account |
| unclearedDeposits             | Float    | Amount of money in transet from an inconplete ACH deposit |
| unsettledFunds                | Float    | Amount of money in unsettled funds |
| nummusEnabled                 | Boolean   |  |

**`cash_balances`** __*Not Implemented Yet*__

If the account type is not cash this value is `null`.

| Key                                    | Type     | Description |
|----------------------------------------|----------|-------------|
| cash_held_for_orders                   | Float    | This is the total amount of money marked for use in outstanding buy orders. |
| created_at                             | String   | When was the cash account created |
| cash                                   | Float    | Amount of cash including unsettled funds |
| buying_power                           | Float    | Amount of cash on hand for purchasing securities (T+3 settled funds not being held for orders) |
| updated_at                             | String   | When any of the values of `cash_balances` was last changed |
| cash_available_for_withdrawl           | Float    | Amount of cash on hand you may transfer to your connected ACH account |
| uncleared_deposits                     | Float    | Value of all initiated ACH transfers which have not completed |
| unsettled_funds                        | Float    | Amount of money being held in statis thanks to SEC's T+3 anti-fun rule |

**`margin_balances`**

~If the account type is not margin this value is `null`.~ **Needs to be implemented first, Currently no check for this to occur**

| Key                                    | Type     | Description |
|----------------------------------------|----------|-------------|
| dayTradeBuyingPower                    | Float    | This is the total amount of money marked for use in outstanding and new buy orders. This value is readjusted before the start of each trading day. |
| createdAt                              | String   | When was the margin account created |
| overnightBuyingPowerHeldForOrders      | Float    | How much overnight buying power is held for orders |
| cashHeldForOrders                      | Float    | How much cash is held for orders |
| dayTradeBuyingPowerHeldForOrders       | Float    | How much day trade buyign power is held for orders |
| markedPatternDayTraderDate             | String   | Date which the account was flagged as a pattern day trader (PDT), `null` otherwise |
| cash                                   | Float    | Amount of cash including unsettled funds |
| unallocatedMarginCash                  | Float    | Amount of unallocated margin cash on hand for purchasing securities |
| updatedAt                              | String   | Date the values were last updated. This is generally updated when an order is placed, and/or deposits/withdrawals made. |
| cashAvailableForWithdrawal             | Float    | Amount of cash available for withdrawal |
| marginLimit                            | Float    | Maximum amount of money you can borrow. Robinhood Instant has 0 |
| overnightBuyingPower                   | Float    | How much buying power is available for the next day |
| unclearedDeposits                      | Float    | Amount of money in uncleared deposits |
| unsettledFunds                         | Float    | Amount of money in unsettled funds from trades |
| dayTradeRatio                          | Float    | |
| overnightRatio                         | Float    | |



# Gather Basic User Info

**Account.GatherBasicInfo(string accessToken)**

This returns very basic information (basically just a name and email address) and Strings for more.

return type: AccountBasicInfo

| Key    | Type   | Description |
|--------|--------|-------------|
| username   | String | The username of the currently logged in account |
| firstName | String | First name of the registered user               |
| lastName  | String | Last name of the registered user                |
| idInfo    | String    | Link to use for more information                |
| url       | String    | This exact String in case you forget what you just did |
| basicInfo | String    | Link where more basic information may be gathered   |
| email      | String | Email address of the currently logged in account    |
| investmentProfile | String | Link where investment related info may be gathered |
| id         | String | The unique ID Robinhood uses to identify this account   |
| internationalInfo | String | International... stuff? |
| employment | String | Employment information you provided may be found here |
| additionalInfo | String | Need more information? Grab it here! |

# Gather the Account ID

**Account.GatherAccountID(string accessToken)**

return type: AccountID

**Response**

| Key    | Type   | Description |
|--------|--------|-------------|
| username   | String | The username of the currently logged in account |
| url       | String    | This exact String in case you forget what you just did |
| id         | String | The unique ID Robinhood uses to identify this account   |

# Account Holder's Affiliation Information

**Account.GatherAccountAffliationInfo(string accessToken)**

return type: AccountAffliationInfo

This method returns SEC Rule 405 related information.

| Key                			  		| Type     | Description |
|---------------------------------------|----------|-------------|
| controlPerson       					| Boolean  | Are you a controlling member of any traded securities? |
| controlPersonSecuritySymbol 		| String   | If so, the symbol will be here |
| objectToDisclosure 			 		| Boolean  | |
| securityAffiliatedAddress 			| String   | |
| securityAffiliatedEmployee 			| Boolean  | |
| securityAffiliatedFirmName 		| String   | |
| securityAffiliatedFirmRelationship | String   | |
| securityAffiliatedPersonName		| String   | |
| sweepConsent 						| Boolean  | |
| updatedAt           					| String | When was any of this information last modified |
| user 									| String 	   | Link back to the `/user/` endpoint |

# Gather Employment Data About the Account Holder

**Account.GatherEmploymentData(string accessToken)**

return type: Employment

This returns the work status and related information.


| Key          		| Type     | Description |
|-------------------|----------|-------------|
| employerAddress  | String   | Postal address of your place of work |
| employerCity 	| String   | City where your employer is located |
| employerName 	| String   | |
| employerState 	| String   | |
| employerZipcode 	| Integer  | |
| employmentStatus | String   | |
| occupation 		| String   | |
| updatedAt    	| String | When was any of this information last modified |
| user 				| String 	   | Link back to the `/user/` endpoint |
| yearsEmployed	| Integer  | How long have you had your current job? |

#TODO

# Gather Investment Profile Data About the Account Holder

This returns answers to the basic investing experience survery presented during registration.


| Key          	    	| Type     | Description |
|-----------------------|----------|-------------|
| annual_income         | String   | `0_24999`, `25000_39999`, `40000_49999`, `50000_74999`, `75000_99999`, `100000_199999`, `200000_299999`, `300000_499999`, `500000_1199999`, or `1200000_inf` |
| investment_experience | String   | `extensive_investment_exp`, `good_investment_exp`, `limited_investment_exp`, or `no_investment_exp` |
| investment_objective 	| String   | `cap_preserve_invest_obj`, `income_invest_obj`, `growth_invest_obj`, `speculation_invest_obj`, `other_invest_obj` |
| liquid_net_worth      | String   | `0_24999`, `25000_39999`, `40000_49999`, `50000_99999`, `100000_199999`, `200000_249999`, `250000_499999`, `500000_999999`, or `1000000_inf` |
| liquidity_needs 	    | String   | `not_important_liq_need`, `somewhat_important_liq_need`, or `very_important_liq_need` |
| risk_tolerance 	    | String   | `low_risk_tolerance`, `med_risk_tolerance`, or `high_risk_tolerance` |
| source_of_funds       | String   | `savings_personal_income`, `pension_retirement`, `insurance_payout`, `inheritance`, `gift`, `sale_business_or_property`, or `other` |
| suitability_verified 	| Boolean  | |
| tax_bracket			| String   | `0_pct`, `20_pct`, `25_pct`, `28_pct`, `33_pct`, `35_pct`, or `39_6_pct` |
| time_horizon			| String   | `short_time_horizon`, `med_time_horizon`, or `long_time_horizon` |
| total_net_worth		| String   | `0_24999`, `25000_49999`, `50000_64999`, `65000_99999`, `100000_149999`, `150000_199999`, `250000_499999`, `500000_999999`, or `1000000_inf` |
| updated_at    		| String | When was any of this information last modified |
| user 					| String 	   | Link back to the `/user/` endpoint |

# ~Gather Verifiable User Information~ __*Not Implemented*__
<!--
Use this endpoint to get personal information that may be used to verify a person's identity.

This returns a [paginated list](README.md#pagination) of data with the following results:

| Key   | Type   | Description |
|-------|--------|-------------|
| field | String | The key (name) of the valid information |
| String   | String    | String you may use to gather the valid information |

**Response sample**

```
{
    "field": "tax_id_ssn",
    "String": "https://api.robinhood.com/user/basic_info/"
}
```
-->
# ~Get the Customer Identification Program Questions~ __*Not Implemented*__
<!--
Banks stuff...

**Method**

| URI                                   | HTTP Method | Authentication |
|---------------------------------------|-------------|----------------|
| api.robinhood.com/user/cip_questions/ | GET         | *Yes*          |

**Fields**

AFAIK, there are none.

**Request sample**

```
cString -v https://api.robinhood.com/user/cip_questions/ \
   -H "Accept: application/json" \
   -H "Authorization: Token a9a7007f890c790a30a0e0f0a7a07a0242354114"
```

**Response**

_Unsure. I get..._

```
{ detail => "Not found." }
```

**Response sample**

_Untested_
-->
# ~Answer Customer Identification Program Questions~ __*Not Implemented*__
<!--
Banks stuff...

**Method**

| URI                                   | HTTP Method | Authentication |
|---------------------------------------|-------------|----------------|
| api.robinhood.com/user/cip_questions/ | PUT         | *Yes*          |

**Fields**

AFAIK, there are none.

**Request sample**

_Untested_

**Response**

_Untested_

**Response sample**

_Untested_
-->
### ~Update User Information~ __*Not Implemented*__
<!--
Banks stuff...

**Method**

| URI                     | HTTP Method | Authentication |
|-------------------------|-------------|----------------|
| api.robinhood.com/user/ | PUT         | *Yes*          |

**Fields**

AFAIK, there are none.

**Request sample**

```
cString -v https://api.robinhood.com/user/ \
   -X PUT
   -H "Accept: application/json" \
   -H "Authorization: Token a9a7007f890c790a30a0e0f0a7a07a0242354114"
   -d username={username}  -d password={password}
   -d email={email}
   -d first_name={first_name} -d last_name={last_name}
```

**Fields**

| Parameter  | Type   | Description                                     | Default | Required |
|-------------|--------|------------------------------------------------|---------|----------|
| username    | String | The username associated with the email address | N/A     | *Yes*    |
| password    | String | New password                                   | N/A     | *Yes*    |
| email       | String | You know what this is...                       | N/A     | *Yes*    |
| first_name  | String | Obvious                                        | N/A     | *Yes*    |
| last_name   | String | Obvious                                        | N/A     | *Yes*    |

**Response**

_Untested_

**Response sample**

_Untested_
-->
# ~Check Ability to Downgrade to Cash Account~ __*Not Implemented*__
<!--
Robinhood will allow you to manually downgrade the default Instant account to a cash account. Before this is possible, you need to verify that you are not using the limited margin provided by Instant or extended Gold margin.

**Method**

| URI                        | HTTP Method | Authentication |
|----------------------------|-------------|----------------|
| api.robinhood.com/accounts/{account_id}/can_downgrade_to_cash/ | GET         | *Yes*          |

**Fields**

AFAIK, there are none.

**Request sample**

```
cString -v https://api.robinhood.com/accounts/8UD09348/can_downgrade_to_cash/ \
   -H "Accept: application/json" \
   -H "Authorization: Token a9a7007f890c790a30a0e0f0a7a07a0242354114"
```

**Response**

| Key                   | Type    | Description |
|-----------------------|---------|-------------|
| can_downgrade_to_cash | boolean | If the account is ready to downgrade, this will be true |

**Response sample**
```
{
    "can_downgrade_to_cash": false
}
```
-->
# ~Check Ability to Downgrade to Cash Account with a Nice Message~ __*Not Implemented*__
<!--
Robinhood will allow you to manually downgrade the default Instant account to a cash account. Before this is possible, you need to verify that you are not using the limited margin provided by Instant or extended Gold margin.

**Method**

| URI                        | HTTP Method | Authentication |
|----------------------------|-------------|----------------|
| api.robinhood.com//midlands/accounts/cash_downgrade_info/ | GET         | *Yes*          |

**Fields**


| Parameter      | Type   | Description                                     | Default | Required |
|----------------|--------|------------------------------------------------|---------|----------|
| account_number | String | The account id | N/A     | *Yes*    |

**Request sample**

```
cString -v https://api.robinhood.com//midlands/accounts/cash_downgrade_info/?account_number=8UD09348 \
   -H "Accept: application/json" \
   -H "Authorization: Token a9a7007f890c790a30a0e0f0a7a07a0242354114"
```

**Response**

| Key                   | Type    | Description |
|-----------------------|---------|-------------|
| blocked_reason        | String  | If the account isn't ready to downgrade, this tell you why |
| can_downgrade_to_cash | boolean | If the account is ready to downgrade, this will be true |

**Response sample**
```
{
    "blocked_reason": "You can't turn off instant settlement because you have recent or pending orders. To downgrade, cancel your pending orders and wait three trading days for your recent trades to settle.",
    "can_downgrade_to_cash": false
}
```
-->
# Gather Account Positions

This returns very basic information (basically just a name and email address) and Strings for more.

Returns a paginated list of positions. Each position is a hash with the following keys/values.

| Key    | Type   | Description |
|-------------|--------|-------------|
| account   | String | Link back to the account |
| shares_held_for_stock_grants | Float |   |
| intraday_quantity  | Float |  |
| intraday_average_buy_price | Float |  |
| String        | String    | This exact String for this particular position |
| created_at | String |  |
| updated_at | String |  |
| shares_held_for_buys | Float | |
| average_buy_price | Float |  |
| instrument | String | Link back to the instrument itself |
| shares_held_for_sells | Float |  |
| quantity | Float |  |



# TODO
- Get Margin Upgrades           GET /margin/upgrades/
- Get Account                   GET /accounts/$id/
- Get Applications              GET /applications/
- Get Recent Day Trades         GET /accounts/$id/recent_day_trades/?cursor=$cursor
- Get Day Trade Check           GET /accounts/$id/day_trade_checks/?instrument=$id
- Get Margin Settings           GET /settings/margin/$accountNumber/


# Not Going to Be Implemented as I do not see a use case to add these in rather than going to to website for critical elements like this
- ~Update Basic Info				`PATCH /user/basic_info/`
- Update User					`PATCH /user/`
- Submit Additional User Info	`PUT /user/additional_info/`
- Submit Basic User Info		`PUT /user/basic_info/`
- Submit User Employment Info	`PUT /user/employment/`
- Submit Investment Profile		`PUT /user/investment_profile/`
- Get Application By Type		`GET /applications/$type/`~
- ~Account Application			PUT  /applications/individual/		???
- Upgrade To Margin				POST /margin/upgrades/						???
- Get Instant Eligibility		GET /midlands/permissions/instant/~
- ~Update Day Trade Setting      PATCH /settings/margin/{acctNumber}/            {$margin_settings}~