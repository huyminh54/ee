using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Sim24
	{
		public string Getphone(string api)
		{
			string result = "";
			try
			{
				RestClient restClient = new RestClient("https://sim24.cc/api?action=number&service=facebook&apikey=" + api);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "number\":\"(.*?)\"").Groups[1].Value;
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
				RestClient restClient = new RestClient("https://sim24.cc/api?action=code&id=" + id + "&apikey=" + api);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				result = Regex.Match(content, "otp\":\"(.*?)\"").Groups[1].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
