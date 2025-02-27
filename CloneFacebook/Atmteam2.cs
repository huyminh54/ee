using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Atmteam2
	{
		public string Getphone(string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://tskvb.com/pick_isdn?service=Facebook&apikey=" + api);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "isdn\": \"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "id\": \"(.*?)\"").Groups[1].Value;
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
				RestClient restClient = new RestClient("https://tskvb.com/Getcodeotp?id_order=" + id + "&apikey=" + api);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				result = Regex.Match(content, "content\": \"(\\d+)").Groups[1].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
