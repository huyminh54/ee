using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Sell282xyz
	{
		public string Getphone(string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://sell282.xyz/api/sim/buy?api_key=" + api + "&service=9");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "phone\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "code_order\":(.*?),").Groups[1].Value;
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

		public string Getcode(string id, string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://sell282.xyz/api/sim/code?api_key=" + api + "&code_order=" + id);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				result = Regex.Match(content, "code\":\"(\\d+)").Groups[1].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
