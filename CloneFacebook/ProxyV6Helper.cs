using System.Text.RegularExpressions;
using System.Threading;
using RestSharp;

namespace CloneFacebook
{
	public class ProxyV6Helper
	{
		public static bool Changeip(string api, string ip, string port)
		{
			try
			{
				RestClient restClient = new RestClient("https://api.proxyv6.net/api/reset-ip-manual?api_key=" + api + "&host=" + ip + "&port=" + port);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "message\":\"(.*?)\"").Groups[1].Value;
				if (value == "SUCCESS")
				{
					return true;
				}
				if (value == "RESET_TOO_FAST")
				{
					Thread.Sleep(1000);
					return false;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}

		public static bool Check_rotating_v6(string api, string ip, string port)
		{
			try
			{
				RestClient restClient = new RestClient("https://api.proxyv6.net/api/get-change-ip-status?api_key=" + api + "&host=" + ip + "&port=" + port);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				string value = Regex.Match(content, "resetIpStatus\":\"(.*?)\"").Groups[1].Value;
				if (value == "done")
				{
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}
	}
}
