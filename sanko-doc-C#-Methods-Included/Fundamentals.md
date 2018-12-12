# Fundamentals

- [Gather Fundamental Data by Ticker Symbol](#gather-fundamental-data-by-ticker-symbol)
- [Gather Fundamental Data for Multiple Ticker Symbols in a Single API Call](#gather-fundamental-data-for-multiple-ticker-symbols-in-a-single-api-call)

# Gather Fundamental Data by Ticker Symbol



| Key            | Type   | Description |
|----------------|--------|-------------|
| open           | Float  | The price at open |
| high           | Float  | The highest trade price since open |
| low            | Float  | The lowest trade price since open |
| volume         | Float  |  |
| average_volume | Float  |  |
| high_52_weeks  | Float  | The highest trade price in the last 52 weeks |
| low_52_weeks   | Float  | The lowest trade price in the last 52 weeks |
| market_cap     | Float  |  |
| dividend_yield | Float  |  |
| pe_ratio       | Float  | Note: Might be null. |
| description    | String | Long description of security suited for display |
| instrument     | URL    | Link back to this security's instrument data |


# Gather Fundamental Data for Multiple Ticker Symbols in a Single API Call

You can gather data for a list of symbols at once by handing the bare `/fundamentals` path a `symbols` query filled with comma separated symbols. Please note that the API will only allow you to request up to ten symbols at a time.



| Key            | Type   | Description |
|----------------|--------|-------------|
| open           | Float  | The price at open |
| high           | Float  | The highest trade price since open |
| low            | Float  | The lowest trade price since open |
| volume         | Float  |  |
| average_volume | Float  |  |
| high_52_weeks  | Float  | The highest trade price in the last 52 weeks |
| low_52_weeks   | Float  | The lowest trade price in the last 52 weeks |
| market_cap     | Float  |  |
| dividend_yield | Float  |  |
| pe_ratio       | Float  | Note: Might be null. |
| description    | String | Long description of security suited for display |
| instrument     | URL    | Link back to this security's instrument data |