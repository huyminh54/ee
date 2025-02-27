using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace CloneFacebook
{
	// Token: 0x0200002D RID: 45
	public class RequestFacebook
	{
		// Token: 0x0600017C RID: 380 RVA: 0x0005A88C File Offset: 0x00058A8C
		public RequestFacebook()
		{
			this._cookieContainer = new CookieContainer();
			this._handler = new HttpClientHandler
			{
				AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate),
				CookieContainer = this._cookieContainer
			};
			this._client = new HttpClient(this._handler);
			this._client.Timeout = new TimeSpan(0, 2, 0);
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600017D RID: 381 RVA: 0x0005A8F4 File Offset: 0x00058AF4
		// (set) Token: 0x0600017E RID: 382 RVA: 0x0005A8FC File Offset: 0x00058AFC
		private HttpClientHandler _handler { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600017F RID: 383 RVA: 0x0005A905 File Offset: 0x00058B05
		// (set) Token: 0x06000180 RID: 384 RVA: 0x0005A90D File Offset: 0x00058B0D
		private HttpClient _client { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000181 RID: 385 RVA: 0x0005A916 File Offset: 0x00058B16
		// (set) Token: 0x06000182 RID: 386 RVA: 0x0005A91E File Offset: 0x00058B1E
		private CookieContainer _cookieContainer { get; set; }

		// Token: 0x06000183 RID: 387 RVA: 0x0005A928 File Offset: 0x00058B28
		public void SetProxy(string ip, string port, string username = null, string password = null)
		{
			bool flag = !string.IsNullOrEmpty(ip) && !string.IsNullOrEmpty(port) && string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password);
			bool flag2 = flag;
			if (flag2)
			{
				WebProxy webProxy = new WebProxy
				{
					Address = new Uri("http://" + ip + ":" + port),
					BypassProxyOnLocal = false,
					UseDefaultCredentials = false
				};
				this._handler.Proxy = webProxy;
			}
			bool flag3 = !string.IsNullOrEmpty(ip) && !string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
			bool flag4 = flag3;
			if (flag4)
			{
				WebProxy webProxy2 = new WebProxy
				{
					Address = new Uri("http://" + ip + ":" + port),
					BypassProxyOnLocal = false,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(username, password)
				};
				this._handler.Proxy = webProxy2;
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0005AA20 File Offset: 0x00058C20
		public void SetHeader(Dictionary<string, string> headers, bool isClear = false)
		{
			if (isClear)
			{
				this._client.DefaultRequestHeaders.Clear();
			}
			foreach (KeyValuePair<string, string> keyValuePair in headers)
			{
				this._client.DefaultRequestHeaders.TryAddWithoutValidation(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0005AAA4 File Offset: 0x00058CA4
		public void SetHeader(List<KeyValuePair<string, string>> headers, bool isClear = false)
		{
			if (isClear)
			{
				this._client.DefaultRequestHeaders.Clear();
			}
			foreach (KeyValuePair<string, string> keyValuePair in headers)
			{
				this._client.DefaultRequestHeaders.TryAddWithoutValidation(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0005AB28 File Offset: 0x00058D28
		public void SetCookie(string cookieInput, string path, string domain)
		{
			string[] array = cookieInput.Split(new char[] { ';' });
			foreach (string text in array)
			{
				string[] array3 = text.Split(new char[] { '=' });
				bool flag = string.IsNullOrEmpty(text);
				bool flag2 = !flag;
				if (flag2)
				{
					bool flag3 = array3.Length != 2;
					bool flag4 = !flag3;
					if (flag4)
					{
						try
						{
							string text2 = array3[0].Trim();
							string text3 = array3[1].Trim();
							Cookie cookie = new Cookie(text2, text3, path, domain);
							this._cookieContainer.Add(cookie);
						}
						catch (Exception ex)
						{
							throw ex;
						}
					}
				}
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0005ABF4 File Offset: 0x00058DF4
		public void SetCookie(List<Cookie> cookies)
		{
			foreach (Cookie cookie in cookies)
			{
				try
				{
					this._cookieContainer.Add(cookie);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0005AC64 File Offset: 0x00058E64
		public string GetCookie(string url)
		{
			bool flag = string.IsNullOrEmpty(url);
			bool flag2 = flag;
			if (flag2)
			{
				throw new Exception("Url Is Null");
			}
			bool flag3 = this._cookieContainer == null;
			bool flag4 = flag3;
			string text;
			if (flag4)
			{
				text = null;
			}
			else
			{
				string text2 = null;
				Uri uri = new Uri(url);
				List<Cookie> list = this._cookieContainer.GetCookies(uri).Cast<Cookie>().ToList<Cookie>();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					bool flag5 = i + 1 == count;
					bool flag6 = flag5;
					if (flag6)
					{
						text2 = text2 + list[i].Name + "=" + list[i].Value;
						break;
					}
					text2 = string.Concat(new string[]
					{
						text2,
						list[i].Name,
						"=",
						list[i].Value,
						";"
					});
				}
				text = text2;
			}
			return text;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0005AD80 File Offset: 0x00058F80
		public string Get(string url)
		{
			HttpResponseMessage result = this._client.GetAsync(url).Result;
			byte[] result2 = result.Content.ReadAsByteArrayAsync().Result;
			return Encoding.UTF8.GetString(result2, 0, result2.Length);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0005ADC4 File Offset: 0x00058FC4
		public string Post(string url, Dictionary<string, string> dataPost)
		{
			HttpResponseMessage result = this._client.PostAsync(url, new FormUrlEncodedContent(dataPost)).Result;
			byte[] result2 = result.Content.ReadAsByteArrayAsync().Result;
			return Encoding.UTF8.GetString(result2, 0, result2.Length);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0005AE10 File Offset: 0x00059010
		public string Post(string url, List<KeyValuePair<string, string>> dataPost)
		{
			HttpResponseMessage result = this._client.PostAsync(url, new FormUrlEncodedContent(dataPost)).Result;
			byte[] result2 = result.Content.ReadAsByteArrayAsync().Result;
			return Encoding.UTF8.GetString(result2, 0, result2.Length);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0005AE5C File Offset: 0x0005905C
		public string Download(string url)
		{
			string text = Application.StartupPath + "\\Image\\" + Guid.NewGuid().ToString() + ".png";
			using (HttpResponseMessage result = this._client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).Result)
			{
				result.EnsureSuccessStatusCode();
				using (FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
				{
					result.Content.CopyToAsync(fileStream).Wait();
				}
			}
			return text;
		}
	}
}
