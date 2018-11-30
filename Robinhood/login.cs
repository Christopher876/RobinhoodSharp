using System;
using System.Collections.Generic;
using System.Text;

namespace Robinhood
{
	class Login
	{
		private string _username = "default";
		private string _password = "default";
		private string _accessKey;
		private string _refreshToken;
		private int _tokenReceived;
		private int _tokenExpires;

		public string AccessToken
		{
			get { return _accessKey; }
			set { _accessKey = value;}
		}

		public string username
		{
			get { return _username; }
			set { _username = value; }
		}

		public string password
		{
			get { return _password; }
			set { _password = value; }
		}

		public string refreshToken
		{
			get { return _refreshToken; }
			set { _refreshToken = value; }
		}

		public int TokenReceived
		{
			get { return _tokenReceived; }
			set { _tokenReceived = value; }
		}

		public int TokenExpired
		{
			get { return _tokenExpires; }
			set { _tokenExpires = value; }
		}
	}
}
