using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class good9fun
	{
		public string[] server_id = new string[8] { "9", "57", "58", "59", "60", "61", "62", "63" };

		public string get_service(string api)
		{
			RestClient restClient = new RestClient("https://api.good9.fun/api/danhsachungdung");
			restClient.Timeout = -1;
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddParameter("api_key", api);
			IRestResponse restResponse = restClient.Execute(restRequest);
			return restResponse.Content;
		}

		public string GetPhone(string api)
		{
			string result = string.Empty;
			try
			{
				string[] array = server_id;
				string[] array2 = array;
				foreach (string value in array2)
				{
					RestClient restClient = new RestClient("https://api.good9.fun/api/dangkysim");
					restClient.Timeout = -1;
					RestRequest restRequest = new RestRequest(Method.POST);
					restRequest.AddParameter("api_key", api);
					restRequest.AddParameter("appId", value);
					IRestResponse restResponse = restClient.Execute(restRequest);
					string content = restResponse.Content;
					string value2 = Regex.Match(content, "number\":\"(.*?)\"").Groups[1].Value;
					string value3 = Regex.Match(content, "\"id\":(.*?)}").Groups[1].Value;
					if (value2 != "" && value3 != "")
					{
						result = value2 + "|" + value3;
						return result;
					}
				}
			}
			catch
			{
				return result;
			}
			return result;
		}

		public string Getcode(string api, string id)
		{
			string result = string.Empty;
			try
			{
				string requestUriString = "https://api.good9.fun/api/layotpByID";
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Method = "POST";
				httpWebRequest.Accept = "application/json";
				httpWebRequest.ContentType = "application/json";
				string value = "{\"api_key\":\"" + api + "\",\"id\":\"" + id + "\"}";
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(value);
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
				{
					string input = streamReader.ReadToEnd();
					result = Regex.Match(input, "otp\":\"(.*?)\"").Groups[1].Value;
				}
				Console.WriteLine(httpWebResponse.StatusCode);
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
