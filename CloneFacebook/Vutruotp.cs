using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Vutruotp
	{
		public string Getphone(string api)
		{
			string result = "";
			try
			{
				RestClient restClient = new RestClient("http://vutruotp.xyz/api/v1/order");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.POST);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				restRequest.AddHeader("Authorization", "OTP " + api);
				restRequest.AddParameter("service", "38");
				restRequest.AddParameter("provider", "Vietnamobile");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "phoneNumber\":\"(.*?)\"").Groups[1].Value;
				string value2 = Regex.Match(content, "id\":(.*?),").Groups[1].Value;
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
			string text = "";
			try
			{
				RestClient restClient = new RestClient("http://vutruotp.xyz/api/v1/order/" + id);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				restRequest.AddHeader("Authorization", "OTP " + api);
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "content\":\"(.*?)\"").Groups[1].Value;
				text = Regex.Match(value, "(\\d{6})").Groups[1].Value;
				if (text == "")
				{
					text = Regex.Match(value, "(\\d{5})").Groups[1].Value;
				}
			}
			catch
			{
				return text;
			}
			return text;
		}
	}
}
