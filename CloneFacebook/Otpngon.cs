using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Otpngon
	{
		public string Getphone(string api)
		{
			string result = "";
			try
			{
				RestClient restClient = new RestClient("https://otpngon.com/public/api/getNumber?api_key=" + api + "&service_id=1");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "Phone\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "Request_ID\":\"(.*?)\"").Groups[1].Value;
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
				RestClient restClient = new RestClient("https://otpngon.com/public/api/getOTP?api_key=" + api + "&request_id=" + id);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				result = Regex.Match(content, "OTP\":\"(.*?)\"").Groups[1].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
