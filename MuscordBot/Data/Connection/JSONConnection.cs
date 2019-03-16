using Newtonsoft.Json;
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

		public JObject ApiCall(string link)
		{
			try
			{
				WebClient client = new WebClient();
				Stream stream = client.OpenRead(link);
				//StreamReader reader = new StreamReader(stream);
                JsonTextReader reader = new JsonTextReader(new StreamReader(stream));

                JObject jObject = JObject.Parse(reader.ReadAsString());

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
