using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Testbossotp
	{
		public string[] server_id = new string[5] { "636aa9cc99bf428e16368aab", "63388a08b79d6d34b7960566", "63388a19b79d6d34b796056a", "63393797b79d6d34b7960fc3", "633889fdb79d6d34b7960562" };

		public string Getid_request(string api)
		{
			string text = string.Empty;
			string result = string.Empty;
			try
			{
				string[] array = server_id;
				string[] array2 = array;
				foreach (string value in array2)
				{
					RestClient restClient = new RestClient("https://test.bossotp.com/api/v1/rent/");
					restClient.Timeout = -1;
					RestRequest restRequest = new RestRequest(Method.POST);
					restRequest.AddHeader("accept", "application/json");
					restRequest.AddHeader("ContentType", "application/json");
					restRequest.AddHeader("authorization", api);
					restRequest.AddParameter("service_id", value);
					IRestResponse restResponse = restClient.Execute(restRequest);
					string content = restResponse.Content;
					string value2 = Regex.Match(content, "rent_id\":\"(.*?)\"").Groups[1].Value;
					if (!(value2 != "") || value2 == null)
					{
						continue;
					}
					do
					{
						RestClient restClient2 = new RestClient("https://test.bossotp.com/api/v1/rent/" + value2);
						restClient2.Timeout = -1;
						RestRequest restRequest2 = new RestRequest(Method.GET);
						restRequest2.AddHeader("accept", "application/json");
						restRequest2.AddHeader("authorization", api);
						IRestResponse restResponse2 = restClient2.Execute(restRequest2);
						text = restResponse2.Content;
					}
					while (text.Contains("Wait Get Number"));
					if (!text.Contains("Get Number TimeOut"))
					{
						string value3 = Regex.Match(text, "number\":\"(.*?)\"").Groups[1].Value;
						if (value3 != "" && value3 != null)
						{
							result = value3 + "|" + value2;
							break;
						}
					}
				}
				if (text.Contains("Get Number TimeOut"))
				{
					return "Get Number TimeOut";
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
				RestClient restClient = new RestClient("https://test.bossotp.com/api/v1/rent/" + id);
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
