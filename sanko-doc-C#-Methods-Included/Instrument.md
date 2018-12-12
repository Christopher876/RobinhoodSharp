# Financial Instrument Information Methods

- [Grab a list of All Instruments](#grab-a-list-of-all-instruments)
- [Gather Basic Instrument Info by Symbol](#gather-basic-instrument-info-by-symbol)
- [Gather Basic Instrument Info by ID](#gather-basic-instrument-info-by-id)
- [Search for Instruments by Keyword](#search-for-instruments-by-keyword)
- [Gather the Split History for an Instrument](#gather-the-split-history-for-an-instrument)
- [Grab Data on a Single Split](#grab-data-on-a-single-split)

# Grab a List of All Instruments

This returns a paginated list of all instruments tracked by Robinhood's partners sorted by their list date. You get everything with this: OTC, NASDAQ CM, ... There are currently 99 pages, 9,825 instruments in total, and 7197 are tradeable with Robinhood.

| Key                   | Type       | Description |
|-----------------------|------------|-------------|
| min_tick_size         | Float      | Note: Might be null. See http://www.finra.org/industry/tick-size-pilot-program |
| splits                | URL        | Link to the split list for this security |
| margin_initial_ratio  | Float      |                                          |
| url 					| URL 	     | Endpoint where more information about this security may be grabbed |
| quote 				| URL 	     | Endpoint where quote data about this security may be grabbed |
| symbol                | String     | The ticker symbol for this security |
| bloomberg_unique      | String     | Bloomberg Global ID (BBGID) for this security. See http://bsym.bloomberg.com/sym/ |
| list_date             | YYYY-MM-DD | Date this security was first traded publically on the exchange |
| fundamentals          | URL        | Link to fundamental data for this security |
| state                 | String     | Indicates whether the security is "active" or not |
| country               | String     | Two char country code for the security's home office or headquarters |
| day_trade_ratio       | Float      |  |
| tradeable             | Boolean    | Indicates whether the security can be traded on Robinhood |
| maintenance_ratio     | Float      |  |
| id                    | String     | The instrument id of this security |
| market                | URL        | Link to the market/exchange this security is traded on |
| name                  | String     | Basic name of the security. Perfect for display |


# Gather Basic Instrument Info by Symbol


| Key                   | Type       | Description |
|-----------------------|------------|-------------|
| min_tick_size         | Float      | Note: Might be null. See http://www.finra.org/industry/tick-size-pilot-program |
| splits                | URL        | Link to the split list for this security |
| margin_initial_ratio  | Float      |                                          |
| url 					| URL 	     | Endpoint where more information about this security may be grabbed |
| quote 				| URL 	     | Endpoint where quote data about this security may be grabbed |
| symbol                | String     | The ticker symbol for this security |
| bloomberg_unique      | String     | Bloomberg Global ID (BBGID) for this security. See http://bsym.bloomberg.com/sym/ |
| list_date             | YYYY-MM-DD | Date this security was first traded publically on the exchange |
| fundamentals          | URL        | Link to fundamental data for this security |
| state                 | String     | Indicates whether the security is "active" or not |
| country               | String     | Two char country code for the security's home office or headquarters |
| day_trade_ratio       | Float      |  |
| tradeable             | Boolean    | Indicates whether the security can be traded on Robinhood |
| maintenance_ratio     | Float      |  |
| id                    | String     | The instrument id of this security |
| market                | URL        | Link to the market/exchange this security is traded on |
| name                  | String     | Basic name of the security. Perfect for display |


# Gather Basic Instrument Info by ID


| Key                   | Type       | Description |
|-----------------------|------------|-------------|
| min_tick_size         | Float      | Note: Might be null. See http://www.finra.org/industry/tick-size-pilot-program |
| splits                | URL        | Link to the split list for this security |
| margin_initial_ratio  | Float      |                                          |
| url 					| URL 	     | Endpoint where more information about this security may be grabbed |
| quote 				| URL 	     | Endpoint where quote data about this security may be grabbed |
| symbol                | String     | The ticker symbol for this security |
| bloomberg_unique      | String     | Bloomberg Global ID (BBGID) for this security. See http://bsym.bloomberg.com/sym/ |
| list_date             | YYYY-MM-DD | Date this security was first traded publically on the exchange |
| fundamentals          | URL        | Link to fundamental data for this security |
| state                 | String     | Indicates whether the security is "active" or not |
| country               | String     | Two char country code for the security's home office or headquarters |
| day_trade_ratio       | Float      |  |
| tradeable             | Boolean    | Indicates whether the security can be traded on Robinhood |
| maintenance_ratio     | Float      |  |
| id                    | String     | The instrument id of this security |
| market                | URL        | Link to the market/exchange this security is traded on |
| name                  | String     | Basic name of the security. Perfect for display |


# Search for Instruments by Keyword


| Key                   | Type       | Description |
|-----------------------|------------|-------------|
| min_tick_size         | Float      | Note: Might be null. See http://www.finra.org/industry/tick-size-pilot-program |
| splits                | URL        | Link to the split list for this security |
| margin_initial_ratio  | Float      |                                          |
| url 					| URL 	     | Endpoint where more information about this security may be grabbed |
| quote 				| URL 	     | Endpoint where quote data about this security may be grabbed |
| symbol                | String     | The ticker symbol for this security |
| bloomberg_unique      | String     | Bloomberg Global ID (BBGID) for this security. See http://bsym.bloomberg.com/sym/ |
| list_date             | YYYY-MM-DD | Date this security was first traded publically on the exchange |
| fundamentals          | URL        | Link to fundamental data for this security |
| state                 | String     | Indicates whether the security is "active" or not |
| country               | String     | Two char country code for the security's home office or headquarters |
| day_trade_ratio       | Float      |  |
| tradeable             | Boolean    | Indicates whether the security can be traded on Robinhood |
| maintenance_ratio     | Float      |  |
| id                    | String     | The instrument id of this security |
| market                | URL        | Link to the market/exchange this security is traded on |
| name                  | String     | Basic name of the security. Perfect for display |



# Gather the Split History for an Instrument

This returns a paginated list of stock splits for this instrument.

| Key            | Type       | Description |
|----------------|------------|-------------|
| url 			 | URL 	      | Endpoint where more information about this particular split |
| instrument     | URL        | Link back to the instrument |
| execution_date | YYYY-MM-DD | The date this split goes into effect |
| divisor        | Float      | |
| multiplier     | Float      | |

# Grab Data on a Single Split

This returns a paginated list of stock splits for this instrument.

A single split data is returned. A split contains the following keys...

| Key            | Type       | Description |
|----------------|------------|-------------|
| url 			 | URL 	      | Endpoint where more information about this particular split |
| instrument     | URL        | Link back to the instrument |
| execution_date | YYYY-MM-DD | The date this split goes into effect |
| divisor        | Float      | |
| multiplier     | Float      | |