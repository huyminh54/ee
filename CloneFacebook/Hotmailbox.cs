using System.Text.RegularExpressions;
using RestSharp;

namespace CloneFacebook
{
	public class Hotmailbox
	{
		public string Getcode(string hotmail, string passmail)
		{
			string result = string.Empty;
			try
			{
				RestClient restClient = new RestClient("https://getcode.hotmailbox.me/facebook?email=" + hotmail + "&password=" + passmail);
				restClient.Timeout = -1;
				RestRequest restRequest = new RestRequest(Method.GET);
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				IRestResponse restResponse = restClient.Execute(restRequest);
				string content = restResponse.Content;
				result = Regex.Match(content, "VerificationCode\":\"(\\d{5,6})").Groups[1].Value;
			}
			catch
			{
				return result;
			}
			return result;
		}
	}
}
