using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using xNet;

namespace CloneFacebook
{
	public class TwoCaptcha
	{
		public static string SloveCaptcha(string apikey)
		{
			string result = "";
			try
			{
				HttpRequest httpRequest = new HttpRequest();
				httpRequest.KeepAlive = true;
				httpRequest.Cookies = new CookieDictionary();
				httpRequest.AddHeader(HttpHeader.Accept, "application/json, text/javascript, */*; q=0.01");
				httpRequest.AddHeader(HttpHeader.AcceptLanguage, "en-US,en;q=0.5");
				httpRequest.UserAgent = Http.ChromeUserAgent();
				string text = httpRequest.Get("https://2captcha.com/in.php?key=" + apikey + "&method=userrecaptcha&googlekey=6Lc9qjcUAAAAADTnJq5kJMjN9aD1lxpRLMnCS2TR&pageurl=https://fbsbx.com/captcha/recaptcha/iframe/?referer=https://m.facebook.com").ToString();
				if (text.StartsWith("OK|"))
				{
					string value = Regex.Match(text, "(\\d+)").Groups[1].Value;
					Thread.Sleep(1000);
					int num = 0;
					while (num < 62)
					{
						text = httpRequest.Get("https://2captcha.com/res.php?key=" + apikey + "&action=get&id=" + value).ToString();
						if (!text.StartsWith("OK|"))
						{
							if (text.Contains("CAPCHA_NOT_READY"))
							{
								Thread.Sleep(5000);
							}
							else if (text.Contains("ERROR_CAPTCHA_UNSOLVABLE"))
							{
								return result;
							}
							Thread.Sleep(1000);
							if (num > 60)
							{
								Console.WriteLine("Time out!!!");
								return result;
							}
							num++;
							continue;
						}
						string value2 = Regex.Match(text, "OK.(.*?)$").Groups[1].Value;
						result = value2;
						goto end_IL_0007;
					}
				}
				else if (text.Contains("ERROR_WRONG_USER_KEY"))
				{
					result = "ERROR_WRONG_USER_KEY";
					return result;
				}
				return result;
				end_IL_0007:;
			}
			catch
			{
				return result;
			}
			return result;
		}

		public bool SolveNormalCapcha(string APIKey, string base64Image, out string result)
		{
			string text = "";
			string text2 = "2captcha.com";
			using (WebClient webClient = new WebClient())
			{
				NameValueCollection nameValueCollection = new NameValueCollection();
				nameValueCollection["method"] = "base64";
				nameValueCollection["key"] = APIKey;
				nameValueCollection["body"] = base64Image;
				byte[] bytes = webClient.UploadValues("http://" + text2 + "/in.php", nameValueCollection);
				text = Encoding.Default.GetString(bytes);
			}
			Thread.Sleep(TimeSpan.FromSeconds(5.0));
			if (text.Substring(0, 3) == "OK|")
			{
				string text3 = text.Remove(0, 3);
				for (int i = 0; i < 24; i++)
				{
					WebRequest webRequest = WebRequest.Create("http://" + text2 + "/res.php?key=" + APIKey + "&action=get&id=" + text3);
					using (WebResponse webResponse = webRequest.GetResponse())
					{
						StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
						string text4 = streamReader.ReadToEnd();
						if (text4.Length < 3)
						{
							result = text4;
							return false;
						}
						if (text4.Substring(0, 3) == "OK|")
						{
							result = text4.Remove(0, 3);
							return true;
						}
						if (text4 != "CAPCHA_NOT_READY")
						{
							result = text4;
							return false;
						}
					}
					Thread.Sleep(5000);
				}
				result = "Timeout";
				return false;
			}
			result = text;
			return false;
		}

		public static string ResloveNormalCaptcha(string captchaKey, string imgBase64)
		{
			string result = "";
			TwoCaptcha twoCaptcha = new TwoCaptcha();
			bool flag = twoCaptcha.SolveNormalCapcha(captchaKey, imgBase64, out result);
			while (!flag)
			{
				flag = twoCaptcha.SolveNormalCapcha(captchaKey, imgBase64, out result);
				Thread.Sleep(TimeSpan.FromSeconds(2.0));
			}
			return result;
		}
	}
}
