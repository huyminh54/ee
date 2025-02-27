using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Tempcode
	{
		public string Getphone(string api)
		{
			string result = "";
			try
			{
				RestClient restClient = new RestClient("https://tempcode.co/api/orders.php");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.POST);
				restRequest.AddParameter("api_key", api);
				restRequest.AddParameter("act", "buy_number");
				restRequest.AddParameter("service_id", "facebook");
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				if (content.Contains("success\":true"))
				{
					string value = Regex.Match(content, "phonenumber\":\"(.*?)\"").Groups[1].Value;
					string value2 = Regex.Match(content, "order_id\":\"(.*?)\"").Groups[1].Value;
					if (value != "" && value2 != "")
					{
						result = value + "|" + value2;
					}
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
				RestClient restClient = new RestClient("https://tempcode.co/api/orders.php");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.POST);
				restRequest.AddParameter("api_key", api);
				restRequest.AddParameter("act", "read_message");
				restRequest.AddParameter("order_id", id);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				if (content.Contains("success\":true"))
				{
					result = Regex.Match(content, "otp\":\"(.*?)\"").Groups[1].Value;
				}
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
