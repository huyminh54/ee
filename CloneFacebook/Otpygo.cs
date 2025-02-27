using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Otpygo
	{
		public string Getphone_VN(string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://otpygo.com/getnumber/" + api);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "phone\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "odid\":(.*?),").Groups[1].Value;
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

		public string Getcode(string id)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://otpygo.com/getotp/" + id);
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
