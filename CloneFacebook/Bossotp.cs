using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Bossotp
	{
		public string Getid_request(string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://bossotp.com/api/v1/rent/");
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.POST);
				restRequest.AddHeader("accept", "application/json");
				restRequest.AddHeader("ContentType", "application/json");
				restRequest.AddHeader("authorization", api);
				restRequest.AddParameter("service_id", "62f0f768356bad8d81b3ac7b");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				result = Regex.Match(content, "rent_id\":\"(.*?)\"").Groups[1].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}

		public string Getphonefromid(string id, string api)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://bossotp.com/api/v1/rent/" + id);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("accept", "application/json");
				restRequest.AddHeader("authorization", api);
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				if (content.Contains("Get Number TimeOut"))
				{
					return "Get Number TimeOut";
				}
				result = Regex.Match(content, "number\":\"(.*?)\"").Groups[1].Value;
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
				RestClient restClient = new RestClient("https://bossotp.com/api/v1/rent/" + id);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("accept", "application/json");
				restRequest.AddHeader("authorization", api);
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				if (content.Contains("Get SMS TimeOut"))
				{
					return "Get SMS TimeOut";
				}
				result = Regex.Match(content, "sms_content(.*?)(\\d{5,6})").Groups[2].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
