using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Goodotp
	{
		public string get_service(string api)
		{
			RestClient restClient = new RestClient("https://api.goodotp.xyz/api/danhsachungdung");
			restClient.Timeout = -1;
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddParameter("api_key", api);
			IRestResponse restResponse = restClient.Execute(restRequest);
			string content = restResponse.Content;
			return "";
		}

		public string GetPhone(string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://api.goodotp.xyz/api/dangkysim");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.POST);
				restRequest.AddParameter("api_key", api);
				restRequest.AddParameter("appId", "9");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "number\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "\"id\":(.*?)}").Groups[1].Value;
				if (value != "" && value2 != "")
				{
					result = value + "|" + value2;
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
				string requestUriString = "https://api.goodotp.xyz/api/layotpByID";
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
