using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Otp282
	{
		public string Getphone(string api)
		{
			string result = "";
			try
			{
				RestClient restClient = new RestClient("https://otp282.com/api/createRequestOTP/" + api + "/service_id/1");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "phone\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "request_id\":\"(.*?)\"").Groups[1].Value;
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
				RestClient restClient = new RestClient("https://otp282.com/api/getOTPCode/" + api + "/request_id/" + id);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				result = Regex.Match(content, "otpcode\":\"(.*?)\"").Groups[1].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
