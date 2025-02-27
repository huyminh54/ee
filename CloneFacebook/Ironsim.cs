using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Ironsim
	{
		public string Getphone(string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://ironsim.com/api/phone/new-session?token=" + api + "&service=7");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				if (content.Contains("Hết số"))
				{
					return "";
				}
				string value = Regex.Match(content, "phone_number\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "session\":(.*?),").Groups[1].Value;
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
				RestClient restClient = new RestClient("https://ironsim.com/api/session/" + id + "/get-otp?token=" + api);
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
