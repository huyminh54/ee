using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Numberotp
	{
		public string Getphone_VN(string api)
		{
			string result = "";
			try
			{
				RestClient restClient = new RestClient("https://numberotp.co/public/api/gsm/order/facebook/" + api);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "phoneNumber\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "id\":\"(.*?)\"").Groups[1].Value;
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

		public string Getphone_US(string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://numberotp.co/public/api/gsm/order/facebook/" + api + "?server=us");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "phoneNumber\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "id\":\"(.*?)\"").Groups[1].Value;
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
			string result = "";
			try
			{
				RestClient restClient = new RestClient("https://numberotp.co/public/api/gsm/get-order/" + id + "/" + api);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				if (content.Contains("status\":\"Failed"))
				{
					return "TimeOut";
				}
				result = Regex.Match(content, "otp(.*?)(\\d{5,6})\"").Groups[2].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
