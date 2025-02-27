using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using xNet;

namespace CloneFacebook
{
	public class Omocaptcha
	{
		public static string Base64Decode(string base64Encoded)
		{
			byte[] bytes = Convert.FromBase64String(base64Encoded);
			return Encoding.UTF8.GetString(bytes);
		}

		public string get_captcha_persist(string pagesource)
		{
			return Regex.Match(pagesource, "captcha_persist_data\" value=\"(.*?)\"").Groups[1].Value;
		}

		public string GetRecaptchaResponse(string api, string yyyy)
		{
			string result = "";
			string empty = string.Empty;
			try
			{
				HttpRequest httpRequest = new HttpRequest();
				httpRequest.KeepAlive = true;
				httpRequest.Cookies = new CookieDictionary();
				httpRequest.AddHeader(HttpHeader.Accept, "application/json, text/javascript, */*; q=0.01");
				httpRequest.AddHeader(HttpHeader.AcceptLanguage, "en-US,en;q=0.5");
				httpRequest.UserAgent = Http.ChromeUserAgent();
				string text = Base64Decode("ewogICAgImFwaV90b2tlbiI6ICJ4eHh4eHh4eHgiLAogICAgImRhdGEiOiB7CiAgICAgICAgInR5cGVfam9iX2lkIjogIjQxIiwKICAgICAgICAiaW5wdXQiOiAieXl5eXl5eXl5IgogICAgfQp9");
				text = text.Replace("xxxxxxxxx", api);
				text = text.Replace("yyyyyyyyy", yyyy);
				string text2 = httpRequest.Post("https://omocaptcha.com/api/createJob", text, "application/json").ToString();
				if (text2.Contains("error\":false"))
				{
					string value = Regex.Match(text2, "job_id\":(.*?),").Groups[1].Value;
					string text3 = Base64Decode("ewogICAgImFwaV90b2tlbiI6Inl5eXl5eXl5eSIsCiAgICAiam9iX2lkIjogeHh4Cn0=");
					text3 = text3.Replace("yyyyyyyyy", api);
					text3 = text3.Replace("xxx", value);
					Thread.Sleep(1000);
					for (int i = 0; i < 62; i++)
					{
						text2 = httpRequest.Post("https://omocaptcha.com/api/getJobResult", text3, "application/json").ToString();
						if (!text2.Contains("running") && !text2.Contains("status\":\"fail"))
						{
							return Regex.Match(text2, "result\":\"(.*?)\"").Groups[1].Value;
						}
						if (text2.Contains("status\":\"fail"))
						{
							return "Get new";
						}
						Thread.Sleep(1000);
						if (i > 60)
						{
							Console.WriteLine("Time out!!!");
							return "Get new";
						}
					}
				}
				return result;
			}
			catch
			{
				return "Get new";
			}
		}
	}
}
