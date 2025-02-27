using System.Text.RegularExpressions;
using Leaf.xNet;

namespace CloneFacebook
{
	public class Emailfaker
	{
		public string Getcode(string email)
		{
			string text = string.Empty;
			try
			{
				HttpRequest httpRequest = new HttpRequest();
				httpRequest.KeepAlive = true;
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 Edg/90.0.818.62";
				string input = httpRequest.Get("https://api.emailfake.com/" + email).ToString();
				MatchCollection matchCollection = Regex.Matches(input, "registration@facebookmail.com(.*?)\">(\\d{5,6})");
				text = matchCollection[0].Groups[2].Value;
				if (text == "" || text == null)
				{
					MatchCollection matchCollection2 = Regex.Matches(input, "https://www.facebook.com/checkpoint(.*?)code=(\\d{5,6})");
					text = matchCollection2[0].Groups[2].Value;
				}
			}
			catch
			{
			}
			return text;
		}

		public string Getmail()
		{
			string result = string.Empty;
			try
			{
				HttpRequest httpRequest = new HttpRequest();
				httpRequest.KeepAlive = true;
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 Edg/90.0.818.62";
				string input = httpRequest.Get("https://api.emailfake.com/").ToString();
				result = Regex.Match(input, "email_ch_text\">(.*?)<").Groups[1].Value;
			}
			catch
			{
			}
			return result;
		}
	}
}
