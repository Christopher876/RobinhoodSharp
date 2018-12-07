# Unofficial Documentation of Robinhood Trade's Private API

Table of Contents:

- [Table of Contents](#table-of-contents)
- [Introduction](#introduction)
	- [Development](#development)
- [API Security](#api-security)
- [API Error Reporting](#api-error-reporting)
- [Pagination](#pagination)
	- [Semi-Pagination](#semi-pagination)

## See also

- [Authentication.md](Authentication.md) for methods related to user authentication, password recovery, etc.
- [Banking.md](Banking.md) for bank accounts & ACH transfers methods
- [Order.md](Order.md) for order-related functions (placing, cancelling, listing previous orders, etc.)
- [Options.md](Options.md) for options related endpoints
- [Quote.md](Quote.md) for stock quotes
- [Fundamentals.md](Fundamentals.md) for basic, fundamental data
- [Instrument.md](Instrument.md) for internal reference to financial instruments
- [Watchlist.md](Watchlist.md) for watchlists management
- [Account.md](Account.md) talks about gathering and modifying user and account information
- [Settings.md](Settings.md) covers notifications and other settings
- [Markets.md](Markets.md) describes the API for getting basic info about specific exchanges themselves
- [Referrals.md](Referrals.md) is all about account referrals
- [Statistics.md](Statistics.md) exposes the new social/statistical endpoints
- [Tags.md](Tags.md) exposes the new categorizing endpoints

Things I have yet to organize are in [Unsorted.md](Unsorted.md)

# Introduction

[Robinhood](http://robinhood.com/) is a commission-free, online securities brokerage. As you would expect, being an online service means everything is handled through a request that is made to a specific URL.

# Pagination

Not many pieces of data return a next area in my experience while wrapping the API in C# so the occurences where pagination is necessary is slim. Areas where there is a next or previous pagination return will be documented. To call the next pagination, call the same method and instead of an empty parameter, use the next string.

## Semi-Pagination

I have already handled this and organized the data.
