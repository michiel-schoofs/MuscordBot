using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MuscordBot.Data.Connection
{
	public class JSONConnection
	{
		public string Link { get; set; }
		public JSONConnection(string link)
		{
			Link = link;
		}

		public JObject ApiCall()
		{
			try
			{
				WebClient client = new WebClient();
				Stream stream = client.OpenRead(Link);
				StreamReader reader = new StreamReader(stream);

				JObject jObject = JObject.Parse(reader.ReadLine());

				stream.Close();

				return jObject;

			}
			catch (WebException e) when ((e.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.InternalServerError)
			{
				return (JObject)"Something went wrong...";
			}
		}
	}
}
