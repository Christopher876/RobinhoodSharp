using System;
using System.Collections.Generic;
using System.Text;

namespace Robinhood
{
	class Endpoints
	{
		public static string baseurl = "https://api.robinhood.com";
		private string _login;

		public string login{
			get
			{
				_login = baseurl + "/oauth2/token/";
				return _login;
			}
		}
	}
}
