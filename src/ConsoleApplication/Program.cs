﻿using ExactOnline.Client.Models;
using ExactOnline.Client.Sdk.Controllers;
using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApplication
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			// These are the authorisation properties of your app.
			// You can find the values in the App Center when you are maintaining the app.
            const string clientId = "wcq4xgyjo823b0v";
            const string clientSecret = "vukz3fusvkt58rm";

			// This can be any url as long as it is identical to the callback url you specified for your app in the App Center.
			var callbackUrl = new Uri("https://github.com/artzain/gorkasapp"); 

            var connector = new Connector(clientId, clientSecret, callbackUrl);
			var client = new ExactOnlineClient(connector.EndPoint, connector.GetAccessToken);

			// Get the Code and Name of a random account in the administration
			var fields = new[] { "Code", "Name" };
			var account = client.For<Account>().Top(1).Select(fields).Get().FirstOrDefault();

			Debug.WriteLine("Account {0} - {1}", account.Code.TrimStart(), account.Name);
            
            
		}
	}
}
