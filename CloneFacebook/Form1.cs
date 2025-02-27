using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using A_A_A;
using ChangerClone;
using CloneFacebook.ChildForm;
using CloneFacebook.Server;
using CloneFacebook.Server.DataPost;
using CreateFacebookRequest;
using DELETEPHONE_VIA;
using DeviceId;
using Duongvanhung_282;
using FBAutoKitDo.Helper;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chrome.ChromeDriverExtensions;
using OpenQA.Selenium.Support.UI;
using OtpNet;
using PHUONGDOAN;
using RestSharp;
using VERIFY_CLONE.MAIL;
using xNet;

namespace CloneFacebook
{
	public class Form1 : Form
	{
		public string username_tool;

		public List<Thread> ListThread_via = new List<Thread>();

		public List<Thread> ListThread_login = new List<Thread>();

		public bool IsRunning = false;

		public bool IsRunning_live_uid = false;

		public bool IsRunning_2FA = false;

		public bool IsRunning_login = false;

		public bool isstop;

		private static int getWidthScreen;

		private static int getHeightScreen;

		private const int GWL_STYLE = -4;

		private const int WS_THICKFRAME = 262144;

		private const int WS_CAPTION = 12582912;

		private const int WS_CHILD = 1073741824;

		private static readonly int WS_VISIBLE;

		private string[] list_lastname;

		private string[] list_firstname;

		public static int Num_LuongProxyAPI;

		public int threadcount = 0;

		public List<Thread> ListThread = new List<Thread>();

		public List<Thread> ListThread_Live_Uid = new List<Thread>();

		public List<Thread> ListThread_2FA = new List<Thread>();

		public static Thread thread;

		public List<string> listapi = new List<string>();

		public string[] mangproxy;

		public string[] manguser_agent;

		public string linkserver_mobiproxy;

		public string api_proxyv6;

		private int tongreg = 0;

		private Random rd = new Random();

		private string svUrl = "http://proxy.tinsoftsv.com";

		private string svUrl_proxyfb = "http://api.proxyfb.com";

		private int tongphone = 0;

		private int susscess_code = 0;

		private int false_code = 0;

		private int count_dem_proxyhttp = 0;

		private string Path_Tool = Path.GetDirectoryName(Application.ExecutablePath);

		public string[] country_random_name = new string[81]
		{
			"albania", "argentina", "armenia", "australia", "austria", "bangladesh", "belgium", "brazil", "bulgaria", "canada",
			"chile", "china", "colombia", "croatia", "cyprus", "czechia", "denmark", "dominican-republic", "estonia", "finland",
			"france", "georgia", "germany", "greece", "hong-kong-sar-china", "hungary", "iceland", "india", "indonesia", "iran",
			"ireland", "israel", "italy", "japan", "jordan", "kazakhstan", "latvia", "lithuania", "luxembourg", "malaysia",
			"mexico", "moldova", "mongolia", "montenegro", "nepal", "netherlands", "new-zealand", "nigeria", "norway", "panama",
			"peru", "philippines", "poland", "portugal", "qatar", "romania", "russia", "saudi-arabia", "serbia", "singapore",
			"singapore-chinese", "singapore-indian", "singapore-malay", "slovakia", "slovenia", "south-africa", "south-korea", "spain", "sweden", "switzerland",
			"taiwan", "thailand", "turkey", "uganda", "ukraine", "united-arab-emirates", "united-kingdom", "united-states", "uruguay", "venezuela",
			"vietnam"
		};

		private bool Loc = false;

		private StringBuilder data = new StringBuilder();

		private object obj = new object();

		public static string ohguey;

		public static List<string> ListAPI;

		public int threadcount_reg = 0;

		private Queue<DataGridViewRow> queRow = new Queue<DataGridViewRow>();

		public int Vonglap = 1;

		private ConcurrentQueue<string> emailQueue = new ConcurrentQueue<string>();

		public static string softname;

		public static string hostname;

		private IContainer components = null;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private GroupBox groupBox4;

		private DataGridView dataGridView1;

		private TabPage tabPage2;

		private TabPage tabPage3;

		private GroupBox groupBox3;

		private GroupBox groupBox2;

		private Label label1;

		private TextBox txt_apiphone;

		private GroupBox groupBox1;

		private Label label3;

		private RichTextBox richTextBox1;

		private ComboBox comboip;

		private Label label2;

		private Label label5;

		private NumericUpDown numericUpDown2;

		private Label label6;

		private Label label8;

		private ComboBox combocaptcha;

		private Label label7;

		private TextBox txt_apicaptcha;

		private LinkLabel linkLabel3;

		private ComboBox combo_DanhMuc;

		private Label label9;

		private ComboBox combo_DinhDang;

		private Label label10;

		private GroupBox groupBox5;

		private DataGridView dataGridView2;

		private Label label11;

		private ComboBox cbb_LocTinhTrang;

		private PictureBox pictureBox3;

		private NumericUpDown numericUpDown3;

		private Label label12;

		private DataGridViewTextBoxColumn TT;

		private DataGridViewTextBoxColumn UID;

		private DataGridViewTextBoxColumn PASS;

		private DataGridViewTextBoxColumn COOKIE;

		private DataGridViewTextBoxColumn EMAIL;

		private DataGridViewTextBoxColumn PASSMAIL;

		private DataGridViewTextBoxColumn STATUS;

		private DataGridViewImageColumn PIC;

		private CheckBox cbgiuanh;

		private NumericUpDown numericUpDown4;

		private Label label16;

		private CheckBox cbcover;

		private CheckBox cbavatar;

		private CheckBox cbnghenghiep;

		private CheckBox cbnoisong;

		private CheckBox cbquequan;

		private CheckBox cb2fa;

		private Label label17;

		private ComboBox combologin;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem cHỌNToolStripMenuItem;

		private ToolStripMenuItem cHỌNHÀNGBÔIĐENToolStripMenuItem;

		private ToolStripMenuItem cHỌNTẤTCẢToolStripMenuItem;

		private ToolStripMenuItem cHỌNACCCHECKPOINTToolStripMenuItem;

		private ToolStripMenuItem bỎCHỌNToolStripMenuItem;

		private ToolStripMenuItem bỎCHỌNHÀNGBÔIĐENToolStripMenuItem;

		private ToolStripMenuItem bỎCHỌNTẤTCẢToolStripMenuItem;

		private ToolStripMenuItem bỎCHỌNACCDIECHECKPOINTToolStripMenuItem;

		private ToolStripMenuItem xÓADÒNGToolStripMenuItem;

		private ToolStripMenuItem xÓADÒNGBÔIĐENToolStripMenuItem;

		private ToolStripMenuItem xÓADÒNGĐÃCHỌNToolStripMenuItem;

		private ToolStripMenuItem xÓATẤTCẢToolStripMenuItem;

		private ToolStripMenuItem cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem;

		private ToolStripMenuItem cOPYACCOUNTToolStripMenuItem;

		private ToolStripMenuItem uIDToolStripMenuItem;

		private ToolStripMenuItem cOOKIEToolStripMenuItem;

		private ToolStripMenuItem uIDPASSToolStripMenuItem;

		private ToolStripMenuItem uIDPASS2FAToolStripMenuItem;

		private ToolStripMenuItem rEFRESHDỮLIỆUToolStripMenuItem;

		private ToolStripMenuItem sỬAGHICHÚToolStripMenuItem;

		private TextBox txt_cover;

		private TextBox txt_avatar;

		private CheckBox cbgetcookiemoi;

		private TabPage tabPage4;

		private FlowLayoutPanel flowLayoutPanel1;

		private CheckBox cbregkhongunlock;

		private Label label18;

		private ComboBox combophone;

		private Label label4;

		private NumericUpDown numericUpDown1;

		private Button button2;

		private Button button1;

		private ComboBox combomail;

		private Label label22;

		private ComboBox comboten;

		private ComboBox combonhiemvu;

		private Label label23;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem checkLiveUidToolStripMenuItem;

		private Label label25;

		private TextBox txt_linkserver;

		private CheckBox cbngonngu;

		private Label label26;

		private ComboBox comboimage;

		private CheckBox cbaddview;

		private DataGridViewCheckBoxColumn chon;

		private DataGridViewTextBoxColumn stt;

		private DataGridViewTextBoxColumn uidclone;

		private DataGridViewTextBoxColumn passclone;

		private DataGridViewTextBoxColumn ma2fa;

		private DataGridViewTextBoxColumn cookieclone;

		private DataGridViewTextBoxColumn token;

		private DataGridViewTextBoxColumn emailclone;

		private DataGridViewTextBoxColumn passmailclone;

		private DataGridViewTextBoxColumn useragent;

		private DataGridViewTextBoxColumn gender;

		private DataGridViewTextBoxColumn birthday;

		private DataGridViewTextBoxColumn friendcount;

		private DataGridViewTextBoxColumn groupcount;

		private DataGridViewTextBoxColumn tinhtrang;

		private DataGridViewTextBoxColumn ghichu;

		private DataGridViewTextBoxColumn lastactive;

		private DataGridViewTextBoxColumn danhmuc;

		private DataGridViewTextBoxColumn proxy;

		private DataGridViewTextBoxColumn trangthai1;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem uIDPASS2FAEMAILPASSMAILToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem3;

		private ToolStripMenuItem uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem;

		private Label lbupdate;

		private CheckBox cbregkhongunlockkhongcaptcha;

		private ToolStripMenuItem toolStripMenuItem4;

		private ComboBox combongonngu;

		private Label label27;

		private TextBox txt_proxyv6net;

		private CheckBox cbverify;

		private CheckBox cb_addmail282;

		private Label label30;

		private CheckBox cb_ngonngureg;

		private Label label13;

		private TextBox txt_folder_anh;

		private System.Windows.Forms.Timer timer1;

		private Button button3;

		private NumericUpDown numericUpDown6;

		private Label label21;

		private NumericUpDown numericUpDown5;

		private Label label14;

		private CheckBox cb_180day;

		private ComboBox comboserver;

		private Label label29;

		private Label label33;

		private NumericUpDown numericUpDown7;

		private Label label32;
        private Button linkLabel2;
        private Button linkLabel1;
        private Button linkLabel13;
        private Button linkLabel17;
        private Button linkLabel8;
        private Button linkLabel6;
        private Button linkLabel9;
        private Button linkLabel5;
        private Button linkLabel4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolStripStatusLabel6;
        private ToolStripStatusLabel toolStripStatusLabel8;
        private ToolStripStatusLabel toolStripStatusLabel10;
        private ToolStripStatusLabel toolStripStatusLabel11;
        private ToolStripStatusLabel toolStripStatusLabel12;
        private ToolStripStatusLabel toolStripStatusLabel13;
        private ToolStripStatusLabel toolStripStatusLabel14;
        public ToolStripStatusLabel toolStripStatusLabel15;
        private ToolStripStatusLabel toolStripLabel1;
        private ToolStripStatusLabel lb_tongreg;
        private ToolStripStatusLabel toolStripLabel2;
        private ToolStripStatusLabel lbtongphone_buy;
        private ToolStripStatusLabel toolStripLabel3;
        private ToolStripStatusLabel codedone;
        private ToolStripStatusLabel toolStripStatusLabel22;
        private ToolStripStatusLabel error_code;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel toolStripStatusLabel7;
        private ToolStripStatusLabel toolStripStatusLabel9;
        private ToolStripStatusLabel toolStripStatusLabel16;
        private ToolStripStatusLabel lbl_User;
        private ToolStripStatusLabel toolStripStatusLabel18;
        private ToolStripStatusLabel toolStripStatusLabel19;
        public ToolStripStatusLabel toolStripStatusLabel20;
        private ToolStripStatusLabel lb_TongAcc;
        private ToolStripStatusLabel lb_Live;
        private ToolStripStatusLabel lb_Die;
        private GroupBox groupBox6;
        private GroupBox groupBox8;
        private GroupBox groupBox7;
        private Button linkLabel7;
        private Button linkLabel14;
        private Button linkLabel10;
        private Button linkLabel11;
        private Button button4;
        private Label label34;
        private ComboBox combosex;
        private NumericUpDown nbr_getphoneagain;
        private Label label35;
        private string string_12;

		public Process Process_0 { get; set; }

		public string UserAgent { get; set; }

		public int PixelRatio { get; set; }

		public Point Size_Emulator { get; set; }

		

		[Obsolete]
		public Form1(int exp, string user)
		{
			
			user = Environment.MachineName;
			InitializeComponent();
			 
			username_tool = user;
			Control.CheckForIllegalCrossThreadCalls = false;
			
			



		}
		 
		 
		//private void timer1_Tick(object sender, EventArgs e)
		//{
		//	Random random = new Random();
		//	int A = random.Next(0, 255);
		//	int R = random.Next(0, 255);
		//	int G = random.Next(0, 255);
		//	int B = random.Next(0, 255);
		//	Invoke((Action)delegate
		//	{
		//		linkLabel1.LinkColor = Color.FromArgb(A, R, G, B);
		//	});
		//	Invoke((Action)delegate
		//	{
		//		lbupdate.ForeColor = Color.FromArgb(A, R, G, B);
		//	});
		//}

		[DllImport("user32")]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32")]
		private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

		private void ChangeLanguageRequest_Cookie(string cookie, string ngonngu)
		{
			RequestXNet requestXNet = new RequestXNet(cookie);
			string input = requestXNet.RequestGet("https://mbasic.facebook.com/");
			MatchCollection matchCollection = Regex.Matches(input, "action=\"/intl/save_locale/(.*?)\"");
			MatchCollection matchCollection2 = Regex.Matches(input, "name=\"fb_dtsg\" value=\"(.*?)\"");
			MatchCollection matchCollection3 = Regex.Matches(input, "name=\"jazoest\" value=\"(.*?)\"");
			string text = "https://mbasic.facebook.com/intl/save_locale/" + matchCollection[0].Groups[1].Value;
			string value = Regex.Match(text, "loc=(.*?)&").Groups[1].Value;
			string newValue = value.Replace(value, ngonngu);
			text = text.Replace(value, newValue);
			string value2 = matchCollection2[0].Groups[1].Value;
			string value3 = matchCollection3[0].Groups[1].Value;
			string text2 = "fb_dtsg=" + value2 + "&jazoest=" + value3;
			requestXNet.RequestPost(text, text2, "application/x-www-form-urlencoded", text, "https://mbasic.facebook.com");
			Sleep(1.0);
		}

		private string changeMD5(string filename)
		{
			Random random = new Random();
			Thread.Sleep(1000);
			int num = random.Next(2, 7);
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = 0;
			}
			using (FileStream fileStream = new FileStream(filename, FileMode.Append))
			{
				fileStream.Write(array, 0, array.Length);
			}
			string result = "";
			using (MD5 mD = MD5.Create())
			{
				using FileStream inputStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
				result = BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "");
			}
			return result;
		}

		public string GetCookieCurrentChrome(ChromeDriver chrome)
		{
			ICookieJar cookies = chrome.Manage().Cookies;
			string text = "";
			foreach (OpenQA.Selenium.Cookie allCookie in cookies.AllCookies)
			{
				text = text + allCookie.Name + "=" + allCookie.Value + "; ";
			}
			text = text.Trim();
			return text.TrimEnd(';');
		}

		public bool method_2(ChromeDriver driver)
		{
			return !method_3(driver);
		}

		public bool method_3(ChromeDriver driver)
		{
			if (Process_0 != null)
			{
				return Process_0.HasExited;
			}
			bool result = true;
			try
			{
				string title = driver.Title;
				result = false;
			}
			catch
			{
			}
			return result;
		}

		public int importcookie(ChromeDriver driver, string string_7, string string_8 = ".facebook.com")
		{
			if (!method_2(driver))
			{
				return -2;
			}
			try
			{
				string[] array = string_7.Split(';');
				string[] array2 = array;
				string[] array3 = array2;
				foreach (string text in array3)
				{
					if (text.Trim() != "")
					{
						string[] array4 = text.Split('=');
						if (array4.Count() > 1 && array4[0].Trim() != "")
						{
							OpenQA.Selenium.Cookie cookie = new OpenQA.Selenium.Cookie(array4[0].Trim(), text.Substring(text.IndexOf('=') + 1).Trim(), string_8, "/", DateTime.Now.AddDays(10.0));
							driver.Manage().Cookies.AddCookie(cookie);
						}
					}
				}
				return 1;
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public Point GetSizeChrome(int column, int row)
		{
			int num = getWidthScreen / column + 15;
			int num2 = getHeightScreen / row + 10;
			return new Point(num, num2);
		}

		public Point GetPointFromIndexPosition(int indexPos, int column, int row)
		{
			Point result = default(Point);
			while (indexPos >= column * row)
			{
				indexPos -= column * row;
			}
			switch (row)
			{
				case 1:
					result.Y = 0;
					break;
				case 2:
					if (indexPos < column)
					{
						result.Y = 0;
					}
					else if (indexPos < column * 2)
					{
						result.Y = getHeightScreen / 2;
						indexPos -= column;
					}
					break;
				case 3:
					if (indexPos < column)
					{
						result.Y = 0;
					}
					else if (indexPos < column * 2)
					{
						result.Y = getHeightScreen / 3;
						indexPos -= column;
					}
					else if (indexPos < column * 3)
					{
						result.Y = getHeightScreen / 3 * 2;
						indexPos -= column * 2;
					}
					break;
				case 4:
					if (indexPos < column)
					{
						result.Y = 0;
					}
					else if (indexPos < column * 2)
					{
						result.Y = getHeightScreen / 4;
						indexPos -= column;
					}
					else if (indexPos < column * 3)
					{
						result.Y = getHeightScreen / 4 * 2;
						indexPos -= column * 2;
					}
					else if (indexPos < column * 4)
					{
						result.Y = getHeightScreen / 4 * 3;
						indexPos -= column * 3;
					}
					break;
				case 5:
					if (indexPos < column)
					{
						result.Y = 0;
					}
					else if (indexPos < column * 2)
					{
						result.Y = getHeightScreen / 5;
						indexPos -= column;
					}
					else if (indexPos < column * 3)
					{
						result.Y = getHeightScreen / 5 * 2;
						indexPos -= column * 2;
					}
					else if (indexPos < column * 4)
					{
						result.Y = getHeightScreen / 5 * 3;
						indexPos -= column * 3;
					}
					else
					{
						result.Y = getHeightScreen / 5 * 4;
						indexPos -= column * 4;
					}
					break;
			}
			int num = getWidthScreen / column;
			result.X = indexPos * num - 10;
			return result;
		}

		public void SaveErrorLog(string er)
		{
			Invoke((Action)delegate
			{
				File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "ErrorLog.txt", "==>[" + DateTime.Now.ToString() + "] " + er + "\r\n");
			});
		}

		protected void Sleep(double seconds)
		{
			Thread.Sleep((int)(1000.0 * seconds));
		}

		public string Getrandomemail()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(RandomString1(1, lowerCase: true));
			stringBuilder.Append(RandomString1(6, lowerCase: true));
			stringBuilder.Append(RandomNumber1(1000, 9999));
			stringBuilder.Append(RandomString1(4, lowerCase: true));
			return stringBuilder.ToString();
		}

		public string randominfo(string filepath)
		{
			string[] array = File.ReadAllLines("Update_info//" + filepath);
			int maxValue = File.ReadLines("Update_info//" + filepath).Count();
			Random random = new Random();
			int num = random.Next(0, maxValue);
			return array[num];
		}

		public string Getrandompassfacebook()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(RandomString(1, lowerCase: false));
			stringBuilder.Append(RandomString(7, lowerCase: true));
			stringBuilder.Append(RandomNumber(100, 999));
			stringBuilder.Append(RandomString(2, lowerCase: true));
			return stringBuilder.ToString();
		}

		public string Getrandompassmailtm()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(RandomString(1, lowerCase: false));
			stringBuilder.Append(RandomString(5, lowerCase: true));
			stringBuilder.Append(RandomNumber(100, 999));
			stringBuilder.Append(RandomString(1, lowerCase: true));
			return stringBuilder.ToString();
		}

		private int RandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}

		private string RandomString(int size, bool lowerCase)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random();
			for (int i = 0; i < size; i++)
			{
				char value = Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0)));
				stringBuilder.Append(value);
			}
			if (lowerCase)
			{
				return stringBuilder.ToString().ToLower();
			}
			return stringBuilder.ToString();
		}

		private int RandomNumber1(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}

		private string RandomString1(int size, bool lowerCase)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random();
			for (int i = 0; i < size; i++)
			{
				char value = Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0)));
				stringBuilder.Append(value);
			}
			if (lowerCase)
			{
				return stringBuilder.ToString().ToLower();
			}
			return stringBuilder.ToString();
		}

		[Obsolete]
		public void linkLabel1_Click(object sender, EventArgs e)
		{
			if (comboimage.Text == "Ảnh đã lưu trong folder Image" && txt_folder_anh.Text == "")
			{
				MessageBox.Show("Chưa chọn folder ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Process[] processesByName = Process.GetProcessesByName("chromedriver");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
			}
			Exception ex;
			foreach (Thread item in ListThread)
			{
				try
				{
					item.Abort();
				}
				catch (Exception ex2)
				{
					ex = ex2;
					Invoke((Action)delegate
					{
						SaveErrorLog(ex.ToString());
					});
				}
			}
			Invoke((Action)delegate
			{
				linkLabel2.Enabled = true;
				linkLabel1.Enabled = false;
			});
			IsRunning = true;
			thread = new Thread(Autoreg);
			thread.Start();
		}

		[Obsolete]
		private void hguywervxcvs()
		{
			string combo_image = string.Empty;
			string type_mail = string.Empty;
			string type_ip = string.Empty;
			int action = 0;
			string ngonngu = string.Empty;
			string combo_server_sim = string.Empty;
			Invoke((Action)delegate
			{
				combo_image = comboimage.Text;
				type_mail = combomail.Text;
				type_ip = comboip.Text;
				action = combonhiemvu.SelectedIndex;
				combo_server_sim = comboserver.Text;
				ngonngu = combongonngu.Text;
			});
			int index_login = 0;
			Invoke((Action)delegate
			{
				index_login = combologin.SelectedIndex;
			});
			api_proxyv6 = txt_proxyv6net.Text;
			linkserver_mobiproxy = txt_linkserver.Text;
			manguser_agent = File.ReadAllLines("Data_Reg\\UA.txt");
			int index_phone = Convert.ToInt32(combophone.SelectedIndex);
			string text_api_phone = txt_apiphone.Text;
			string text_api_captcha = txt_apicaptcha.Text;
			int index_captcha = Convert.ToInt32(combocaptcha.SelectedIndex);
			int limit_getphone = Convert.ToInt32(numericUpDown4.Value);
			int limit_getcodephone = Convert.ToInt32(numericUpDown3.Value);
			if (type_ip == "TINSOFT" || type_ip == "TMPROXY" || type_ip == "SHOPLIKEPROXY" || type_ip == "MINPROXY" || type_ip == "PROXYFB.COM")
			{
				listapi = richTextBox1.Lines.ToList();
				{
					foreach (string Apikey2 in listapi)
					{
						int index2 = listapi.IndexOf(Apikey2);
						Thread thread = new Thread((ThreadStart)delegate
						{
							try
							{
								login(index2, Apikey2, index_login, type_ip, action, index_phone, text_api_phone, text_api_captcha, index_captcha, limit_getphone, limit_getcodephone, combo_image, ngonngu, type_mail, combo_server_sim);
							}
							catch
							{
							}
						});
						thread.Start();
						thread.IsBackground = true;
						ListThread_login.Add(thread);
						Thread.Sleep(500);
					}
					return;
				}
			}
			if (type_ip == "LISTPROXY" || type_ip == "PROXYV6.NET")
			{
				int num = Convert.ToInt32(numericUpDown1.Value);
				mangproxy = File.ReadAllLines("Data_Reg\\proxy_http.txt");
				int j;
				for (j = 0; j < num; j++)
				{
					Thread thread2 = new Thread((ThreadStart)delegate
					{
						try
						{
							login(j, "", index_login, type_ip, action, index_phone, text_api_phone, text_api_captcha, index_captcha, limit_getphone, limit_getcodephone, combo_image, ngonngu, type_mail, combo_server_sim);
						}
						catch
						{
						}
					});
					thread2.Start();
					thread2.IsBackground = true;
					ListThread_login.Add(thread2);
					Thread.Sleep(500);
				}
			}
			else if (type_ip == "WIFI")
			{
				int num2 = Convert.ToInt32(numericUpDown1.Value);
				int i;
				for (i = 0; i < num2; i++)
				{
					Thread thread3 = new Thread((ThreadStart)delegate
					{
						try
						{
							login(i, "", index_login, type_ip, action, index_phone, text_api_phone, text_api_captcha, index_captcha, limit_getphone, limit_getcodephone, combo_image, ngonngu, type_mail, combo_server_sim);
						}
						catch
						{
						}
					});
					thread3.Start();
					thread3.IsBackground = true;
					ListThread_login.Add(thread3);
					Thread.Sleep(500);
				}
			}
			else
			{
				if (!(type_ip == "MOBIPROXY") && !(type_ip == "OCBPROXY") && !(type_ip == "XPROXY"))
				{
					return;
				}
				listapi = richTextBox1.Lines.ToList();
				foreach (string Apikey in listapi)
				{
					int index = listapi.IndexOf(Apikey);
					Thread thread4 = new Thread((ThreadStart)delegate
					{
						try
						{
							login(index, Apikey, index_login, type_ip, action, index_phone, text_api_phone, text_api_captcha, index_captcha, limit_getphone, limit_getcodephone, combo_image, ngonngu, type_mail, combo_server_sim);
						}
						catch
						{
						}
					});
					thread4.Start();
					thread4.IsBackground = true;
					ListThread_login.Add(thread4);
					Thread.Sleep(500);
				}
			}
		}

		[Obsolete]
		public void Autoreg()
		{
			string ngonngu = string.Empty;
			string type_ip = string.Empty;
			string combo_server_sim = string.Empty;
			string type_mail = string.Empty;
			string type_name = string.Empty;
			string combo_image = string.Empty;
			string combo_sex = string.Empty;
			Invoke((Action)delegate
			{
				ngonngu = combongonngu.Text;
				type_ip = comboip.Text;
				type_mail = combomail.Text;
				type_name = comboten.Text;
				combo_image = comboimage.Text;
				combo_server_sim = comboserver.Text;
				combo_sex = combosex.Text;
			});
			linkserver_mobiproxy = txt_linkserver.Text;
			api_proxyv6 = txt_proxyv6net.Text;
			manguser_agent = File.ReadAllLines("Data_Reg\\UA.txt");
			if (type_name == "Tên việt")
			{
				list_lastname = File.ReadAllLines("Data_Reg\\viet\\lastname.txt").ToArray();
				list_firstname = File.ReadAllLines("Data_Reg\\viet\\firstname.txt").ToArray();
			}
			else if (type_name == "Tên ngoại")
			{
				list_lastname = File.ReadAllLines("Data_Reg\\ngoai\\lastname.txt").ToArray();
				list_firstname = File.ReadAllLines("Data_Reg\\ngoai\\firstname.txt").ToArray();
			}
			int index_phone = Convert.ToInt32(combophone.SelectedIndex);
			string text_api_phone = txt_apiphone.Text;
			string text_api_captcha = txt_apicaptcha.Text;
			int index_captcha = Convert.ToInt32(combocaptcha.SelectedIndex);
			int limit_getphone = Convert.ToInt32(numericUpDown4.Value);
			int limit_getcodephone = Convert.ToInt32(numericUpDown3.Value);
			int delay_reg = Convert.ToInt32(numericUpDown2.Value);
			if (type_ip == "TINSOFT" || type_ip == "TMPROXY" || type_ip == "SHOPLIKEPROXY" || type_ip == "MINPROXY" || type_ip == "PROXYFB.COM")
			{
				listapi = richTextBox1.Lines.ToList();
				{
					foreach (string Apikey2 in listapi)
					{
						int index2 = listapi.IndexOf(Apikey2);
						Thread thread = new Thread((ThreadStart)delegate
						{
							try
							{
								reg(index2, Apikey2, type_ip, index_phone, text_api_phone, text_api_captcha, type_mail, index_captcha, limit_getphone, limit_getcodephone, delay_reg, ngonngu, combo_image, combo_server_sim, combo_sex);
							}
							catch
							{
							}
						});
						thread.Start();
						thread.IsBackground = true;
						ListThread.Add(thread);
						Sleep(Convert.ToInt32(numericUpDown7.Value));
					}
					return;
				}
			}
			if (type_ip == "LISTPROXY" || type_ip == "PROXYV6.NET")
			{
				int num = Convert.ToInt32(numericUpDown1.Value);
				mangproxy = File.ReadAllLines("Data_Reg\\proxy_http.txt");
				int j;
				for (j = 0; j < num; j++)
				{
					Thread thread2 = new Thread((ThreadStart)delegate
					{
						try
						{
							reg(j, "", type_ip, index_phone, text_api_phone, text_api_captcha, type_mail, index_captcha, limit_getphone, limit_getcodephone, delay_reg, ngonngu, combo_image, combo_server_sim, combo_sex);
						}
						catch
						{
						}
					});
					thread2.Start();
					thread2.IsBackground = true;
					ListThread.Add(thread2);
					Sleep(Convert.ToInt32(numericUpDown7.Value));
				}
			}
			else if (type_ip == "WIFI")
			{
				int num2 = Convert.ToInt32(numericUpDown1.Value);
				int i;
				for (i = 0; i < num2; i++)
				{
					Thread thread3 = new Thread((ThreadStart)delegate
					{
						try
						{
							reg(i, "", type_ip, index_phone, text_api_phone, text_api_captcha, type_mail, index_captcha, limit_getphone, limit_getcodephone, delay_reg, ngonngu, combo_image, combo_server_sim, combo_sex);
						}
						catch
						{
						}
					});
					thread3.Start();
					thread3.IsBackground = true;
					ListThread.Add(thread3);
					Sleep(Convert.ToInt32(numericUpDown7.Value));
				}
			}
			else
			{
				if (!(type_ip == "MOBIPROXY") && !(type_ip == "OCBPROXY") && !(type_ip == "XPROXY"))
				{
					return;
				}
				listapi = richTextBox1.Lines.ToList();
				foreach (string Apikey in listapi)
				{
					int index = listapi.IndexOf(Apikey);
					Thread thread4 = new Thread((ThreadStart)delegate
					{
						try
						{
							reg(index, Apikey, type_ip, index_phone, text_api_phone, text_api_captcha, type_mail, index_captcha, limit_getphone, limit_getcodephone, delay_reg, ngonngu, combo_image, combo_server_sim, combo_sex);
						}
						catch
						{
						}
					});
					thread4.Start();
					thread4.IsBackground = true;
					ListThread.Add(thread4);
					Sleep(Convert.ToInt32(numericUpDown7.Value));
				}
			}
		}

		public static Process GetWindowHandleByDriverId(int driverId)
		{
			IEnumerable<Process> enumerable = from _ in Process.GetProcessesByName("chrome")
											  where !_.MainWindowHandle.Equals(IntPtr.Zero)
											  select _;
			foreach (Process item in enumerable)
			{
				int parentProcess = GetParentProcess(item.Id);
				if (parentProcess == driverId)
				{
					return item;
				}
			}
			return null;
		}

		private static int GetParentProcess(int Id)
		{
			int result = 0;
			using (ManagementObject managementObject = new ManagementObject($"win32_process.handle='{Id}'"))
			{
				managementObject.Get();
				result = Convert.ToInt32(managementObject["ParentProcessId"]);
			}
			return result;
		}

		public int CheckExistElements(ChromeDriver driver, double timeWait_Second = 0.0, params string[] querySelectors)
		{
			int num = 0;
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					num = Convert.ToInt32(driver.ExecuteScript("var arr='" + string.Join("|", querySelectors) + "'.split('|');var output=0;for(i=0;i<arr.length;i++){ if (document.querySelectorAll(arr[i]).length > 0) { output = i + 1; break;}; }return (output + ''); "));
					if (num == 0)
					{
						if ((double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0)
						{
							break;
						}
						Thread.Sleep(1000);
						continue;
					}
					return num;
				}
			}
			catch
			{
			}
			return num;
		}

		private string getSVContent(string url)
		{
			string text = "";
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
					text = webClient.DownloadString(url);
				}
				if (string.IsNullOrEmpty(text))
				{
					text = "";
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}

		private string getSVContent_proxyfb(string url)
		{
			string text = "";
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
					text = webClient.DownloadString(url);
				}
				if (string.IsNullOrEmpty(text))
				{
					text = "";
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}

		private bool Resetproxy_MobiProxy(string url, string port)
		{
			try
			{
				string empty = string.Empty;
				using WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
				empty = webClient.DownloadString(url + "proxy_recreat?proxy=" + port);
				if (empty.Contains("RECREAT_PROXY_DONE"))
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

		private bool Resetproxy_OCBProxy(string url, string port)
		{
			try
			{
				string empty = string.Empty;
				using WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
				empty = webClient.DownloadString(url + "reset?proxy=" + port);
				if (empty.Contains("\"status\":true"))
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

		private bool Reset_Xproxy(string url, string port)
		{
			try
			{
				string empty = string.Empty;
				using WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
				empty = webClient.DownloadString(url + "api/v1/rotate_ip/proxy/" + port);
				if (empty.Contains("msg\":\"command_sent"))
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

		private bool checkproxy_Xproxy(string proxy, string url)
		{
			try
			{
				string empty = string.Empty;
				using WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
				empty = webClient.DownloadString(url + "api/v1/rotate_ip/proxy/" + proxy);
				if (empty.Contains("MODEM_READY"))
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

		private bool checkproxy_mobiproxy(string ip, string port, string url)
		{
			try
			{
				if (port.Contains("51"))
				{
					port = port.Replace("51", "40");
				}
				string empty = string.Empty;
				using WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
				empty = webClient.DownloadString(url + "proxy_check?proxy=" + ip + ":" + port);
				if (empty.Contains("proxy_ok"))
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

		private bool checkproxy_ocbproxy(string proxy, string url)
		{
			try
			{
				string empty = string.Empty;
				using WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
				empty = webClient.DownloadString(url + "status?proxy=" + proxy);
				if (empty.Contains("MODEM_READY"))
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

		[Obsolete]
		private string Acc180(ChromeDriver driver, XuanAction xuan, string combo_image, string ngonngu, string uid, string proxy)
		{
			TimeSpan timeSpan = new TimeSpan(0, 2, 0);
			TimeSpan span = new TimeSpan(0, 2, 0);
			TimeSpan timeSpan2 = new TimeSpan(0, 5, 0);
			TimeSpan span2 = new TimeSpan(0, 0, 30);
			try
			{
				string text;
				while (true)
				{
					text = string.Empty;
					int num = 0;
					while (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count <= 0)
					{
						if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
						{
							if (xuan.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span))
							{
								Sleep(1.0);
							}
						}
						else
						{
							if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
							{
								return "havephone";
							}
							if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
							{
								return "true|";
							}
							if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
							{
								return "true|";
							}
							if (driver.PageSource.Contains("Mã đó không hoạt động. Vui lòng kiểm tra mã và thử lại") || driver.PageSource.Contains("That code didn't work. Please check the code and try again."))
							{
								return "false|";
							}
							if (num == 15)
							{
								return "false|";
							}
						}
						Sleep(1.0);
						num++;
					}
					Thread.Sleep(100);
					switch (combo_image)
					{
						case "Ảnh đã lưu trong folder Image":
							lock (this.obj)
							{
								string[] files = Directory.GetFiles(txt_folder_anh.Text);
								if (files.Length == 0)
								{
									return "false|";
								}
								text = files[rd.Next(0, files.Length - 1)];
							}
							break;
						case "https://boredhumans.com/faces.php":
							lock (this.obj)
							{
								while (!method_41(uid, proxy))
								{
									Sleep(1.0);
								}
								text = Path_Tool + "\\Image\\" + uid + ".png";
							}
							break;
						case "https://this-person-does-not-exist.com":
							lock (this.obj)
							{
								while (!method_40(uid, ""))
								{
									Sleep(1.0);
								}
								text = Path_Tool + "\\Image\\" + uid + ".png";
							}
							break;
						case "https://www.unrealperson.com":
							lock (this.obj)
							{
								while (!method_42(uid, proxy))
								{
									Sleep(1.0);
								}
								text = Path_Tool + "\\Image\\" + uid + ".png";
							}
							break;
						case "https://fakeface.rest":
							lock (this.obj)
							{
								while (!method_43(uid))
								{
									Sleep(1.0);
								}
								text = Path_Tool + "\\Image\\" + uid + ".png";
							}
							break;
					}
					if (!File.Exists(text))
					{
						Console.WriteLine("NOT IMAGE");
						continue;
					}
					if (!(changeMD5(text) == "") && changeMD5(text) != null)
					{
						break;
					}
					if (File.Exists(text))
					{
						File.Delete(text);
					}
				}
				driver.FindElementByCssSelector("[type=\"file\"]").SendKeys(text);
				Thread.Sleep(1000);
				while (true)
				{
					if (driver.FindElements(By.XPath("//button[@name='action_upload_image']")).Count > 0)
					{
						xuan.ClickElement(driver, By.XPath("//button[@name='action_upload_image']"), span2);
						Sleep(1.0);
						break;
					}
					if (driver.FindElements(By.XPath("//input[@name='action_upload_image']")).Count > 0)
					{
						xuan.ClickElement(driver, By.XPath("//input[@name='action_upload_image']"), span2);
						Sleep(1.0);
						break;
					}
					if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
					{
						return "false|";
					}
				}
				if (driver.FindElements(By.XPath("//input[@type='file']")).Count > 0)
				{
					return "false|";
				}
				int num2 = 0;
				do
				{
					if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
					{
						return "true|" + text;
					}
					if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
					{
						return "true|";
					}
					if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
					{
						return "true|";
					}
					Sleep(1.0);
					num2++;
				}
				while (num2 != 20);
				return "true|" + text;
			}
			catch
			{
				return "false|";
			}
		}

		[Obsolete]
		private string gyguysgfuer(ChromeDriver driver, XuanAction xuan, Hotmailbox apihotmail, Mailtm apimailtm, string accountmailtm, string passmailtm, string hotmail, string passhotmail, string type_mail, string text, string emailfake, Emailfaker apiemailfake)
		{
			try
			{
				string text2 = string.Empty;
				TimeSpan span = new TimeSpan(0, 2, 0);
				TimeSpan span2 = new TimeSpan(0, 2, 0);
				TimeSpan timeSpan = new TimeSpan(0, 5, 0);
				TimeSpan span3 = new TimeSpan(0, 0, 30);
				if (!xuan.Goto(driver, "https://mbasic.facebook.com/", span))
				{
					return "ERROR";
				}
				switch (type_mail)
				{
					case "Mailtm":
						while (true)
						{
							text2 = apimailtm.GetCodeMailTm(accountmailtm, passmailtm, text);
							if (text2 != "")
							{
								break;
							}
							Sleep(1.0);
						}
						break;
					case "Hotmail":
						while (true)
						{
							text2 = apihotmail.Getcode(hotmail, passhotmail);
							if (text2 != "")
							{
								break;
							}
							Sleep(1.0);
						}
						break;
					case "Emailfake.com":
						while (true)
						{
							text2 = apiemailfake.Getcode(emailfake);
							if (text2 != "")
							{
								break;
							}
							Sleep(1.0);
						}
						break;
				}
				if (!xuan.SendKey(driver, By.XPath("//input[@name='c']"), span3, text2))
				{
					return "ERROR";
				}
				if (!xuan.ClickElement(driver, By.XPath("//input[@name='submit[confirm]']"), span3))
				{
					return "ERROR";
				}
				int num = 0;
				while (true)
				{
					if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
					{
						if (!xuan.Goto(driver, "https://m.facebook.com/", span))
						{
							return "ERROR";
						}
						int num2 = 0;
						while (true)
						{
							if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
							{
								if (xuan.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span2))
								{
									Sleep(1.0);
									return "CAPTCHA";
								}
							}
							else if (num2 == 10)
							{
								break;
							}
							Sleep(1.0);
							num2++;
						}
						return "ERROR";
					}
					if (!driver.Url.Contains("gettingstarted") && driver.Url.Contains("checkpoint") && !driver.Url.Contains("282"))
					{
						return "ERROR";
					}
					if (driver.Url.Contains("gettingstarted"))
					{
						return "OK";
					}
					if (num == 10)
					{
						break;
					}
					num++;
					Sleep(1.0);
				}
				return "ERROR";
			}
			catch
			{
				return "ERROR";
			}
		}

		[Obsolete]
		private void login(int index_chrome, string apikey, int index_login, string type_ip, int action, int index_phone, string text_api_phone, string text_api_captcha, int index_captcha, int limit_getphone, int limit_getcodephone, string combo_image, string ngonngu, string type_mail, string combo_server_sim)
		{
			while (queRow.Count > 0 && IsRunning_login && queRow.Count != 0 && IsRunning_login)
			{
				int index = queRow.Dequeue().Index;
				int num = 0;
				string text = "hn";
				Random random = new Random();
				string text2 = string.Empty;
				try
				{
					string uid = dataGridView2.Rows[index].Cells["uidclone"].Value.ToString();
					string text3 = dataGridView2.Rows[index].Cells["ma2fa"].Value.ToString();
					string pass = dataGridView2.Rows[index].Cells["passclone"].Value.ToString();
					string text4 = dataGridView2.Rows[index].Cells["cookieclone"].Value.ToString();
					string text5 = dataGridView2.Rows[index].Cells["emailclone"].Value.ToString();
					string text6 = dataGridView2.Rows[index].Cells["passmailclone"].Value.ToString();
					switch (type_ip)
					{
						case "TINSOFT":
							dataGridView2.Rows[index].Cells["trangthai1"].Value = "Đang lấy ip Tinsoftproxy...";
							while (true)
							{
								string sVContent = getSVContent(svUrl + "/api/changeProxy.php?key=" + apikey + "&location=0");
								if (sVContent != "")
								{
									try
									{
										JObject jObject4 = JObject.Parse(sVContent);
										if (bool.Parse(jObject4["success"]!.ToString()))
										{
											text2 = jObject4["proxy"]!.ToString();
											if (text2 != "" && text2.Contains(":"))
											{
												Console.WriteLine("API: " + apikey + "==> proxy: " + text2);
												break;
											}
										}
										else
										{
											num = int.Parse(Regex.Match(sVContent, "wait (\\d+)").Groups[1].Value);
											if (num > 0)
											{
												for (int j = 0; j < num; j++)
												{
													dataGridView2.Rows[index].Cells["trangthai1"].Value = $"Chờ request get ip tinsoft {j} / {num}";
													Sleep(1.0);
												}
											}
										}
									}
									catch
									{
									}
								}
								Sleep(1.0);
							}
							break;
						case "TMPROXY":
							dataGridView2.Rows[index].Cells["trangthai1"].Value = "Đang lấy ip Tmproxy...";
							while (true)
							{
								List<string> list = new List<string>();
								RestClient restClient = new RestClient("https://tmproxy.com/api/proxy/get-new-proxy");
								restClient.Timeout = -1;
								RestRequest restRequest = new RestRequest(Method.POST);
								restRequest.AddHeader("Content-Type", "application/json");
								string value = "{\"api_key\": \"" + apikey + "\",\"id_location\": 1}";
								restRequest.AddParameter("application/json", value, ParameterType.RequestBody);
								IRestResponse restResponse = restClient.Execute(restRequest);
								JObject jObject3 = JObject.Parse(restResponse.Content);
								list.Add(jObject3["message"]!.ToString());
								JToken jToken = jObject3["data"];
								if (jToken != null)
								{
									list.Add(jToken["https"]!.ToString());
								}
								if (list[0] == "")
								{
									text2 = list[1];
								}
								else if (list[0].Contains("retry"))
								{
									int[] array = (from m in Regex.Matches(list[0], "\\d+").OfType<Match>()
												   select int.Parse(m.Value)).ToArray();
									text2 = "wait|" + Convert.ToInt32(array[0].ToString());
								}
								else if (list[0].ToLower().Contains("hết"))
								{
									text2 = "TMProxy Hết Hạn";
								}
								if (text2 != "" && text2.Contains(":"))
								{
									break;
								}
								Sleep(6.0);
							}
							break;
						case "SHOPLIKEPROXY":
							dataGridView2.Rows[index].Cells["trangthai1"].Value = "Đang lấy ip Shoplikeproxy...";
							while (true)
							{
								NetHelper netHelper2 = new NetHelper();
								string text9 = "http://proxy.shoplike.vn/Api/getNewProxy?access_token=" + apikey;
								if (text != "")
								{
									text9 = text9 + "&location=" + text;
								}
								string text10 = netHelper2.RequestGet(text9);
								if (text10.Contains("success"))
								{
									JObject jObject5 = JObject.Parse(text10);
									string text11 = JObject.Parse(JObject.Parse(text10)["data"]!.ToString())["proxy"]!.ToString();
									if (text11 != "")
									{
										text2 = text11;
									}
								}
								else
								{
									if (text10.Contains("Het proxy"))
									{
										dataGridView2.Rows[index].Cells["trangthai1"].Value = "[Lỗi]   Hết proxy!";
										break;
									}
									if (text10.Contains("Con lai"))
									{
										text2 = "Đợi " + Convert.ToInt32(Regex.Match(text10, "Con lai (.*?) giay").Groups[1].Value);
									}
									else if (text10.Contains("het han"))
									{
										text2 = "hethan";
									}
								}
								if (text2 != "" && text2.Contains(":"))
								{
									goto end_IL_013c;
								}
								Sleep(5.0);
							}
							goto end_IL_002d;
						case "MINPROXY":
							dataGridView2.Rows[index].Cells["trangthai1"].Value = "Đang lấy ip Minproxy...";
							while (true)
							{
								NetHelper netHelper = new NetHelper();
								string url = "https://dash.minproxy.vn/api/rotating/v1/proxy/get-new-proxy?api_key=" + apikey;
								string text7 = netHelper.RequestGet(url);
								if (text7.Contains("lay proxy thanh cong"))
								{
									JObject jObject2 = JObject.Parse(text7);
									string text8 = JObject.Parse(JObject.Parse(text7)["data"]!.ToString())["http_proxy"]!.ToString();
									if (text8 != "")
									{
										text2 = text8;
									}
								}
								else if (text7.Contains("lay proxy moi that bai"))
								{
									int num2 = Convert.ToInt32(Regex.Match(text7, "next_request\":(\\d+)").Groups[1].Value);
									text2 = "Đợi " + num2;
									Sleep(num2);
								}
								else if (text7.Contains("api wrong"))
								{
									text2 = "hethan";
								}
								if (text2 != "" && text2.Contains(":"))
								{
									break;
								}
								Sleep(1.0);
							}
							break;
						case "LISTPROXY":
							if (count_dem_proxyhttp >= mangproxy.Length)
							{
								count_dem_proxyhttp = 0;
							}
							text2 = mangproxy[count_dem_proxyhttp];
							count_dem_proxyhttp++;
							break;
						case "PROXYV6.NET":
							dataGridView2.Rows[index].Cells["trangthai1"].Value = "Đang lấy ip Proxyv6.net...";
							if (count_dem_proxyhttp >= mangproxy.Length)
							{
								count_dem_proxyhttp = 0;
							}
							text2 = mangproxy[count_dem_proxyhttp];
							count_dem_proxyhttp++;
							while (!ProxyV6Helper.Changeip(api_proxyv6, text2.Split(':')[0], text2.Split(':')[1]))
							{
								Sleep(1.0);
							}
							while (!ProxyV6Helper.Check_rotating_v6(api_proxyv6, text2.Split(':')[0], text2.Split(':')[1]))
							{
								Sleep(1.0);
							}
							Sleep(1.0);
							break;
						case "WIFI":
							text2 = "";
							break;
						case "MOBIPROXY":
							dataGridView2.Rows[index].Cells["trangthai1"].Value = "Đang reset MOBIPROXY (" + apikey + ")...";
							text2 = apikey;
							while (true)
							{
								lock (this.obj)
								{
									if (Resetproxy_MobiProxy(linkserver_mobiproxy, text2))
									{
										Sleep(10.0);
										break;
									}
								}
							}
							while (!checkproxy_mobiproxy(text2.Split(':')[0], text2.Split(':')[1], linkserver_mobiproxy))
							{
							}
							Sleep(1.0);
							break;
						case "OCBPROXY":
							dataGridView2.Rows[index].Cells["trangthai1"].Value = "Đang reset OCBPROXY (" + apikey + ")...";
							text2 = apikey;
							while (true)
							{
								lock (this.obj)
								{
									if (Resetproxy_OCBProxy(linkserver_mobiproxy, text2))
									{
										Sleep(6.0);
										break;
									}
								}
							}
							while (!checkproxy_ocbproxy(text2, linkserver_mobiproxy))
							{
							}
							Sleep(1.0);
							break;
						case "XPROXY":
							text2 = apikey;
							while (true)
							{
								lock (this.obj)
								{
									if (Reset_Xproxy(linkserver_mobiproxy, text2))
									{
										Sleep(6.0);
										break;
									}
								}
							}
							while (!checkproxy_Xproxy(text2, linkserver_mobiproxy))
							{
							}
							Sleep(1.0);
							Sleep(1.0);
							break;
						case "PROXYFB.COM":
							{
								while (true)
								{
									dataGridView2.Rows[index].Cells["trangthai1"].Value = "Đang lấy ip Proxyfb.com...";
									string sVContent_proxyfb = getSVContent_proxyfb(svUrl_proxyfb + "/api/changeProxy.php?key=" + apikey + "&location=0");
									if (sVContent_proxyfb != "")
									{
										try
										{
											JObject jObject = JObject.Parse(sVContent_proxyfb);
											if (bool.Parse(jObject["success"]!.ToString()))
											{
												text2 = jObject["proxy"]!.ToString();
												if (text2 != "" && text2.Contains(":"))
												{
													Console.WriteLine("API: " + apikey + "==> proxy: " + text2);
													break;
												}
											}
											else
											{
												num = int.Parse(Regex.Match(sVContent_proxyfb, "wait (\\d+)").Groups[1].Value);
												if (num > 0)
												{
													for (int i = 0; i < num; i++)
													{
														dataGridView2.Rows[index].Cells["trangthai1"].Value = $"Chờ request get ip proxyfb {i} / {num}";
														Sleep(1.0);
													}
												}
											}
										}
										catch
										{
										}
									}
									Sleep(6.0);
								}
								break;
							}
						end_IL_013c:
							break;
					}
					try
					{
						switch (action)
						{
							case 0:
								switch (index_login)
								{
									case 0:
										login_uid_pass(index_chrome, index, uid, pass, text3, text2, text5, text6);
										break;
									case 1:
										login_cookie(index_chrome, index, uid, pass, text3, text4, text2, text5, text6);
										break;
								}
								break;
							case 1:
								switch (index_login)
								{
									case 0:
										unlock_uid_pass(index_chrome, index, uid, pass, text3, text2, text5, text6, index_captcha, text_api_captcha, index_phone, text_api_phone, limit_getphone, limit_getcodephone, combo_image, ngonngu, type_mail, combo_server_sim);
										break;
									case 1:
										cookie76324hgjdf(index_chrome, index, uid, pass, text3, text4, text2, text5, text6, index_captcha, text_api_captcha, index_phone, text_api_phone, limit_getphone, limit_getcodephone, combo_image, ngonngu, type_mail, combo_server_sim);
										break;
								}
								break;
							case 2:
								switch (index_login)
								{
									case 0:
										verify_uid_pass(index_chrome, index, uid, pass, text2, ngonngu, type_mail);
										break;
									case 1:
										verify_cookie(index_chrome, index, uid, pass, text4, text2, ngonngu, type_mail);
										break;
								}
								break;
						}
					}
					catch (Exception ex)
					{
						dataGridView2.Rows[index].Cells["trangthai1"].Value = "[Lỗi]   " + ex.Message;
					}
				end_IL_002d:;
				}
				catch (Exception ex2)
				{
					dataGridView2.Rows[index].Cells["trangthai1"].Value = "[Lỗi]   " + ex2.Message;
				}
				Thread.Sleep(10);
				UpdateData(index);
			}
			IsRunning_login = false;
			Invoke((Action)delegate
			{
				linkLabel9.Enabled = true;
				linkLabel8.Enabled = false;
			});
		}

		[Obsolete]
		public void reg(int index_chrome, string apikey, string type_ip, int index_phone, string text_api_phone, string text_api_captcha, string type_mail, int index_captcha, int limit_getphone, int limit_getcodephone, int delay_reg, string ngonngu, string combo_image, string combo_server_sim, string combo_sex)
		{
			while (IsRunning)
			{
				bool flag = false;
				string text = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;
				Random random = new Random();
				IntPtr handle = IntPtr.Zero;
				int num = 0;
				Panel ptn2 = new Panel();
				Label name = new Label();
				string text2 = manguser_agent[random.Next(0, manguser_agent.Length)];
				Point pointFromIndexPosition = GetPointFromIndexPosition(index_chrome, Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				Point sizeChrome = GetSizeChrome(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				int num2 = 0;
				string text3 = "hn";
				string text4 = string.Empty;
				int num3 = 0;
				ChromeDriver driver = null;
				Omocaptcha omocaptcha = new Omocaptcha();
				Emailfaker emailfaker = new Emailfaker();
				Mailtm mailtm = new Mailtm();
				Hotmailbox hotmailbox = new Hotmailbox();
				string text5 = list_lastname[random.Next(0, list_lastname.Length)];
				string text6 = list_firstname[random.Next(0, list_firstname.Length)];
				string account_mailtm = string.Empty;
				string hotmail = string.Empty;
				string passhotmail = string.Empty;
				string pass_mailtm = string.Empty;
				string empty = string.Empty;
				string empty2 = string.Empty;
				string result = string.Empty;
				string empty3 = string.Empty;
				try
				{
					switch (type_ip)
					{
						case "TINSOFT":
							while (true)
							{
								Console.WriteLine("API: " + apikey);
								string sVContent = getSVContent(svUrl + "/api/changeProxy.php?key=" + apikey + "&location=0");
								if (sVContent != "")
								{
									try
									{
										JObject jObject4 = JObject.Parse(sVContent);
										if (bool.Parse(jObject4["success"]!.ToString()))
										{
											text4 = jObject4["proxy"]!.ToString();
											if (text4 != "" && text4.Contains(":"))
											{
												Console.WriteLine("API: " + apikey + "==> proxy: " + text4);
												break;
											}
										}
										else
										{
											num2 = int.Parse(Regex.Match(sVContent, "wait (\\d+)").Groups[1].Value);
											if (num2 > 0)
											{
												for (int k = 0; k < num2; k++)
												{
													Console.WriteLine("API: " + apikey + " wait: " + k + "/" + num2);
													Sleep(1.0);
												}
											}
										}
									}
									catch
									{
									}
								}
								Sleep(6.0);
							}
							break;
						case "TMPROXY":
							while (true)
							{
								List<string> list = new List<string>();
								RestClient restClient = new RestClient("https://tmproxy.com/api/proxy/get-new-proxy");
								restClient.Timeout = -1;
								RestRequest restRequest = new RestRequest(Method.POST);
								restRequest.AddHeader("Content-Type", "application/json");
								string value = "{\"api_key\": \"" + apikey + "\",\"id_location\": 1}";
								restRequest.AddParameter("application/json", value, ParameterType.RequestBody);
								IRestResponse restResponse = restClient.Execute(restRequest);
								JObject jObject5 = JObject.Parse(restResponse.Content);
								list.Add(jObject5["message"]!.ToString());
								JToken jToken = jObject5["data"];
								if (jToken != null)
								{
									list.Add(jToken["https"]!.ToString());
								}
								if (list[0] == "")
								{
									text4 = list[1];
								}
								else if (list[0].Contains("retry"))
								{
									int[] array = (from m in Regex.Matches(list[0], "\\d+").OfType<Match>()
												   select int.Parse(m.Value)).ToArray();
									text4 = "wait|" + Convert.ToInt32(array[0].ToString());
								}
								else if (list[0].ToLower().Contains("hết"))
								{
									text4 = "TMProxy Hết Hạn";
								}
								if (text4 != "" && text4.Contains(":"))
								{
									break;
								}
								Sleep(6.0);
							}
							break;
						case "SHOPLIKEPROXY":
							while (true)
							{
								Console.WriteLine("API: " + apikey);
								NetHelper netHelper2 = new NetHelper();
								string text9 = "http://proxy.shoplike.vn/Api/getNewProxy?access_token=" + apikey;
								if (text3 != "")
								{
									text9 = text9 + "&location=" + text3;
								}
								string text10 = netHelper2.RequestGet(text9);
								if (text10.Contains("success"))
								{
									JObject jObject3 = JObject.Parse(text10);
									string text11 = JObject.Parse(JObject.Parse(text10)["data"]!.ToString())["proxy"]!.ToString();
									if (text11 != "")
									{
										text4 = text11;
									}
								}
								else
								{
									if (text10.Contains("Het proxy"))
									{
										Console.WriteLine("API: " + apikey + "==> Het proxy");
										break;
									}
									if (text10.Contains("Con lai"))
									{
										int num5 = Convert.ToInt32(Regex.Match(text10, "Con lai (.*?) giay").Groups[1].Value);
										text4 = "Đợi " + num5;
										for (int j = 0; j < num5; j++)
										{
											Console.WriteLine("API: " + apikey + " wait: " + j + "/" + num5);
											Sleep(1.0);
										}
									}
									else if (text10.Contains("het han"))
									{
										text4 = "hethan";
									}
								}
								if (text4 != "" && text4.Contains(":"))
								{
									Console.WriteLine("API: " + apikey + "==> proxy: " + text4);
									goto end_IL_01d9;
								}
								Sleep(2.0);
							}
							goto end_IL_01d3;
						case "MINPROXY":
							while (true)
							{
								NetHelper netHelper = new NetHelper();
								string url = "https://dash.minproxy.vn/api/rotating/v1/proxy/get-new-proxy?api_key=" + apikey;
								string text7 = netHelper.RequestGet(url);
								if (text7.Contains("lay proxy thanh cong"))
								{
									JObject jObject2 = JObject.Parse(text7);
									string text8 = JObject.Parse(JObject.Parse(text7)["data"]!.ToString())["http_proxy"]!.ToString();
									if (text8 != "")
									{
										text4 = text8;
									}
								}
								else if (text7.Contains("lay proxy moi that bai"))
								{
									int num4 = Convert.ToInt32(Regex.Match(text7, "next_request\":(\\d+)").Groups[1].Value);
									text4 = "Đợi " + num4;
									Sleep(num4);
								}
								else if (text7.Contains("api wrong"))
								{
									text4 = "hethan";
								}
								if (text4 != "" && text4.Contains(":"))
								{
									break;
								}
								Sleep(1.0);
							}
							break;
						case "LISTPROXY":
							if (count_dem_proxyhttp >= mangproxy.Length)
							{
								count_dem_proxyhttp = 0;
							}
							text4 = mangproxy[count_dem_proxyhttp];
							count_dem_proxyhttp++;
							break;
						case "PROXYV6.NET":
							if (count_dem_proxyhttp >= mangproxy.Length)
							{
								count_dem_proxyhttp = 0;
							}
							text4 = mangproxy[count_dem_proxyhttp];
							count_dem_proxyhttp++;
							while (!ProxyV6Helper.Changeip(api_proxyv6, text4.Split(':')[0], text4.Split(':')[1]))
							{
								Sleep(1.0);
							}
							while (!ProxyV6Helper.Check_rotating_v6(api_proxyv6, text4.Split(':')[0], text4.Split(':')[1]))
							{
								Sleep(1.0);
							}
							Sleep(1.0);
							break;
						case "WIFI":
							text4 = "";
							break;
						case "MOBIPROXY":
							text4 = apikey;
							while (true)
							{
								lock (this.obj)
								{
									if (Resetproxy_MobiProxy(linkserver_mobiproxy, text4))
									{
										Sleep(10.0);
										break;
									}
								}
							}
							while (!checkproxy_mobiproxy(text4.Split(':')[0], text4.Split(':')[1], linkserver_mobiproxy))
							{
							}
							Sleep(1.0);
							break;
						case "OCBPROXY":
							text4 = apikey;
							while (true)
							{
								lock (this.obj)
								{
									if (Resetproxy_OCBProxy(linkserver_mobiproxy, text4))
									{
										Sleep(6.0);
										break;
									}
								}
							}
							while (!checkproxy_ocbproxy(text4, linkserver_mobiproxy))
							{
							}
							Sleep(1.0);
							break;
						case "XPROXY":
							text4 = apikey;
							while (true)
							{
								lock (this.obj)
								{
									if (Reset_Xproxy(linkserver_mobiproxy, text4))
									{
										Sleep(6.0);
										break;
									}
								}
							}
							while (!checkproxy_Xproxy(text4, linkserver_mobiproxy))
							{
							}
							Sleep(1.0);
							Sleep(1.0);
							break;
						case "PROXYFB.COM":
							{
								while (true)
								{
									Console.WriteLine("API: " + apikey);
									string sVContent_proxyfb = getSVContent_proxyfb(svUrl_proxyfb + "/api/changeProxy.php?key=" + apikey + "&location=0");
									if (sVContent_proxyfb != "")
									{
										try
										{
											JObject jObject = JObject.Parse(sVContent_proxyfb);
											if (bool.Parse(jObject["success"]!.ToString()))
											{
												text4 = jObject["proxy"]!.ToString();
												if (text4 != "" && text4.Contains(":"))
												{
													Console.WriteLine("API: " + apikey + "==> proxy: " + text4);
													break;
												}
											}
											else
											{
												num2 = int.Parse(Regex.Match(sVContent_proxyfb, "wait (\\d+)").Groups[1].Value);
												if (num2 > 0)
												{
													for (int i = 0; i < num2; i++)
													{
														Console.WriteLine("API: " + apikey + " wait: " + i + "/" + num2);
														Sleep(1.0);
													}
												}
											}
										}
										catch
										{
										}
									}
									Sleep(6.0);
								}
								break;
							}
						end_IL_01d9:
							break;
					}
					string myip = text4.Split(':')[0];
					XuanAction xuanAction = new XuanAction();
					TimeSpan span = new TimeSpan(0, 2, 0);
					TimeSpan span2 = new TimeSpan(0, 2, 0);
					TimeSpan span3 = new TimeSpan(0, 5, 0);
					TimeSpan span4 = new TimeSpan(0, 0, 30);
					ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
					chromeDriverService.HideCommandPromptWindow = true;
					ChromeOptions chromeOptions = new ChromeOptions();
					chromeOptions.AddArgument("--app=https://mbasic.facebook.com/");
					if (text4 != "" && text4.Split(':').Length == 2)
					{
						chromeOptions.AddArgument("--proxy-server= " + text4);
					}
					else if (text4 != "" && text4.Split(':').Length == 4)
					{
						chromeOptions.AddHttpProxy(text4.Split(':')[0], int.Parse(text4.Split(':')[1]), text4.Split(':')[2], text4.Split(':')[3]);
					}
					chromeOptions.AddArguments("--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--window-size=" + sizeChrome.X + "," + sizeChrome.Y, "--window-position=" + pointFromIndexPosition.X + "," + pointFromIndexPosition.Y, "--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36", "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=BlockCredentialedSubresources", "--disable-popup-blocking");
					chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 0);
					chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
					chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
					chromeOptions.AddExcludedArgument("enable-automation");
					chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
					chromeOptions.AddArgument("user-agent=" + text2);
					UserAgent = text2;
					ChromeMobileEmulationDeviceSettings chromeMobileEmulationDeviceSettings = new ChromeMobileEmulationDeviceSettings();
					chromeMobileEmulationDeviceSettings.EnableTouchEvents = true;
					chromeMobileEmulationDeviceSettings.Width = sizeChrome.X;
					chromeMobileEmulationDeviceSettings.Height = sizeChrome.Y;
					chromeMobileEmulationDeviceSettings.UserAgent = UserAgent;
					chromeMobileEmulationDeviceSettings.PixelRatio = PixelRatio;
					ChromeMobileEmulationDeviceSettings deviceSettings = chromeMobileEmulationDeviceSettings;
					chromeOptions.EnableMobileEmulation(deviceSettings);
					driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3.0));
					driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
					driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(6.0);
					if (!cbaddview.Checked)
					{
						goto IL_13ca;
					}
					try
					{
						num = chromeDriverService.ProcessId;
						Process windowHandleByDriverId = GetWindowHandleByDriverId(num);
						handle = windowHandleByDriverId.MainWindowHandle;
						Thread.Sleep(1000);
					}
					catch
					{
						goto end_IL_01d3;
					}
					if (num != 0)
					{
						Sleep(1.0);
						lock (this.obj)
						{
							Invoke((Action)delegate
							{
								ptn2.Width = 280;
								ptn2.Height = 300;
								ptn2.BorderStyle = BorderStyle.FixedSingle;
								ptn2.AutoScroll = true;
								ptn2.SetAutoScrollMargin(320, 480);
								name.Text = "IP:" + myip;
								name.Location = new Point(0, 0);
								ptn2.Controls.Add(name);
								Invoke((Action)delegate
								{
									flowLayoutPanel1.Controls.Add(ptn2);
								});
								SetParent(handle, ptn2.Handle);
								SetWindowLong(handle, -4, WS_VISIBLE);
								MoveWindow(handle, -8, -36, 320, 480, Repaint: true);
								driver.Manage().Window.Position = new Point(0, 15);
							});
						}
						goto IL_13ca;
					}
					goto end_IL_01d3;
				IL_13ca:
					if (Path_Tool == null)
					{
						Path_Tool = Application.StartupPath;
					}
					string text_image = string.Empty;
					string empty4 = string.Empty;
					string empty5 = string.Empty;
					string account_tempmail = string.Empty;
					string empty6 = string.Empty;
					string empty7 = string.Empty;
					Sleep(1.0);
					string uid = string.Empty;
					Otpygo otpygo = new Otpygo();
					Sellotpvn sellotpvn = new Sellotpvn();
					Sell282xyz sell282xyz = new Sell282xyz();
					Numberotp numberotp = new Numberotp();
					Atmteam2 atmteam = new Atmteam2();
					Fb282 fb = new Fb282();
					Otpngon otpngon = new Otpngon();
					good9fun good9fun2 = new good9fun();
					Atmteam atmteam2 = new Atmteam();
					Goodotp goodotp = new Goodotp();
					Sellotp sellotp = new Sellotp();
					Suppersim suppersim = new Suppersim();
					hcotp hcotp = new hcotp();
					Winmail winmail = new Winmail();
					Trumotpvn trumotpvn = new Trumotpvn();
					Vutruotp vutruotp = new Vutruotp();
					Ironsim ironsim = new Ironsim();
					string cookie = string.Empty;
					Ndline ndline = new Ndline();
					Viotp viotp = new Viotp();
					Tempsms tempsms = new Tempsms();
					string text12 = string.Empty;
					Codetext247 codetext = new Codetext247();
					Tempcode tempcode = new Tempcode();
					Bossotp bossotp = new Bossotp();
					Testbossotp testbossotp = new Testbossotp();
					Otp282 otp = new Otp282();
					Sim24 sim = new Sim24();
					Chothuesimcode chothuesimcode = new Chothuesimcode();
					string text13 = string.Empty;
					string text14 = string.Empty;
					int num6 = 0;
					string text15 = string.Empty;
					switch (type_mail)
					{
						case "Mailtm":
							while (true)
							{
								empty = mailtm.getdomains();
								if (empty != "" && empty != null)
								{
									break;
								}
								Sleep(1.0);
							}
							account_mailtm = Getrandomemail() + "@" + empty;
							pass_mailtm = Getrandompassmailtm();
							break;
						case "Hotmail":
							emailQueue.TryDequeue(out result);
							if (result != null)
							{
								empty2 = result;
								string[] array2 = result.Split('|');
								hotmail = array2[0];
								passhotmail = array2[1];
								File.AppendAllText("Data_Reg\\email_runned.txt", result + "\n");
								Invoke((Action)delegate
								{
									linkLabel10.Text = "[ " + emailQueue.Count + " ]";
								});
								break;
							}
							goto end_IL_01d3;
						case "Emailfake.com":
							while (true)
							{
								account_tempmail = emailfaker.Getmail();
								if (account_tempmail != "" && account_tempmail != null)
								{
									break;
								}
								Sleep(1.0);
							}
							break;
					}

					string passfacebook = Getrandompassfacebook();
					string text16 = string.Empty;
					switch (type_ip)
					{
						case "PROXYV6.NET":
						case "LISTPROXY":
						case "MINPROXY":
							if (xuanAction.Goto(driver, "https://m.facebook.com", span))
							{
								break;
							}
							goto end_IL_01d3;
					}
					while (xuanAction.Goto(driver, "https://m.facebook.com", span) && !driver.PageSource.Contains("Không thể truy cập trang web này") && !driver.PageSource.Contains("This site can’t be reached"))
					{
						int num7 = 0;
						while (true)
						{
							if (driver.FindElements(By.XPath("//button[@data-cookiebanner='accept_button']")).Count > 0 && xuanAction.ClickElement(driver, By.XPath("//button[@data-cookiebanner='accept_button']"), span4))
							{
								Sleep(1.0);
							}
							if (driver.FindElements(By.XPath("//a[@id='signup-button']")).Count > 0)
							{
								if (xuanAction.ClickElement(driver, By.XPath("//a[@id='signup-button']"), span4))
								{
									Sleep(1.0);
									int num8 = 0;
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@name='lastname']")).Count > 0)
										{

											driver.FindElement(By.XPath("//input[@name='lastname']")).SendKeys(text5);
											Thread.Sleep(200);
											driver.FindElement(By.XPath("//input[@name='firstname']")).SendKeys(text6);
											Thread.Sleep(200);
											int num9 = 0;
											while (true)
											{
												if (driver.FindElements(By.XPath("//button[@data-sigil='touchable multi_step_next']")).Count > 0)
												{
													xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable multi_step_next']"), span3);
													int num10 = 0;
													while (true)
													{
														if (driver.FindElements(By.XPath("//select[@name='birthday_day']")).Count > 0)
														{
															Sleep(1.0);
															int num11 = random.Next(1, 20);
															IWebElement element = driver.FindElement(By.Name("birthday_day"));
															SelectElement selectElement = new SelectElement(element);
															selectElement.SelectByValue(num11.ToString());
															Thread.Sleep(100);
															int num12 = random.Next(1, 12);
															element = driver.FindElement(By.Name("birthday_month"));
															selectElement = new SelectElement(element);
															selectElement.SelectByValue(num12.ToString());
															Thread.Sleep(100);
															int num13 = random.Next(1990, 2000);
															element = driver.FindElement(By.Name("birthday_year"));
															selectElement = new SelectElement(element);
															selectElement.SelectByValue(num13.ToString());
															while (!xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable multi_step_next']"), span2))
															{
															}
															Sleep(1.0);
															int num14 = 0;
															while (true)
															{
																if (driver.FindElements(By.XPath("//a[@data-sigil='switch_phone_to_email']")).Count > 0)
																{
																	if (xuanAction.ClickElement(driver, By.XPath("//a[@data-sigil='switch_phone_to_email']"), span2))
																	{
																		Sleep(1.0);
																		switch (type_mail)
																		{
																			case "Mailtm":
																				{
																					if (!mailtm.Create_Mailtm(account_mailtm, pass_mailtm, text4))
																					{
																						goto end_IL_1f36;
																					}
																					Sleep(1.0);
																					int num16 = 0;
																					while (true)
																					{
																						if (driver.FindElements(By.XPath("//input[@name='reg_email__']")).Count > 0)
																						{
																							driver.FindElement(By.XPath("//input[@name='reg_email__']")).SendKeys(account_mailtm);
																							Thread.Sleep(200);
																							break;
																						}
																						if (num16 != 15)
																						{
																							Sleep(1.0);
																							num16++;
																							continue;
																						}
																						goto end_IL_1f36;
																					}
																					goto default;
																				}
																			case "Hotmail":
																				{
																					int num17 = 0;
																					while (true)
																					{
																						if (driver.FindElements(By.XPath("//input[@name='reg_email__']")).Count > 0)
																						{
																							driver.FindElement(By.XPath("//input[@name='reg_email__']")).SendKeys(hotmail);
																							Thread.Sleep(200);
																							break;
																						}
																						if (num17 != 15)
																						{
																							Sleep(1.0);
																							num17++;
																							continue;
																						}
																						goto end_IL_1f36;
																					}
																					goto default;
																				}
																			case "Emailfake.com":
																				{
																					int num15 = 0;
																					while (true)
																					{
																						if (driver.FindElements(By.XPath("//input[@name='reg_email__']")).Count > 0)
																						{
																							driver.FindElement(By.XPath("//input[@name='reg_email__']")).SendKeys(account_tempmail);
																							Thread.Sleep(200);
																							break;
																						}
																						if (num15 != 15)
																						{
																							Sleep(1.0);
																							num15++;
																							continue;
																						}
																						goto end_IL_1f36;
																					}
																					goto default;
																				}
																			default:
																				{
																					while (!xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable multi_step_next']"), span2))
																					{
																					}
																					Sleep(1.0);
																					int num18 = 0;
																					while (true)
																					{
																						if (driver.FindElements(By.XPath("//input[@name='sex'][@value='1']")).Count > 0)
																						{
																							//int num19 = random.Next(10);
																							empty3 = combo_sex;
																							if (empty3.Contains("Nữ"))
																							{
																								empty3 = "Nữ";
																								xuanAction.ClickElement(driver, By.XPath("//input[@name='sex'][@value='1']"), span2);
																								Thread.Sleep(100);
																							}
																							else if (empty3.Contains("Nam"))
																							{
																								empty3 = "nam";
																								xuanAction.ClickElement(driver, By.XPath("//input[@name='sex'][@value='2']"), span2);
																								Thread.Sleep(100);
																							}
																							else
                                                                                            {
																								int num19 = random.Next(10);
																								if (num19 % 2 ==0)
																								{
																									empty3 = "Nữ";
																									xuanAction.ClickElement(driver, By.XPath("//input[@name='sex'][@value='1']"), span2);
																									Thread.Sleep(100);
																								}
																								else 
																								{
																									empty3 = "nam";
																									xuanAction.ClickElement(driver, By.XPath("//input[@name='sex'][@value='2']"), span2);
																									Thread.Sleep(100);
																								}

																							}
																							while (!xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable multi_step_next']"), span2))
																							{
																							}
																							Sleep(1.0);
																							int num20 = 0;
																							while (true)
																							{
																								if (driver.FindElements(By.XPath("//input[@name='reg_passwd__']")).Count > 0)
																								{
																									driver.FindElement(By.XPath("//input[@name='reg_passwd__']")).SendKeys(passfacebook);
																									Thread.Sleep(200);
																									int num21 = 0;
																									while (true)
																									{
																										if (driver.FindElements(By.XPath("//button[@data-sigil='touchable multi_step_submit']")).Count > 0)
																										{
																											driver.FindElement(By.XPath("//button[@data-sigil='touchable multi_step_submit']")).Click();
																											Sleep(1.0);
																											break;
																										}
																										if (num21 != 10)
																										{
																											Sleep(1.0);
																											num21++;
																											continue;
																										}
																										goto end_IL_1eba;
																									}
																									goto end_IL_1a48;
																								}
																								if (num20 != 15)
																								{
																									Sleep(1.0);
																									num20++;
																									continue;
																								}
																								break;
																								continue;
																							end_IL_1eba:
																								break;
																							}
																							break;
																						}
																						if (num18 != 15)
																						{
																							Sleep(1.0);
																							num18++;
																							continue;
																						}
																						break;
																					}
																					goto end_IL_1f36;
																				}
																			end_IL_1a48:
																				break;
																		}
																		goto IL_24ab;
																	}
																	goto IL_1f1a;
																}
																if (num14 != 15)
																{
																	goto IL_1f1a;
																}
																break;
															IL_1f1a:
																Sleep(1.0);
																num14++;
																continue;
															end_IL_1f36:
																break;
															}
															break;
														}
														if (num10 != 15)
														{
															Sleep(1.0);
															num10++;
															continue;
														}
														break;
													}
													break;
												}
												if (driver.FindElements(By.XPath("//input[@id='password_step_input']")).Count <= 0)
												{
													if (num9 == 5)
													{
														break;
													}
													num9++;
													Sleep(1.0);
													continue;
												}
												if (type_mail == "Mailtm")
												{
													if (!mailtm.Create_Mailtm(account_mailtm, pass_mailtm, text4))
													{
														break;
													}
													Sleep(1.0);
													int num22 = 0;
													while (true)
													{
														if (driver.FindElements(By.XPath("//input[@name='reg_email__']")).Count > 0)
														{
															driver.FindElement(By.XPath("//input[@name='reg_email__']")).SendKeys(account_mailtm);
															Thread.Sleep(200);
															break;
														}
														if (num22 != 15)
														{
															Sleep(1.0);
															num22++;
															continue;
														}
														goto end_IL_19732;
													}
												}
												else if (type_mail == "Hotmail")
												{
													int num23 = 0;
													while (true)
													{
														if (driver.FindElements(By.XPath("//input[@name='reg_email__']")).Count > 0)
														{
															driver.FindElement(By.XPath("//input[@name='reg_email__']")).SendKeys(hotmail);
															Thread.Sleep(200);
															break;
														}
														if (num23 != 15)
														{
															Sleep(1.0);
															num23++;
															continue;
														}
														goto end_IL_19732;
													}
												}
												int num24 = 0;
												while (true)
												{
													if (driver.FindElements(By.XPath("//input[@name='sex'][@value='1']")).Count > 0)
													{
														int num25 = random.Next(10);
														if (num25 % 2 == 0)
														{
															xuanAction.ClickElement(driver, By.XPath("//input[@name='sex'][@value='1']"), span2);
															Thread.Sleep(100);
														}
														else
														{
															xuanAction.ClickElement(driver, By.XPath("//input[@name='sex'][@value='2']"), span2);
															Thread.Sleep(100);
														}
														int num26 = 0;
														while (true)
														{
															if (driver.FindElements(By.XPath("//select[@name='birthday_day']")).Count > 0)
															{
																Sleep(1.0);
																int num27 = random.Next(1, 20);
																IWebElement element2 = driver.FindElement(By.Name("birthday_day"));
																SelectElement selectElement2 = new SelectElement(element2);
																selectElement2.SelectByValue(num27.ToString());
																Thread.Sleep(100);
																int num28 = random.Next(1, 12);
																element2 = driver.FindElement(By.Name("birthday_month"));
																selectElement2 = new SelectElement(element2);
																selectElement2.SelectByValue(num28.ToString());
																Thread.Sleep(100);
																int num29 = random.Next(1990, 2000);
																element2 = driver.FindElement(By.Name("birthday_year"));
																selectElement2 = new SelectElement(element2);
																selectElement2.SelectByValue(num29.ToString());
																int num30 = 0;
																while (true)
																{
																	if (driver.FindElements(By.XPath("//input[@name='reg_passwd__']")).Count > 0)
																	{
																		driver.FindElement(By.XPath("//input[@name='reg_passwd__']")).SendKeys(passfacebook);
																		Thread.Sleep(200);
																		int num31 = 0;
																		while (true)
																		{
																			if (driver.FindElements(By.XPath("//input[@name='submit']")).Count > 0)
																			{
																				xuanAction.ClickElement(driver, By.XPath("//input[@name='submit']"), span4);
																				break;
																			}
																			if (num31 != 15)
																			{
																				Sleep(1.0);
																				num31++;
																				continue;
																			}
																			goto end_IL_19732;
																		}
																		break;
																	}
																	if (num30 != 15)
																	{
																		Sleep(1.0);
																		num30++;
																		continue;
																	}
																	goto end_IL_19732;
																}
																break;
															}
															if (num26 != 15)
															{
																Sleep(1.0);
																num26++;
																continue;
															}
															goto end_IL_19732;
														}
														break;
													}
													if (num24 != 15)
													{
														Sleep(1.0);
														num24++;
														continue;
													}
													goto end_IL_19732;
												}
												goto IL_24ab;
											IL_24ab:
												Sleep(delay_reg);
												int num32 = 0;
												while (true)
												{
													if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
													{
														while (true)
														{
															if (driver.PageSource.Contains("30 ngày") || driver.PageSource.Contains("30 days"))
															{
																flag = false;
																break;
															}
															if (driver.PageSource.Contains("180 ngày") || driver.PageSource.Contains("180 days"))
															{
																flag = true;
																break;
															}
														}
														if (cb_180day.Checked && !flag)
														{
															break;
														}
														if (driver.Url.Contains("mbasic.facebook.com"))
														{
															xuanAction.Goto(driver, "https://m.facebook.com/", span);
														}
														int num33 = 0;
														while (true)
														{
															if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
															{
																if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span2))
																{
																	Sleep(1.0);
																	cookie = GetCookieCurrentChrome(driver);
																	uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																	break;
																}
															}
															else if (num33 == 10)
															{
																goto end_IL_19724;
															}
															Sleep(1.0);
															num33++;
														}
													}
													else
													{
														if (driver.PageSource.Contains("Registration Error") || driver.PageSource.Contains("Lô\u0303i đăng ky\u0301") || driver.PageSource.Contains("Registration Error") || driver.PageSource.Contains("Lô\u0303i đăng ky\u0301") || driver.PageSource.Contains("Đã xảy ra lỗi với đăng ký của bạn. Vui lòng thử đăng ký lại.") || driver.PageSource.Contains("Please try registering again") || driver.Url.Contains("Fm.facebook.com%2Ferror") || driver.FindElements(By.XPath("//input[@name='reg_passwd__']")).Count > 0)
														{
															break;
														}
														if (driver.Url.Contains("login/save-device"))
														{
															if (!cbverify.Checked)
															{
																cookie = GetCookieCurrentChrome(driver);
																uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																string time61 = DateTime.Now.ToString();
																lock (this.obj)
																{
																	tongreg++;
																	File.AppendAllText("Account_282\\" + text + "_noveri_live.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time61 + "\n");
																}
																Invoke((Action)delegate
																{
																	lb_tongreg.Text = tongreg + " accounts";
																	dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account noveri live (" + time61 + ")");
																});
																break;
															}
															switch (gyguysgfuer(driver, xuanAction, hotmailbox, mailtm, account_mailtm, pass_mailtm, hotmail, passhotmail, type_mail, text4, account_tempmail, emailfaker))
															{
																case "OK":
																	{
																		cookie = GetCookieCurrentChrome(driver);
																		uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																		string time59 = DateTime.Now.ToString();
																		switch (type_mail)
																		{
																			case "Mailtm":
																				lock (this.obj)
																				{
																					tongreg++;
																					File.AppendAllText("Account_282\\" + text + "_verify_mailtm.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time59 + "\n");
																				}
																				Invoke((Action)delegate
																				{
																					lb_tongreg.Text = tongreg + " accounts";
																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account Verify mailtm (" + time59 + ")");
																				});
																				break;
																			case "Hotmail":
																				lock (this.obj)
																				{
																					tongreg++;
																					File.AppendAllText("Account_282\\" + text + "_verify_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time59 + "\n");
																				}
																				Invoke((Action)delegate
																				{
																					lb_tongreg.Text = tongreg + " accounts";
																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account Verify hotmail (" + time59 + ")");
																				});
																				break;
																			case "Emailfake.com":
																				lock (this.obj)
																				{
																					tongreg++;
																					File.AppendAllText("Account_282\\" + text + "_verify_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time59 + "\n");
																				}
																				Invoke((Action)delegate
																				{
																					lb_tongreg.Text = tongreg + " accounts";
																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account Verify emailfake (" + time59 + ")");
																				});
																				break;
																		}
																		goto end_IL_19724;
																	}
																case "ERROR":
																	{
																		cookie = GetCookieCurrentChrome(driver);
																		uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																		string time60 = DateTime.Now.ToString();
																		lock (this.obj)
																		{
																			tongreg++;
																			File.AppendAllText("Account_282\\" + text + "_noveri_error.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time60 + "\n");
																		}
																		Invoke((Action)delegate
																		{
																			lb_tongreg.Text = tongreg + " accounts";
																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Lỗi khi verify mail account noveri (" + time60 + ")");
																		});
																		goto end_IL_19724;
																	}
																case "CAPTCHA":
																	break;
																default:
																	goto IL_19708;
															}
														}
														else
														{
															if (driver.FindElements(By.XPath("//span[contains(text(),'Ok')]")).Count <= 0 && driver.FindElements(By.XPath("//button[@value='OK']")).Count <= 0)
															{
																if (num32 == 5)
																{
																	break;
																}
																goto IL_19708;
															}
															if (!cbverify.Checked)
															{
																cookie = GetCookieCurrentChrome(driver);
																uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																string time58 = DateTime.Now.ToString();
																lock (this.obj)
																{
																	tongreg++;
																	File.AppendAllText("Account_282\\" + text + "_noveri_live.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time58 + "\n");
																}
																Invoke((Action)delegate
																{
																	lb_tongreg.Text = tongreg + " accounts";
																	dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account noveri live (" + time58 + ")");
																});
																break;
															}
															switch (gyguysgfuer(driver, xuanAction, hotmailbox, mailtm, account_mailtm, pass_mailtm, hotmail, passhotmail, type_mail, text4, account_tempmail, emailfaker))
															{
																case "OK":
																	{
																		cookie = GetCookieCurrentChrome(driver);
																		uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																		string time55 = DateTime.Now.ToString();
																		switch (type_mail)
																		{
																			case "Mailtm":
																				lock (this.obj)
																				{
																					tongreg++;
																					File.AppendAllText("Account_282\\" + text + "_verify_mailtm.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time55 + "\n");
																				}
																				Invoke((Action)delegate
																				{
																					lb_tongreg.Text = tongreg + " accounts";
																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account Verify mailtm (" + time55 + ")");
																				});
																				break;
																			case "Hotmail":
																				lock (this.obj)
																				{
																					tongreg++;
																					File.AppendAllText("Account_282\\" + text + "_verify_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time55 + "\n");
																				}
																				Invoke((Action)delegate
																				{
																					lb_tongreg.Text = tongreg + " accounts";
																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account Verify hotmail (" + time55 + ")");
																				});
																				break;
																			case "Emailfake.com":
																				lock (this.obj)
																				{
																					tongreg++;
																					File.AppendAllText("Account_282\\" + text + "_verify_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time55 + "\n");
																				}
																				Invoke((Action)delegate
																				{
																					lb_tongreg.Text = tongreg + " accounts";
																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account Verify emailfake (" + time55 + ")");
																				});
																				break;
																		}
																		goto end_IL_19724;
																	}
																case "ERROR":
																	{
																		cookie = GetCookieCurrentChrome(driver);
																		uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																		string time57 = DateTime.Now.ToString();
																		lock (this.obj)
																		{
																			tongreg++;
																			File.AppendAllText("Account_282\\" + text + "_noveri_error.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time57 + "\n");
																		}
																		Invoke((Action)delegate
																		{
																			lb_tongreg.Text = tongreg + " accounts";
																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Lỗi khi verify mail account noveri (" + time57 + ")");
																		});
																		goto end_IL_19724;
																	}
																case "CAPTCHA":
																	break;
																default:
																	goto IL_19708;
															}
														}
													}
													while (true)
													{
													IL_196fa:
														cookie = GetCookieCurrentChrome(driver);
														uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
														Thread.Sleep(100);
														if (cbregkhongunlockkhongcaptcha.Checked)
														{
															cookie = GetCookieCurrentChrome(driver);
															uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
															string time54 = DateTime.Now.ToString();
															lock (this.obj)
															{
																tongreg++;
																File.AppendAllText("Account_282\\" + text + "_checkpoint_282_havecaptcha.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time54 + "\n");
															}
															Invoke((Action)delegate
															{
																lb_tongreg.Text = tongreg + " accounts";
																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 chưa giải captcha (" + time54 + ")");
															});
															break;
														}
														while (true)
														{
															string text17 = string.Empty;
															switch (index_captcha)
															{
																case 0:
																	text17 = CaptchaService.Anycaptcha_Giai_recaptcha(text_api_captcha, "https://fbsbx.com/captcha/recaptcha/iframe/?referer=https://m.facebook.com", "6Lc9qjcUAAAAADTnJq5kJMjN9aD1lxpRLMnCS2TR");
																	goto default;
																case 1:
																	{
																		string empty8 = string.Empty;
																		if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/", span))
																		{
																			goto end_IL_196ed;
																		}
																		while (true)
																		{
																			Sleep(2.0);
																			while (true)
																			{
																				string pageSource = driver.PageSource;
																				empty8 = omocaptcha.get_captcha_persist(pageSource);
																				if (empty8 != "")
																				{
																					break;
																				}
																				Sleep(1.0);
																			}
																			text17 = omocaptcha.GetRecaptchaResponse(text_api_captcha, empty8);
																			if (!(text17 == "Get new"))
																			{
																				break;
																			}
																			while (true)
																			{
																				if (driver.FindElements(By.XPath("//a[contains(text(),'Get a new code')]")).Count > 0)
																				{
																					xuanAction.ClickElement(driver, By.XPath("//a[contains(text(),'Get a new code')]"), span4);
																					Sleep(2.0);
																					break;
																				}
																				if (driver.FindElements(By.XPath("//a[contains(text(),'lấy mã mới')]")).Count > 0)
																				{
																					xuanAction.ClickElement(driver, By.XPath("//a[contains(text(),'lấy mã mới')]"), span4);
																					Sleep(2.0);
																					break;
																				}
																			}
																		}
																		goto default;
																	}
																case 2:
																	text17 = TwoCaptcha.SloveCaptcha(text_api_captcha);
																	if (!(text17 == "ERROR_WRONG_USER_KEY"))
																	{
																		goto default;
																	}
																	goto end_IL_196ed;
																default:
																	{
																		if (text17 != "")
																		{
																			if (index_captcha == 0 || index_captcha == 2)
																			{
																				driver.ExecuteScript("document.querySelector('#captcha_response').value=\"" + text17 + "\"");
																				Thread.Sleep(1000);
																				xuanAction.ClickElement(driver, By.Name("action_submit_bot_captcha_response"), span4);
																				Sleep(4.0);
																			}
																			else if (index_captcha == 1)
																			{
																				driver.FindElement(By.XPath("//input[@id='captcha_response']")).SendKeys(text17);
																				Thread.Sleep(500);
																				xuanAction.ClickElement(driver, By.XPath("//input[@name='action_submit_bot_captcha_response']"), span4);
																				Sleep(4.0);
																				if (driver.FindElements(By.XPath("//input[@name='action_submit_bot_captcha_response']")).Count > 0)
																				{
																					xuanAction.ClickElement(driver, By.XPath("//input[@name='action_submit_bot_captcha_response']"), span4);
																					Sleep(4.0);
																				}
																			}
																			int num34 = CheckExistElements(driver, 10.0, "[name=\"contact_point\"]", "#mobile_image_data", "#captcha_response");
																			if (driver.PageSource.Contains("Không thể truy cập trang web này") || driver.PageSource.Contains("We need more information") || driver.PageSource.Contains("Chúng tôi cần thêm thông tin"))
																			{
																				goto end_IL_196ed;
																			}
																			if (num34 == 3)
																			{
																				continue;
																			}
																			if (num34 != 0)
																			{
																				Thread.Sleep(100);
																			}
																		}
																		Thread.Sleep(10);
																		if (index_captcha == 1 && !xuanAction.Goto(driver, "https://m.facebook.com/", span))
																		{
																			goto end_IL_196ed;
																		}
																		if (driver.PageSource.Contains("captcha_persist_data"))
																		{
																			break;
																		}
																		Sleep(1.0);
																		while (true)
																		{
																			if (driver.FindElements(By.XPath("//button[@name='action_resend_code']")).Count > 0)
																			{
																				if (!xuanAction.ClickElement(driver, By.XPath("//button[@name='action_resend_code']"), span2))
																				{
																					continue;
																				}
																				Sleep(1.0);
																				xuanAction.ClickElement(driver, By.XPath("//button[@name='action_resend_code']"), span2);
																				Sleep(1.0);
																				int num35 = 0;
																				switch (type_mail)
																				{
																					case "Mailtm":
																						while (true)
																						{
																							text16 = mailtm.GetCodeMailTm(account_mailtm, pass_mailtm, text4);
																							if (text16 != "")
																							{
																								break;
																							}
																							if (num35 != 180)
																							{
																								Sleep(1.0);
																								num35++;
																								continue;
																							}
																							goto end_IL_196d6;
																						}
																						break;
																					case "Hotmail":
																						while (true)
																						{
																							text16 = hotmailbox.Getcode(hotmail, passhotmail);
																							if (text16 != "")
																							{
																								break;
																							}
																							if (num35 != 180)
																							{
																								Sleep(1.0);
																								num35++;
																								continue;
																							}
																							goto end_IL_196d6;
																						}
																						break;
																					case "Emailfake.com":
																						while (true)
																						{
																							text16 = emailfaker.Getcode(account_tempmail);
																							if (text16 != "")
																							{
																								break;
																							}
																							if (num35 != 180)
																							{
																								Sleep(1.0);
																								num35++;
																								continue;
																							}
																							goto end_IL_196d6;
																						}
																						break;
																				}
																				if (text16 == null || !(text16 != ""))
																				{
																					break;
																				}
																				int num36 = 0;
																				while (true)
																				{
																					if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
																					{
																						driver.FindElement(By.XPath("//input[@name='code']")).SendKeys(text16);
																						Thread.Sleep(200);
																						while (!xuanAction.ClickElement(driver, By.XPath("//button[@name='action_submit_code']"), span2))
																						{
																						}
																						Sleep(1.0);
																						int num37 = 0;
																						while (true)
																						{
																							if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
																							{
																								if (cbregkhongunlock.Checked)
																								{
																									cookie = GetCookieCurrentChrome(driver);
																									uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																									string time53 = DateTime.Now.ToString();
																									switch (type_mail)
																									{
																										case "Mailtm":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time53 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time53 + ")");
																											});
																											break;
																										case "Hotmail":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time53 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time53 + ")");
																											});
																											break;
																										case "Emailfake.com":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time53 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time53 + ")");
																											});
																											break;
																									}
																									break;
																								}
																								if (cbregkhongunlock.Checked || !xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span2))
																								{
																									goto IL_18cc0;
																								}
																								Sleep(1.0);
																							}
																							else
																							{
																								if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count <= 0)
																								{
																									if (num37 == 15)
																									{
																										if (!cbregkhongunlock.Checked)
																										{
																											break;
																										}
																										cookie = GetCookieCurrentChrome(driver);
																										uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																										string time52 = DateTime.Now.ToString();
																										switch (type_mail)
																										{
																											case "Mailtm":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time52 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time52 + ")");
																												});
																												break;
																											case "Hotmail":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time52 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time52 + ")");
																												});
																												break;
																											case "Emailfake.com":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time52 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time52 + ")");
																												});
																												break;
																										}
																										break;
																									}
																									goto IL_18cc0;
																								}
																								if (cbregkhongunlock.Checked)
																								{
																									cookie = GetCookieCurrentChrome(driver);
																									uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																									string time51 = DateTime.Now.ToString();
																									switch (type_mail)
																									{
																										case "Mailtm":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time51 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time51 + ")");
																											});
																											break;
																										case "Hotmail":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time51 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time51 + ")");
																											});
																											break;
																										case "Emailfake.com":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time51 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time51 + ")");
																											});
																											break;
																									}
																									break;
																								}
																								if (cbregkhongunlock.Checked)
																								{
																									goto IL_18cc0;
																								}
																							}
																							if (cb_ngonngureg.Checked)
																							{
																								xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
																								string cookieCurrentChrome = GetCookieCurrentChrome(driver);
																								ChangeLanguageRequest_Cookie(cookieCurrentChrome, ngonngu);
																								xuanAction.Goto(driver, "https://m.facebook.com/", span);
																							}
																							if (flag)
																							{
																								string result_180 = Acc180(driver, xuanAction, combo_image, ngonngu, uid, text4);
																								if (!(result_180 == "havephone"))
																								{
																									if (result_180 != "havephone")
																									{
																										if (result_180.Split('|')[0] == "true")
																										{
																											string time50 = DateTime.Now.ToString();
																											switch (type_mail)
																											{
																												case "Mailtm":
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_Khang282_mailtm.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time50 + "\n");
																													}
																													break;
																												case "Hotmail":
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_Khang282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time50 + "\n");
																													}
																													break;
																												case "Emailfake.com":
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_Khang282_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time50 + "\n");
																													}
																													break;
																											}
																											if (cbgiuanh.Checked)
																											{
																												switch (type_mail)
																												{
																													case "Mailtm":
																														if (result_180.Split('|')[1] != "")
																														{
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")", Image.FromFile(result_180.Split('|')[1]));
																															});
																														}
																														else
																														{
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")");
																															});
																														}
																														break;
																													case "Hotmail":
																														if (result_180.Split('|')[1] != "")
																														{
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")", Image.FromFile(result_180.Split('|')[1]));
																															});
																														}
																														else
																														{
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")");
																															});
																														}
																														break;
																													case "Emailfake.com":
																														if (result_180.Split('|')[1] != "")
																														{
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")", Image.FromFile(result_180.Split('|')[1]));
																															});
																														}
																														else
																														{
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")");
																															});
																														}
																														break;
																												}
																												break;
																											}
																											switch (type_mail)
																											{
																												case "Mailtm":
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")");
																													});
																													break;
																												case "Hotmail":
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")");
																													});
																													break;
																												case "Emailfake.com":
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time50 + ")");
																													});
																													break;
																											}
																											break;
																										}
																										cookie = GetCookieCurrentChrome(driver);
																										uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																										string time49 = DateTime.Now.ToString();
																										switch (type_mail)
																										{
																											case "Mailtm":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time49 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time49 + ")");
																												});
																												break;
																											case "Hotmail":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time49 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time49 + ")");
																												});
																												break;
																											case "Emailfake.com":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time49 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time49 + ")");
																												});
																												break;
																										}
																										break;
																									}
																									cookie = GetCookieCurrentChrome(driver);
																									uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																									string time48 = DateTime.Now.ToString();
																									switch (type_mail)
																									{
																										case "Mailtm":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time48 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time48 + ")");
																											});
																											break;
																										case "Hotmail":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time48 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time48 + ")");
																											});
																											break;
																										case "Emailfake.com":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time48 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time48 + ")");
																											});
																											break;
																									}
																									break;
																								}
																								if (cb_180day.Checked)
																								{
																									break;
																								}
																								int num38 = 0;
																								while (true)
																								{
																									if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
																									{
																										if (index_phone == 0 || index_phone == 11)
																										{
																											new SelectElement(driver.FindElementByName("country_code")).SelectByValue("US");
																											Thread.Sleep(100);
																										}
																										else if (index_phone == 1 || index_phone == 2 || index_phone == 3 || index_phone == 4 || index_phone == 5 || index_phone == 6 || index_phone == 7 || index_phone == 8 || index_phone == 9 || index_phone == 10 || index_phone == 12 || index_phone == 13 || index_phone == 14 || index_phone == 15 || index_phone == 16 || index_phone == 17 || index_phone == 18 || index_phone == 19 || index_phone == 20 || index_phone == 21 || index_phone == 22 || index_phone == 23)
																										{
																											if (combo_server_sim == "Server việt")
																											{
																												new SelectElement(driver.FindElementByName("country_code")).SelectByValue("VN");
																												Thread.Sleep(100);
																											}
																											else if (combo_server_sim == "Server ngoại")
																											{
																												new SelectElement(driver.FindElementByName("country_code")).SelectByValue("MM");
																												Thread.Sleep(100);
																											}
																										}
																										break;
																									}
																									if (num38 != 15)
																									{
																										Sleep(1.0);
																										num38++;
																										continue;
																									}
																									cookie = GetCookieCurrentChrome(driver);
																									uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																									string time47 = DateTime.Now.ToString();
																									switch (type_mail)
																									{
																										case "Mailtm":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time47 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time47 + ")");
																											});
																											break;
																										case "Hotmail":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time47 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time47 + ")");
																											});
																											break;
																										case "Emailfake.com":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time47 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time47 + ")");
																											});
																											break;
																									}
																									goto end_IL_18ce4;
																								}
																							}
																							else
																							{
																								int num39 = 0;
																								while (true)
																								{
																									if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
																									{
																										if (index_phone == 0 || index_phone == 11)
																										{
																											new SelectElement(driver.FindElementByName("country_code")).SelectByValue("US");
																											Thread.Sleep(100);
																										}
																										else if (index_phone == 1 || index_phone == 2 || index_phone == 3 || index_phone == 4 || index_phone == 5 || index_phone == 6 || index_phone == 7 || index_phone == 8 || index_phone == 9 || index_phone == 10 || index_phone == 12 || index_phone == 13 || index_phone == 14 || index_phone == 15 || index_phone == 16 || index_phone == 17 || index_phone == 18 || index_phone == 19 || index_phone == 20 || index_phone == 21 || index_phone == 22 || index_phone == 23 || index_phone == 24)
																										{
																											if (combo_server_sim == "Server việt")
																											{
																												new SelectElement(driver.FindElementByName("country_code")).SelectByValue("VN");
																												Thread.Sleep(100);
																											}
																											else if (combo_server_sim == "Server ngoại")
																											{
																												new SelectElement(driver.FindElementByName("country_code")).SelectByValue("MM");
																												Thread.Sleep(100);
																											}
																										}
																										break;
																									}
																									if (num39 != 15)
																									{
																										Sleep(1.0);
																										num39++;
																										continue;
																									}
																									cookie = GetCookieCurrentChrome(driver);
																									uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																									string time46 = DateTime.Now.ToString();
																									switch (type_mail)
																									{
																										case "Mailtm":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time46 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time46 + ")");
																											});
																											break;
																										case "Hotmail":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time46 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time46 + ")");
																											});
																											break;
																										case "Emailfake.com":
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time46 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time46 + ")");
																											});
																											break;
																									}
																									goto end_IL_18ce4;
																								}
																							}
																							string time23;
																							while (true)
																							{
																							IL_75c9:
																								if (driver.FindElements(By.Name("country_code")).Count > 0)
																								{
																									if (index_phone == 0 || index_phone == 11)
																									{
																										new SelectElement(driver.FindElementByName("country_code")).SelectByValue("US");
																										Thread.Sleep(100);
																									}
																									else if (index_phone == 1 || index_phone == 2 || index_phone == 3 || index_phone == 4 || index_phone == 5 || index_phone == 6 || index_phone == 7 || index_phone == 8 || index_phone == 9 || index_phone == 10 || index_phone == 12 || index_phone == 13 || index_phone == 14 || index_phone == 15 || index_phone == 16 || index_phone == 17 || index_phone == 18 || index_phone == 19 || index_phone == 20 || index_phone == 21 || index_phone == 22 || index_phone == 23 || index_phone == 24)
																									{
																										if (combo_server_sim == "Server việt")
																										{
																											new SelectElement(driver.FindElementByName("country_code")).SelectByValue("VN");
																											Thread.Sleep(100);
																										}
																										else if (combo_server_sim == "Server ngoại")
																										{
																											new SelectElement(driver.FindElementByName("country_code")).SelectByValue("MM");
																											Thread.Sleep(100);
																										}
																									}
																								}
																								int num40 = 0;
																								if (index_phone == 0)
																								{
																									while (true)
																									{
																										string text18 = tempcode.Getphone(text_api_phone);
																										text13 = text18.Split('|')[0];
																										text15 = text18.Split('|')[1];
																										if (text13 != "" && text13 != null)
																										{
																											break;
																										}
																										if (num40 != limit_getphone)
																										{
																											Sleep(2.0);
																											num40++;
																											continue;
																										}
																										cookie = GetCookieCurrentChrome(driver);
																										uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																										string time44 = DateTime.Now.ToString();
																										switch (type_mail)
																										{
																											case "Mailtm":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time44 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time44 + ")");
																												});
																												break;
																											case "Hotmail":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time44 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time44 + ")");
																												});
																												break;
																											case "Emailfake.com":
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time44 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time44 + ")");
																												});
																												break;
																										}
																										goto end_IL_75c9;
																									}
																								}
																								else if (index_phone == 1)
																								{
																									while (true)
																									{
																										string text19 = otp.Getphone(text_api_phone);
																										if (text19.Split('|').Length != 0 && text19.Contains("|"))
																										{
																											text13 = text19.Split('|')[0];
																											text15 = text19.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time43 = DateTime.Now.ToString();
																												switch (type_mail)
																												{
																													case "Mailtm":
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time43 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time43 + ")");
																														});
																														break;
																													case "Hotmail":
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time43 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time43 + ")");
																														});
																														break;
																													case "Emailfake.com":
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time43 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time43 + ")");
																														});
																														break;
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 2)
																								{
																									while (true)
																									{
																										string text20 = codetext.Getphone(text_api_phone);
																										if (text20 != "")
																										{
																											text13 = text20.Split('|')[0];
																											text15 = text20.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																										}
																										else if (num40 == limit_getphone)
																										{
																											cookie = GetCookieCurrentChrome(driver);
																											uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																											string time42 = DateTime.Now.ToString();
																											if (type_mail == "Mailtm")
																											{
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time42 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time42 + ")");
																												});
																											}
																											else if (type_mail == "Hotmail")
																											{
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time42 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time42 + ")");
																												});
																											}
																											goto end_IL_75c9;
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 3)
																								{
																									while (true)
																									{
																										string text21 = sim.Getphone(text_api_phone);
																										if (text21.Split('|').Length != 0 && text21.Contains("|"))
																										{
																											text13 = text21.Split('|')[0];
																											text15 = text21.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																										}
																										else if (num40 == limit_getphone)
																										{
																											cookie = GetCookieCurrentChrome(driver);
																											uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																											string time41 = DateTime.Now.ToString();
																											if (type_mail == "Mailtm")
																											{
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time41 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time41 + ")");
																												});
																											}
																											else if (type_mail == "Hotmail")
																											{
																												lock (this.obj)
																												{
																													tongreg++;
																													File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time41 + "\n");
																												}
																												Invoke((Action)delegate
																												{
																													lb_tongreg.Text = tongreg + " accounts";
																													dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time41 + ")");
																												});
																											}
																											goto end_IL_75c9;
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 4)
																								{
																									while (true)
																									{
																										string text22 = viotp.Getphone(text_api_phone);
																										text13 = text22.Split('|')[0];
																										text15 = text22.Split('|')[1];
																										if (text13 != "" && text13 != null)
																										{
																											break;
																										}
																										if (num40 != limit_getphone)
																										{
																											Sleep(2.0);
																											num40++;
																											continue;
																										}
																										cookie = GetCookieCurrentChrome(driver);
																										uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																										string time40 = DateTime.Now.ToString();
																										if (type_mail == "Mailtm")
																										{
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time40 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time40 + ")");
																											});
																										}
																										else if (type_mail == "Hotmail")
																										{
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time40 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time40 + ")");
																											});
																										}
																										goto end_IL_75c9;
																									}
																								}
																								else if (index_phone == 5)
																								{
																									while (true)
																									{
																										text12 = tempsms.Get_id_request(text_api_phone, "13");
																										if (text12 != "" && text12 != null)
																										{
																											for (int l = 0; l < 20; l++)
																											{
																												text13 = tempsms.GetphoneFromID(text_api_phone, text12);
																												if (text13 != "" && text13 != null)
																												{
																													break;
																												}
																												Sleep(1.0);
																											}
																											break;
																										}
																										if (num40 != limit_getphone)
																										{
																											Sleep(2.0);
																											num40++;
																											continue;
																										}
																										cookie = GetCookieCurrentChrome(driver);
																										uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																										string time39 = DateTime.Now.ToString();
																										if (type_mail == "Mailtm")
																										{
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time39 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time39 + ")");
																											});
																										}
																										else if (type_mail == "Hotmail")
																										{
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time39 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time39 + ")");
																											});
																										}
																										goto end_IL_75c9;
																									}
																								}
																								else if (index_phone == 6)
																								{
																									while (true)
																									{
																										string text23 = chothuesimcode.Getphone(text_api_phone, "1001");
																										text13 = text23.Split('|')[0];
																										text15 = text23.Split('|')[1];
																										if (text13 != "" && text13 != null)
																										{
																											break;
																										}
																										if (num40 != limit_getphone)
																										{
																											Sleep(2.0);
																											num40++;
																											continue;
																										}
																										cookie = GetCookieCurrentChrome(driver);
																										uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																										string time38 = DateTime.Now.ToString();
																										if (type_mail == "Mailtm")
																										{
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time38 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time38 + ")");
																											});
																										}
																										else if (type_mail == "Hotmail")
																										{
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time38 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time38 + ")");
																											});
																										}
																										goto end_IL_75c9;
																									}
																								}
																								else if (index_phone == 7)
																								{
																									while (true)
																									{
																										text12 = bossotp.Getid_request(text_api_phone);
																										if (text12 != "" && text12 != null)
																										{
																											for (int n = 0; n < 20; n++)
																											{
																												text13 = bossotp.Getphonefromid(text12, text_api_phone);
																												if (text13 != "" && text13 != null)
																												{
																													break;
																												}
																												Sleep(1.0);
																											}
																											break;
																										}
																										if (num40 != limit_getphone)
																										{
																											Sleep(2.0);
																											num40++;
																											continue;
																										}
																										cookie = GetCookieCurrentChrome(driver);
																										uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																										string time37 = DateTime.Now.ToString();
																										if (type_mail == "Mailtm")
																										{
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time37 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time37 + ")");
																											});
																										}
																										else if (type_mail == "Hotmail")
																										{
																											lock (this.obj)
																											{
																												tongreg++;
																												File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time37 + "\n");
																											}
																											Invoke((Action)delegate
																											{
																												lb_tongreg.Text = tongreg + " accounts";
																												dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time37 + ")");
																											});
																										}
																										goto end_IL_75c9;
																									}
																								}
																								else if (index_phone == 8)
																								{
																									while (true)
																									{
																										string text24 = testbossotp.Getid_request(text_api_phone);
																										if (text24.Split('|').Length != 0 && text24.Contains("|"))
																										{
																											text13 = text24.Split('|')[0];
																											text15 = text24.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time36 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time36 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time36 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time36 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time36 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 9)
																								{
																									while (true)
																									{
																										string text25 = ndline.Getphone(text_api_phone);
																										if (text25.Split('|').Length != 0 && text25.Contains("|"))
																										{
																											text13 = text25.Split('|')[0];
																											text15 = text25.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time35 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time35 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time35 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time35 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time35 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 10)
																								{
																									while (true)
																									{
																										string text26 = trumotpvn.Getphone(text_api_phone);
																										if (text26.Split('|').Length != 0 && text26.Contains("|"))
																										{
																											text13 = text26.Split('|')[0];
																											text15 = text26.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time33 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time33 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time33 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time33 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time33 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 11)
																								{
																									while (true)
																									{
																										string text27 = winmail.Getphone(text_api_phone);
																										if (text27.Split('|').Length != 0 && text27.Contains("|"))
																										{
																											text13 = text27.Split('|')[0];
																											text15 = text27.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time32 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time32 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time32 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time32 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time32 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 12)
																								{
																									while (true)
																									{
																										string text28 = hcotp.Getphone(text_api_phone);
																										if (text28.Split('|').Length != 0 && text28.Contains("|"))
																										{
																											text13 = text28.Split('|')[0];
																											text15 = text28.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time31 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time31 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time31 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time31 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time31 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 13)
																								{
																									while (true)
																									{
																										string text29 = sellotp.Getphone(text_api_phone);
																										if (text29.Split('|').Length != 0 && text29.Contains("|"))
																										{
																											text13 = text29.Split('|')[0];
																											text15 = text29.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time30 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time30 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time30 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time30 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time30 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 14)
																								{
																									while (true)
																									{
																										string text30 = suppersim.Getphone(text_api_phone);
																										if (text30.Split('|').Length != 0 && text30.Contains("|"))
																										{
																											text13 = text30.Split('|')[0];
																											text15 = text30.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time29 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time29 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time29 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time29 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time29 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 15)
																								{
																									while (true)
																									{
																										string phone = goodotp.GetPhone(text_api_phone);
																										if (phone.Split('|').Length != 0 && phone.Contains("|"))
																										{
																											text13 = phone.Split('|')[0];
																											text15 = phone.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time28 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time28 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time28 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time28 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time28 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 16)
																								{
																									while (true)
																									{
																										string text31 = atmteam2.Getphone(text_api_phone);
																										if (text31.Split('|').Length != 0 && text31.Contains("|"))
																										{
																											text13 = text31.Split('|')[0];
																											text15 = text31.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time27 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time27 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time27 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time27 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time27 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 17)
																								{
																									while (true)
																									{
																										string phone2 = good9fun2.GetPhone(text_api_phone);
																										if (phone2.Split('|').Length != 0 && phone2.Contains("|"))
																										{
																											text13 = phone2.Split('|')[0];
																											text15 = phone2.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time26 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time26 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time26 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time26 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time26 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 18)
																								{
																									while (true)
																									{
																										string text32 = otpngon.Getphone(text_api_phone);
																										if (text32.Split('|').Length != 0 && text32.Contains("|"))
																										{
																											text13 = text32.Split('|')[0];
																											text15 = text32.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time25 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time25 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time25 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time25 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time25 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 19)
																								{
																									while (true)
																									{
																										string text33 = fb.Getphone(text_api_phone);
																										if (text33.Split('|').Length != 0 && text33.Contains("|"))
																										{
																											text13 = text33.Split('|')[0];
																											text15 = text33.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time24 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time24 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time24 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time24 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time24 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 20)
																								{
																									if (combo_server_sim == "Server việt")
																									{
																										while (true)
																										{
																											string text34 = numberotp.Getphone_VN(text_api_phone);
																											if (text34.Split('|').Length != 0 && text34.Contains("|"))
																											{
																												text13 = text34.Split('|')[0];
																												text15 = text34.Split('|')[1];
																												if (text13 != "" && text13 != null)
																												{
																													break;
																												}
																												if (num40 == limit_getphone)
																												{
																													cookie = GetCookieCurrentChrome(driver);
																													uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																													string time22 = DateTime.Now.ToString();
																													if (type_mail == "Mailtm")
																													{
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time22 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time22 + ")");
																														});
																													}
																													else if (type_mail == "Hotmail")
																													{
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time22 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time22 + ")");
																														});
																													}
																													goto end_IL_75c9;
																												}
																											}
																											Sleep(2.0);
																											num40++;
																										}
																									}
																									else if (combo_server_sim == "Server ngoại")
																									{
																										while (true)
																										{
																											string text35 = numberotp.Getphone_US(text_api_phone);
																											if (text35.Split('|').Length != 0 && text35.Contains("|"))
																											{
																												text13 = text35.Split('|')[0];
																												text15 = text35.Split('|')[1];
																												if (text13 != "" && text13 != null)
																												{
																													break;
																												}
																												if (num40 == limit_getphone)
																												{
																													cookie = GetCookieCurrentChrome(driver);
																													uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																													string time21 = DateTime.Now.ToString();
																													if (type_mail == "Mailtm")
																													{
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time21 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time21 + ")");
																														});
																													}
																													else if (type_mail == "Hotmail")
																													{
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time21 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time21 + ")");
																														});
																													}
																													goto end_IL_75c9;
																												}
																											}
																											Sleep(2.0);
																											num40++;
																										}
																									}
																								}
																								else if (index_phone == 21)
																								{
																									while (true)
																									{
																										string text36 = atmteam.Getphone(text_api_phone);
																										if (text36.Split('|').Length != 0 && text36.Contains("|"))
																										{
																											text13 = text36.Split('|')[0];
																											text15 = text36.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time20 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time20 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time20 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time20 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time20 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 22)
																								{
																									while (true)
																									{
																										string text37 = sell282xyz.Getphone(text_api_phone);
																										if (text37.Split('|').Length != 0 && text37.Contains("|"))
																										{
																											text13 = text37.Split('|')[0];
																											text15 = text37.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time19 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time19 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time19 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time19 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time19 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 23)
																								{
																									if (combo_server_sim == "Server việt")
																									{
																										while (true)
																										{
																											string text38 = sellotpvn.Getphone_VN(text_api_phone);
																											if (text38.Split('|').Length != 0 && text38.Contains("|"))
																											{
																												text13 = text38.Split('|')[0];
																												text15 = text38.Split('|')[1];
																												if (text13 != "" && text13 != null)
																												{
																													break;
																												}
																												if (num40 == limit_getphone)
																												{
																													cookie = GetCookieCurrentChrome(driver);
																													uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																													string time18 = DateTime.Now.ToString();
																													if (type_mail == "Mailtm")
																													{
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time18 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time18 + ")");
																														});
																													}
																													else if (type_mail == "Hotmail")
																													{
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time18 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time18 + ")");
																														});
																													}
																													goto end_IL_75c9;
																												}
																											}
																											Sleep(2.0);
																											num40++;
																										}
																									}
																									else if (combo_server_sim == "Server ngoại")
																									{
																										while (true)
																										{
																											string text39 = sellotpvn.Getphone_US(text_api_phone);
																											if (text39.Split('|').Length != 0 && text39.Contains("|"))
																											{
																												text13 = text39.Split('|')[0];
																												text15 = text39.Split('|')[1];
																												if (text13 != "" && text13 != null)
																												{
																													break;
																												}
																												if (num40 == limit_getphone)
																												{
																													cookie = GetCookieCurrentChrome(driver);
																													uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																													string time17 = DateTime.Now.ToString();
																													if (type_mail == "Mailtm")
																													{
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time17 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time17 + ")");
																														});
																													}
																													else if (type_mail == "Hotmail")
																													{
																														lock (this.obj)
																														{
																															tongreg++;
																															File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time17 + "\n");
																														}
																														Invoke((Action)delegate
																														{
																															lb_tongreg.Text = tongreg + " accounts";
																															dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time17 + ")");
																														});
																													}
																													goto end_IL_75c9;
																												}
																											}
																											Sleep(2.0);
																											num40++;
																										}
																									}
																								}
																								else if (index_phone == 24)
																								{
																									while (true)
																									{
																										string text40 = otpygo.Getphone_VN(text_api_phone);
																										if (text40.Split('|').Length != 0 && text40.Contains("|"))
																										{
																											text13 = text40.Split('|')[0];
																											text15 = text40.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time16 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time16 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time16 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time16 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time16 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 25)
																								{
																									while (true)
																									{
																										string text26 = vutruotp.Getphone(text_api_phone);
																										if (text26.Split('|').Length != 0 && text26.Contains("|"))
																										{
																											text13 = text26.Split('|')[0];
																											text15 = text26.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time33 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time33 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time33 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time33 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time33 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								else if (index_phone == 26)
																								{
																									while (true)
																									{
																										string text26 = ironsim.Getphone(text_api_phone);
																										if (text26.Split('|').Length != 0 && text26.Contains("|"))
																										{
																											text13 = text26.Split('|')[0];
																											text15 = text26.Split('|')[1];
																											if (text13 != "" && text13 != null)
																											{
																												break;
																											}
																											if (num40 == limit_getphone)
																											{
																												cookie = GetCookieCurrentChrome(driver);
																												uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																												string time33 = DateTime.Now.ToString();
																												if (type_mail == "Mailtm")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time33 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time33 + ")");
																													});
																												}
																												else if (type_mail == "Hotmail")
																												{
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time33 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time33 + ")");
																													});
																												}
																												goto end_IL_75c9;
																											}
																										}
																										Sleep(2.0);
																										num40++;
																									}
																								}
																								if (text13 != "" && text13 != null && text13 != "Get Number TimeOut")
																								{
																									if (index_phone == 0 || index_phone == 11)
																									{
																										if (!text13.StartsWith("+1"))
																										{
																											text13 = "+1" + text13;
																										}
																									}
																									else if ((index_phone == 1 || index_phone == 2 || index_phone == 3 || index_phone == 4 || index_phone == 5 || index_phone == 6 || index_phone == 7 || index_phone == 8 || index_phone == 9 || index_phone == 10 || index_phone == 12 || index_phone == 13 || index_phone == 14 || index_phone == 15 || index_phone == 16 || index_phone == 17 || index_phone == 18 || index_phone == 19 || index_phone == 20 || index_phone == 21 || index_phone == 22 || index_phone == 23 || index_phone == 24) && combo_server_sim == "Server việt")
																									{
																										if (!text13.StartsWith("0") && !text13.StartsWith("+84"))
																										{
																											if (!text13.StartsWith("84"))
																											{
																												text13 = "+84" + text13;
																											}
																										}
																										else if (text13.StartsWith("0"))
																										{
																											text13 = "+84" + text13.Remove(0, 1);
																										}
																									}
																									lock (this.obj)
																									{
																										tongphone++;
																									}
																									Invoke((Action)delegate
																									{
																										lbtongphone_buy.Text = tongphone.ToString();
																									});
																									int num41 = 0;
																									while (true)
																									{
																										if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
																										{
																											xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span4, text13);
																											int num42 = 0;
																											while (true)
																											{
																												if (driver.FindElements(By.XPath("//button[@name='action_set_contact_point']")).Count > 0)
																												{
																													if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_set_contact_point']"), span2))
																													{
																														Sleep(1.0);
																														Sleep(5.0);
																														if (driver.PageSource.Contains("Gần đây, số điện thoại bạn đang cố gắng xác minh đã được sử dụng để xác minh một tài khoản khác. Vui lòng thử số khác.") || driver.PageSource.Contains("The phone number you're trying to verify was recently used to verify a different account. Please try a different number.") || driver.PageSource.Contains("Số này đã được dùng để xác minh quá nhiều tài khoản trên Facebook. Hãy thử dùng số khác.") || driver.PageSource.Contains("This number has been used to verify too many accounts on Facebook. Please try a different number."))
																														{
																															if (num3 == 3)
																															{
																																lock (this.obj)
																																{
																																	false_code++;
																																}
																																Invoke((Action)delegate
																																{
																																	error_code.Text = susscess_code.ToString();
																																});
																																cookie = GetCookieCurrentChrome(driver);
																																uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																string time15 = DateTime.Now.ToString();
																																switch (type_mail)
																																{
																																	case "Mailtm":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time15 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time15 + ")");
																																		});
																																		break;
																																	case "Hotmail":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time15 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time15 + ")");
																																		});
																																		break;
																																	case "Emailfake.com":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time15 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time15 + ")");
																																		});
																																		break;
																																}
																																break;
																															}
																															num3++;
																														}
																														else if (driver.PageSource.Contains("Bạn cần nhập số di động hợp lệ") || driver.PageSource.Contains("Please enter a valid email address or mobile number."))
																														{
																															if (num3 == 3)
																															{
																																lock (this.obj)
																																{
																																	false_code++;
																																}
																																Invoke((Action)delegate
																																{
																																	error_code.Text = susscess_code.ToString();
																																});
																																cookie = GetCookieCurrentChrome(driver);
																																uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																string time14 = DateTime.Now.ToString();
																																switch (type_mail)
																																{
																																	case "Mailtm":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time14 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time14 + ")");
																																		});
																																		break;
																																	case "Hotmail":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time14 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time14 + ")");
																																		});
																																		break;
																																	case "Emailfake.com":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time14 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time14 + ")");
																																		});
																																		break;
																																}
																																break;
																															}
																															num3++;
																														}
																														else if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
																														{
																															if (num3 == 3)
																															{
																																lock (this.obj)
																																{
																																	false_code++;
																																}
																																Invoke((Action)delegate
																																{
																																	error_code.Text = susscess_code.ToString();
																																});
																																cookie = GetCookieCurrentChrome(driver);
																																uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																string time13 = DateTime.Now.ToString();
																																switch (type_mail)
																																{
																																	case "Mailtm":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time13 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time13 + ")");
																																		});
																																		break;
																																	case "Hotmail":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time13 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time13 + ")");
																																		});
																																		break;
																																	case "Emailfake.com":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time13 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time13 + ")");
																																		});
																																		break;
																																}
																																break;
																															}
																															num3++;
																														}
																														else
																														{
																															Sleep(3.0);
																															switch (index_phone)
																															{
																																case 0:
																																	{
																																		for (int num60 = 0; num60 < limit_getcodephone; num60++)
																																		{
																																			text14 = tempcode.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 1:
																																	{
																																		for (int num44 = 0; num44 < limit_getcodephone; num44++)
																																		{
																																			text14 = otp.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 2:
																																	{
																																		for (int num52 = 0; num52 < limit_getcodephone; num52++)
																																		{
																																			text14 = codetext.Getcode(text_api_phone, text13);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 3:
																																	{
																																		for (int num64 = 0; num64 < limit_getcodephone; num64++)
																																		{
																																			text14 = sim.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 4:
																																	{
																																		for (int num56 = 0; num56 < limit_getcodephone; num56++)
																																		{
																																			text14 = viotp.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 5:
																																	{
																																		for (int num48 = 0; num48 < limit_getcodephone; num48++)
																																		{
																																			text14 = tempsms.Getcode(text_api_phone, text12);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 6:
																																	{
																																		for (int num66 = 0; num66 < limit_getcodephone; num66++)
																																		{
																																			text14 = chothuesimcode.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 7:
																																	{
																																		for (int num62 = 0; num62 < limit_getcodephone; num62++)
																																		{
																																			text14 = bossotp.Getcode(text12, text_api_phone);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 8:
																																	{
																																		for (int num58 = 0; num58 < limit_getcodephone; num58++)
																																		{
																																			text14 = testbossotp.Getcode(text15, text_api_phone);
																																			if (text14 == null || !(text14 != ""))
																																			{
																																				Sleep(1.0);
																																				continue;
																																			}
																																			if (!(text14 == "Get SMS TimeOut"))
																																			{
																																				break;
																																			}
																																			lock (this.obj)
																																			{
																																				false_code++;
																																			}
																																			Invoke((Action)delegate
																																			{
																																				error_code.Text = susscess_code.ToString();
																																			});
																																			goto end_IL_181d1;
																																		}
																																		break;
																																	}
																																case 9:
																																	{
																																		for (int num54 = 0; num54 < limit_getcodephone; num54++)
																																		{
																																			text14 = ndline.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 10:
																																	{
																																		for (int num50 = 0; num50 < limit_getcodephone; num50++)
																																		{
																																			text14 = trumotpvn.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 11:
																																	{
																																		for (int num46 = 0; num46 < limit_getcodephone; num46++)
																																		{
																																			text14 = winmail.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 12:
																																	{
																																		for (int num67 = 0; num67 < limit_getcodephone; num67++)
																																		{
																																			text14 = hcotp.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 13:
																																	{
																																		for (int num65 = 0; num65 < limit_getcodephone; num65++)
																																		{
																																			text14 = sellotp.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 14:
																																	{
																																		for (int num63 = 0; num63 < limit_getcodephone; num63++)
																																		{
																																			text14 = suppersim.Getcode(text_api_phone, text15, text4);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 15:
																																	{
																																		for (int num61 = 0; num61 < limit_getcodephone; num61++)
																																		{
																																			text14 = goodotp.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 16:
																																	{
																																		for (int num59 = 0; num59 < limit_getcodephone; num59++)
																																		{
																																			text14 = atmteam2.Getcode(text15, text_api_phone);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 17:
																																	{
																																		for (int num57 = 0; num57 < limit_getcodephone; num57++)
																																		{
																																			text14 = good9fun2.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 18:
																																	{
																																		for (int num55 = 0; num55 < limit_getcodephone; num55++)
																																		{
																																			text14 = otpngon.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 19:
																																	{
																																		for (int num53 = 0; num53 < limit_getcodephone; num53++)
																																		{
																																			text14 = fb.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 20:
																																	{
																																		for (int num51 = 0; num51 < limit_getcodephone; num51++)
																																		{
																																			text14 = numberotp.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 21:
																																	{
																																		for (int num49 = 0; num49 < limit_getcodephone; num49++)
																																		{
																																			text14 = atmteam.Getcode(text15, text_api_phone);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 22:
																																	{
																																		for (int num47 = 0; num47 < limit_getcodephone; num47++)
																																		{
																																			text14 = sell282xyz.Getcode(text15, text_api_phone);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 23:
																																	{
																																		for (int num45 = 0; num45 < limit_getcodephone; num45++)
																																		{
																																			text14 = sellotpvn.Getcode(text15, text_api_phone);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 24:
																																	{
																																		for (int num43 = 0; num43 < limit_getcodephone; num43++)
																																		{
																																			text14 = otpygo.Getcode(text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 25:
																																	{
																																		for (int num50 = 0; num50 < limit_getcodephone; num50++)
																																		{
																																			text14 = vutruotp.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																																case 26:
																																	{
																																		for (int num50 = 0; num50 < limit_getcodephone; num50++)
																																		{
																																			text14 = ironsim.Getcode(text_api_phone, text15);
																																			if (text14 != null && text14 != "")
																																			{
																																				break;
																																			}
																																			Sleep(1.0);
																																		}
																																		break;
																																	}
																															}
																															if (text14 != "" && text14 != null && text14 != "Get SMS TimeOut" && text14 != "TimeOut")
																															{
																																lock (this.obj)
																																{
																																	susscess_code++;
																																}
																																Invoke((Action)delegate
																																{
																																	codedone.Text = susscess_code.ToString();
																																});
																																if (cb_ngonngureg.Checked)
																																{
																																	xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
																																	string cookieCurrentChrome2 = GetCookieCurrentChrome(driver);
																																	ChangeLanguageRequest_Cookie(cookieCurrentChrome2, "en_US");
																																}
																																if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
																																{
																																	cookie = GetCookieCurrentChrome(driver);
																																	uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																	string time11 = DateTime.Now.ToString();
																																	switch (type_mail)
																																	{
																																		case "Mailtm":
																																			lock (this.obj)
																																			{
																																				tongreg++;
																																				File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time11 + "\n");
																																			}
																																			Invoke((Action)delegate
																																			{
																																				lb_tongreg.Text = tongreg + " accounts";
																																				dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time11 + ")");
																																			});
																																			break;
																																		case "Hotmail":
																																			lock (this.obj)
																																			{
																																				tongreg++;
																																				File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time11 + "\n");
																																			}
																																			Invoke((Action)delegate
																																			{
																																				lb_tongreg.Text = tongreg + " accounts";
																																				dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time11 + ")");
																																			});
																																			break;
																																		case "Emailfake.com":
																																			lock (this.obj)
																																			{
																																				tongreg++;
																																				File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time11 + "\n");
																																			}
																																			Invoke((Action)delegate
																																			{
																																				lb_tongreg.Text = tongreg + " accounts";
																																				dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time11 + ")");
																																			});
																																			break;
																																	}
																																	break;
																																}
																																int num68 = 0;
																																while (true)
																																{
																																	if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
																																	{
																																		driver.FindElement(By.XPath("//input[@name='code']")).SendKeys(text14);
																																		Thread.Sleep(200);
																																		int num69 = 0;
																																		while (true)
																																		{
																																			if (driver.FindElements(By.XPath("//button[@name='action_submit_code']")).Count > 0)
																																			{
																																				if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_submit_code']"), span2))
																																				{
																																					Sleep(1.0);
																																					while (true)
																																					{
																																					IL_164de:
																																						int num70 = 0;
																																						while (true)
																																						{
																																							if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
																																							{
																																								Thread.Sleep(100);
																																								switch (combo_image)
																																								{
																																									case "Ảnh đã lưu trong folder Image":
																																										lock (this.obj)
																																										{
																																											string[] files = Directory.GetFiles(txt_folder_anh.Text);
																																											if (files.Length != 0)
																																											{
																																												text_image = files[random.Next(0, files.Length - 1)];
																																												break;
																																											}
																																										}
																																										goto end_IL_164d1;
																																									case "https://boredhumans.com/faces.php":
																																										lock (this.obj)
																																										{
																																											while (!method_41(uid, text4))
																																											{
																																												Sleep(1.0);
																																											}
																																											text_image = Path_Tool + "\\Image\\" + uid + ".png";
																																										}
																																										break;
																																									case "https://this-person-does-not-exist.com":
																																										lock (this.obj)
																																										{
																																											while (!method_40(uid, ""))
																																											{
																																												Sleep(1.0);
																																											}
																																											text_image = Path_Tool + "\\Image\\" + uid + ".png";
																																										}
																																										break;
																																									case "https://www.unrealperson.com":
																																										lock (this.obj)
																																										{
																																											while (!method_42(uid, text4))
																																											{
																																												Sleep(1.0);
																																											}
																																											text_image = Path_Tool + "\\Image\\" + uid + ".png";
																																										}
																																										break;
																																									case "https://fakeface.rest":
																																										lock (this.obj)
																																										{
																																											while (!method_43(uid))
																																											{
																																												Sleep(1.0);
																																											}
																																											text_image = Path_Tool + "\\Image\\" + uid + ".png";
																																										}
																																										break;
																																								}
																																								if (!File.Exists(text_image))
																																								{
																																									Console.WriteLine("NOT IMAGE");
																																								}
																																								else
																																								{
																																									if (!(changeMD5(text_image) == "") && changeMD5(text_image) != null)
																																									{
																																										driver.FindElementByCssSelector("[type=\"file\"]").SendKeys(text_image);
																																										Thread.Sleep(1000);
																																										while (true)
																																										{
																																											if (driver.FindElements(By.XPath("//button[@name='action_upload_image']")).Count > 0)
																																											{
																																												xuanAction.ClickElement(driver, By.XPath("//button[@name='action_upload_image']"), span4);
																																												Sleep(1.0);
																																											}
																																											else
																																											{
																																												if (driver.FindElements(By.XPath("//input[@name='action_upload_image']")).Count <= 0)
																																												{
																																													if (!driver.PageSource.Contains("Không có Internet") && !driver.PageSource.Contains("No Internet") && !driver.PageSource.Contains("Không thể truy cập"))
																																													{
																																														continue;
																																													}
																																													cookie = GetCookieCurrentChrome(driver);
																																													uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																													string time10 = DateTime.Now.ToString();
																																													switch (type_mail)
																																													{
																																														case "Mailtm":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time10 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time10 + ")");
																																															});
																																															break;
																																														case "Hotmail":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time10 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time10 + ")");
																																															});
																																															break;
																																														case "Emailfake.com":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time10 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time10 + ")");
																																															});
																																															break;
																																													}
																																													break;
																																												}
																																												xuanAction.ClickElement(driver, By.XPath("//input[@name='action_upload_image']"), span4);
																																												Sleep(1.0);
																																											}
																																											if (driver.FindElements(By.XPath("//input[@type='file']")).Count > 0)
																																											{
																																												string time9 = DateTime.Now.ToString();
																																												if (type_mail == "Mailtm")
																																												{
																																													lock (this.obj)
																																													{
																																														tongreg++;
																																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + time9 + "\n");
																																													}
																																													Invoke((Action)delegate
																																													{
																																														lb_tongreg.Text = tongreg + " accounts";
																																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time9 + ")");
																																													});
																																												}
																																												else if (type_mail == "Hotmail")
																																												{
																																													lock (this.obj)
																																													{
																																														tongreg++;
																																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + time9 + "\n");
																																													}
																																													Invoke((Action)delegate
																																													{
																																														lb_tongreg.Text = tongreg + " accounts";
																																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time9 + ")");
																																													});
																																												}
																																												break;
																																											}
																																											int num71 = 0;
																																											while (true)
																																											{
																																												if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
																																												{
																																													string time8 = DateTime.Now.ToString();
																																													switch (type_mail)
																																													{
																																														case "Mailtm":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_Khang282_mailtm.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time8 + "\n");
																																															}
																																															break;
																																														case "Hotmail":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_Khang282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time8 + "\n");
																																															}
																																															break;
																																														case "Emailfake.com":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_Khang282_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time8 + "\n");
																																															}
																																															break;
																																													}
																																													if (cbgiuanh.Checked)
																																													{
																																														switch (type_mail)
																																														{
																																															case "Mailtm":
																																																Invoke((Action)delegate
																																																{
																																																	lb_tongreg.Text = tongreg + " accounts";
																																																	dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time8 + ")", Image.FromFile(text_image));
																																																});
																																																break;
																																															case "Hotmail":
																																																Invoke((Action)delegate
																																																{
																																																	lb_tongreg.Text = tongreg + " accounts";
																																																	dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time8 + ")", Image.FromFile(text_image));
																																																});
																																																break;
																																															case "Emailfake.com":
																																																Invoke((Action)delegate
																																																{
																																																	lb_tongreg.Text = tongreg + " accounts";
																																																	dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time8 + ")", Image.FromFile(text_image));
																																																});
																																																break;
																																														}
																																														break;
																																													}
																																													if (File.Exists(text_image))
																																													{
																																														File.Delete(text_image);
																																													}
																																													switch (type_mail)
																																													{
																																														case "Mailtm":
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time8 + ")");
																																															});
																																															break;
																																														case "Hotmail":
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time8 + ")");
																																															});
																																															break;
																																														case "Emailfake.com":
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Đã kháng 282 thành công vào lúc (" + time8 + ")");
																																															});
																																															break;
																																													}
																																													break;
																																												}
																																												if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
																																												{
																																													cookie = GetCookieCurrentChrome(driver);
																																													uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																													string time7 = DateTime.Now.ToString();
																																													switch (type_mail)
																																													{
																																														case "Mailtm":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_unlocked.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time7 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time7 + ")");
																																															});
																																															break;
																																														case "Hotmail":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_unlocked_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time7 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time7 + ")");
																																															});
																																															break;
																																														case "Emailfake.com":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_unlocked.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time7 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time7 + ")");
																																															});
																																															break;
																																													}
																																													break;
																																												}
																																												if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
																																												{
																																													cookie = GetCookieCurrentChrome(driver);
																																													uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																													string time6 = DateTime.Now.ToString();
																																													switch (type_mail)
																																													{
																																														case "Mailtm":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_unlocked.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time6 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time6 + ")");
																																															});
																																															break;
																																														case "Hotmail":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_unlocked_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time6 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time6 + ")");
																																															});
																																															break;
																																														case "Emailfake.com":
																																															lock (this.obj)
																																															{
																																																tongreg++;
																																																File.AppendAllText("Account_282\\" + text + "_unlocked.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time6 + "\n");
																																															}
																																															Invoke((Action)delegate
																																															{
																																																lb_tongreg.Text = tongreg + " accounts";
																																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time6 + ")");
																																															});
																																															break;
																																													}
																																													break;
																																												}
																																												Sleep(1.0);
																																												num71++;
																																												if (num71 != 20)
																																												{
																																													continue;
																																												}
																																												string text41 = DateTime.Now.ToString();
																																												switch (type_mail)
																																												{
																																													case "Mailtm":
																																														lock (this.obj)
																																														{
																																															tongreg++;
																																															File.AppendAllText("Account_282\\" + text + "_Khang282_mailtm.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + text41 + "\n");
																																														}
																																														break;
																																													case "Hotmail":
																																														lock (this.obj)
																																														{
																																															tongreg++;
																																															File.AppendAllText("Account_282\\" + text + "_Khang282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + text41 + "\n");
																																														}
																																														break;
																																													case "Emailfake.com":
																																														lock (this.obj)
																																														{
																																															tongreg++;
																																															File.AppendAllText("Account_282\\" + text + "_Khang282_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + text41 + "\n");
																																														}
																																														break;
																																												}
																																												break;
																																											}
																																											break;
																																										}
																																										break;
																																									}
																																									if (File.Exists(text_image))
																																									{
																																										File.Delete(text_image);
																																									}
																																								}
																																								goto IL_164de;
																																							}
																																							if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
																																							{
																																								cookie = GetCookieCurrentChrome(driver);
																																								uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																								string time5 = DateTime.Now.ToString();
																																								switch (type_mail)
																																								{
																																									case "Mailtm":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_unlocked.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time5 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time5 + ")");
																																										});
																																										break;
																																									case "Hotmail":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_unlocked_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time5 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time5 + ")");
																																										});
																																										break;
																																									case "Emailfake.com":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_unlocked.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time5 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time5 + ")");
																																										});
																																										break;
																																								}
																																								break;
																																							}
																																							if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
																																							{
																																								cookie = GetCookieCurrentChrome(driver);
																																								uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																								string time4 = DateTime.Now.ToString();
																																								switch (type_mail)
																																								{
																																									case "Mailtm":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_unlocked.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time4 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time4 + ")");
																																										});
																																										break;
																																									case "Hotmail":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_unlocked_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time4 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time4 + ")");
																																										});
																																										break;
																																									case "Emailfake.com":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_unlocked.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time4 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Unlock thành công 282 (" + time4 + ")");
																																										});
																																										break;
																																								}
																																								break;
																																							}
																																							if (driver.PageSource.Contains("Mã đó không hoạt động. Vui lòng kiểm tra mã và thử lại") || driver.PageSource.Contains("That code didn't work. Please check the code and try again."))
																																							{
																																								cookie = GetCookieCurrentChrome(driver);
																																								uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																								string time3 = DateTime.Now.ToString();
																																								switch (type_mail)
																																								{
																																									case "Mailtm":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time3 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time3 + ")");
																																										});
																																										break;
																																									case "Hotmail":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time3 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time3 + ")");
																																										});
																																										break;
																																									case "Emailfake.com":
																																										lock (this.obj)
																																										{
																																											tongreg++;
																																											File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time3 + "\n");
																																										}
																																										Invoke((Action)delegate
																																										{
																																											lb_tongreg.Text = tongreg + " accounts";
																																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time3 + ")");
																																										});
																																										break;
																																								}
																																								break;
																																							}
																																							if (num70 != 15)
																																							{
																																								Sleep(1.0);
																																								num70++;
																																								continue;
																																							}
																																							cookie = GetCookieCurrentChrome(driver);
																																							uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																							string time2 = DateTime.Now.ToString();
																																							switch (type_mail)
																																							{
																																								case "Mailtm":
																																									lock (this.obj)
																																									{
																																										tongreg++;
																																										File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time2 + "\n");
																																									}
																																									Invoke((Action)delegate
																																									{
																																										lb_tongreg.Text = tongreg + " accounts";
																																										dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time2 + ")");
																																									});
																																									break;
																																								case "Hotmail":
																																									lock (this.obj)
																																									{
																																										tongreg++;
																																										File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time2 + "\n");
																																									}
																																									Invoke((Action)delegate
																																									{
																																										lb_tongreg.Text = tongreg + " accounts";
																																										dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time2 + ")");
																																									});
																																									break;
																																								case "Emailfake.com":
																																									lock (this.obj)
																																									{
																																										tongreg++;
																																										File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time2 + "\n");
																																									}
																																									Invoke((Action)delegate
																																									{
																																										lb_tongreg.Text = tongreg + " accounts";
																																										dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time2 + ")");
																																									});
																																									break;
																																							}
																																							break;
																																							continue;
																																						end_IL_164d1:
																																							break;
																																						}
																																						break;
																																					}
																																					break;
																																				}
																																			}
																																			else if (num69 == 10)
																																			{
																																				cookie = GetCookieCurrentChrome(driver);
																																				uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																				string time64 = DateTime.Now.ToString();
																																				switch (type_mail)
																																				{
																																					case "Mailtm":
																																						lock (this.obj)
																																						{
																																							tongreg++;
																																							File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time64 + "\n");
																																						}
																																						Invoke((Action)delegate
																																						{
																																							lb_tongreg.Text = tongreg + " accounts";
																																							dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time64 + ")");
																																						});
																																						break;
																																					case "Hotmail":
																																						lock (this.obj)
																																						{
																																							tongreg++;
																																							File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time64 + "\n");
																																						}
																																						Invoke((Action)delegate
																																						{
																																							lb_tongreg.Text = tongreg + " accounts";
																																							dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time64 + ")");
																																						});
																																						break;
																																					case "Emailfake.com":
																																						lock (this.obj)
																																						{
																																							tongreg++;
																																							File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time64 + "\n");
																																						}
																																						Invoke((Action)delegate
																																						{
																																							lb_tongreg.Text = tongreg + " accounts";
																																							dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time64 + ")");
																																						});
																																						break;
																																				}
																																				break;
																																			}
																																			Sleep(1.0);
																																			num69++;
																																		}
																																		break;
																																	}
																																	if (num68 == 10)
																																	{
																																		cookie = GetCookieCurrentChrome(driver);
																																		uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																		string time63 = DateTime.Now.ToString();
																																		switch (type_mail)
																																		{
																																			case "Mailtm":
																																				lock (this.obj)
																																				{
																																					tongreg++;
																																					File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time63 + "\n");
																																				}
																																				Invoke((Action)delegate
																																				{
																																					lb_tongreg.Text = tongreg + " accounts";
																																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time63 + ")");
																																				});
																																				break;
																																			case "Hotmail":
																																				lock (this.obj)
																																				{
																																					tongreg++;
																																					File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time63 + "\n");
																																				}
																																				Invoke((Action)delegate
																																				{
																																					lb_tongreg.Text = tongreg + " accounts";
																																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time63 + ")");
																																				});
																																				break;
																																			case "Emailfake.com":
																																				lock (this.obj)
																																				{
																																					tongreg++;
																																					File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time63 + "\n");
																																				}
																																				Invoke((Action)delegate
																																				{
																																					lb_tongreg.Text = tongreg + " accounts";
																																					dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time63 + ")");
																																				});
																																				break;
																																		}
																																		break;
																																	}
																																	Sleep(1.0);
																																	num68++;
																																}
																																break;
																															}
																															num6++;
																															if (num6 == 4)
																															{
																																lock (this.obj)
																																{
																																	false_code++;
																																}
																																Invoke((Action)delegate
																																{
																																	error_code.Text = susscess_code.ToString();
																																});
																																cookie = GetCookieCurrentChrome(driver);
																																uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																string time62 = DateTime.Now.ToString();
																																switch (type_mail)
																																{
																																	case "Mailtm":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time62 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time62 + ")");
																																		});
																																		break;
																																	case "Hotmail":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time62 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time62 + ")");
																																		});
																																		break;
																																	case "Emailfake.com":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time62 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time62 + ")");
																																		});
																																		break;
																																}
																																break;
																															}
																															while (true)
																															{
																																if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
																																{
																																	xuanAction.ClickElement(driver, By.XPath("//button[@name='action_unset_contact_point']"), span2);
																																	Sleep(1.0);
																																	break;
																																}
																																if (xuanAction.Goto(driver, "https://m.facebook.com", span))
																																{
																																	continue;
																																}
																																cookie = GetCookieCurrentChrome(driver);
																																uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																																string time56 = DateTime.Now.ToString();
																																switch (type_mail)
																																{
																																	case "Mailtm":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time56 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time56 + ")");
																																		});
																																		break;
																																	case "Hotmail":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time56 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time56 + ")");
																																		});
																																		break;
																																	case "Emailfake.com":
																																		lock (this.obj)
																																		{
																																			tongreg++;
																																			File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time56 + "\n");
																																		}
																																		Invoke((Action)delegate
																																		{
																																			lb_tongreg.Text = tongreg + " accounts";
																																			dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time56 + ")");
																																		});
																																		break;
																																}
																																goto end_IL_181d1;
																															}
																														}
																														goto IL_75c9;
																													}
																												}
																												else if (num42 == 10)
																												{
																													lock (this.obj)
																													{
																														false_code++;
																													}
																													Invoke((Action)delegate
																													{
																														error_code.Text = susscess_code.ToString();
																													});
																													cookie = GetCookieCurrentChrome(driver);
																													uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																													string time45 = DateTime.Now.ToString();
																													switch (type_mail)
																													{
																														case "Mailtm":
																															lock (this.obj)
																															{
																																tongreg++;
																																File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time45 + "\n");
																															}
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time45 + ")");
																															});
																															break;
																														case "Hotmail":
																															lock (this.obj)
																															{
																																tongreg++;
																																File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time45 + "\n");
																															}
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time45 + ")");
																															});
																															break;
																														case "Emailfake.com":
																															lock (this.obj)
																															{
																																tongreg++;
																																File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time45 + "\n");
																															}
																															Invoke((Action)delegate
																															{
																																lb_tongreg.Text = tongreg + " accounts";
																																dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time45 + ")");
																															});
																															break;
																													}
																													break;
																												}
																												Sleep(1.0);
																												num42++;
																												continue;
																											end_IL_181d1:
																												break;
																											}
																											break;
																										}
																										if (num41 == 10)
																										{
																											lock (this.obj)
																											{
																												false_code++;
																											}
																											Invoke((Action)delegate
																											{
																												error_code.Text = susscess_code.ToString();
																											});
																											cookie = GetCookieCurrentChrome(driver);
																											uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																											string time34 = DateTime.Now.ToString();
																											switch (type_mail)
																											{
																												case "Mailtm":
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time34 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time34 + ")");
																													});
																													break;
																												case "Hotmail":
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time34 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time34 + ")");
																													});
																													break;
																												case "Emailfake.com":
																													lock (this.obj)
																													{
																														tongreg++;
																														File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time34 + "\n");
																													}
																													Invoke((Action)delegate
																													{
																														lb_tongreg.Text = tongreg + " accounts";
																														dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time34 + ")");
																													});
																													break;
																											}
																											break;
																										}
																										num41++;
																										Sleep(1.0);
																									}
																									break;
																								}
																								cookie = GetCookieCurrentChrome(driver);
																								uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																								time23 = DateTime.Now.ToString();
																								switch (type_mail)
																								{
																									case "Mailtm":
																										lock (this.obj)
																										{
																											tongreg++;
																											File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time23 + "\n");
																										}
																										Invoke((Action)delegate
																										{
																											lb_tongreg.Text = tongreg + " accounts";
																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time23 + ")");
																										});
																										break;
																									case "Hotmail":
																										lock (this.obj)
																										{
																											tongreg++;
																											File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time23 + "\n");
																										}
																										Invoke((Action)delegate
																										{
																											lb_tongreg.Text = tongreg + " accounts";
																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time23 + ")");
																										});
																										break;
																									case "Emailfake.com":
																										lock (this.obj)
																										{
																											tongreg++;
																											File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time23 + "\n");
																										}
																										Invoke((Action)delegate
																										{
																											lb_tongreg.Text = tongreg + " accounts";
																											dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time23 + ")");
																										});
																										break;
																								}
																								break;
																								continue;
																							end_IL_75c9:
																								break;
																							}
																							break;
																						IL_18cc0:
																							Sleep(1.0);
																							num37++;
																							continue;
																						end_IL_18ce4:
																							break;
																						}
																						break;
																					}
																					if (num36 == 15)
																					{
																						string time12 = DateTime.Now.ToString();
																						switch (type_mail)
																						{
																							case "Mailtm":
																								lock (this.obj)
																								{
																									tongreg++;
																									File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time12 + "\n");
																								}
																								Invoke((Action)delegate
																								{
																									lb_tongreg.Text = tongreg + " accounts";
																									dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time12 + ")");
																								});
																								break;
																							case "Hotmail":
																								lock (this.obj)
																								{
																									tongreg++;
																									File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time12 + "\n");
																								}
																								Invoke((Action)delegate
																								{
																									lb_tongreg.Text = tongreg + " accounts";
																									dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time12 + ")");
																								});
																								break;
																							case "Emailfake.com":
																								lock (this.obj)
																								{
																									tongreg++;
																									File.AppendAllText("Account_282\\" + text + "_checkpoint_282_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time12 + "\n");
																								}
																								Invoke((Action)delegate
																								{
																									lb_tongreg.Text = tongreg + " accounts";
																									dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time12 + ")");
																								});
																								break;
																						}
																						break;
																					}
																					num36++;
																					Sleep(1.0);
																				}
																				break;
																			}
																			if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
																			{
																				if (!cbregkhongunlock.Checked)
																				{
																					break;
																				}
																				cookie = GetCookieCurrentChrome(driver);
																				uid = Regex.Match(cookie, "c_user=(\\d+)").Groups[1].Value;
																				string time = DateTime.Now.ToString();
																				switch (type_mail)
																				{
																					case "Mailtm":
																						lock (this.obj)
																						{
																							tongreg++;
																							File.AppendAllText("Account_282\\" + text + "_checkpoint_282.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_mailtm + "|" + pass_mailtm + "|" + text2 + "|" + time + "\n");
																						}
																						Invoke((Action)delegate
																						{
																							lb_tongreg.Text = tongreg + " accounts";
																							dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_mailtm, pass_mailtm, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time + ")");
																						});
																						break;
																					case "Hotmail":
																						lock (this.obj)
																						{
																							tongreg++;
																							File.AppendAllText("Account_282\\" + text + "_checkpoint_282_hotmail.txt", uid + "|" + passfacebook + "|" + cookie + "|" + hotmail + "|" + passhotmail + "|" + text2 + "|" + time + "\n");
																						}
																						Invoke((Action)delegate
																						{
																							lb_tongreg.Text = tongreg + " accounts";
																							dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, hotmail, passhotmail, "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time + ")");
																						});
																						break;
																					case "Emailfake.com":
																						lock (this.obj)
																						{
																							tongreg++;
																							File.AppendAllText("Account_282\\" + text + "_checkpoint_282_emailfake.txt", uid + "|" + passfacebook + "|" + cookie + "|" + account_tempmail + "|" + text2 + "|" + time + "\n");
																						}
																						Invoke((Action)delegate
																						{
																							lb_tongreg.Text = tongreg + " accounts";
																							dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, uid, passfacebook, cookie, account_tempmail, "", "[" + myip + "](" + uid + ") Account checkpoint 282 (" + time + ")");
																						});
																						break;
																				}
																				break;
																			}
																			if (!driver.PageSource.Contains("captcha_persist_data"))
																			{
																				continue;
																			}
																			goto end_IL_3bdc;
																			continue;
																		end_IL_196d6:
																			break;
																		}
																		goto end_IL_196ed;
																	}
																end_IL_3bdc:
																	break;
															}
															goto IL_196fa;
															continue;
														end_IL_196ed:
															break;
														}
														break;
													}
													break;
												IL_19708:
													Sleep(1.0);
													num32++;
													continue;
												end_IL_19724:
													break;
												}
												break;
												continue;
											end_IL_19732:
												break;
											}
											break;
										}
										if (driver.FindElements(By.XPath("//button[@data-cookiebanner='accept_button']")).Count > 0)
										{
											if (xuanAction.ClickElement(driver, By.XPath("//button[@data-cookiebanner='accept_button']"), span4))
											{
												Sleep(1.0);
											}
										}
										else
										{
											if (driver.FindElements(By.XPath("//a[@id='signup-button']")).Count > 0)
											{
												goto IL_19864;
											}
											if (num8 == 15)
											{
												break;
											}
										}
										Sleep(1.0);
										num8++;
									}
									break;
								}
							}
							else if (num7 == 15)
							{
								break;
							}
							Sleep(1.0);
							num7++;
						}
						break;
					IL_19864:;
					}
				end_IL_01d3:;
				}
				catch (Exception)
				{
				}
				if (driver != null)
				{
					driver.Quit();
				}
				if (!cbaddview.Checked)
				{
					continue;
				}
				try
				{
					Invoke((Action)delegate
					{
						flowLayoutPanel1.Controls.Remove(ptn2);
					});
				}
				catch
				{
				}
			}
		}

		[Obsolete]
		private void cookie76324hgjdf(int index_chrome, int i, string uid, string pass, string ma2fa, string cookieclone, string text, string emailclone, string passmailclone, int index_captcha, string text_api_captcha, int index_phone, string text_api_phone, int limit_getphone, int limit_getcodephone, string combo_image, string ngonngu, string type_mail, string combo_server_sim)
		{
			IntPtr handle = IntPtr.Zero;
			int num = 0;
			Panel ptn2 = new Panel();
			Label name = new Label();
			ChromeDriver driver = null;
			int num2 = 0;
			bool flag = false;
			string ip = text.Split(':')[0];
			try
			{
				string text2 = string.Empty;
				if (Path_Tool == null)
				{
					Path_Tool = Application.StartupPath;
				}
				Emailfaker emailfaker = new Emailfaker();
				Random random = new Random();
				string text3 = manguser_agent[random.Next(0, manguser_agent.Length)];
				dataGridView2.Rows[i].Cells["useragent"].Value = text3;
				string empty = string.Empty;
				Otpygo otpygo = new Otpygo();
				Sellotpvn sellotpvn = new Sellotpvn();
				Sell282xyz sell282xyz = new Sell282xyz();
				Mailtm mailtm = new Mailtm();
				Hotmailbox hotmailbox = new Hotmailbox();
				Atmteam2 atmteam = new Atmteam2();
				Numberotp numberotp = new Numberotp();
				Fb282 fb = new Fb282();
				Otpngon otpngon = new Otpngon();
				Atmteam atmteam2 = new Atmteam();
				Omocaptcha omocaptcha = new Omocaptcha();
				Goodotp goodotp = new Goodotp();
				Sellotp sellotp = new Sellotp();
				Suppersim suppersim = new Suppersim();
				hcotp hcotp = new hcotp();
				Winmail winmail = new Winmail();
				Trumotpvn trumotpvn = new Trumotpvn();
				Vutruotp vutruotp = new Vutruotp();
				Ironsim ironsim = new Ironsim();
				string empty2 = string.Empty;
				Ndline ndline = new Ndline();
				Viotp viotp = new Viotp();
				Tempsms tempsms = new Tempsms();
				string text4 = string.Empty;
				Codetext247 codetext = new Codetext247();
				Tempcode tempcode = new Tempcode();
				Bossotp bossotp = new Bossotp();
				Testbossotp testbossotp = new Testbossotp();
				Otp282 otp = new Otp282();
				Sim24 sim = new Sim24();
				Chothuesimcode chothuesimcode = new Chothuesimcode();
				good9fun good9fun2 = new good9fun();
				Tempmail tempmail = new Tempmail();
				string text5 = string.Empty;
				string text6 = string.Empty;
				string text7 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				string text8 = string.Empty;
				string empty5 = string.Empty;
				string empty6 = string.Empty;
				string email = string.Empty;
				string hotmail = string.Empty;
				string passmail = string.Empty;
				string password = string.Empty;
				string empty7 = string.Empty;
				string empty8 = string.Empty;
				string result = string.Empty;
				if (cb_addmail282.Checked)
				{
					switch (type_mail)
					{
						case "Mailtm":
							while (true)
							{
								empty7 = mailtm.getdomains();
								if (empty7 != "" && empty7 != null)
								{
									email = Getrandomemail() + "@" + empty7;
									password = Getrandompassmailtm();
									if (mailtm.Create_Mailtm(email, password, text))
									{
										break;
									}
								}
								Sleep(1.0);
							}
							break;
						case "Hotmail":
							emailQueue.TryDequeue(out result);
							if (result != null)
							{
								empty8 = result;
								string[] array = result.Split('|');
								hotmail = array[0];
								passmail = array[1];
								File.AppendAllText("Data_Reg\\email_runned.txt", result + "\n");
								Invoke((Action)delegate
								{
									linkLabel10.Text = "[ " + emailQueue.Count + " ]";
								});
								break;
							}
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Hết hotmail";
							goto end_IL_0056;
						case "Emailfake.com":
							while (true)
							{
								text8 = emailfaker.Getmail();
								if (text8 != "" && text8 != null)
								{
									break;
								}
								Sleep(1.0);
							}
							break;
					}
				}
				Point pointFromIndexPosition = GetPointFromIndexPosition(index_chrome, Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				Point sizeChrome = GetSizeChrome(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				XuanAction xuanAction = new XuanAction();
				string text9 = string.Empty;
				TimeSpan span = new TimeSpan(0, 2, 0);
				TimeSpan span2 = new TimeSpan(0, 2, 0);
				TimeSpan span3 = new TimeSpan(0, 0, 30);
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
				chromeDriverService.HideCommandPromptWindow = true;
				ChromeOptions chromeOptions = new ChromeOptions();
				chromeOptions.AddArgument("--app=https://m.facebook.com/");
				if (text != "" && text.Split(':').Length == 2)
				{
					chromeOptions.AddArgument("--proxy-server= " + text);
				}
				else if (text != "" && text.Split(':').Length == 4)
				{
					chromeOptions.AddHttpProxy(text.Split(':')[0], int.Parse(text.Split(':')[1]), text.Split(':')[2], text.Split(':')[3]);
				}
				chromeOptions.AddArguments("--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--window-size=" + sizeChrome.X + "," + sizeChrome.Y, "--window-position=" + pointFromIndexPosition.X + "," + pointFromIndexPosition.Y, "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=BlockCredentialedSubresources", "--disable-popup-blocking");
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 0);
				chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
				chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
				chromeOptions.AddExcludedArgument("enable-automation");
				chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
				chromeOptions.AddArgument("user-agent=" + text3);
				Sleep(Convert.ToInt32(numericUpDown7.Value));
				driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3.0));
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(6.0);
				if (!cbaddview.Checked)
				{
					goto IL_0830;
				}
				try
				{
					num2 = chromeDriverService.ProcessId;
					Process windowHandleByDriverId = GetWindowHandleByDriverId(num2);
					handle = windowHandleByDriverId.MainWindowHandle;
					Thread.Sleep(1000);
				}
				catch
				{
					goto end_IL_0056;
				}
				if (num2 != 0)
				{
					Sleep(1.0);
					lock (this.obj)
					{
						Invoke((Action)delegate
						{
							ptn2.Width = 280;
							ptn2.Height = 300;
							ptn2.BorderStyle = BorderStyle.FixedSingle;
							ptn2.AutoScroll = true;
							ptn2.SetAutoScrollMargin(320, 480);
							name.Text = "IP:" + ip;
							name.Location = new Point(0, 0);
							ptn2.Controls.Add(name);
							Invoke((Action)delegate
							{
								flowLayoutPanel1.Controls.Add(ptn2);
							});
							SetParent(handle, ptn2.Handle);
							SetWindowLong(handle, -4, WS_VISIBLE);
							MoveWindow(handle, -8, -36, 320, 480, Repaint: true);
							driver.Manage().Window.Position = new Point(0, 15);
						});
					}
					goto IL_0830;
				}
				goto end_IL_0056;
			IL_0830:
				Sleep(2.0);
				string empty9 = string.Empty;
				if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				else
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập bằng cookie...";
					int num3 = 0;
					while (true)
					{
						if (driver.FindElements(By.XPath("//button[@name='login']")).Count <= 0 && driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count <= 0)
						{
							if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
							{
								driver.Navigate().Refresh();
								Sleep(1.0);
							}
							if (num3 == 10)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không mở được facebook!";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							num3++;
							Sleep(1.0);
							continue;
						}
						importcookie(driver, cookieclone);
						xuanAction.Goto(driver, driver.Url.Replace("www.face", "m.face").Replace("mbasic.face", "m.face"), span);
						Thread.Sleep(2000);
						dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Kiểm tra trạng thái đăng nhập...";
						Sleep(3.0);
						while (true)
						{
							if (driver.FindElements(By.XPath("//span[contains(text(),'Ok')]")).Count > 0)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
								break;
							}
							if (driver.PageSource.Contains("captcha_persist_data"))
							{
								goto IL_9dae;
							}
							int num4;
							if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
							{
								xuanAction.ClickElement(driver, By.XPath("//button[@name='action_unset_contact_point']"), span3);
								Sleep(1.0);
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone...";
							}
							else
							{
								if (driver.FindElements(By.XPath("//input[@name='code']")).Count <= 0)
								{
									if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
									{
										goto IL_1f98;
									}
									if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count <= 0)
									{
										if (driver.Url.Contains("disabled"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Vô phương cứu chữa";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone...";
											goto IL_3d9c;
										}
										if (driver.Url.Contains("actor_experience"))
										{
											xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
										}
										if (driver.FindElements(By.XPath("//a[@id='nux-nav-button']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//a[@id='nux-nav-button']"), span2);
											Sleep(1.0);
											goto IL_1f71;
										}
										if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
										{
											string text10 = DateTime.Now.ToString();
											empty2 = GetCookieCurrentChrome(driver);
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Chờ set duyệt (" + text10 + ")";
											dataGridView2.Rows[i].Cells["ghichu"].Value = "Chờ set duyệt (" + text10 + ")";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Checkpoint 282";
											dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										if (driver.FindElements(By.XPath("//div[@data-sigil='login_profile_form']")).Count > 0)
										{
											if (pass != "")
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Nhập lại mật khẩu...";
												xuanAction.Clicks(driver, By.XPath("//div[@data-sigil='login_profile_form']"), span2, 0);
												Sleep(1.0);
												while (driver.FindElements(By.XPath("//input[@type='password']")).Count <= 0)
												{
												}
												xuanAction.SendKey(driver, By.XPath("//input[@type='password']"), span2, pass);
												Sleep(1.0);
												while (driver.FindElements(By.XPath("//button[@data-sigil='touchable password_login_button']")).Count <= 0)
												{
												}
												xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable password_login_button']"), span2);
												Sleep(1.0);
												goto IL_1f71;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Cookie die!";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang giải 282...";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										}
										else
										{
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.Url.Contains("login/save-device"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (driver.FindElements(By.XPath("//a[@name='News Feed']")).Count > 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (driver.FindElements(By.XPath("//div[@id='login_error']")).Count > 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tên người dùng hoặc mật khẩu không hợp lệ ";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.FindElements(By.XPath("//div[@data-sigil='messenger_icon']")).Count > 5)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (driver.FindElements(By.XPath("//div[contains(text(),'Photo')]")).Count > 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (!driver.PageSource.Contains("We've suspended your account"))
											{
												if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												goto IL_1f71;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang giải 282...";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										}
									}
									num4 = 0;
									while (true)
									{
										if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
										{
											if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3))
											{
												Sleep(1.0);
												break;
											}
											goto IL_1de6;
										}
										if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
										{
											goto IL_3d29;
										}
										if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
										{
											goto IL_9e10;
										}
										if (driver.PageSource.Contains("captcha_persist_data"))
										{
											break;
										}
										if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
										{
											goto IL_1f98;
										}
										if (driver.FindElements(By.XPath("//input[@name='action_proceed']")).Count > 0)
										{
											if (xuanAction.ClickElement(driver, By.XPath("//input[@name='action_proceed']"), span3))
											{
												Sleep(1.0);
												break;
											}
										}
										else
										{
											if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
											{
												string text11 = DateTime.Now.ToString();
												empty2 = GetCookieCurrentChrome(driver);
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Chờ set duyệt (" + text11 + ")";
												dataGridView2.Rows[i].Cells["ghichu"].Value = "Chờ set duyệt (" + text11 + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Checkpoint 282";
												dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_a27f;
											}
											if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_a27f;
											}
											if (num4 == 10)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Unknow checkpoint (action_proceed)";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_a27f;
											}
										}
										goto IL_1de6;
									IL_1de6:
										Sleep(1.0);
										num4++;
									}
									goto IL_9dae;
								}
								xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span3);
								Sleep(1.0);
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
							}
							goto IL_3d9c;
						IL_1efb:
							xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span3);
							Sleep(1.0);
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
							goto IL_3d9c;
						IL_9e5c:
							xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span3);
							Sleep(1.0);
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
							goto IL_3d9c;
						IL_3d9c:
							if (cb_addmail282.Checked)
							{
								int num5 = 0;
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm mail...";
								while (true)
								{
									if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0 && driver.FindElements(By.XPath("//select[@name='country_code']")).Count == 0)
									{
										switch (type_mail)
										{
											case "Mailtm":
												xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span3, email);
												break;
											case "Hotmail":
												xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span3, hotmail);
												break;
											case "Emailfake.com":
												xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span3, text8);
												break;
										}
										if (driver.FindElements(By.XPath("//input[@name='action_set_contact_point']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//input[@name='action_set_contact_point']"), span3);
										}
										else if (driver.FindElements(By.XPath("//button[@name='action_set_contact_point']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//button[@name='action_set_contact_point']"), span3);
										}
										if (driver.FindElements(By.XPath("//input[@name='action_resend_code']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//input[@name='action_resend_code']"), span3);
										}
										else if (driver.FindElements(By.XPath("//button[@name='action_resend_code']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//button[@name='action_resend_code']"), span3);
										}
										Sleep(2.0);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy OTP mail...";
										switch (type_mail)
										{
											case "Mailtm":
												while (true)
												{
													text9 = mailtm.GetCodeMailTm(email, password, text);
													if (text9 != "" && text9 != null)
													{
														break;
													}
													Sleep(1.0);
												}
												break;
											case "Hotmail":
												while (true)
												{
													text9 = hotmailbox.Getcode(hotmail, passmail);
													if (text9 != "" && text9 != null)
													{
														break;
													}
													Sleep(1.0);
												}
												break;
											case "Emailfake.com":
												while (true)
												{
													text9 = emailfaker.Getcode(text8);
													if (text9 != "" && text9 != null)
													{
														break;
													}
													Sleep(1.0);
												}
												break;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Điền code mail " + text9 + "...";
										xuanAction.Goto(driver, "https://m.facebook.com/", span);
										xuanAction.SendKey(driver, By.XPath("//input[@name='code']"), span3, text9);
										while (driver.FindElements(By.XPath("//button[@name='action_submit_code']")).Count <= 0)
										{
										}
										xuanAction.ClickElement(driver, By.XPath("//button[@name='action_submit_code']"), span3);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone...";
										break;
									}
									if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
									{
										xuanAction.ClickElement(driver, By.XPath("//button[@name='action_unset_contact_point']"), span2);
										Sleep(1.0);
									}
									else if (driver.FindElements(By.XPath("//input[@name='action_unset_contact_point']")).Count > 0)
									{
										xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span2);
										Sleep(1.0);
									}
									else if (num5 == 10)
									{
										break;
									}
									Sleep(1.0);
									num5++;
								}
							}
							if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
							{
								xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3);
								Sleep(1.0);
							}
							if (cbngonngu.Checked)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đổi ngôn ngữ theo cài đặt (" + ngonngu + ")";
								xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
								string cookieCurrentChrome = GetCookieCurrentChrome(driver);
								ChangeLanguageRequest_Cookie(cookieCurrentChrome, ngonngu);
								xuanAction.Goto(driver, "https://m.facebook.com/", span);
							}
							while (true)
							{
								int num6 = 0;
								if (index_phone == 0)
								{
									while (true)
									{
										string text12 = tempcode.Getphone(text_api_phone);
										text5 = text12.Split('|')[0];
										text7 = text12.Split('|')[1];
										if (text5 != "" && text5 != null)
										{
											break;
										}
										if (num6 != limit_getphone)
										{
											Sleep(2.0);
											num6++;
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_9576;
									}
								}
								else if (index_phone == 1)
								{
									while (true)
									{
										string text13 = otp.Getphone(text_api_phone);
										if (text13.Split('|').Length != 0 && text13.Contains("|"))
										{
											text5 = text13.Split('|')[0];
											text7 = text13.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 2)
								{
									while (true)
									{
										string text14 = codetext.Getphone(text_api_phone);
										text5 = text14.Split('|')[0];
										text7 = text14.Split('|')[1];
										if (text5 != "" && text5 != null)
										{
											break;
										}
										if (num6 != limit_getphone)
										{
											Sleep(2.0);
											num6++;
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_9576;
									}
								}
								else if (index_phone == 3)
								{
									while (true)
									{
										string text15 = sim.Getphone(text_api_phone);
										if (text15.Split('|').Length != 0 && text15.Contains("|"))
										{
											text5 = text15.Split('|')[0];
											text7 = text15.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
										}
										else if (num6 == limit_getphone)
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_9576;
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 4)
								{
									while (true)
									{
										string text16 = viotp.Getphone(text_api_phone);
										text5 = text16.Split('|')[0];
										text7 = text16.Split('|')[1];
										if (text5 != "" && text5 != null)
										{
											break;
										}
										if (num6 != limit_getphone)
										{
											Sleep(2.0);
											num6++;
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_9576;
									}
								}
								else if (index_phone == 5)
								{
									while (true)
									{
										text4 = tempsms.Get_id_request(text_api_phone, "13");
										if (text4 != "" && text4 != null)
										{
											for (int j = 0; j < 20; j++)
											{
												text5 = tempsms.GetphoneFromID(text_api_phone, text4);
												if (text5 != "" && text5 != null)
												{
													break;
												}
												Sleep(1.0);
											}
											break;
										}
										if (num6 != limit_getphone)
										{
											Sleep(2.0);
											num6++;
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_9576;
									}
								}
								else if (index_phone == 6)
								{
									while (true)
									{
										string text17 = chothuesimcode.Getphone(text_api_phone, "1001");
										text5 = text17.Split('|')[0];
										text7 = text17.Split('|')[1];
										if (text5 != "" && text5 != null)
										{
											break;
										}
										if (num6 != limit_getphone)
										{
											Sleep(2.0);
											num6++;
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_9576;
									}
								}
								else if (index_phone == 7)
								{
									while (true)
									{
										text4 = bossotp.Getid_request(text_api_phone);
										if (text4 != "" && text4 != null)
										{
											for (int k = 0; k < 20; k++)
											{
												text5 = bossotp.Getphonefromid(text4, text_api_phone);
												if (text5 != "" && text5 != null)
												{
													break;
												}
												Sleep(1.0);
											}
											break;
										}
										if (num6 != limit_getphone)
										{
											Sleep(2.0);
											num6++;
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_9576;
									}
								}
								else if (index_phone == 8)
								{
									while (true)
									{
										string text18 = testbossotp.Getid_request(text_api_phone);
										if (text18.Split('|').Length != 0 && text18.Contains("|"))
										{
											text5 = text18.Split('|')[0];
											text7 = text18.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 9)
								{
									while (true)
									{
										string text19 = ndline.Getphone(text_api_phone);
										if (text19.Split('|').Length != 0 && text19.Contains("|"))
										{
											text5 = text19.Split('|')[0];
											text7 = text19.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 10)
								{
									while (true)
									{
										string text20 = trumotpvn.Getphone(text_api_phone);
										if (text20.Split('|').Length != 0 && text20.Contains("|"))
										{
											text5 = text20.Split('|')[0];
											text7 = text20.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 11)
								{
									while (true)
									{
										string text21 = winmail.Getphone(text_api_phone);
										if (text21.Split('|').Length != 0 && text21.Contains("|"))
										{
											text5 = text21.Split('|')[0];
											text7 = text21.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 12)
								{
									while (true)
									{
										string text22 = hcotp.Getphone(text_api_phone);
										if (text22.Split('|').Length != 0 && text22.Contains("|"))
										{
											text5 = text22.Split('|')[0];
											text7 = text22.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 13)
								{
									while (true)
									{
										string text23 = sellotp.Getphone(text_api_phone);
										if (text23.Split('|').Length != 0 && text23.Contains("|"))
										{
											text5 = text23.Split('|')[0];
											text7 = text23.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 14)
								{
									while (true)
									{
										string text24 = suppersim.Getphone(text_api_phone);
										if (text24.Split('|').Length != 0 && text24.Contains("|"))
										{
											text5 = text24.Split('|')[0];
											text7 = text24.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 15)
								{
									while (true)
									{
										string phone = goodotp.GetPhone(text_api_phone);
										if (phone.Split('|').Length != 0 && phone.Contains("|"))
										{
											text5 = phone.Split('|')[0];
											text7 = phone.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 16)
								{
									while (true)
									{
										string text25 = atmteam2.Getphone(text_api_phone);
										if (text25.Split('|').Length != 0 && text25.Contains("|"))
										{
											text5 = text25.Split('|')[0];
											text7 = text25.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 17)
								{
									while (true)
									{
										string phone2 = good9fun2.GetPhone(text_api_phone);
										if (phone2.Split('|').Length != 0 && phone2.Contains("|"))
										{
											text5 = phone2.Split('|')[0];
											text7 = phone2.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 18)
								{
									while (true)
									{
										string text26 = otpngon.Getphone(text_api_phone);
										if (text26.Split('|').Length != 0 && text26.Contains("|"))
										{
											text5 = text26.Split('|')[0];
											text7 = text26.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 19)
								{
									while (true)
									{
										string text27 = fb.Getphone(text_api_phone);
										if (text27.Split('|').Length != 0 && text27.Contains("|"))
										{
											text5 = text27.Split('|')[0];
											text7 = text27.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 20)
								{
									if (combo_server_sim == "Server việt")
									{
										while (true)
										{
											string text28 = numberotp.Getphone_VN(text_api_phone);
											if (text28.Split('|').Length != 0 && text28.Contains("|"))
											{
												text5 = text28.Split('|')[0];
												text7 = text28.Split('|')[1];
												if (text5 != "" && text5 != null)
												{
													break;
												}
												if (num6 == limit_getphone)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_9576;
												}
											}
											Sleep(2.0);
											num6++;
										}
									}
									else if (combo_server_sim == "Server ngoại")
									{
										while (true)
										{
											string text29 = numberotp.Getphone_US(text_api_phone);
											if (text29.Split('|').Length != 0 && text29.Contains("|"))
											{
												text5 = text29.Split('|')[0];
												text7 = text29.Split('|')[1];
												if (text5 != "" && text5 != null)
												{
													break;
												}
												if (num6 == limit_getphone)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_9576;
												}
											}
											Sleep(2.0);
											num6++;
										}
									}
								}
								else if (index_phone == 21)
								{
									while (true)
									{
										string text30 = atmteam.Getphone(text_api_phone);
										if (text30.Split('|').Length != 0 && text30.Contains("|"))
										{
											text5 = text30.Split('|')[0];
											text7 = text30.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 22)
								{
									while (true)
									{
										string text31 = sell282xyz.Getphone(text_api_phone);
										if (text31.Split('|').Length != 0 && text31.Contains("|"))
										{
											text5 = text31.Split('|')[0];
											text7 = text31.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 23)
								{
									if (combo_server_sim == "Server việt")
									{
										while (true)
										{
											string text32 = sellotpvn.Getphone_VN(text_api_phone);
											if (text32.Split('|').Length != 0 && text32.Contains("|"))
											{
												text5 = text32.Split('|')[0];
												text7 = text32.Split('|')[1];
												if (text5 != "" && text5 != null)
												{
													break;
												}
												if (num6 == limit_getphone)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_9576;
												}
											}
											Sleep(2.0);
											num6++;
										}
									}
									else if (combo_server_sim == "Server ngoại")
									{
										while (true)
										{
											string text33 = sellotpvn.Getphone_US(text_api_phone);
											if (text33.Split('|').Length != 0 && text33.Contains("|"))
											{
												text5 = text33.Split('|')[0];
												text7 = text33.Split('|')[1];
												if (text5 != "" && text5 != null)
												{
													break;
												}
												if (num6 == limit_getphone)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_9576;
												}
											}
											Sleep(2.0);
											num6++;
										}
									}
								}
								else if (index_phone == 24)
								{
									while (true)
									{
										string text34 = otpygo.Getphone_VN(text_api_phone);
										if (text34.Split('|').Length != 0 && text34.Contains("|"))
										{
											text5 = text34.Split('|')[0];
											text7 = text34.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 25)
								{
									while (true)
									{
										string text20 = vutruotp.Getphone(text_api_phone);
										if (text20.Split('|').Length != 0 && text20.Contains("|"))
										{
											text5 = text20.Split('|')[0];
											text7 = text20.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								else if (index_phone == 26)
								{
									while (true)
									{
										string text20 = ironsim.Getphone(text_api_phone);
										if (text20.Split('|').Length != 0 && text20.Contains("|"))
										{
											text5 = text20.Split('|')[0];
											text7 = text20.Split('|')[1];
											if (text5 != "" && text5 != null)
											{
												break;
											}
											if (num6 == limit_getphone)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
										}
										Sleep(2.0);
										num6++;
									}
								}
								if (text5 == "" || text5 == null)
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang điền phonenumber (" + text5 + ")";
								if (driver.FindElements(By.XPath("//input[@name='action_proceed']")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//input[@name='action_proceed']"), span3);
									Sleep(1.0);
								}
								else if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3);
									Sleep(1.0);
								}
								if (driver.FindElements(By.Name("country_code")).Count > 0)
								{
									try
									{
										if (index_phone == 0 || index_phone == 11)
										{
											new SelectElement(driver.FindElementByName("country_code")).SelectByValue("US");
											Thread.Sleep(100);
										}
										else if (index_phone == 1 || index_phone == 2 || index_phone == 3 || index_phone == 4 || index_phone == 5 || index_phone == 6 || index_phone == 7 || index_phone == 8 || index_phone == 9 || index_phone == 10 || index_phone == 12 || index_phone == 13 || index_phone == 14 || index_phone == 15 || index_phone == 16 || index_phone == 17 || index_phone == 18 || index_phone == 19 || index_phone == 20 || index_phone == 21 || index_phone == 22 || index_phone == 23 || index_phone == 24)
										{
											if (combo_server_sim == "Server việt")
											{
												new SelectElement(driver.FindElementByName("country_code")).SelectByValue("VN");
												Thread.Sleep(100);
											}
											else if (combo_server_sim == "Server ngoại")
											{
												new SelectElement(driver.FindElementByName("country_code")).SelectByValue("MM");
												Thread.Sleep(100);
											}
										}
									}
									catch
									{
									}
								}
								if (index_phone == 0 || index_phone == 11)
								{
									if (!text5.StartsWith("+1"))
									{
										text5 = "+1" + text5;
									}
								}
								else if ((index_phone == 1 || index_phone == 2 || index_phone == 3 || index_phone == 4 || index_phone == 5 || index_phone == 6 || index_phone == 7 || index_phone == 8 || index_phone == 9 || index_phone == 10 || index_phone == 12 || index_phone == 13 || index_phone == 14 || index_phone == 15 || index_phone == 16 || index_phone == 17 || index_phone == 18 || index_phone == 19 || index_phone == 20 || index_phone == 21 || index_phone == 22 || index_phone == 23 || index_phone == 24) && combo_server_sim == "Server việt")
								{
									if (!text5.StartsWith("0") && !text5.StartsWith("+84"))
									{
										if (!text5.StartsWith("84"))
										{
											text5 = "+84" + text5;
										}
									}
									else if (text5.StartsWith("0"))
									{
										text5 = "+84" + text5.Remove(0, 1);
									}
								}
								int num7 = 0;
								while (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count <= 0)
								{
									if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_9576;
									}
									if (num7 != 10)
									{
										num7++;
										Sleep(1.0);
										continue;
									}
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy chỗ điền phone (" + uid + ")";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_9576;
								}
								xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span3, text5);
								Sleep(1.0);
								int num8 = 0;
								while (true)
								{
									if (driver.FindElements(By.XPath("//button[@name='action_set_contact_point']")).Count > 0)
									{
										if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_set_contact_point']"), span3))
										{
											break;
										}
										goto IL_79d4;
									}
									if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_9576;
									}
									if (driver.FindElements(By.XPath("//input[@name='action_set_contact_point']")).Count > 0)
									{
										if (!xuanAction.ClickElement(driver, By.XPath("//input[@name='action_set_contact_point']"), span3))
										{
											goto IL_79d4;
										}
										goto IL_9509;
									}
									if (num8 != 10)
									{
										goto IL_79d4;
									}
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy nút tiếp tục phone (" + uid + ")";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_9576;
								IL_79d4:
									Sleep(1.0);
									num8++;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang check số (" + text5 + ")";
								Sleep(3.0);
								goto IL_7a65;
							IL_9509:
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang check số (" + text5 + ")";
								Sleep(3.0);
								goto IL_7a65;
							IL_7a65:
								Sleep(5.0);
								if (driver.PageSource.Contains("Please try a different number.") || driver.PageSource.Contains("Vui lòng thử số khác."))
								{
									if (num == Convert.ToInt32(nbr_getphoneagain.Value))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Số dùng quá nhiều (" + uid + ")";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									num++;
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone mới (" + uid + ")";
									continue;
								}
								if (driver.PageSource.Contains("Không thể truy cập"))
								{
									driver.Navigate().Refresh();
									Sleep(5.0);
								}
								else
								{
									if (driver.PageSource.Contains("Bạn cần nhập số di động hợp lệ") || driver.PageSource.Contains("Please enter a valid email address or mobile number."))
									{
										if (num == Convert.ToInt32(nbr_getphoneagain.Value))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Số dùng quá nhiều (" + uid + ")";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										num++;
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone mới (" + uid + ")";
										continue;
									}
									if (driver.PageSource.Contains("Gần đây, số điện thoại bạn đang cố gắng xác minh đã được sử dụng để xác minh một tài khoản khác. Vui lòng thử số khác.") || driver.PageSource.Contains("The phone number you're trying to verify was recently used to verify a different account. Please try a different number.") || driver.PageSource.Contains("Số này đã được dùng để xác minh quá nhiều tài khoản trên Facebook. Hãy thử dùng số khác.") || driver.PageSource.Contains("This number has been used to verify too many accounts on Facebook. Please try a different number."))
									{
										if (num == Convert.ToInt32(nbr_getphoneagain.Value))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Số dùng quá nhiều (" + uid + ")";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										num++;
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone mới (" + uid + ")";
										continue;
									}
									if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
									{
										if (num == Convert.ToInt32(nbr_getphoneagain.Value))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Số dùng quá nhiều (" + uid + ")";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										num++;
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone mới (" + uid + ")";
										continue;
									}
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy OTP (" + text5 + ")...";
								switch (index_phone)
								{
									case 0:
										{
											for (int num9 = 0; num9 < limit_getcodephone; num9++)
											{
												text6 = tempcode.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 1:
										{
											for (int num17 = 0; num17 < limit_getcodephone; num17++)
											{
												text6 = otp.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 2:
										{
											for (int num31 = 0; num31 < limit_getcodephone; num31++)
											{
												text6 = codetext.Getcode(text_api_phone, text5);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 3:
										{
											for (int num21 = 0; num21 < limit_getcodephone; num21++)
											{
												text6 = sim.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 4:
										{
											for (int num13 = 0; num13 < limit_getcodephone; num13++)
											{
												text6 = viotp.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 5:
										{
											for (int num33 = 0; num33 < limit_getcodephone; num33++)
											{
												text6 = tempsms.Getcode(text_api_phone, text4);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 6:
										{
											for (int num29 = 0; num29 < limit_getcodephone; num29++)
											{
												text6 = chothuesimcode.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 7:
										{
											for (int num23 = 0; num23 < limit_getcodephone; num23++)
											{
												text6 = bossotp.Getcode(text4, text_api_phone);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 8:
										{
											for (int num19 = 0; num19 < limit_getcodephone; num19++)
											{
												text6 = testbossotp.Getcode(text7, text_api_phone);
												if (text6 == null || !(text6 != ""))
												{
													Sleep(1.0);
													continue;
												}
												if (!(text6 == "Get SMS TimeOut"))
												{
													break;
												}
												goto end_IL_9576;
											}
											goto default;
										}
									case 9:
										{
											for (int num15 = 0; num15 < limit_getcodephone; num15++)
											{
												text6 = ndline.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 10:
										{
											for (int num11 = 0; num11 < limit_getcodephone; num11++)
											{
												text6 = trumotpvn.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 11:
										{
											for (int m = 0; m < limit_getcodephone; m++)
											{
												text6 = winmail.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 12:
										{
											for (int num32 = 0; num32 < limit_getcodephone; num32++)
											{
												text6 = hcotp.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 13:
										{
											for (int num30 = 0; num30 < limit_getcodephone; num30++)
											{
												text6 = sellotp.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 14:
										{
											for (int num28 = 0; num28 < limit_getcodephone; num28++)
											{
												text6 = suppersim.Getcode(text_api_phone, text7, text);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 15:
										{
											for (int num24 = 0; num24 < limit_getcodephone; num24++)
											{
												text6 = goodotp.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 16:
										{
											for (int num22 = 0; num22 < limit_getcodephone; num22++)
											{
												text6 = atmteam2.Getcode(text7, text_api_phone);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 17:
										{
											for (int num20 = 0; num20 < limit_getcodephone; num20++)
											{
												text6 = good9fun2.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 18:
										{
											for (int num18 = 0; num18 < limit_getcodephone; num18++)
											{
												text6 = otpngon.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 19:
										{
											for (int num16 = 0; num16 < limit_getcodephone; num16++)
											{
												text6 = fb.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 20:
										{
											for (int num14 = 0; num14 < limit_getcodephone; num14++)
											{
												text6 = numberotp.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 21:
										{
											for (int num12 = 0; num12 < limit_getcodephone; num12++)
											{
												text6 = atmteam.Getcode(text7, text_api_phone);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 22:
										{
											for (int num10 = 0; num10 < limit_getcodephone; num10++)
											{
												text6 = sell282xyz.Getcode(text7, text_api_phone);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 23:
										{
											for (int n = 0; n < limit_getcodephone; n++)
											{
												text6 = sellotpvn.Getcode(text7, text_api_phone);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 24:
										{
											for (int l = 0; l < limit_getcodephone; l++)
											{
												text6 = otpygo.Getcode(text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 25:
										{
											for (int num11 = 0; num11 < limit_getcodephone; num11++)
											{
												text6 = vutruotp.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									case 26:
										{
											for (int num11 = 0; num11 < limit_getcodephone; num11++)
											{
												text6 = ironsim.Getcode(text_api_phone, text7);
												if (text6 != null && text6 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											goto default;
										}
									default:
										{
											int num25;
											switch (text6)
											{
												default:
													num25 = ((text6 == "TimeOut") ? 1 : 0);
													break;
												case "":
												case null:
												case "Get SMS TimeOut":
													num25 = 1;
													break;
											}
											if (num25 != 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Phone không về code (" + text5 + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_9576;
											}
											if (cbngonngu.Checked)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đổi lại ngôn ngữ US...";
												xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
												string cookieCurrentChrome2 = GetCookieCurrentChrome(driver);
												ChangeLanguageRequest_Cookie(cookieCurrentChrome2, "en_US");
											}
											if (xuanAction.Goto(driver, "https://m.facebook.com/", span))
											{
												int num26 = 0;
												while (true)
												{
													if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
													{
														xuanAction.SendKey(driver, By.XPath("//input[@name='code']"), span3, text6);
														Thread.Sleep(200);
														int num27 = 0;
														while (true)
														{
															if (driver.FindElements(By.XPath("//button[@name='action_submit_code']")).Count > 0)
															{
																xuanAction.ClickElement(driver, By.XPath("//button[@name='action_submit_code']"), span3);
																break;
															}
															if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																goto end_IL_9457;
															}
															if (num27 != 10)
															{
																Sleep(1.0);
																num27++;
																continue;
															}
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy nút tiếp tục code phone (" + uid + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_9457;
														}
														goto end_IL_8110;
													}
													if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													if (num26 != 10)
													{
														Sleep(1.0);
														num26++;
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy chỗ điền code phone (" + uid + ")";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
													continue;
												end_IL_9457:
													break;
												}
											}
											else
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											}
											goto end_IL_9576;
										}
									end_IL_8110:
										break;
								}
								goto IL_1f98;
								continue;
							end_IL_9576:
								break;
							}
							break;
						IL_9ed2:
							Sleep(1.0);
							while (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count <= 0)
							{
								if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
								{
									goto IL_1e85;
								}
								if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
								{
									goto IL_1efb;
								}
								if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
								{
									if (!xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3))
									{
										continue;
									}
									goto IL_9dfa;
								}
								if (driver.FindElements(By.XPath("//div[@aria-label='Close']")).Count > 0 || driver.Url.Contains("actor_experience"))
								{
									xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
									continue;
								}
								if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_a27f;
								}
								if (driver.FindElements(By.XPath("//input[@name='contact_point_index']")).Count <= 0)
								{
									if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count <= 0)
									{
										continue;
									}
									goto IL_1f98;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Facebook gửi otp về sdt cũ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								goto end_IL_a27f;
							}
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
							goto IL_3d9c;
						IL_1e85:
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
							xuanAction.ClickElement(driver, By.XPath("//button[@name='action_unset_contact_point']"), span3);
							Sleep(1.0);
							goto IL_3d9c;
						IL_1f71:
							driver.Navigate().Refresh();
							Sleep(2.0);
							continue;
						IL_1f98:
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tiếp tục unlock...";
							num4 = 0;
							while (true)
							{
								if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
								{
									if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
									{
										empty2 = GetCookieCurrentChrome(driver);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										break;
									}
									if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
									{
										empty2 = GetCookieCurrentChrome(driver);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										break;
									}
									if (check_live(uid))
									{
										empty2 = GetCookieCurrentChrome(driver);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										break;
									}
									if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span2))
									{
										Sleep(1.0);
									}
									else if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count <= 0)
									{
										goto IL_3d00;
									}
								}
								else
								{
									if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
									{
										empty2 = GetCookieCurrentChrome(driver);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										break;
									}
									if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
									{
										empty2 = GetCookieCurrentChrome(driver);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										break;
									}
									if (driver.PageSource.Contains("The confirmation code you entered is invalid or has expired. Please make sure you entered your confirmation code correctly."))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Code phone này bị lỗi (" + text5 + "|" + text6 + ")";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count <= 0)
									{
										if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										if (num4 == 10)
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy chỗ up ảnh (" + uid + ")";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										goto IL_3d00;
									}
								}
								while (true)
								{
								IL_3cf8:
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang download ảnh...";
									int num34 = 0;
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
										{
											switch (combo_image)
											{
												case "Ảnh đã lưu trong folder Image":
													lock (this.obj)
													{
														string[] files = Directory.GetFiles(txt_folder_anh.Text);
														if (files.Length != 0)
														{
															text2 = files[random.Next(0, files.Length - 1)];
															break;
														}
													}
													goto end_IL_3cef;
												case "https://boredhumans.com/faces.php":
													lock (this.obj)
													{
														while (!method_41(uid, text))
														{
															Sleep(1.0);
														}
														text2 = Path_Tool + "\\Image\\" + uid + ".png";
													}
													break;
												case "https://this-person-does-not-exist.com":
													lock (this.obj)
													{
														while (!method_40(uid, ""))
														{
															Sleep(1.0);
														}
														text2 = Path_Tool + "\\Image\\" + uid + ".png";
													}
													break;
												case "https://www.unrealperson.com":
													lock (this.obj)
													{
														while (!method_42(uid, text))
														{
															Sleep(1.0);
														}
														text2 = Path_Tool + "\\Image\\" + uid + ".png";
													}
													break;
												case "https://fakeface.rest":
													lock (this.obj)
													{
														while (!method_43(uid))
														{
															Sleep(1.0);
														}
														text2 = Path_Tool + "\\Image\\" + uid + ".png";
													}
													break;
											}
											if (File.Exists(text2))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang up ảnh...";
												if (!(changeMD5(text2) == "") && changeMD5(text2) != null)
												{
													driver.FindElementByCssSelector("[type=\"file\"]").SendKeys(text2);
													Thread.Sleep(1000);
													while (true)
													{
														if (driver.FindElements(By.XPath("//button[@name='action_upload_image']")).Count > 0)
														{
															xuanAction.ClickElement(driver, By.XPath("//button[@name='action_upload_image']"), span3);
															Sleep(1.0);
														}
														else
														{
															if (driver.FindElements(By.XPath("//input[@name='action_upload_image']")).Count <= 0)
															{
																if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
																{
																	dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
																	dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																	dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																	break;
																}
																continue;
															}
															xuanAction.ClickElement(driver, By.XPath("//input[@name='action_upload_image']"), span3);
															Sleep(1.0);
														}
														if (driver.FindElements(By.XPath("//input[@type='file']")).Count > 0)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Up ảnh không thành công(" + uid + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															break;
														}
														int num35 = 0;
														while (true)
														{
															if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
															{
																if (combo_image == "Ảnh đã lưu trong folder Image" && File.Exists(text2))
																{
																	File.Delete(text2);
																}
																string text35 = DateTime.Now.ToString();
																empty2 = GetCookieCurrentChrome(driver);
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Chờ xét duyệt (" + text35 + ")";
																dataGridView2.Rows[i].Cells["ghichu"].Value = "Chờ set duyệt (" + text35 + ")";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Checkpoint 282";
																dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															}
															else
															{
																if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
																{
																	dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
																	dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																	dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																	break;
																}
																if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
																{
																	empty2 = GetCookieCurrentChrome(driver);
																	dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
																	dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
																	dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
																	dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
																}
																else
																{
																	if (!driver.PageSource.Contains("You're back on Facebook") && !driver.PageSource.Contains("Bạn đã trở lại Facebook"))
																	{
																		Sleep(1.0);
																		num35++;
																		if (num35 == 20)
																		{
																			string text36 = DateTime.Now.ToString();
																			empty2 = GetCookieCurrentChrome(driver);
																			dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Chờ xét duyệt (" + text36 + ")";
																			dataGridView2.Rows[i].Cells["ghichu"].Value = "Chờ set duyệt (" + text36 + ")";
																			dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Checkpoint 282";
																			dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
																			dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																			break;
																		}
																		continue;
																	}
																	empty2 = GetCookieCurrentChrome(driver);
																	dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
																	dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
																	dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
																	dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
																}
															}
															if (cbgiuanh.Checked)
															{
																break;
															}
															try
															{
																if (File.Exists(text2))
																{
																	File.Delete(text2);
																}
															}
															catch (Exception)
															{
															}
															break;
														}
														break;
													}
													break;
												}
												if (File.Exists(text2))
												{
													File.Delete(text2);
												}
											}
											goto IL_3cf8;
										}
										if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3);
										}
										else
										{
											if (driver.FindElements(By.XPath("//button[@id='nuxChoosePhotoButton']")).Count > 0)
											{
												empty2 = GetCookieCurrentChrome(driver);
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
											{
												empty2 = GetCookieCurrentChrome(driver);
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (check_live(uid))
											{
												empty2 = GetCookieCurrentChrome(driver);
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
											{
												empty2 = GetCookieCurrentChrome(driver);
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["cookieclone"].Value = empty2;
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (driver.PageSource.Contains("Mã đó không hoạt động. Vui lòng kiểm tra mã và thử lại") || driver.PageSource.Contains("That code didn't work. Please check the code and try again."))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Unlock không thành công (" + uid + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (num34 == 15)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Up ảnh không thành công (" + uid + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
										}
										Sleep(1.0);
										num34++;
										continue;
									end_IL_3cef:
										break;
									}
									break;
								}
								break;
							IL_3d00:
								Sleep(1.0);
								num4++;
							}
							break;
						IL_9dfa:
							Sleep(1.0);
							goto IL_3d9c;
						IL_3d29:
							xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span3);
							Sleep(1.0);
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
							goto IL_3d9c;
						IL_9e10:
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
							goto IL_3d9c;
						IL_9dae:
							while (true)
							{
								empty2 = GetCookieCurrentChrome(driver);
								if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
								{
									break;
								}
								if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
								{
									goto IL_9e5c;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang giải captcha...";
								if (!driver.Url.Contains("mbasic.facebook"))
								{
									if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/", span))
									{
										goto end_IL_a27f;
									}
									Sleep(1.0);
								}
								while (true)
								{
									string text37 = string.Empty;
									if (index_captcha == 0)
									{
										if (CaptchaService.Anycaptcha_Giai_normalcaptcha(empty2, text_api_captcha, "https://mbasic.facebook.com/"))
										{
											goto IL_9d1d;
										}
										if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
										{
											break;
										}
										text37 = CaptchaService.Anycaptcha_Giai_recaptcha(text_api_captcha, "https://fbsbx.com/captcha/recaptcha/iframe/?referer=https://m.facebook.com", "6Lc9qjcUAAAAADTnJq5kJMjN9aD1lxpRLMnCS2TR");
										if (text37 == "")
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Giải captcha FB thất bại";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
									}
									else if (index_captcha == 1)
									{
										while (true)
										{
											string empty10 = string.Empty;
											while (true)
											{
												string pageSource = driver.PageSource;
												empty10 = omocaptcha.get_captcha_persist(pageSource);
												if (empty10 != "")
												{
													break;
												}
												Sleep(1.0);
											}
											text37 = CaptchaService.Omocaptcha_Giai_normalcaptcha(text_api_captcha, empty10);
											if (!(text37 == "Get new"))
											{
												break;
											}
											if (xuanAction.Goto(driver, "https://mbasic.facebook.com/", span))
											{
												Sleep(1.0);
												continue;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Giải captcha FB thất bại";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_9d50;
										}
									}
									else if (index_captcha == 2)
									{
										string value = Regex.Match(driver.PageSource, "captcha_persist_data\" value=\"(.*?)\"").Groups[1].Value;
										if (CaptchaService.Twocaptcha_Giai_normalcaptcha(text_api_captcha, empty2, "https://mbasic.facebook.com/"))
										{
											goto IL_9d1d;
										}
										if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
										{
											break;
										}
										text37 = CaptchaService.Twocaptcha_Giai_recaptcha(text_api_captcha);
										if (text37 == "")
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Giải captcha FB thất bại";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
									}
									if (text37 != "")
									{
										if (index_captcha == 0 || index_captcha == 2)
										{
											driver.ExecuteScript("document.querySelector('#captcha_response').value=\"" + text37 + "\"");
											Thread.Sleep(1000);
											xuanAction.ClickElement(driver, By.Name("action_submit_bot_captcha_response"), span3);
											Sleep(4.0);
										}
										else if (index_captcha == 1)
										{
											driver.FindElement(By.XPath("//input[@id='captcha_response']")).SendKeys(text37);
											Thread.Sleep(500);
											xuanAction.ClickElement(driver, By.XPath("//input[@name='action_submit_bot_captcha_response']"), span3);
											Sleep(4.0);
											if (driver.FindElements(By.XPath("//input[@name='action_submit_bot_captcha_response']")).Count > 0)
											{
												xuanAction.ClickElement(driver, By.XPath("//input[@name='action_submit_bot_captcha_response']"), span3);
												Sleep(4.0);
											}
										}
										int num36 = CheckExistElements(driver, 10.0, "[name=\"contact_point\"]", "#mobile_image_data", "#captcha_response");
										if (driver.PageSource.Contains("Không thể truy cập trang web này") || driver.PageSource.Contains("We need more information") || driver.PageSource.Contains("Chúng tôi cần thêm thông tin"))
										{
											break;
										}
										if (num36 == 3)
										{
											continue;
										}
										if (num36 != 0)
										{
											Thread.Sleep(100);
										}
									}
									goto IL_9d1d;
								IL_9d1d:
									Thread.Sleep(10);
									if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/", span))
									{
										break;
									}
									goto IL_9d61;
									continue;
								end_IL_9d50:
									break;
								}
								goto end_IL_a27f;
							IL_9d61:
								if (driver.PageSource.Contains("captcha_persist_data"))
								{
									driver.Navigate().Refresh();
									Sleep(5.0);
									continue;
								}
								goto IL_9ed2;
							}
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone...";
							goto IL_3d9c;
							continue;
						end_IL_a27f:
							break;
						}
						break;
					}
				}
			end_IL_0056:;
			}
			catch
			{
				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Có lỗi xảy ra khi unlock bằng cookie";
				dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
				dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
			}
			UpdateData(i);
			if (driver != null)
			{
				driver.Quit();
			}
			dataGridView2.Rows[i].Cells["chon"].Value = false;
			if (!cbaddview.Checked)
			{
				return;
			}
			try
			{
				Invoke((Action)delegate
				{
					flowLayoutPanel1.Controls.Remove(ptn2);
				});
			}
			catch
			{
			}
		}

		[Obsolete]
		private void login_cookie(int index_chrome, int i, string uid, string pass, string ma2fa, string cookieclone, string text, string emailclone, string passmailclone)
		{
			IntPtr handle = IntPtr.Zero;
			int num = 0;
			Random random = new Random();
			Panel ptn2 = new Panel();
			Label name = new Label();
			ChromeDriver driver = null;
			string ip = string.Empty;
			try
			{
				string text2 = manguser_agent[random.Next(0, manguser_agent.Length)];
				dataGridView2.Rows[i].Cells["useragent"].Value = text2;
				ip = text.Split(':')[0];
				Point pointFromIndexPosition = GetPointFromIndexPosition(index_chrome, Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				Point sizeChrome = GetSizeChrome(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				XuanAction xuanAction = new XuanAction();
				TimeSpan span = new TimeSpan(0, 2, 0);
				TimeSpan span2 = new TimeSpan(0, 2, 0);
				TimeSpan span3 = new TimeSpan(0, 0, 30);
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
				chromeDriverService.HideCommandPromptWindow = true;
				ChromeOptions chromeOptions = new ChromeOptions();
				chromeOptions.AddArgument("--app=https://m.facebook.com/");
				if (text != "" && text.Split(':').Length == 2)
				{
					chromeOptions.AddArgument("--proxy-server= " + text);
				}
				else if (text != "" && text.Split(':').Length == 4)
				{
					chromeOptions.AddHttpProxy(text.Split(':')[0], int.Parse(text.Split(':')[1]), text.Split(':')[2], text.Split(':')[3]);
				}
				chromeOptions.AddArgument("user-agent=" + text2);
				chromeOptions.AddArguments("--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--window-size=" + sizeChrome.X + "," + sizeChrome.Y, "--window-position=" + pointFromIndexPosition.X + "," + pointFromIndexPosition.Y, "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=BlockCredentialedSubresources", "--disable-popup-blocking");
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 0);
				chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
				chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
				chromeOptions.AddExcludedArgument("enable-automation");
				chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
				Sleep(Convert.ToInt32(numericUpDown7.Value));
				driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3.0));
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(6.0);
				if (!cbaddview.Checked)
				{
					goto IL_04fe;
				}
				try
				{
					num = chromeDriverService.ProcessId;
					Process windowHandleByDriverId = GetWindowHandleByDriverId(num);
					handle = windowHandleByDriverId.MainWindowHandle;
					Thread.Sleep(1000);
				}
				catch
				{
					goto end_IL_0049;
				}
				if (num != 0)
				{
					Sleep(1.0);
					lock (this.obj)
					{
						Invoke((Action)delegate
						{
							ptn2.Width = 280;
							ptn2.Height = 300;
							ptn2.BorderStyle = BorderStyle.FixedSingle;
							ptn2.AutoScroll = true;
							ptn2.SetAutoScrollMargin(320, 480);
							name.Text = "IP:" + ip;
							name.Location = new Point(0, 0);
							ptn2.Controls.Add(name);
							Invoke((Action)delegate
							{
								flowLayoutPanel1.Controls.Add(ptn2);
							});
							SetParent(handle, ptn2.Handle);
							SetWindowLong(handle, -4, WS_VISIBLE);
							MoveWindow(handle, -8, -36, 320, 480, Repaint: true);
							driver.Manage().Window.Position = new Point(0, 15);
						});
					}
					goto IL_04fe;
				}
				goto end_IL_0049;
			IL_04fe:
				Sleep(2.0);
				if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				else
				{
					string text3 = string.Empty;
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập bằng cookie...";
					while (driver.FindElements(By.XPath("//button[@name='login']")).Count <= 0 && driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count <= 0)
					{
					}
					importcookie(driver, cookieclone);
					xuanAction.Goto(driver, driver.Url.Replace("www.face", "m.face").Replace("mbasic.face", "m.face"), span);
					Thread.Sleep(2000);
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Kiểm tra trạng thái đăng nhập...";
					while (true)
					{
						if (driver.FindElements(By.XPath("//span[contains(text(),'Ok')]")).Count > 0)
						{
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
							dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
							dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
							xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'Ok')]"), span2);
							Sleep(1.0);
						}
						else if (driver.FindElements(By.XPath("//div[@aria-label='Close']")).Count > 0 || driver.Url.Contains("actor_experience"))
						{
							xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
							if (!check_live(uid))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
						}
						else
						{
							if (driver.FindElements(By.XPath("//a[@id='nux-nav-button']")).Count > 0)
							{
								xuanAction.ClickElement(driver, By.XPath("//a[@id='nux-nav-button']"), span2);
								Sleep(1.0);
							}
							if (driver.FindElements(By.XPath("//button[@id='nux-nav-button']")).Count > 0)
							{
								xuanAction.ClickElement(driver, By.XPath("//button[@id='nux-nav-button']"), span3);
								Sleep(2.0);
								xuanAction.ClickElement(driver, By.XPath("//a[@id='qf_skip_dialog_skip_link']"), span3);
								Sleep(1.0);
								goto IL_538b;
							}
							if (driver.FindElements(By.XPath("//div[@data-sigil='login_profile_form']")).Count > 0)
							{
								if (pass != "")
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Nhập lại mật khẩu...";
									xuanAction.Clicks(driver, By.XPath("//div[@data-sigil='login_profile_form']"), span2, 0);
									Sleep(1.0);
									while (driver.FindElements(By.XPath("//input[@type='password']")).Count <= 0)
									{
									}
									xuanAction.SendKey(driver, By.XPath("//input[@type='password']"), span2, pass);
									Sleep(1.0);
									while (driver.FindElements(By.XPath("//button[@data-sigil='touchable password_login_button']")).Count <= 0)
									{
									}
									xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable password_login_button']"), span2);
									Sleep(1.0);
									goto IL_538b;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Cookie die!";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("login/save-device"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
								xuanAction.Goto(driver, "https://m.facebook.com/", span);
								Sleep(1.0);
							}
							else if (driver.PageSource.Contains("menu/bookmarks"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
								Sleep(1.0);
							}
							else if (driver.FindElements(By.XPath("//a[@name='News Feed']")).Count > 0)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
								Sleep(1.0);
							}
							else
							{
								if (driver.FindElements(By.XPath("//div[@id='login_error']")).Count > 0)
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tên người dùng hoặc mật khẩu không hợp lệ ";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (driver.FindElements(By.XPath("//div[@data-sigil='messenger_icon']")).Count > 5)
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
									Sleep(1.0);
								}
								else
								{
									if (driver.FindElements(By.XPath("//div[contains(text(),'Photo')]")).Count <= 0)
									{
										if (driver.PageSource.Contains("We've suspended your account"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										goto IL_538b;
									}
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
									Sleep(1.0);
								}
							}
						}
						if (cbngonngu.Checked)
						{
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đổi ngôn ngữ...";
							Sleep(1.0);
							if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/language.php", span))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Lỗi đổi ngôn ngữ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (!xuanAction.ClickElement(driver, By.XPath("//input[@value='English (US)']"), span3))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Lỗi đổi ngôn ngữ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							Sleep(2.0);
						}
						if (cb2fa.Checked)
						{
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang bật 2fa...";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/security/2fac/settings/", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							int num2 = 0;
							while (true)
							{
								if (driver.FindElements(By.XPath("//span[contains(text(),'Use authentication app')]")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'Use authentication app')]"), span2);
								}
								else if (driver.FindElements(By.XPath("//span[contains(text(),'Use Authentication App')]")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'Use Authentication App')]"), span2);
								}
								else if (driver.FindElements(By.XPath("//span[contains(text(),'Dùng ứng dụng xác thực')]")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'Dùng ứng dụng xác thực')]"), span2);
								}
								else if (driver.FindElements(By.XPath("//span[contains(text(),'dùng ứng dụng xác thực')]")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'dùng ứng dụng xác thực')]"), span2);
								}
								else
								{
									if (driver.FindElements(By.XPath("//span[contains(text(),'use authentication app')]")).Count <= 0)
									{
										if (driver.FindElements(By.XPath("//input[@name='pass']")).Count > 0)
										{
											xuanAction.SendKey(driver, By.XPath("//input[@name='pass']"), span3, pass);
											Thread.Sleep(10);
											xuanAction.ClickElement(driver, By.XPath("//button[@name='save']"), span3);
											Thread.Sleep(200);
										}
										else if (driver.PageSource.Contains("You can’t manage your security settings now") || driver.PageSource.Contains("Bạn không thể quản lý cài đặt bảo mật của mình ngay bây giờ") || num2 == 10)
										{
											break;
										}
										num2++;
										Sleep(1.0);
										continue;
									}
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'use authentication app')]"), span2);
								}
								while (true)
								{
									if (driver.FindElements(By.XPath("//input[@name='confirmButton']")).Count > 0)
									{
										while (text3 == "")
										{
											text3 = Regex.Match(driver.PageSource, "data-testid=\"key\">(.*?)<").Groups[1].Value;
											if (text3 != "")
											{
												text3 = text3.Replace(" ", "");
											}
											else if (text3 == "")
											{
												text3 = Regex.Match(driver.PageSource, "secret=(.*?)&").Groups[1].Value.Replace(" ", "");
											}
											Thread.Sleep(500);
										}
										while (driver.FindElements(By.XPath("//input[@name='confirmButton']")).Count <= 0)
										{
										}
										xuanAction.ClickElement(driver, By.XPath("//input[@name='confirmButton']"), span2);
										Sleep(1.0);
										byte[] secretKey = Base32Encoding.ToBytes(text3);
										Totp totp = new Totp(secretKey);
										string text4;
										while (true)
										{
											text4 = totp.ComputeTotp();
											if (text4 != "")
											{
												break;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Lỗi bật 2fa...";
										}
										Thread.Sleep(500);
										while (true)
										{
											if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
											{
												xuanAction.SendKey(driver, By.XPath("//input[@name='code']"), span2, text4);
												Sleep(1.0);
												while (driver.FindElements(By.XPath("//input[@id='submit_code_button']")).Count <= 0)
												{
												}
												xuanAction.ClickElement(driver, By.XPath("//input[@id='submit_code_button']"), span2);
												Sleep(1.0);
												while (true)
												{
													if (driver.PageSource.Contains("Xác thực 2 yếu tố đang bật") || driver.PageSource.Contains("Two-factor authentication is on"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Thành công bật 2fa...";
														dataGridView2.Rows[i].Cells["ma2fa"].Value = text3;
														UpdateData(i);
														goto end_IL_28f5;
													}
													if (driver.FindElements(By.XPath("//button[@value='Done']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Xong']")).Count > 0)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Thành công bật 2fa...";
														dataGridView2.Rows[i].Cells["ma2fa"].Value = text3;
														UpdateData(i);
														goto end_IL_28f5;
													}
													if (driver.PageSource.Contains("We've suspended your account"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
														break;
													}
													if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
														break;
													}
													if (!driver.Url.Contains("checkpoint"))
													{
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
													break;
												}
												break;
											}
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.PageSource.Contains("We've suspended your account"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (!driver.Url.Contains("checkpoint"))
											{
												continue;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										break;
									}
									if (driver.PageSource.Contains("You can’t manage your security settings now") || driver.PageSource.Contains("Bạn không thể quản lý cài đặt bảo mật của mình ngay bây giờ"))
									{
										goto end_IL_28f5;
									}
									if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.PageSource.Contains("We've suspended your account"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (!driver.Url.Contains("checkpoint"))
									{
										if (driver.FindElements(By.XPath("//input[@name='pass']")).Count > 0)
										{
											Thread.Sleep(200);
											driver.FindElement(By.XPath("//input[@name='pass']")).SendKeys(pass);
											Thread.Sleep(100);
											while (true)
											{
												if (driver.FindElements(By.XPath("//button[@name='save']")).Count > 0)
												{
													xuanAction.ClickElement(driver, By.XPath("//button[@name='save']"), span2);
													break;
												}
												if (driver.FindElements(By.XPath("//input[@name='save']")).Count > 0)
												{
													xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span2);
													break;
												}
											}
										}
										else if (driver.PageSource.Contains("You can’t manage your security settings now") || driver.PageSource.Contains("Bạn hiện chưa thể quản lý cài đặt bảo mật"))
										{
											goto end_IL_28f5;
										}
										continue;
									}
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								goto end_IL_53ae;
								continue;
							end_IL_28f5:
								break;
							}
						}
						if (cbquequan.Checked)
						{
							string text5 = randominfo("quequan.txt");
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm quê quán (" + text5 + ") ";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/editprofile.php?type=basic&edit=hometown", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							while (true)
							{
								if (driver.FindElements(By.XPath("//input[@name='hometown[]']")).Count > 0)
								{
									xuanAction.SendKey(driver, By.XPath("//input[@name='hometown[]']"), span3, text5);
									Sleep(1.0);
									xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span3);
									Sleep(1.0);
									if (driver.FindElements(By.XPath("//input[@name='save']")).Count > 0)
									{
										xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span3);
										Sleep(1.0);
									}
									if (!cbnoisong.Checked)
									{
										break;
									}
									string text6 = randominfo("noisong.txt");
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm nơi sống (" + text5 + ") ";
									xuanAction.Goto(driver, "https://mbasic.facebook.com/editprofile.php?type=basic&edit=current_city", span);
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@name='current_city[]']")).Count > 0)
										{
											xuanAction.SendKey(driver, By.XPath("//input[@name='current_city[]']"), span3, text6);
											Sleep(1.0);
											xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span3);
											Sleep(1.0);
											if (driver.FindElements(By.XPath("//input[@name='save']")).Count > 0)
											{
												xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span3);
												Sleep(1.0);
											}
											break;
										}
										if (driver.PageSource.Contains("We've suspended your account"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (!driver.Url.Contains("checkpoint"))
										{
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_53ae;
									}
									break;
								}
								if (driver.PageSource.Contains("We've suspended your account"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (!driver.Url.Contains("checkpoint"))
								{
									continue;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								goto end_IL_53ae;
							}
						}
						if (cbnghenghiep.Checked)
						{
							string text7 = randominfo("work.txt");
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm nghề nghiệp (" + text7 + ") ";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/me", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							cookieclone = GetCookieCurrentChrome(driver);
							Request request = new Request(cookieclone, "", text);
							request.AddHeader("referer", "https://mbasic.facebook.com/editprofile/eduwork/add/?type=958371&refid=17&paipv=0");
							string text8 = request.RequestGet("https://mbasic.facebook.com/editprofile/eduwork/add/?type=958371&refid=17&paipv=0");
							string url = request.Uri().Replace("m.facebook.com", "mbasic.facebook.com");
							string input = request.RequestGet(url);
							string url2 = "https://mbasic.facebook.com/profile/edit/exp/work/" + Regex.Match(input, "action=\"/profile/edit/exp/work/(.*?)\"").Groups[1].Value.Replace("amp;", "");
							string value = Regex.Match(input, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
							string value2 = Regex.Match(input, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
							string text9 = "fb_dtsg=" + value2 + "&jazoest=" + value + "&query=" + text7;
							string input2 = request.RequestPost(url2, text9);
							MatchCollection matchCollection = Regex.Matches(input2, "profile picture(.*?)href=\"(.*?)\"");
							if (matchCollection.Count > 0)
							{
								string url3 = "https://mbasic.facebook.com/" + matchCollection[random.Next(0, matchCollection.Count)].Groups[2].Value.Replace("amp;", "");
								string input3 = request.RequestGet(url3);
								value = Regex.Match(input3, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
								value2 = Regex.Match(input3, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
								string url4 = "https://mbasic.facebook.com/editprofile" + Regex.Match(input3, "action=\"/editprofile(.*?)\"").Groups[1].Value.Replace("amp;", "");
								string text10 = "fb_dtsg=" + value2 + "&jazoest=" + value + "&position=&start_month=1&start_day=21&start_year=2023&current=on&end_month=-1&end_day=-1&end_year=-1";
								string text11 = request.RequestPost(url4, text10);
							}
							xuanAction.Goto(driver, "https://mbasic.facebook.com/me", span);
						}
						if (cbavatar.Checked)
						{
							string path = txt_avatar.Text;
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang cập nhật ảnh đại diện...";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/profile_picture", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							while (true)
							{
								if (driver.FindElements(By.XPath("//input[@type='file']")).Count > 0)
								{
									string[] files = Directory.GetFiles(path);
									string text12 = files[random.Next(0, files.Length)];
									driver.FindElementByCssSelector("[type=\"file\"]").SendKeys(text12);
									Thread.Sleep(1000);
									int num3 = 0;
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@type='submit']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//input[@type='submit']"), span3);
											Sleep(1.0);
											break;
										}
										if (driver.PageSource.Contains("We've suspended your account"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (driver.Url.Contains("checkpoint"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (num3 != 10)
										{
											num3++;
											Sleep(1.0);
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không cập nhật được avatar";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Error";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Yellow;
										goto end_IL_53ae;
									}
									break;
								}
								if (driver.PageSource.Contains("We've suspended your account"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (!driver.Url.Contains("checkpoint"))
								{
									continue;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								goto end_IL_53ae;
							}
						}
						if (cbcover.Checked)
						{
							string path2 = txt_cover.Text;
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang cập nhật ảnh bìa...";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/photos/upload/?cover_photo", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							while (true)
							{
								if (driver.FindElements(By.XPath("//input[@type='file']")).Count > 0)
								{
									string[] files2 = Directory.GetFiles(path2);
									string text13 = files2[random.Next(0, files2.Length)];
									driver.FindElementByCssSelector("[type=\"file\"]").SendKeys(text13);
									Thread.Sleep(1000);
									int num4 = 0;
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@type='submit']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//input[@type='submit']"), span3);
											Sleep(1.0);
											break;
										}
										if (driver.PageSource.Contains("We've suspended your account"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (driver.Url.Contains("checkpoint"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53ae;
										}
										if (num4 != 10)
										{
											num4++;
											Sleep(1.0);
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không cập nhật được ảnh bìa";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Error";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Yellow;
										goto end_IL_53ae;
									}
									break;
								}
								if (driver.PageSource.Contains("We've suspended your account"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53ae;
								}
								if (!driver.Url.Contains("checkpoint"))
								{
									continue;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								goto end_IL_53ae;
							}
						}
						if (cbgetcookiemoi.Checked)
						{
							cookieclone = GetCookieCurrentChrome(driver);
							dataGridView2.Rows[i].Cells["cookieclone"].Value = cookieclone;
						}
						dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Đã cập nhật info thành công uid (" + uid + ")";
						cookieclone = dataGridView2.Rows[i].Cells["cookieclone"].Value.ToString();
						lock (this.obj)
						{
							File.AppendAllText("Account_Full_Info\\live.txt", uid + "|" + pass + "|" + text3 + "|" + cookieclone + "|" + emailclone + "|" + passmailclone + "\n");
						}
						break;
					IL_538b:
						driver.Navigate().Refresh();
						Sleep(2.0);
						continue;
					end_IL_53ae:
						break;
					}
				}
			end_IL_0049:;
			}
			catch
			{
			}
			UpdateData(i);
			if (driver != null)
			{
				driver.Quit();
			}
			dataGridView2.Rows[i].Cells["chon"].Value = false;
			if (!cbaddview.Checked)
			{
				return;
			}
			try
			{
				Invoke((Action)delegate
				{
					flowLayoutPanel1.Controls.Remove(ptn2);
				});
			}
			catch
			{
			}
		}

		[Obsolete]
		private void unlock_uid_pass(int index_chrome, int i, string uid, string pass, string ma2fa, string text, string emailclone, string passmailclone, int index_captcha, string text_api_captcha, int index_phone, string text_api_phone, int limit_getphone, int limit_getcodephone, string combo_image, string ngonngu, string type_mail, string combo_server_sim)
		{
			IntPtr handle = IntPtr.Zero;
			int num = 0;
			Random random = new Random();
			int num2 = 0;
			Panel ptn2 = new Panel();
			Label name = new Label();
			string ip = string.Empty;
			bool flag = false;
			ChromeDriver driver = null;
			Emailfaker emailfaker = new Emailfaker();
			try
			{
				if (Path_Tool == null)
				{
					Path_Tool = Application.StartupPath;
				}
				string text2 = string.Empty;
				string text3 = manguser_agent[random.Next(0, manguser_agent.Length)];
				dataGridView2.Rows[i].Cells["useragent"].Value = text3;
				Sellotpvn sellotpvn = new Sellotpvn();
				Sell282xyz sell282xyz = new Sell282xyz();
				Otpygo otpygo = new Otpygo();
				Atmteam2 atmteam = new Atmteam2();
				Numberotp numberotp = new Numberotp();
				Fb282 fb = new Fb282();
				Otpngon otpngon = new Otpngon();
				good9fun good9fun2 = new good9fun();
				Atmteam atmteam2 = new Atmteam();
				Omocaptcha omocaptcha = new Omocaptcha();
				Goodotp goodotp = new Goodotp();
				Sellotp sellotp = new Sellotp();
				Suppersim suppersim = new Suppersim();
				hcotp hcotp = new hcotp();
				Winmail winmail = new Winmail();
				Trumotpvn trumotpvn = new Trumotpvn();
				Vutruotp vutruotp = new Vutruotp();
				Ironsim ironsim = new Ironsim();
				string empty = string.Empty;
				Ndline ndline = new Ndline();
				Viotp viotp = new Viotp();
				Tempsms tempsms = new Tempsms();
				string text4 = string.Empty;
				Codetext247 codetext = new Codetext247();
				Tempcode tempcode = new Tempcode();
				Bossotp bossotp = new Bossotp();
				Testbossotp testbossotp = new Testbossotp();
				Otp282 otp = new Otp282();
				Sim24 sim = new Sim24();
				Chothuesimcode chothuesimcode = new Chothuesimcode();
				string text5 = string.Empty;
				string text6 = string.Empty;
				string text7 = string.Empty;
				Mailtm mailtm = new Mailtm();
				Hotmailbox hotmailbox = new Hotmailbox();
				Tempmail tempmail = new Tempmail();
				string text8 = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string text9 = string.Empty;
				string empty4 = string.Empty;
				string empty5 = string.Empty;
				string email = string.Empty;
				string hotmail = string.Empty;
				string passmail = string.Empty;
				string password = string.Empty;
				string empty6 = string.Empty;
				string empty7 = string.Empty;
				string result = string.Empty;
				if (cb_addmail282.Checked)
				{
					switch (type_mail)
					{
						case "Mailtm":
							while (true)
							{
								empty6 = mailtm.getdomains();
								if (empty6 != "" && empty6 != null)
								{
									email = Getrandomemail() + "@" + empty6;
									password = Getrandompassmailtm();
									if (mailtm.Create_Mailtm(email, password, text))
									{
										break;
									}
								}
								Sleep(1.0);
							}
							break;
						case "Hotmail":
							emailQueue.TryDequeue(out result);
							if (result != null)
							{
								empty7 = result;
								string[] array = result.Split('|');
								hotmail = array[0];
								passmail = array[1];
								File.AppendAllText("Data_Reg\\email_runned.txt", result + "\n");
								Invoke((Action)delegate
								{
									linkLabel10.Text = "[ " + emailQueue.Count + " ]";
								});
								break;
							}
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Hết hotmail";
							goto end_IL_0055;
						case "Emailfake.com":
							while (true)
							{
								text9 = emailfaker.Getmail();
								if (text9 != "" && text9 != null)
								{
									break;
								}
								Sleep(1.0);
							}
							break;
					}
				}
				Point pointFromIndexPosition = GetPointFromIndexPosition(index_chrome, Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				Point sizeChrome = GetSizeChrome(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				ip = text.Split(':')[0];
				XuanAction xuanAction = new XuanAction();
				TimeSpan span = new TimeSpan(0, 2, 0);
				TimeSpan span2 = new TimeSpan(0, 2, 0);
				TimeSpan span3 = new TimeSpan(0, 0, 30);
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
				chromeDriverService.HideCommandPromptWindow = true;
				ChromeOptions chromeOptions = new ChromeOptions();
				chromeOptions.AddArgument("--app=https://m.facebook.com/");
				if (text != "" && text.Split(':').Length == 2)
				{
					chromeOptions.AddArgument("--proxy-server= " + text);
				}
				else if (text != "" && text.Split(':').Length == 4)
				{
					chromeOptions.AddHttpProxy(text.Split(':')[0], int.Parse(text.Split(':')[1]), text.Split(':')[2], text.Split(':')[3]);
				}
				chromeOptions.AddArguments("--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--window-size=" + sizeChrome.X + "," + sizeChrome.Y, "--window-position=" + pointFromIndexPosition.X + "," + pointFromIndexPosition.Y, "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=BlockCredentialedSubresources", "--disable-popup-blocking");
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 0);
				chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
				chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
				chromeOptions.AddExcludedArgument("enable-automation");
				chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
				chromeOptions.AddArgument("user-agent=" + text3);
				Sleep(Convert.ToInt32(numericUpDown7.Value));
				driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3.0));
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(6.0);
				if (!cbaddview.Checked)
				{
					goto IL_0833;
				}
				try
				{
					num = chromeDriverService.ProcessId;
					Process windowHandleByDriverId = GetWindowHandleByDriverId(num);
					handle = windowHandleByDriverId.MainWindowHandle;
					Thread.Sleep(1000);
				}
				catch
				{
					goto end_IL_0055;
				}
				if (num != 0)
				{
					Sleep(1.0);
					lock (this.obj)
					{
						Invoke((Action)delegate
						{
							ptn2.Width = 280;
							ptn2.Height = 300;
							ptn2.BorderStyle = BorderStyle.FixedSingle;
							ptn2.AutoScroll = true;
							ptn2.SetAutoScrollMargin(320, 480);
							name.Text = "IP:" + ip;
							name.Location = new Point(0, 0);
							ptn2.Controls.Add(name);
							Invoke((Action)delegate
							{
								flowLayoutPanel1.Controls.Add(ptn2);
							});
							SetParent(handle, ptn2.Handle);
							SetWindowLong(handle, -4, WS_VISIBLE);
							MoveWindow(handle, -8, -36, 320, 480, Repaint: true);
							driver.Manage().Window.Position = new Point(0, 15);
						});
					}
					goto IL_0833;
				}
				goto end_IL_0055;
			IL_0833:
				Sleep(2.0);
				if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				else
				{
					string empty8 = string.Empty;
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập bằng uid|pass...";
					string empty9 = string.Empty;
					int num3 = 0;
					while (true)
					{
						if (driver.FindElements(By.XPath("//button[@name='login']")).Count <= 0 && driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count <= 0)
						{
							if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
							{
								driver.Navigate().Refresh();
								Sleep(1.0);
							}
							if (num3 == 15)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							num3++;
							continue;
						}
						while (true)
						{
							if (!xuanAction.SendKey(driver, By.XPath("//input[@name='email']"), span2, uid))
							{
								if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								continue;
							}
							while (true)
							{
								if (!xuanAction.SendKey(driver, By.XPath("//input[@name='pass']"), span2, pass))
								{
									if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									continue;
								}
								while (true)
								{
									if (driver.FindElements(By.XPath("//button[@name='login']")).Count > 0)
									{
										xuanAction.ClickElement(driver, By.XPath("//button[@name='login']"), span2);
										Sleep(2.0);
									}
									else
									{
										if (driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count <= 0)
										{
											if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											continue;
										}
										xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']"), span2);
										Sleep(2.0);
									}
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Kiểm tra trạng thái đăng nhập...";
									Sleep(3.0);
									while (true)
									{
										if (driver.FindElements(By.XPath("//span[contains(text(),'Ok')]")).Count > 0)
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
											break;
										}
										if (driver.FindElements(By.XPath("//input[@id='approvals_code']")).Count > 0)
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Nhập 2fa...";
											string text10;
											do
											{
												byte[] secretKey = Base32Encoding.ToBytes(ma2fa);
												Totp totp = new Totp(secretKey);
												text10 = totp.ComputeTotp();
											}
											while (!(text10 != ""));
											xuanAction.SendKey(driver, By.XPath("//input[@id='approvals_code']"), span3, text10);
											do
											{
												xuanAction.ClickElement(driver, By.XPath("//button[@id='checkpointSubmitButton-actual-button']"), span3);
												Sleep(1.0);
											}
											while (driver.FindElements(By.XPath("//button[@id='checkpointSubmitButton-actual-button']")).Count != 0);
										}
										if (driver.PageSource.Contains("captcha_persist_data"))
										{
											goto IL_a3a4;
										}
										int num4;
										if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//button[@name='action_unset_contact_point']"), span3);
											Sleep(1.0);
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone...";
										}
										else
										{
											if (driver.FindElements(By.XPath("//input[@name='code']")).Count <= 0)
											{
												if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
												{
													goto IL_7bfb;
												}
												if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count <= 0)
												{
													if (driver.Url.Contains("disabled"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Vô phương cứu chữa";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone...";
														goto IL_25ae;
													}
													if (driver.FindElements(By.XPath("//div[@aria-label='Close']")).Count > 0 || driver.Url.Contains("actor_experience"))
													{
														xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
													}
													if (driver.FindElements(By.XPath("//a[@id='nux-nav-button']")).Count > 0)
													{
														xuanAction.ClickElement(driver, By.XPath("//a[@id='nux-nav-button']"), span2);
														Sleep(1.0);
														goto IL_a477;
													}
													if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
													{
														string text11 = DateTime.Now.ToString();
														empty = GetCookieCurrentChrome(driver);
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Chờ set duyệt (" + text11 + ")";
														dataGridView2.Rows[i].Cells["ghichu"].Value = "Chờ set duyệt (" + text11 + ")";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Checkpoint 282";
														dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang giải 282...";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													}
													else
													{
														if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															break;
														}
														if (driver.Url.Contains("login/save-device"))
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
															break;
														}
														if (driver.FindElements(By.XPath("//a[@name='News Feed']")).Count > 0)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
															break;
														}
														if (driver.FindElements(By.XPath("//div[@id='login_error']")).Count > 0)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tên người dùng hoặc mật khẩu không hợp lệ ";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															break;
														}
														if (driver.FindElements(By.XPath("//div[@data-sigil='messenger_icon']")).Count > 5)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
															break;
														}
														if (driver.FindElements(By.XPath("//div[contains(text(),'Photo')]")).Count > 0)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Tài khoản live";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
															break;
														}
														if (!driver.PageSource.Contains("We've suspended your account"))
														{
															if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																break;
															}
															goto IL_a477;
														}
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang giải 282...";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													}
												}
												num4 = 0;
												while (true)
												{
													if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
													{
														if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3))
														{
															Sleep(1.0);
															break;
														}
														goto IL_20c4;
													}
													if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
													{
														goto IL_9b54;
													}
													if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
													{
														goto IL_a3b5;
													}
													if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
													{
														goto IL_a42b;
													}
													if (driver.PageSource.Contains("captcha_persist_data"))
													{
														break;
													}
													if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
													{
														goto IL_7bfb;
													}
													if (driver.FindElements(By.XPath("//input[@name='action_proceed']")).Count > 0)
													{
														if (xuanAction.ClickElement(driver, By.XPath("//input[@name='action_proceed']"), span3))
														{
															Sleep(1.0);
															break;
														}
													}
													else
													{
														if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
														{
															string text12 = DateTime.Now.ToString();
															empty = GetCookieCurrentChrome(driver);
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Chờ set duyệt (" + text12 + ")";
															dataGridView2.Rows[i].Cells["ghichu"].Value = "Chờ set duyệt (" + text12 + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Checkpoint 282";
															dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_a49a;
														}
														if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_a49a;
														}
														if (num4 == 10)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Unknow checkpoint (action_proceed)";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_a49a;
														}
													}
													goto IL_20c4;
												IL_20c4:
													Sleep(1.0);
													num4++;
												}
												goto IL_a3a4;
											}
											xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span3);
											Sleep(1.0);
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
										}
										goto IL_25ae;
									IL_a42b:
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
										goto IL_25ae;
									IL_25ae:
										if (cb_addmail282.Checked)
										{
											int num5 = 0;
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm mail...";
											while (true)
											{
												if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0 && driver.FindElements(By.XPath("//select[@name='country_code']")).Count == 0)
												{
													switch (type_mail)
													{
														case "Mailtm":
															xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span3, email);
															break;
														case "Hotmail":
															xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span3, hotmail);
															break;
														case "Emailfake.com":
															xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span3, text9);
															break;
													}
													if (driver.FindElements(By.XPath("//input[@name='action_set_contact_point']")).Count > 0)
													{
														xuanAction.ClickElement(driver, By.XPath("//input[@name='action_set_contact_point']"), span3);
													}
													else if (driver.FindElements(By.XPath("//button[@name='action_set_contact_point']")).Count > 0)
													{
														xuanAction.ClickElement(driver, By.XPath("//button[@name='action_set_contact_point']"), span3);
													}
													if (driver.FindElements(By.XPath("//input[@name='action_resend_code']")).Count > 0)
													{
														xuanAction.ClickElement(driver, By.XPath("//input[@name='action_resend_code']"), span3);
													}
													else if (driver.FindElements(By.XPath("//button[@name='action_resend_code']")).Count > 0)
													{
														xuanAction.ClickElement(driver, By.XPath("//button[@name='action_resend_code']"), span3);
													}
													Sleep(2.0);
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy OTP mail...";
													switch (type_mail)
													{
														case "Mailtm":
															while (true)
															{
																text8 = mailtm.GetCodeMailTm(email, password, text);
																if (text8 != "" && text8 != null)
																{
																	break;
																}
																Sleep(1.0);
															}
															break;
														case "Hotmail":
															while (true)
															{
																text8 = hotmailbox.Getcode(hotmail, passmail);
																if (text8 != "" && text8 != null)
																{
																	break;
																}
																Sleep(1.0);
															}
															break;
														case "Emailfake.com":
															while (true)
															{
																text8 = emailfaker.Getcode(text9);
																if (text8 != "" && text8 != null)
																{
																	break;
																}
																Sleep(1.0);
															}
															break;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Điền code mail " + text8 + "...";
													xuanAction.Goto(driver, "https://m.facebook.com/", span);
													xuanAction.SendKey(driver, By.XPath("//input[@name='code']"), span3, text8);
													while (driver.FindElements(By.XPath("//button[@name='action_submit_code']")).Count <= 0)
													{
													}
													xuanAction.ClickElement(driver, By.XPath("//button[@name='action_submit_code']"), span3);
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone...";
													break;
												}
												if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
												{
													xuanAction.ClickElement(driver, By.XPath("//button[@name='action_unset_contact_point']"), span2);
													Sleep(1.0);
												}
												else if (driver.FindElements(By.XPath("//input[@name='action_unset_contact_point']")).Count > 0)
												{
													xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span2);
													Sleep(1.0);
												}
												else if (num5 == 10)
												{
													break;
												}
												Sleep(1.0);
												num5++;
											}
										}
										if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3);
											Sleep(1.0);
										}
										while (true)
										{
											int num6 = 0;
											if (index_phone == 0)
											{
												while (true)
												{
													string text13 = tempcode.Getphone(text_api_phone);
													text5 = text13.Split('|')[0];
													text7 = text13.Split('|')[1];
													if (text5 != "" && text5 != null)
													{
														break;
													}
													if (num6 != limit_getphone)
													{
														Sleep(2.0);
														num6++;
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_7bea;
												}
											}
											else if (index_phone == 1)
											{
												while (true)
												{
													string text14 = otp.Getphone(text_api_phone);
													if (text14.Split('|').Length != 0 && text14.Contains("|"))
													{
														text5 = text14.Split('|')[0];
														text7 = text14.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 2)
											{
												while (true)
												{
													string text15 = codetext.Getphone(text_api_phone);
													text5 = text15.Split('|')[0];
													text7 = text15.Split('|')[1];
													if (text5 != "" && text5 != null)
													{
														break;
													}
													if (num6 != limit_getphone)
													{
														Sleep(2.0);
														num6++;
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_7bea;
												}
											}
											else if (index_phone == 3)
											{
												while (true)
												{
													string text16 = sim.Getphone(text_api_phone);
													if (text16.Split('|').Length != 0 && text16.Contains("|"))
													{
														text5 = text16.Split('|')[0];
														text7 = text16.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
													}
													else if (num6 == limit_getphone)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														goto end_IL_7bea;
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 4)
											{
												while (true)
												{
													string text17 = viotp.Getphone(text_api_phone);
													text5 = text17.Split('|')[0];
													text7 = text17.Split('|')[1];
													if (text5 != "" && text5 != null)
													{
														break;
													}
													if (num6 != limit_getphone)
													{
														Sleep(2.0);
														num6++;
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_7bea;
												}
											}
											else if (index_phone == 5)
											{
												while (true)
												{
													text4 = tempsms.Get_id_request(text_api_phone, "13");
													if (text4 != "" && text4 != null)
													{
														for (int j = 0; j < 20; j++)
														{
															text5 = tempsms.GetphoneFromID(text_api_phone, text4);
															if (text5 != "" && text5 != null)
															{
																break;
															}
															Sleep(1.0);
														}
														break;
													}
													if (num6 != limit_getphone)
													{
														Sleep(2.0);
														num6++;
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_7bea;
												}
											}
											else if (index_phone == 6)
											{
												while (true)
												{
													string text18 = chothuesimcode.Getphone(text_api_phone, "1001");
													text5 = text18.Split('|')[0];
													text7 = text18.Split('|')[1];
													if (text5 != "" && text5 != null)
													{
														break;
													}
													if (num6 != limit_getphone)
													{
														Sleep(2.0);
														num6++;
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_7bea;
												}
											}
											else if (index_phone == 7)
											{
												while (true)
												{
													text4 = bossotp.Getid_request(text_api_phone);
													if (text4 != "" && text4 != null)
													{
														for (int k = 0; k < 20; k++)
														{
															text5 = bossotp.Getphonefromid(text4, text_api_phone);
															if (text5 != "" && text5 != null)
															{
																break;
															}
															Sleep(1.0);
														}
														break;
													}
													if (num6 != limit_getphone)
													{
														Sleep(2.0);
														num6++;
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_7bea;
												}
											}
											else if (index_phone == 8)
											{
												while (true)
												{
													string text19 = testbossotp.Getid_request(text_api_phone);
													if (text19.Split('|').Length != 0 && text19.Contains("|"))
													{
														text5 = text19.Split('|')[0];
														text7 = text19.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 9)
											{
												while (true)
												{
													string text20 = ndline.Getphone(text_api_phone);
													if (text20.Split('|').Length != 0 && text20.Contains("|"))
													{
														text5 = text20.Split('|')[0];
														text7 = text20.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 10)
											{
												while (true)
												{
													string text21 = trumotpvn.Getphone(text_api_phone);
													if (text21.Split('|').Length != 0 && text21.Contains("|"))
													{
														text5 = text21.Split('|')[0];
														text7 = text21.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 11)
											{
												while (true)
												{
													string text22 = winmail.Getphone(text_api_phone);
													if (text22.Split('|').Length != 0 && text22.Contains("|"))
													{
														text5 = text22.Split('|')[0];
														text7 = text22.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 12)
											{
												while (true)
												{
													string text23 = hcotp.Getphone(text_api_phone);
													if (text23.Split('|').Length != 0 && text23.Contains("|"))
													{
														text5 = text23.Split('|')[0];
														text7 = text23.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 13)
											{
												while (true)
												{
													string text24 = sellotp.Getphone(text_api_phone);
													if (text24.Split('|').Length != 0 && text24.Contains("|"))
													{
														text5 = text24.Split('|')[0];
														text7 = text24.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 14)
											{
												while (true)
												{
													string text25 = suppersim.Getphone(text_api_phone);
													if (text25.Split('|').Length != 0 && text25.Contains("|"))
													{
														text5 = text25.Split('|')[0];
														text7 = text25.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 15)
											{
												while (true)
												{
													string phone = goodotp.GetPhone(text_api_phone);
													if (phone.Split('|').Length != 0 && phone.Contains("|"))
													{
														text5 = phone.Split('|')[0];
														text7 = phone.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 16)
											{
												while (true)
												{
													string text26 = atmteam2.Getphone(text_api_phone);
													if (text26.Split('|').Length != 0 && text26.Contains("|"))
													{
														text5 = text26.Split('|')[0];
														text7 = text26.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 17)
											{
												while (true)
												{
													string phone2 = good9fun2.GetPhone(text_api_phone);
													if (phone2.Split('|').Length != 0 && phone2.Contains("|"))
													{
														text5 = phone2.Split('|')[0];
														text7 = phone2.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 18)
											{
												while (true)
												{
													string text27 = otpngon.Getphone(text_api_phone);
													if (text27.Split('|').Length != 0 && text27.Contains("|"))
													{
														text5 = text27.Split('|')[0];
														text7 = text27.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 19)
											{
												while (true)
												{
													string text28 = fb.Getphone(text_api_phone);
													if (text28.Split('|').Length != 0 && text28.Contains("|"))
													{
														text5 = text28.Split('|')[0];
														text7 = text28.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 20)
											{
												if (combo_server_sim == "Server việt")
												{
													while (true)
													{
														string text29 = numberotp.Getphone_VN(text_api_phone);
														if (text29.Split('|').Length != 0 && text29.Contains("|"))
														{
															text5 = text29.Split('|')[0];
															text7 = text29.Split('|')[1];
															if (text5 != "" && text5 != null)
															{
																break;
															}
															if (num6 == limit_getphone)
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																goto end_IL_7bea;
															}
														}
														Sleep(2.0);
														num6++;
													}
												}
												else if (combo_server_sim == "Server ngoại")
												{
													while (true)
													{
														string text30 = numberotp.Getphone_US(text_api_phone);
														if (text30.Split('|').Length != 0 && text30.Contains("|"))
														{
															text5 = text30.Split('|')[0];
															text7 = text30.Split('|')[1];
															if (text5 != "" && text5 != null)
															{
																break;
															}
															if (num6 == limit_getphone)
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																goto end_IL_7bea;
															}
														}
														Sleep(2.0);
														num6++;
													}
												}
											}
											else if (index_phone == 21)
											{
												while (true)
												{
													string text31 = atmteam.Getphone(text_api_phone);
													if (text31.Split('|').Length != 0 && text31.Contains("|"))
													{
														text5 = text31.Split('|')[0];
														text7 = text31.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 22)
											{
												while (true)
												{
													string text32 = sell282xyz.Getphone(text_api_phone);
													if (text32.Split('|').Length != 0 && text32.Contains("|"))
													{
														text5 = text32.Split('|')[0];
														text7 = text32.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 23)
											{
												if (combo_server_sim == "Server việt")
												{
													while (true)
													{
														string text33 = sellotpvn.Getphone_VN(text_api_phone);
														if (text33.Split('|').Length != 0 && text33.Contains("|"))
														{
															text5 = text33.Split('|')[0];
															text7 = text33.Split('|')[1];
															if (text5 != "" && text5 != null)
															{
																break;
															}
															if (num6 == limit_getphone)
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																goto end_IL_7bea;
															}
														}
														Sleep(2.0);
														num6++;
													}
												}
												else if (combo_server_sim == "Server ngoại")
												{
													while (true)
													{
														string text34 = sellotpvn.Getphone_US(text_api_phone);
														if (text34.Split('|').Length != 0 && text34.Contains("|"))
														{
															text5 = text34.Split('|')[0];
															text7 = text34.Split('|')[1];
															if (text5 != "" && text5 != null)
															{
																break;
															}
															if (num6 == limit_getphone)
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																goto end_IL_7bea;
															}
														}
														Sleep(2.0);
														num6++;
													}
												}
											}
											else if (index_phone == 24)
											{
												while (true)
												{
													string text35 = otpygo.Getphone_VN(text_api_phone);
													if (text35.Split('|').Length != 0 && text35.Contains("|"))
													{
														text5 = text35.Split('|')[0];
														text7 = text35.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 25)
											{
												while (true)
												{
													string text21 = vutruotp.Getphone(text_api_phone);
													if (text21.Split('|').Length != 0 && text21.Contains("|"))
													{
														text5 = text21.Split('|')[0];
														text7 = text21.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											else if (index_phone == 26)
											{
												while (true)
												{
													string text21 = ironsim.Getphone(text_api_phone);
													if (text21.Split('|').Length != 0 && text21.Contains("|"))
													{
														text5 = text21.Split('|')[0];
														text7 = text21.Split('|')[1];
														if (text5 != "" && text5 != null)
														{
															break;
														}
														if (num6 == limit_getphone)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
													}
													Sleep(2.0);
													num6++;
												}
											}
											if (text5 == "" || text5 == null)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không lấy được phone";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang điền phonenumber (" + text5 + ")";
											if (driver.FindElements(By.XPath("//input[@name='action_proceed']")).Count > 0)
											{
												xuanAction.ClickElement(driver, By.XPath("//input[@name='action_proceed']"), span3);
												Sleep(1.0);
											}
											else if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
											{
												xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3);
												Sleep(1.0);
											}
											if (cbngonngu.Checked)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đổi ngôn ngữ theo cài đặt (" + ngonngu + ")";
												xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
												string cookieCurrentChrome = GetCookieCurrentChrome(driver);
												ChangeLanguageRequest_Cookie(cookieCurrentChrome, ngonngu);
												xuanAction.Goto(driver, "https://m.facebook.com/", span);
											}
											if (driver.FindElements(By.Name("country_code")).Count > 0)
											{
												try
												{
													if (index_phone == 0 || index_phone == 11)
													{
														new SelectElement(driver.FindElementByName("country_code")).SelectByValue("US");
														Thread.Sleep(100);
													}
													else if (index_phone == 1 || index_phone == 2 || index_phone == 3 || index_phone == 4 || index_phone == 5 || index_phone == 6 || index_phone == 7 || index_phone == 8 || index_phone == 9 || index_phone == 10 || index_phone == 12 || index_phone == 13 || index_phone == 14 || index_phone == 15 || index_phone == 16 || index_phone == 17 || index_phone == 18 || index_phone == 19 || index_phone == 20 || index_phone == 21 || index_phone == 22 || index_phone == 23 || index_phone == 24)
													{
														if (combo_server_sim == "Server việt")
														{
															new SelectElement(driver.FindElementByName("country_code")).SelectByValue("VN");
															Thread.Sleep(100);
														}
														else if (combo_server_sim == "Server ngoại")
														{
															new SelectElement(driver.FindElementByName("country_code")).SelectByValue("MM");
															Thread.Sleep(100);
														}
													}
												}
												catch
												{
												}
											}
											if (index_phone == 0 || index_phone == 11)
											{
												if (!text5.StartsWith("+1"))
												{
													text5 = "+1" + text5;
												}
											}
											else if ((index_phone == 1 || index_phone == 2 || index_phone == 3 || index_phone == 4 || index_phone == 5 || index_phone == 6 || index_phone == 7 || index_phone == 8 || index_phone == 9 || index_phone == 10 || index_phone == 12 || index_phone == 13 || index_phone == 14 || index_phone == 15 || index_phone == 16 || index_phone == 17 || index_phone == 18 || index_phone == 19 || index_phone == 20 || index_phone == 21 || index_phone == 22 || index_phone == 23 || index_phone == 24) && combo_server_sim == "Server việt")
											{
												if (!text5.StartsWith("0") && !text5.StartsWith("+84"))
												{
													if (!text5.StartsWith("84"))
													{
														text5 = "+84" + text5;
													}
												}
												else if (text5.StartsWith("0"))
												{
													text5 = "+84" + text5.Remove(0, 1);
												}
											}
											int num7 = 0;
											while (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count <= 0)
											{
												if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_7bea;
												}
												if (num7 != 10)
												{
													num7++;
													Sleep(1.0);
													continue;
												}
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy chỗ điền phone (" + uid + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_7bea;
											}
											xuanAction.SendKey(driver, By.XPath("//input[@name='contact_point']"), span3, text5);
											Sleep(1.0);
											int num8 = 0;
											while (true)
											{
												if (driver.FindElements(By.XPath("//button[@name='action_set_contact_point']")).Count > 0)
												{
													if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_set_contact_point']"), span3))
													{
														break;
													}
													goto IL_604e;
												}
												if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													goto end_IL_7bea;
												}
												if (driver.FindElements(By.XPath("//input[@name='action_set_contact_point']")).Count > 0)
												{
													if (!xuanAction.ClickElement(driver, By.XPath("//input[@name='action_set_contact_point']"), span3))
													{
														goto IL_604e;
													}
													goto IL_60df;
												}
												if (num8 != 10)
												{
													goto IL_604e;
												}
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy nút tiếp tục phone (" + uid + ")";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_7bea;
											IL_604e:
												Sleep(1.0);
												num8++;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang check số (" + text5 + ")";
											Sleep(3.0);
											goto IL_6149;
										IL_60df:
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang check số (" + text5 + ")";
											Sleep(3.0);
											goto IL_6149;
										IL_6149:
											Sleep(5.0);
											if (driver.PageSource.Contains("Please try a different number.") || driver.PageSource.Contains("Vui lòng thử số khác."))
											{
												if (num2 == 3)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Số dùng quá nhiều (" + uid + ")";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												num2++;
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone mới (" + uid + ")";
												continue;
											}
											if (driver.PageSource.Contains("Không thể truy cập"))
											{
												driver.Navigate().Refresh();
												Sleep(5.0);
											}
											else
											{
												if (driver.PageSource.Contains("Bạn cần nhập số di động hợp lệ") || driver.PageSource.Contains("Please enter a valid email address or mobile number."))
												{
													if (num2 == 3)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Số dùng quá nhiều (" + uid + ")";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													num2++;
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone mới (" + uid + ")";
													continue;
												}
												if (driver.PageSource.Contains("Gần đây, số điện thoại bạn đang cố gắng xác minh đã được sử dụng để xác minh một tài khoản khác. Vui lòng thử số khác.") || driver.PageSource.Contains("The phone number you're trying to verify was recently used to verify a different account. Please try a different number.") || driver.PageSource.Contains("Số này đã được dùng để xác minh quá nhiều tài khoản trên Facebook. Hãy thử dùng số khác.") || driver.PageSource.Contains("This number has been used to verify too many accounts on Facebook. Please try a different number."))
												{
													if (num2 == 3)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Số dùng quá nhiều (" + uid + ")";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													num2++;
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone mới (" + uid + ")";
													continue;
												}
												if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
												{
													if (num2 == 3)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Số dùng quá nhiều (" + uid + ")";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													num2++;
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone mới (" + uid + ")";
													continue;
												}
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy OTP (" + text5 + ")...";
											switch (index_phone)
											{
												case 0:
													{
														for (int num9 = 0; num9 < limit_getcodephone; num9++)
														{
															text6 = tempcode.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 1:
													{
														for (int num17 = 0; num17 < limit_getcodephone; num17++)
														{
															text6 = otp.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 2:
													{
														for (int num31 = 0; num31 < limit_getcodephone; num31++)
														{
															text6 = codetext.Getcode(text_api_phone, text5);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 3:
													{
														for (int num21 = 0; num21 < limit_getcodephone; num21++)
														{
															text6 = sim.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 4:
													{
														for (int num13 = 0; num13 < limit_getcodephone; num13++)
														{
															text6 = viotp.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 5:
													{
														for (int num33 = 0; num33 < limit_getcodephone; num33++)
														{
															text6 = tempsms.Getcode(text_api_phone, text4);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 6:
													{
														for (int num29 = 0; num29 < limit_getcodephone; num29++)
														{
															text6 = chothuesimcode.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 7:
													{
														for (int num23 = 0; num23 < limit_getcodephone; num23++)
														{
															text6 = bossotp.Getcode(text4, text_api_phone);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 8:
													{
														for (int num19 = 0; num19 < limit_getcodephone; num19++)
														{
															text6 = testbossotp.Getcode(text7, text_api_phone);
															if (text6 == null || !(text6 != ""))
															{
																Sleep(1.0);
																continue;
															}
															if (!(text6 == "Get SMS TimeOut"))
															{
																break;
															}
															goto end_IL_7bea;
														}
														goto default;
													}
												case 9:
													{
														for (int num15 = 0; num15 < limit_getcodephone; num15++)
														{
															text6 = ndline.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 10:
													{
														for (int num11 = 0; num11 < limit_getcodephone; num11++)
														{
															text6 = trumotpvn.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 11:
													{
														for (int m = 0; m < limit_getcodephone; m++)
														{
															text6 = winmail.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 12:
													{
														for (int num32 = 0; num32 < limit_getcodephone; num32++)
														{
															text6 = hcotp.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 13:
													{
														for (int num30 = 0; num30 < limit_getcodephone; num30++)
														{
															text6 = sellotp.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 14:
													{
														for (int num28 = 0; num28 < limit_getcodephone; num28++)
														{
															text6 = suppersim.Getcode(text_api_phone, text7, text);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 15:
													{
														for (int num24 = 0; num24 < limit_getcodephone; num24++)
														{
															text6 = goodotp.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 16:
													{
														for (int num22 = 0; num22 < limit_getcodephone; num22++)
														{
															text6 = atmteam2.Getcode(text7, text_api_phone);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 17:
													{
														for (int num20 = 0; num20 < limit_getcodephone; num20++)
														{
															text6 = good9fun2.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 18:
													{
														for (int num18 = 0; num18 < limit_getcodephone; num18++)
														{
															text6 = otpngon.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 19:
													{
														for (int num16 = 0; num16 < limit_getcodephone; num16++)
														{
															text6 = fb.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 20:
													{
														for (int num14 = 0; num14 < limit_getcodephone; num14++)
														{
															text6 = numberotp.Getcode(text_api_phone, text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 21:
													{
														for (int num12 = 0; num12 < limit_getcodephone; num12++)
														{
															text6 = atmteam.Getcode(text7, text_api_phone);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 22:
													{
														for (int num10 = 0; num10 < limit_getcodephone; num10++)
														{
															text6 = sell282xyz.Getcode(text7, text_api_phone);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 23:
													{
														for (int n = 0; n < limit_getcodephone; n++)
														{
															text6 = sellotpvn.Getcode(text7, text_api_phone);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												case 24:
													{
														for (int l = 0; l < limit_getcodephone; l++)
														{
															text6 = otpygo.Getcode(text7);
															if (text6 != null && text6 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														goto default;
													}
												default:
													{
														int num25;
														switch (text6)
														{
															default:
																num25 = ((text6 == "TimeOut") ? 1 : 0);
																break;
															case "":
															case null:
															case "Get SMS TimeOut":
																num25 = 1;
																break;
														}
														if (num25 != 0)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Phone không về code (" + text5 + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															goto end_IL_7bea;
														}
														if (cbngonngu.Checked)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đổi lại ngôn ngữ US...";
															xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
															string cookieCurrentChrome2 = GetCookieCurrentChrome(driver);
															ChangeLanguageRequest_Cookie(cookieCurrentChrome2, "en_US");
														}
														if (xuanAction.Goto(driver, "https://m.facebook.com/", span))
														{
															int num26 = 0;
															while (true)
															{
																if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
																{
																	xuanAction.SendKey(driver, By.XPath("//input[@name='code']"), span3, text6);
																	Thread.Sleep(200);
																	int num27 = 0;
																	while (true)
																	{
																		if (driver.FindElements(By.XPath("//button[@name='action_submit_code']")).Count > 0)
																		{
																			xuanAction.ClickElement(driver, By.XPath("//button[@name='action_submit_code']"), span3);
																			break;
																		}
																		if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
																		{
																			dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
																			dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																			dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																			goto end_IL_7b3b;
																		}
																		if (num27 != 10)
																		{
																			Sleep(1.0);
																			num27++;
																			continue;
																		}
																		dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy nút tiếp tục code phone (" + uid + ")";
																		dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																		dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																		goto end_IL_7b3b;
																	}
																	goto end_IL_67f4;
																}
																if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
																{
																	dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
																	dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																	dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																	break;
																}
																if (num26 != 10)
																{
																	Sleep(1.0);
																	num26++;
																	continue;
																}
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy chỗ điền code phone (" + uid + ")";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																break;
																continue;
															end_IL_7b3b:
																break;
															}
														}
														else
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														}
														goto end_IL_7bea;
													}
												end_IL_67f4:
													break;
											}
											goto IL_7bfb;
											continue;
										end_IL_7bea:
											break;
										}
										break;
									IL_9bca:
										Sleep(1.0);
										goto IL_25ae;
									IL_a477:
										driver.Navigate().Refresh();
										Sleep(2.0);
										continue;
									IL_253b:
										xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span3);
										Sleep(1.0);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
										goto IL_25ae;
									IL_9b54:
										xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span3);
										Sleep(1.0);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
										goto IL_25ae;
									IL_a3a4:
										while (true)
										{
											empty = GetCookieCurrentChrome(driver);
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang giải captcha...";
											if (!driver.Url.Contains("mbasic.facebook"))
											{
												if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/", span))
												{
													break;
												}
												Sleep(1.0);
											}
											while (true)
											{
												string text36 = string.Empty;
												if (index_captcha == 0)
												{
													if (CaptchaService.Anycaptcha_Giai_normalcaptcha(empty, text_api_captcha, "https://mbasic.facebook.com/"))
													{
														goto IL_a316;
													}
													if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
													{
														break;
													}
													text36 = CaptchaService.Anycaptcha_Giai_recaptcha(text_api_captcha, "https://fbsbx.com/captcha/recaptcha/iframe/?referer=https://m.facebook.com", "6Lc9qjcUAAAAADTnJq5kJMjN9aD1lxpRLMnCS2TR");
													if (text36 == "")
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Giải captcha FB thất bại";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
												}
												else if (index_captcha == 1)
												{
													while (true)
													{
														string empty10 = string.Empty;
														while (true)
														{
															string pageSource = driver.PageSource;
															empty10 = omocaptcha.get_captcha_persist(pageSource);
															if (empty10 != "")
															{
																break;
															}
															Sleep(1.0);
														}
														text36 = CaptchaService.Omocaptcha_Giai_normalcaptcha(text_api_captcha, empty10);
														if (!(text36 == "Get new"))
														{
															break;
														}
														if (xuanAction.Goto(driver, "https://mbasic.facebook.com/", span))
														{
															Sleep(1.0);
															continue;
														}
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Giải captcha FB thất bại";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														goto end_IL_a349;
													}
												}
												else if (index_captcha == 2)
												{
													string value = Regex.Match(driver.PageSource, "captcha_persist_data\" value=\"(.*?)\"").Groups[1].Value;
													if (CaptchaService.Twocaptcha_Giai_normalcaptcha(text_api_captcha, empty, "https://mbasic.facebook.com/"))
													{
														goto IL_a316;
													}
													if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
													{
														break;
													}
													text36 = CaptchaService.Twocaptcha_Giai_recaptcha(text_api_captcha);
													if (text36 == "")
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Giải captcha FB thất bại";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
												}
												if (text36 != "")
												{
													if (index_captcha == 0 || index_captcha == 2)
													{
														driver.ExecuteScript("document.querySelector('#captcha_response').value=\"" + text36 + "\"");
														Thread.Sleep(1000);
														xuanAction.ClickElement(driver, By.Name("action_submit_bot_captcha_response"), span3);
														Sleep(4.0);
													}
													else if (index_captcha == 1)
													{
														driver.FindElement(By.XPath("//input[@id='captcha_response']")).SendKeys(text36);
														Thread.Sleep(500);
														xuanAction.ClickElement(driver, By.XPath("//input[@name='action_submit_bot_captcha_response']"), span3);
														Sleep(4.0);
														if (driver.FindElements(By.XPath("//input[@name='action_submit_bot_captcha_response']")).Count > 0)
														{
															xuanAction.ClickElement(driver, By.XPath("//input[@name='action_submit_bot_captcha_response']"), span3);
															Sleep(4.0);
														}
													}
													int num34 = CheckExistElements(driver, 10.0, "[name=\"contact_point\"]", "#mobile_image_data", "#captcha_response");
													if (driver.PageSource.Contains("Không thể truy cập trang web này") || driver.PageSource.Contains("We need more information") || driver.PageSource.Contains("Chúng tôi cần thêm thông tin"))
													{
														break;
													}
													if (num34 == 3)
													{
														continue;
													}
													if (num34 != 0)
													{
														Thread.Sleep(100);
													}
												}
												goto IL_a316;
											IL_a316:
												Thread.Sleep(10);
												if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/", span))
												{
													break;
												}
												goto IL_a357;
												continue;
											end_IL_a349:
												break;
											}
											break;
										IL_a357:
											if (driver.PageSource.Contains("captcha_persist_data"))
											{
												driver.Navigate().Refresh();
												Sleep(5.0);
												continue;
											}
											goto IL_2163;
										}
										break;
									IL_7bfb:
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang up ảnh...";
										num4 = 0;
										while (true)
										{
											if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
											{
												if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
												{
													empty = GetCookieCurrentChrome(driver);
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
												{
													empty = GetCookieCurrentChrome(driver);
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (check_live(uid))
												{
													empty = GetCookieCurrentChrome(driver);
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span2))
												{
													Sleep(1.0);
												}
												else if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count <= 0)
												{
													goto IL_9b27;
												}
											}
											else
											{
												if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
												{
													empty = GetCookieCurrentChrome(driver);
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
												{
													empty = GetCookieCurrentChrome(driver);
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (driver.PageSource.Contains("The confirmation code you entered is invalid or has expired. Please make sure you entered your confirmation code correctly."))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Code phone này bị lỗi (" + text5 + "|" + text6 + ")";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count <= 0)
												{
													if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													if (num4 == 10)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không tìm thấy chỗ up ảnh (" + uid + ")";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													goto IL_9b27;
												}
											}
											while (true)
											{
											IL_9b1b:
												int num35 = 0;
												while (true)
												{
													if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
													{
														switch (combo_image)
														{
															case "Ảnh đã lưu trong folder Image":
																lock (this.obj)
																{
																	string[] files = Directory.GetFiles(txt_folder_anh.Text);
																	if (files.Length != 0)
																	{
																		text2 = files[random.Next(0, files.Length - 1)];
																		break;
																	}
																}
																goto end_IL_9b0e;
															case "https://boredhumans.com/faces.php":
																lock (this.obj)
																{
																	while (!method_41(uid, text))
																	{
																		Sleep(1.0);
																	}
																	text2 = Path_Tool + "\\Image\\" + uid + ".png";
																}
																break;
															case "https://this-person-does-not-exist.com":
																lock (this.obj)
																{
																	while (!method_40(uid, ""))
																	{
																		Sleep(1.0);
																	}
																	text2 = Path_Tool + "\\Image\\" + uid + ".png";
																}
																break;
															case "https://www.unrealperson.com":
																lock (this.obj)
																{
																	while (!method_42(uid, text))
																	{
																		Sleep(1.0);
																	}
																	text2 = Path_Tool + "\\Image\\" + uid + ".png";
																}
																break;
															case "https://fakeface.rest":
																lock (this.obj)
																{
																	while (!method_43(uid))
																	{
																		Sleep(1.0);
																	}
																	text2 = Path_Tool + "\\Image\\" + uid + ".png";
																}
																break;
														}
														if (File.Exists(text2))
														{
															if (!(changeMD5(text2) == "") && changeMD5(text2) != null)
															{
																driver.FindElementByCssSelector("[type=\"file\"]").SendKeys(text2);
																Thread.Sleep(1000);
																while (true)
																{
																	if (driver.FindElements(By.XPath("//button[@name='action_upload_image']")).Count > 0)
																	{
																		xuanAction.ClickElement(driver, By.XPath("//button[@name='action_upload_image']"), span3);
																		Sleep(1.0);
																	}
																	else
																	{
																		if (driver.FindElements(By.XPath("//input[@name='action_upload_image']")).Count <= 0)
																		{
																			if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
																			{
																				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
																				dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																				dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																				break;
																			}
																			continue;
																		}
																		xuanAction.ClickElement(driver, By.XPath("//input[@name='action_upload_image']"), span3);
																		Sleep(1.0);
																	}
																	if (driver.FindElements(By.XPath("//input[@type='file']")).Count > 0)
																	{
																		dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Up ảnh không thành công(" + uid + ")";
																		dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																		dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																		break;
																	}
																	int num36 = 0;
																	while (true)
																	{
																		if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
																		{
																			if (combo_image == "Ảnh đã lưu trong folder Image" && File.Exists(text2))
																			{
																				File.Delete(text2);
																			}
																			string text37 = DateTime.Now.ToString();
																			empty = GetCookieCurrentChrome(driver);
																			dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Chờ xét duyệt (" + text37 + ")";
																			dataGridView2.Rows[i].Cells["ghichu"].Value = "Chờ set duyệt (" + text37 + ")";
																			dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Checkpoint 282";
																			dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
																			dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																		}
																		else
																		{
																			if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
																			{
																				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
																				dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																				dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																				break;
																			}
																			if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
																			{
																				empty = GetCookieCurrentChrome(driver);
																				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
																				dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
																				dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
																				dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
																			}
																			else
																			{
																				if (!driver.PageSource.Contains("You're back on Facebook") && !driver.PageSource.Contains("Bạn đã trở lại Facebook"))
																				{
																					Sleep(1.0);
																					num36++;
																					if (num36 == 20)
																					{
																						string text38 = DateTime.Now.ToString();
																						empty = GetCookieCurrentChrome(driver);
																						dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Chờ xét duyệt (" + text38 + ")";
																						dataGridView2.Rows[i].Cells["ghichu"].Value = "Chờ set duyệt (" + text38 + ")";
																						dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Checkpoint 282";
																						dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
																						dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																						break;
																					}
																					continue;
																				}
																				empty = GetCookieCurrentChrome(driver);
																				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
																				dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
																				dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
																				dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
																			}
																		}
																		if (cbgiuanh.Checked)
																		{
																			break;
																		}
																		try
																		{
																			if (File.Exists(text2))
																			{
																				File.Delete(text2);
																			}
																		}
																		catch (Exception)
																		{
																		}
																		break;
																	}
																	break;
																}
																break;
															}
															if (File.Exists(text2))
															{
																File.Delete(text2);
															}
														}
														goto IL_9b1b;
													}
													if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
													{
														xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3);
													}
													else
													{
														if (driver.FindElements(By.XPath("//button[@id='nuxChoosePhotoButton']")).Count > 0)
														{
															empty = GetCookieCurrentChrome(driver);
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
															dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
															break;
														}
														if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															break;
														}
														if (driver.FindElements(By.XPath("//button[@value='Back to Facebook']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Quay lại Facebook']")).Count > 0)
														{
															empty = GetCookieCurrentChrome(driver);
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
															dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
															break;
														}
														if (check_live(uid))
														{
															empty = GetCookieCurrentChrome(driver);
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
															dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
															break;
														}
														if (driver.PageSource.Contains("You're back on Facebook") || driver.PageSource.Contains("Bạn đã trở lại Facebook"))
														{
															empty = GetCookieCurrentChrome(driver);
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Unlock thành công (" + uid + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
															dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
															break;
														}
														if (driver.PageSource.Contains("Mã đó không hoạt động. Vui lòng kiểm tra mã và thử lại") || driver.PageSource.Contains("That code didn't work. Please check the code and try again."))
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Unlock không thành công (" + uid + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															break;
														}
														if (num35 == 15)
														{
															dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Unlock không thành công (" + uid + ")";
															dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
															dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
															break;
														}
													}
													Sleep(1.0);
													num35++;
													continue;
												end_IL_9b0e:
													break;
												}
												break;
											}
											break;
										IL_9b27:
											Sleep(1.0);
											num4++;
										}
										break;
									IL_24c8:
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
										xuanAction.ClickElement(driver, By.XPath("//button[@name='action_unset_contact_point']"), span3);
										Sleep(1.0);
										goto IL_25ae;
									IL_2163:
										Sleep(1.0);
										while (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count <= 0)
										{
											if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
											{
												goto IL_24c8;
											}
											if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
											{
												goto IL_253b;
											}
											if (driver.FindElements(By.XPath("//button[@name='action_proceed']")).Count > 0)
											{
												if (!xuanAction.ClickElement(driver, By.XPath("//button[@name='action_proceed']"), span3))
												{
													continue;
												}
												goto IL_9bca;
											}
											if (driver.FindElements(By.XPath("//div[@aria-label='Close']")).Count > 0 || driver.Url.Contains("actor_experience"))
											{
												xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
												continue;
											}
											if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												goto end_IL_a49a;
											}
											if (driver.FindElements(By.XPath("//input[@name='contact_point_index']")).Count <= 0)
											{
												if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count <= 0)
												{
													continue;
												}
												goto IL_7bfb;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Facebook gửi otp về sdt cũ";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_a49a;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
										goto IL_25ae;
									IL_a3b5:
										xuanAction.ClickElement(driver, By.XPath("//input[@name='action_unset_contact_point']"), span3);
										Sleep(1.0);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy phone của " + combophone.Text;
										goto IL_25ae;
										continue;
									end_IL_a49a:
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
				}
			end_IL_0055:;
			}
			catch (Exception ex2)
			{
				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   (" + ex2.Message + ")";
				dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
				dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
			}
			UpdateData(i);
			if (driver != null)
			{
				driver.Quit();
			}
			dataGridView2.Rows[i].Cells["chon"].Value = false;
			if (!cbaddview.Checked)
			{
				return;
			}
			try
			{
				Invoke((Action)delegate
				{
					flowLayoutPanel1.Controls.Remove(ptn2);
				});
			}
			catch
			{
			}
		}

		[Obsolete]
		private void login_uid_pass(int index_chrome, int i, string uid, string pass, string ma2fa, string text, string emailclone, string passmailclone)
		{
			int num = 0;
			IntPtr handle = IntPtr.Zero;
			Random random = new Random();
			Panel ptn2 = new Panel();
			Label name = new Label();
			string ip = string.Empty;
			ChromeDriver driver = null;
			try
			{
				string text2 = manguser_agent[random.Next(0, manguser_agent.Length)];
				dataGridView2.Rows[i].Cells["useragent"].Value = text2;
				Point pointFromIndexPosition = GetPointFromIndexPosition(index_chrome, Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				Point sizeChrome = GetSizeChrome(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				ip = text.Split(':')[0];
				XuanAction xuanAction = new XuanAction();
				TimeSpan span = new TimeSpan(0, 2, 0);
				TimeSpan span2 = new TimeSpan(0, 2, 0);
				TimeSpan span3 = new TimeSpan(0, 0, 30);
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
				chromeDriverService.HideCommandPromptWindow = true;
				ChromeOptions chromeOptions = new ChromeOptions();
				chromeOptions.AddArgument("--app=https://m.facebook.com/");
				if (text != "" && text.Split(':').Length == 2)
				{
					chromeOptions.AddArgument("--proxy-server= " + text);
				}
				else if (text != "" && text.Split(':').Length == 4)
				{
					chromeOptions.AddHttpProxy(text.Split(':')[0], int.Parse(text.Split(':')[1]), text.Split(':')[2], text.Split(':')[3]);
				}
				chromeOptions.AddArguments("--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--window-size=" + sizeChrome.X + "," + sizeChrome.Y, "--window-position=" + pointFromIndexPosition.X + "," + pointFromIndexPosition.Y, "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=BlockCredentialedSubresources", "--disable-popup-blocking");
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 0);
				chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
				chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
				chromeOptions.AddExcludedArgument("enable-automation");
				chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
				chromeOptions.AddArgument("user-agent=" + text2);
				Sleep(Convert.ToInt32(numericUpDown7.Value));
				driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3.0));
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(6.0);
				if (!cbaddview.Checked)
				{
					goto IL_0519;
				}
				try
				{
					num = chromeDriverService.ProcessId;
					Process windowHandleByDriverId = GetWindowHandleByDriverId(num);
					handle = windowHandleByDriverId.MainWindowHandle;
					Thread.Sleep(1000);
				}
				catch
				{
					goto end_IL_0049;
				}
				if (num != 0)
				{
					Sleep(1.0);
					lock (this.obj)
					{
						try
						{
							flowLayoutPanel1.Invoke((Action)delegate
							{
								ptn2.Width = 280;
								ptn2.Height = 300;
								ptn2.BorderStyle = BorderStyle.FixedSingle;
								ptn2.AutoScroll = true;
								ptn2.SetAutoScrollMargin(320, 480);
								name.Text = "IP:" + ip;
								name.Location = new Point(0, 0);
								ptn2.Controls.Add(name);
								Invoke((Action)delegate
								{
									flowLayoutPanel1.Controls.Add(ptn2);
								});
								SetParent(handle, ptn2.Handle);
								SetWindowLong(handle, -4, WS_VISIBLE);
								MoveWindow(handle, -8, -36, 320, 480, Repaint: true);
								driver.Manage().Window.Position = new Point(0, 15);
							});
							Thread.Sleep(500);
						}
						catch
						{
							goto end_IL_0049;
						}
					}
					goto IL_0519;
				}
				goto end_IL_0049;
			IL_0519:
				Sleep(2.0);
				if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				else
				{
					string empty = string.Empty;
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập bằng uid|pass...";
					string text3 = string.Empty;
					while (driver.FindElements(By.XPath("//button[@name='login']")).Count <= 0 && driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count <= 0)
					{
					}
					while (!xuanAction.SendKey(driver, By.XPath("//input[@name='email']"), span2, uid))
					{
					}
					while (!xuanAction.SendKey(driver, By.XPath("//input[@name='pass']"), span2, pass))
					{
					}
					while (true)
					{
						if (driver.FindElements(By.XPath("//button[@name='login']")).Count > 0)
						{
							xuanAction.ClickElement(driver, By.XPath("//button[@name='login']"), span2);
							Sleep(2.0);
							break;
						}
						if (driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count > 0)
						{
							xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']"), span2);
							Sleep(2.0);
							break;
						}
					}
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Kiểm tra trạng thái đăng nhập...";
					Sleep(3.0);
					while (true)
					{
						if (driver.FindElements(By.XPath("//span[contains(text(),'Ok')]")).Count > 0)
						{
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
							dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
							dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
							xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'Ok')]"), span2);
							Sleep(1.0);
						}
						else
						{
							if (driver.FindElements(By.XPath("//input[@id='approvals_code']")).Count > 0)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Nhập 2fa...";
								string text4;
								do
								{
									byte[] secretKey = Base32Encoding.ToBytes(ma2fa);
									Totp totp = new Totp(secretKey);
									text4 = totp.ComputeTotp();
								}
								while (!(text4 != ""));
								xuanAction.SendKey(driver, By.XPath("//input[@id='approvals_code']"), span3, text4);
								do
								{
									xuanAction.ClickElement(driver, By.XPath("//button[@id='checkpointSubmitButton-actual-button']"), span3);
									Sleep(1.0);
								}
								while (driver.FindElements(By.XPath("//button[@id='checkpointSubmitButton-actual-button']")).Count != 0);
							}
							if (driver.FindElements(By.XPath("//div[@aria-label='Close']")).Count > 0 || driver.Url.Contains("actor_experience"))
							{
								xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
								if (!check_live(uid))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
							}
							else
							{
								if (driver.FindElements(By.XPath("//a[@id='nux-nav-button']")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//a[@id='nux-nav-button']"), span2);
									Sleep(1.0);
								}
								if (driver.FindElements(By.XPath("//button[@id='nux-nav-button']")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//button[@id='nux-nav-button']"), span3);
									Sleep(2.0);
									xuanAction.ClickElement(driver, By.XPath("//a[@id='qf_skip_dialog_skip_link']"), span3);
									Sleep(1.0);
									goto IL_537d;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (driver.Url.Contains("checkpoint"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (driver.Url.Contains("login/save-device"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")Đăng nhập thành công!";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
									xuanAction.Goto(driver, "https://m.facebook.com/", span);
									Sleep(1.0);
								}
								else if (driver.FindElements(By.XPath("//a[@name='News Feed']")).Count > 0)
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")Đăng nhập thành công!";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
									Sleep(1.0);
								}
								else
								{
									if (driver.FindElements(By.XPath("//div[@id='login_error']")).Count > 0)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tên người dùng hoặc mật khẩu không hợp lệ ";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.FindElements(By.XPath("//div[@data-sigil='messenger_icon']")).Count > 5)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										Sleep(1.0);
									}
									else if (driver.PageSource.Contains("menu/bookmarks"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										Sleep(1.0);
									}
									else
									{
										if (driver.FindElements(By.XPath("//div[contains(text(),'Photo')]")).Count <= 0)
										{
											if (driver.PageSource.Contains("We've suspended your account"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											goto IL_537d;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập thành công!";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										Sleep(1.0);
									}
								}
							}
						}
						if (cbngonngu.Checked)
						{
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đổi ngôn ngữ...";
							Sleep(1.0);
							if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/language.php", span))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Lỗi đổi ngôn ngữ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (!xuanAction.ClickElement(driver, By.XPath("//input[@value='English (US)']"), span3))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Lỗi đổi ngôn ngữ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							Sleep(2.0);
						}
						if (cb2fa.Checked)
						{
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang bật 2fa...";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/security/2fac/settings/", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							int num2 = 0;
							while (true)
							{
								if (driver.FindElements(By.XPath("//span[contains(text(),'Use authentication app')]")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'Use authentication app')]"), span2);
								}
								else if (driver.FindElements(By.XPath("//span[contains(text(),'Use Authentication App')]")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'Use Authentication App')]"), span2);
								}
								else if (driver.FindElements(By.XPath("//span[contains(text(),'Dùng ứng dụng xác thực')]")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'Dùng ứng dụng xác thực')]"), span2);
								}
								else if (driver.FindElements(By.XPath("//span[contains(text(),'dùng ứng dụng xác thực')]")).Count > 0)
								{
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'dùng ứng dụng xác thực')]"), span2);
								}
								else
								{
									if (driver.FindElements(By.XPath("//span[contains(text(),'use authentication app')]")).Count <= 0)
									{
										if (driver.FindElements(By.XPath("//input[@name='pass']")).Count > 0)
										{
											xuanAction.SendKey(driver, By.XPath("//input[@name='pass']"), span3, pass);
											Thread.Sleep(10);
											xuanAction.ClickElement(driver, By.XPath("//button[@name='save']"), span3);
											Thread.Sleep(200);
										}
										else if (driver.PageSource.Contains("You can’t manage your security settings now") || driver.PageSource.Contains("Bạn không thể quản lý cài đặt bảo mật của mình ngay bây giờ") || num2 == 10)
										{
											break;
										}
										num2++;
										Sleep(1.0);
										continue;
									}
									xuanAction.ClickElement(driver, By.XPath("//span[contains(text(),'use authentication app')]"), span2);
								}
								while (true)
								{
									if (driver.FindElements(By.XPath("//input[@name='confirmButton']")).Count > 0)
									{
										while (text3 == "")
										{
											text3 = Regex.Match(driver.PageSource, "data-testid=\"key\">(.*?)<").Groups[1].Value;
											if (text3 != "")
											{
												text3 = text3.Replace(" ", "");
											}
											else if (text3 == "")
											{
												text3 = Regex.Match(driver.PageSource, "secret=(.*?)&").Groups[1].Value.Replace(" ", "");
											}
											Thread.Sleep(500);
										}
										while (driver.FindElements(By.XPath("//input[@name='confirmButton']")).Count <= 0)
										{
										}
										xuanAction.ClickElement(driver, By.XPath("//input[@name='confirmButton']"), span2);
										Sleep(1.0);
										byte[] secretKey2 = Base32Encoding.ToBytes(text3);
										Totp totp2 = new Totp(secretKey2);
										string text5;
										while (true)
										{
											text5 = totp2.ComputeTotp();
											if (text5 != "")
											{
												break;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Lỗi bật 2fa...";
										}
										Thread.Sleep(500);
										while (true)
										{
											if (driver.FindElements(By.XPath("//input[@name='code']")).Count > 0)
											{
												xuanAction.SendKey(driver, By.XPath("//input[@name='code']"), span2, text5);
												Sleep(1.0);
												while (driver.FindElements(By.XPath("//input[@id='submit_code_button']")).Count <= 0)
												{
												}
												xuanAction.ClickElement(driver, By.XPath("//input[@id='submit_code_button']"), span2);
												Sleep(1.0);
												while (true)
												{
													if (driver.PageSource.Contains("Xác thực 2 yếu tố đang bật") || driver.PageSource.Contains("Two-factor authentication is on"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Thành công bật 2fa...";
														dataGridView2.Rows[i].Cells["ma2fa"].Value = text3;
														UpdateData(i);
														goto end_IL_28e7;
													}
													if (driver.FindElements(By.XPath("//button[@value='Done']")).Count > 0 || driver.FindElements(By.XPath("//button[@value='Xong']")).Count > 0)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Thành công bật 2fa...";
														dataGridView2.Rows[i].Cells["ma2fa"].Value = text3;
														UpdateData(i);
														goto end_IL_28e7;
													}
													if (driver.PageSource.Contains("We've suspended your account"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
														break;
													}
													if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
														break;
													}
													if (!driver.Url.Contains("checkpoint"))
													{
														continue;
													}
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
													break;
												}
												break;
											}
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.PageSource.Contains("We've suspended your account"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (!driver.Url.Contains("checkpoint"))
											{
												continue;
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										break;
									}
									if (driver.PageSource.Contains("You can’t manage your security settings now") || driver.PageSource.Contains("Bạn không thể quản lý cài đặt bảo mật của mình ngay bây giờ"))
									{
										goto end_IL_28e7;
									}
									if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.PageSource.Contains("We've suspended your account"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (!driver.Url.Contains("checkpoint"))
									{
										if (driver.FindElements(By.XPath("//input[@name='pass']")).Count > 0)
										{
											Thread.Sleep(200);
											driver.FindElement(By.XPath("//input[@name='pass']")).SendKeys(pass);
											Thread.Sleep(100);
											while (true)
											{
												if (driver.FindElements(By.XPath("//button[@name='save']")).Count > 0)
												{
													xuanAction.ClickElement(driver, By.XPath("//button[@name='save']"), span2);
													break;
												}
												if (driver.FindElements(By.XPath("//input[@name='save']")).Count > 0)
												{
													xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span2);
													break;
												}
											}
										}
										else if (driver.PageSource.Contains("You can’t manage your security settings now") || driver.PageSource.Contains("Bạn hiện chưa thể quản lý cài đặt bảo mật"))
										{
											goto end_IL_28e7;
										}
										continue;
									}
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								goto end_IL_53a0;
								continue;
							end_IL_28e7:
								break;
							}
						}
						if (cbquequan.Checked)
						{
							string text6 = randominfo("quequan.txt");
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm quê quán (" + text6 + ") ";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/editprofile.php?type=basic&edit=hometown", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							while (true)
							{
								if (driver.FindElements(By.XPath("//input[@name='hometown[]']")).Count > 0)
								{
									xuanAction.SendKey(driver, By.XPath("//input[@name='hometown[]']"), span3, text6);
									Sleep(1.0);
									xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span3);
									Sleep(1.0);
									if (driver.FindElements(By.XPath("//input[@name='save']")).Count > 0)
									{
										xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span3);
										Sleep(1.0);
									}
									if (!cbnoisong.Checked)
									{
										break;
									}
									string text7 = randominfo("noisong.txt");
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm nơi sống (" + text6 + ") ";
									xuanAction.Goto(driver, "https://mbasic.facebook.com/editprofile.php?type=basic&edit=current_city", span);
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@name='current_city[]']")).Count > 0)
										{
											xuanAction.SendKey(driver, By.XPath("//input[@name='current_city[]']"), span3, text7);
											Sleep(1.0);
											xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span3);
											Sleep(1.0);
											if (driver.FindElements(By.XPath("//input[@name='save']")).Count > 0)
											{
												xuanAction.ClickElement(driver, By.XPath("//input[@name='save']"), span3);
												Sleep(1.0);
											}
											break;
										}
										if (driver.PageSource.Contains("We've suspended your account"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (!driver.Url.Contains("checkpoint"))
										{
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										goto end_IL_53a0;
									}
									break;
								}
								if (driver.PageSource.Contains("We've suspended your account"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (!driver.Url.Contains("checkpoint"))
								{
									continue;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								goto end_IL_53a0;
							}
						}
						if (cbnghenghiep.Checked)
						{
							string text8 = randominfo("work.txt");
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm nghề nghiệp (" + text8 + ") ";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/me", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							empty = GetCookieCurrentChrome(driver);
							Request request = new Request(empty, "", text);
							request.AddHeader("referer", "https://mbasic.facebook.com/editprofile/eduwork/add/?type=958371&refid=17&paipv=0");
							string text9 = request.RequestGet("https://mbasic.facebook.com/editprofile/eduwork/add/?type=958371&refid=17&paipv=0");
							string url = request.Uri().Replace("m.facebook.com", "mbasic.facebook.com");
							string input = request.RequestGet(url);
							string url2 = "https://mbasic.facebook.com/profile/edit/exp/work/" + Regex.Match(input, "action=\"/profile/edit/exp/work/(.*?)\"").Groups[1].Value.Replace("amp;", "");
							string value = Regex.Match(input, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
							string value2 = Regex.Match(input, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
							string text10 = "fb_dtsg=" + value2 + "&jazoest=" + value + "&query=" + text8;
							string input2 = request.RequestPost(url2, text10);
							MatchCollection matchCollection = Regex.Matches(input2, "profile picture(.*?)href=\"(.*?)\"");
							if (matchCollection.Count > 0)
							{
								string url3 = "https://mbasic.facebook.com/" + matchCollection[random.Next(0, matchCollection.Count)].Groups[2].Value.Replace("amp;", "");
								string input3 = request.RequestGet(url3);
								value = Regex.Match(input3, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
								value2 = Regex.Match(input3, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
								string url4 = "https://mbasic.facebook.com/editprofile" + Regex.Match(input3, "action=\"/editprofile(.*?)\"").Groups[1].Value.Replace("amp;", "");
								string text11 = "fb_dtsg=" + value2 + "&jazoest=" + value + "&position=&start_month=1&start_day=21&start_year=2023&current=on&end_month=-1&end_day=-1&end_year=-1";
								string text12 = request.RequestPost(url4, text11);
							}
							xuanAction.Goto(driver, "https://mbasic.facebook.com/me", span);
						}
						if (cbavatar.Checked)
						{
							string path = txt_avatar.Text;
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang cập nhật ảnh đại diện...";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/profile_picture", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							while (true)
							{
								if (driver.FindElements(By.XPath("//input[@type='file']")).Count > 0)
								{
									string[] files = Directory.GetFiles(path);
									string text13 = files[random.Next(0, files.Length)];
									driver.FindElementByCssSelector("[type=\"file\"]").SendKeys(text13);
									Thread.Sleep(1000);
									int num3 = 0;
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@type='submit']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//input[@type='submit']"), span3);
											Sleep(1.0);
											break;
										}
										if (driver.PageSource.Contains("We've suspended your account"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (driver.Url.Contains("checkpoint"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (num3 != 10)
										{
											num3++;
											Sleep(1.0);
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không cập nhật được avatar";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Error";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Yellow;
										goto end_IL_53a0;
									}
									break;
								}
								if (driver.PageSource.Contains("We've suspended your account"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (!driver.Url.Contains("checkpoint"))
								{
									continue;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								goto end_IL_53a0;
							}
						}
						if (cbcover.Checked)
						{
							string path2 = txt_cover.Text;
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang cập nhật ảnh bìa...";
							xuanAction.Goto(driver, "https://mbasic.facebook.com/photos/upload/?cover_photo", span);
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.PageSource.Contains("We've suspended your account"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							if (driver.Url.Contains("checkpoint"))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							while (true)
							{
								if (driver.FindElements(By.XPath("//input[@type='file']")).Count > 0)
								{
									string[] files2 = Directory.GetFiles(path2);
									string text14 = files2[random.Next(0, files2.Length)];
									driver.FindElementByCssSelector("[type=\"file\"]").SendKeys(text14);
									Thread.Sleep(1000);
									int num4 = 0;
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@type='submit']")).Count > 0)
										{
											xuanAction.ClickElement(driver, By.XPath("//input[@type='submit']"), span3);
											Sleep(1.0);
											break;
										}
										if (driver.PageSource.Contains("We've suspended your account"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (driver.Url.Contains("checkpoint"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											goto end_IL_53a0;
										}
										if (num4 != 10)
										{
											num4++;
											Sleep(1.0);
											continue;
										}
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không cập nhật được ảnh bìa";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Error";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Yellow;
										goto end_IL_53a0;
									}
									break;
								}
								if (driver.PageSource.Contains("We've suspended your account"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									goto end_IL_53a0;
								}
								if (!driver.Url.Contains("checkpoint"))
								{
									continue;
								}
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint ";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								goto end_IL_53a0;
							}
						}
						if (cbgetcookiemoi.Checked)
						{
							empty = GetCookieCurrentChrome(driver);
							dataGridView2.Rows[i].Cells["cookieclone"].Value = empty;
						}
						dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Đã cập nhật info thành công uid (" + uid + ")";
						empty = dataGridView2.Rows[i].Cells["cookieclone"].Value.ToString();
						lock (this.obj)
						{
							File.AppendAllText("Account_Full_Info\\live.txt", uid + "|" + pass + "|" + text3 + "|" + empty + "|" + emailclone + "|" + passmailclone + "\n");
						}
						break;
					IL_537d:
						driver.Navigate().Refresh();
						Sleep(2.0);
						continue;
					end_IL_53a0:
						break;
					}
				}
			end_IL_0049:;
			}
			catch
			{
			}
			UpdateData(i);
			if (driver != null)
			{
				driver.Quit();
			}
			dataGridView2.Rows[i].Cells["chon"].Value = false;
			if (!cbaddview.Checked)
			{
				return;
			}
			try
			{
				Invoke((Action)delegate
				{
					flowLayoutPanel1.Controls.Remove(ptn2);
				});
			}
			catch
			{
			}
		}

		[Obsolete]
		private void verify_uid_pass(int index_chrome, int i, string uid, string pass, string text, string ngonngu, string type_mail)
		{
			IntPtr handle = IntPtr.Zero;
			int num = 0;
			Random random = new Random();
			Panel ptn2 = new Panel();
			Label name = new Label();
			string ip = string.Empty;
			Mailtm mailtm = new Mailtm();
			string text2 = string.Empty;
			Hotmailbox hotmailbox = new Hotmailbox();
			ChromeDriver driver = null;
			ip = text.Split(':')[0];
			try
			{
				string text3 = string.Empty;
				string text4 = string.Empty;
				string text5 = string.Empty;
				string text6 = string.Empty;
				string empty = string.Empty;
				string empty2 = string.Empty;
				string result = string.Empty;
				if (type_mail == "Mailtm")
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang tạo mailtm";
					while (true)
					{
						empty = mailtm.getdomains();
						if (empty != "" && empty != null)
						{
							break;
						}
						Sleep(1.0);
					}
					text3 = Getrandomemail() + "@" + empty;
					text6 = Getrandompassmailtm();
					if (mailtm.Create_Mailtm(text3, text6, text))
					{
						goto IL_032f;
					}
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Get mailtm thất bại, chạy lại là được";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				else
				{
					if (!(type_mail == "Hotmail"))
					{
						goto IL_032f;
					}
					emailQueue.TryDequeue(out result);
					if (result != null)
					{
						empty2 = result;
						string[] array = result.Split('|');
						text4 = array[0];
						text5 = array[1];
						File.AppendAllText("Data_Reg\\email_runned.txt", result + "\n");
						Invoke((Action)delegate
						{
							linkLabel10.Text = "[ " + emailQueue.Count + " ]";
						});
						goto IL_032f;
					}
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Hết hotmail! Vui lòng nạp thêm";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				goto end_IL_0077;
			IL_032f:
				string text7 = dataGridView2.Rows[i].Cells["useragent"].Value.ToString();
				if (text7 == "" || text7 == null)
				{
					text7 = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36";
				}
				string empty3 = string.Empty;
				Point pointFromIndexPosition = GetPointFromIndexPosition(index_chrome, Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				Point sizeChrome = GetSizeChrome(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				XuanAction xuanAction = new XuanAction();
				TimeSpan span = new TimeSpan(0, 2, 0);
				TimeSpan span2 = new TimeSpan(0, 2, 0);
				TimeSpan span3 = new TimeSpan(0, 0, 30);
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
				chromeDriverService.HideCommandPromptWindow = true;
				ChromeOptions chromeOptions = new ChromeOptions();
				chromeOptions.AddArgument("--app=https://m.facebook.com/");
				if (text != "" && text.Split(':').Length == 2)
				{
					chromeOptions.AddArgument("--proxy-server= " + text);
				}
				else if (text != "" && text.Split(':').Length == 4)
				{
					chromeOptions.AddHttpProxy(text.Split(':')[0], int.Parse(text.Split(':')[1]), text.Split(':')[2], text.Split(':')[3]);
				}
				chromeOptions.AddArguments("--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--window-size=" + sizeChrome.X + "," + sizeChrome.Y, "--window-position=" + pointFromIndexPosition.X + "," + pointFromIndexPosition.Y, "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=BlockCredentialedSubresources", "--disable-popup-blocking");
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 0);
				chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
				chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
				chromeOptions.AddExcludedArgument("enable-automation");
				chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
				chromeOptions.AddArgument("user-agent=" + text7);
				Sleep(Convert.ToInt32(numericUpDown7.Value));
				driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3.0));
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(6.0);
				if (!cbaddview.Checked)
				{
					goto IL_07e5;
				}
				try
				{
					num = chromeDriverService.ProcessId;
					Process windowHandleByDriverId = GetWindowHandleByDriverId(num);
					handle = windowHandleByDriverId.MainWindowHandle;
					Thread.Sleep(1000);
				}
				catch
				{
					goto end_IL_0077;
				}
				if (num != 0)
				{
					Sleep(1.0);
					lock (this.obj)
					{
						Invoke((Action)delegate
						{
							ptn2.Width = 280;
							ptn2.Height = 300;
							ptn2.BorderStyle = BorderStyle.FixedSingle;
							ptn2.AutoScroll = true;
							ptn2.SetAutoScrollMargin(320, 480);
							name.Text = "IP:" + ip;
							name.Location = new Point(0, 0);
							ptn2.Controls.Add(name);
							Invoke((Action)delegate
							{
								flowLayoutPanel1.Controls.Add(ptn2);
							});
							SetParent(handle, ptn2.Handle);
							SetWindowLong(handle, -4, WS_VISIBLE);
							MoveWindow(handle, -8, -36, 320, 480, Repaint: true);
							driver.Manage().Window.Position = new Point(0, 15);
						});
					}
					goto IL_07e5;
				}
				goto end_IL_0077;
			IL_07e5:
				Sleep(2.0);
				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập bằng uid|pass...";
				if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				else
				{
					string empty4 = string.Empty;
					string empty5 = string.Empty;
					int num2 = 0;
					while (true)
					{
						if (driver.FindElements(By.XPath("//button[@name='login']")).Count <= 0 && driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count <= 0)
						{
							if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
							{
								driver.Navigate().Refresh();
								Sleep(1.0);
							}
							if (num2 == 15)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							num2++;
							continue;
						}
						while (true)
						{
							if (!xuanAction.SendKey(driver, By.XPath("//input[@name='email']"), span2, uid))
							{
								if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								continue;
							}
							while (true)
							{
								if (!xuanAction.SendKey(driver, By.XPath("//input[@name='pass']"), span2, pass))
								{
									if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									continue;
								}
								while (true)
								{
									if (driver.FindElements(By.XPath("//button[@name='login']")).Count > 0)
									{
										xuanAction.ClickElement(driver, By.XPath("//button[@name='login']"), span2);
										Sleep(2.0);
									}
									else
									{
										if (driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count <= 0)
										{
											if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											continue;
										}
										xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']"), span2);
										Sleep(2.0);
									}
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Kiểm tra trạng thái đăng nhập...";
									Sleep(3.0);
									while (true)
									{
										if (driver.FindElements(By.XPath("//span[contains(text(),'Ok')]")).Count > 0)
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
											break;
										}
										if (driver.FindElements(By.XPath("//input[@name='c']")).Count <= 0)
										{
											if (driver.FindElements(By.XPath("//input[@id='approvals_code']")).Count > 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản có 2fa";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Error";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Yellow;
												break;
											}
											if (driver.PageSource.Contains("captcha_persist_data"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.Url.Contains("disabled"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Vô phương cứu chữa";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.FindElements(By.XPath("//div[@aria-label='Close']")).Count > 0 || driver.Url.Contains("actor_experience"))
											{
												xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
											}
											if (driver.FindElements(By.XPath("//a[@id='nux-nav-button']")).Count > 0)
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
												break;
											}
											if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282 chờ xét duyệt";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (!driver.Url.Contains("login/save-device"))
											{
												if (driver.FindElements(By.XPath("//a[@name='News Feed']")).Count > 0)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (driver.FindElements(By.XPath("//div[@id='login_error']")).Count > 0)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tên người dùng hoặc mật khẩu không hợp lệ ";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												if (driver.FindElements(By.XPath("//div[@data-sigil='messenger_icon']")).Count > 5)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (driver.FindElements(By.XPath("//div[contains(text(),'Photo')]")).Count > 0)
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (driver.PageSource.Contains("We've suspended your account"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												driver.Navigate().Refresh();
												Sleep(2.0);
												continue;
											}
											xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
										}
										empty3 = GetCookieCurrentChrome(driver);
										dataGridView2.Rows[i].Cells["cookieclone"].Value = empty3;
										UpdateData(i);
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm mail...";
										if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/changeemail", span))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										while (true)
										{
											if (driver.FindElements(By.XPath("//input[@name='new']")).Count > 0)
											{
												if (type_mail == "Mailtm")
												{
													xuanAction.SendKey(driver, By.XPath("//input[@name='new']"), span3, text3);
												}
												else if (type_mail == "Hotmail")
												{
													xuanAction.SendKey(driver, By.XPath("//input[@name='new']"), span3, text4);
												}
												xuanAction.ClickElement(driver, By.XPath("//input[@name='submit']"), span3);
												while (true)
												{
													if (driver.FindElements(By.XPath("//input[@name='c']")).Count > 0)
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy OTP mail...";
														if (type_mail == "Mailtm")
														{
															while (true)
															{
																text2 = mailtm.GetCodeMailTm(text3, text6, text);
																if (text2 != "")
																{
																	break;
																}
																Sleep(1.0);
															}
														}
														else if (type_mail == "Hotmail")
														{
															while (true)
															{
																text2 = hotmailbox.Getcode(text4, text5);
																if (text2 != "")
																{
																	break;
																}
																Sleep(1.0);
															}
														}
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang xác minh OTP " + text2;
														xuanAction.SendKey(driver, By.XPath("//input[@name='c']"), span3, text2);
														while (driver.FindElements(By.XPath("//input[@name='submit[confirm]']")).Count <= 0)
														{
														}
														xuanAction.ClickElement(driver, By.XPath("//input[@name='submit[confirm]']"), span3);
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Kiểm tra trạng thái...";
														while (true)
														{
															if (driver.Url.Contains("gettingstarted"))
															{
																if (type_mail == "Mailtm")
																{
																	dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Xác minh thành công mailtm " + uid + "(" + text3 + ")";
																	dataGridView2.Rows[i].Cells["emailclone"].Value = text3;
																	dataGridView2.Rows[i].Cells["passmailclone"].Value = text6;
																}
																else if (type_mail == "Hotmail")
																{
																	dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Xác minh thành công hotmail " + uid + "(" + text4 + ")";
																	dataGridView2.Rows[i].Cells["emailclone"].Value = text4;
																	dataGridView2.Rows[i].Cells["passmailclone"].Value = text5;
																}
																empty3 = GetCookieCurrentChrome(driver);
																dataGridView2.Rows[i].Cells["cookieclone"].Value = empty3;
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
																break;
															}
															if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																break;
															}
															if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																break;
															}
															if (driver.Url.Contains("disabled"))
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Vô phương cứu chữa";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																break;
															}
															if (!driver.Url.Contains("gettingstarted") && driver.Url.Contains("checkpoint") && !driver.Url.Contains("282"))
															{
																dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint";
																dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
																dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
																break;
															}
														}
														break;
													}
													if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
													if (driver.Url.Contains("disabled"))
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Vô phương cứu chữa";
														dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
														dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
														break;
													}
												}
												break;
											}
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
											if (driver.Url.Contains("disabled"))
											{
												dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Vô phương cứu chữa";
												dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
												dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
												break;
											}
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
				}
			end_IL_0077:;
			}
			catch (Exception ex)
			{
				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   (" + ex.Message + ")";
				dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
				dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
			}
			UpdateData(i);
			if (driver != null)
			{
				driver.Quit();
			}
			dataGridView2.Rows[i].Cells["chon"].Value = false;
			if (!cbaddview.Checked)
			{
				return;
			}
			try
			{
				Invoke((Action)delegate
				{
					flowLayoutPanel1.Controls.Remove(ptn2);
				});
			}
			catch
			{
			}
		}

		[Obsolete]
		private void verify_cookie(int index_chrome, int i, string uid, string pass, string cookieclone, string text, string ngonngu, string type_mail)
		{
			IntPtr handle = IntPtr.Zero;
			int num = 0;
			Random random = new Random();
			Panel ptn2 = new Panel();
			Label name = new Label();
			string ip = string.Empty;
			Mailtm mailtm = new Mailtm();
			string text2 = string.Empty;
			Mail mail = new Mail();
			ChromeDriver driver = null;
			ip = text.Split(':')[0];
			try
			{
				string text3 = string.Empty;
				string text4 = string.Empty;
				string text5 = string.Empty;
				string text6 = string.Empty;
				string empty = string.Empty;
				string empty2 = string.Empty;
				string result = string.Empty;
				if (type_mail == "Mailtm")
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang tạo mailtm";
					while (true)
					{
						empty = mailtm.getdomains();
						if (empty != "" && empty != null)
						{
							break;
						}
						Sleep(1.0);
					}
					text3 = Getrandomemail() + "@" + empty;
					text6 = Getrandompassmailtm();
					if (mailtm.Create_Mailtm(text3, text6, text))
					{
						goto IL_032f;
					}
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Get mailtm thất bại, chạy lại là được";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				else
				{
					if (!(type_mail == "Hotmail"))
					{
						goto IL_032f;
					}
					emailQueue.TryDequeue(out result);
					if (result != null)
					{
						empty2 = result;
						string[] array = result.Split('|');
						text4 = array[0];
						text5 = array[1];
						File.AppendAllText("Data_Reg\\email_runned.txt", result + "\n");
						Invoke((Action)delegate
						{
							linkLabel10.Text = "[ " + emailQueue.Count + " ]";
						});
						goto IL_032f;
					}
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Hết hotmail! Vui lòng nạp thêm";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				goto end_IL_0077;
			IL_032f:
				string text7 = dataGridView2.Rows[i].Cells["useragent"].Value.ToString();
				if (text7 == "" || text7 == null)
				{
					text7 = manguser_agent[random.Next(0, manguser_agent.Length)];
				}
				string empty3 = string.Empty;
				Point pointFromIndexPosition = GetPointFromIndexPosition(index_chrome, Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				Point sizeChrome = GetSizeChrome(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value));
				XuanAction xuanAction = new XuanAction();
				TimeSpan span = new TimeSpan(0, 2, 0);
				TimeSpan span2 = new TimeSpan(0, 2, 0);
				TimeSpan span3 = new TimeSpan(0, 0, 30);
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
				chromeDriverService.HideCommandPromptWindow = true;
				ChromeOptions chromeOptions = new ChromeOptions();
				chromeOptions.AddArgument("--app=https://m.facebook.com/");
				if (text != "" && text.Split(':').Length == 2)
				{
					chromeOptions.AddArgument("--proxy-server= " + text);
				}
				else if (text != "" && text.Split(':').Length == 4)
				{
					chromeOptions.AddHttpProxy(text.Split(':')[0], int.Parse(text.Split(':')[1]), text.Split(':')[2], text.Split(':')[3]);
				}
				chromeOptions.AddArguments("--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--window-size=" + sizeChrome.X + "," + sizeChrome.Y, "--window-position=" + pointFromIndexPosition.X + "," + pointFromIndexPosition.Y, "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=BlockCredentialedSubresources", "--disable-popup-blocking");
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 0);
				chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
				chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
				chromeOptions.AddExcludedArgument("enable-automation");
				chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
				chromeOptions.AddArgument("user-agent=" + text7);
				Sleep(Convert.ToInt32(numericUpDown7.Value));
				driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3.0));
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(6.0);
				if (!cbaddview.Checked)
				{
					goto IL_07f6;
				}
				try
				{
					num = chromeDriverService.ProcessId;
					Process windowHandleByDriverId = GetWindowHandleByDriverId(num);
					handle = windowHandleByDriverId.MainWindowHandle;
					Thread.Sleep(1000);
				}
				catch
				{
					goto end_IL_0077;
				}
				if (num != 0)
				{
					Sleep(1.0);
					lock (this.obj)
					{
						Invoke((Action)delegate
						{
							ptn2.Width = 280;
							ptn2.Height = 300;
							ptn2.BorderStyle = BorderStyle.FixedSingle;
							ptn2.AutoScroll = true;
							ptn2.SetAutoScrollMargin(320, 480);
							name.Text = "IP:" + ip;
							name.Location = new Point(0, 0);
							ptn2.Controls.Add(name);
							Invoke((Action)delegate
							{
								flowLayoutPanel1.Controls.Add(ptn2);
							});
							SetParent(handle, ptn2.Handle);
							SetWindowLong(handle, -4, WS_VISIBLE);
							MoveWindow(handle, -8, -36, 320, 480, Repaint: true);
							driver.Manage().Window.Position = new Point(0, 15);
						});
					}
					goto IL_07f6;
				}
				goto end_IL_0077;
			IL_07f6:
				Sleep(1.0);
				if (!xuanAction.Goto(driver, "https://m.facebook.com/", span))
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
					dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
					dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
				}
				else
				{
					dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đăng nhập bằng cookie...";
					int num2 = 0;
					while (true)
					{
						if (driver.FindElements(By.XPath("//button[@name='login']")).Count <= 0 && driver.FindElements(By.XPath("//button[@data-sigil='touchable login_button_block m_login_button']")).Count <= 0)
						{
							if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
							{
								driver.Navigate().Refresh();
								Sleep(1.0);
							}
							if (num2 == 10)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Không mở được facebook!";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							num2++;
							Sleep(1.0);
							continue;
						}
						importcookie(driver, cookieclone);
						xuanAction.Goto(driver, driver.Url.Replace("www.face", "m.face").Replace("mbasic.face", "m.face"), span);
						Thread.Sleep(2000);
						dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Kiểm tra trạng thái đăng nhập...";
						Sleep(3.0);
						while (true)
						{
							if (driver.FindElements(By.XPath("//span[contains(text(),'Ok')]")).Count > 0)
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
								break;
							}
							if (driver.FindElements(By.XPath("//input[@name='c']")).Count <= 0)
							{
								if (driver.FindElements(By.XPath("//div[@data-sigil='login_profile_form']")).Count > 0)
								{
									if (!(pass != ""))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Cookie die!";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Nhập lại mật khẩu...";
									xuanAction.Clicks(driver, By.XPath("//div[@data-sigil='login_profile_form']"), span2, 0);
									Sleep(1.0);
									while (driver.FindElements(By.XPath("//input[@type='password']")).Count <= 0)
									{
									}
									xuanAction.SendKey(driver, By.XPath("//input[@type='password']"), span2, pass);
									Sleep(1.0);
									while (driver.FindElements(By.XPath("//button[@data-sigil='touchable password_login_button']")).Count <= 0)
									{
									}
									xuanAction.ClickElement(driver, By.XPath("//button[@data-sigil='touchable password_login_button']"), span2);
									Sleep(1.0);
								}
								else
								{
									if (driver.FindElements(By.XPath("//input[@id='approvals_code']")).Count > 0)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản có 2fa";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Error";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Yellow;
										break;
									}
									if (driver.PageSource.Contains("captcha_persist_data"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.FindElements(By.XPath("//button[@name='action_unset_contact_point']")).Count > 0)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.FindElements(By.XPath("//input[@name='mobile_image_data']")).Count > 0)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.Url.Contains("disabled"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Vô phương cứu chữa";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.FindElements(By.XPath("//input[@name='contact_point']")).Count > 0)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
								}
								if (driver.FindElements(By.XPath("//div[@aria-label='Close']")).Count > 0 || driver.Url.Contains("actor_experience"))
								{
									xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
								}
								if (driver.FindElements(By.XPath("//a[@id='nux-nav-button']")).Count > 0)
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
									break;
								}
								if (driver.PageSource.Contains("bạn đã không tán thành với quyết định") || driver.PageSource.Contains("you disagreed with the decision"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282 chờ xét duyệt";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (!driver.Url.Contains("login/save-device"))
								{
									if (driver.FindElements(By.XPath("//a[@name='News Feed']")).Count > 0)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										break;
									}
									if (driver.FindElements(By.XPath("//div[@id='login_error']")).Count > 0)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tên người dùng hoặc mật khẩu không hợp lệ ";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.FindElements(By.XPath("//div[@data-sigil='messenger_icon']")).Count > 5)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										break;
									}
									if (driver.FindElements(By.XPath("//div[contains(text(),'Photo')]")).Count > 0)
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Tài khoản live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
										break;
									}
									if (driver.PageSource.Contains("We've suspended your account"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									if (driver.PageSource.Contains("Không có Internet") || driver.PageSource.Contains("No Internet") || driver.PageSource.Contains("Không thể truy cập"))
									{
										dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
										dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
										dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
										break;
									}
									driver.Navigate().Refresh();
									Sleep(2.0);
									continue;
								}
								xuanAction.Goto(driver, "https://mbasic.facebook.com/", span);
							}
							empty3 = GetCookieCurrentChrome(driver);
							dataGridView2.Rows[i].Cells["cookieclone"].Value = empty3;
							UpdateData(i);
							dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang thêm mail...";
							if (!xuanAction.Goto(driver, "https://mbasic.facebook.com/changeemail", span))
							{
								dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Mạng không ổn định";
								dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
								dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
								break;
							}
							while (true)
							{
								if (driver.FindElements(By.XPath("//input[@name='new']")).Count > 0)
								{
									if (type_mail == "Mailtm")
									{
										xuanAction.SendKey(driver, By.XPath("//input[@name='new']"), span3, text3);
									}
									else if (type_mail == "Hotmail")
									{
										xuanAction.SendKey(driver, By.XPath("//input[@name='new']"), span3, text4);
									}
									xuanAction.ClickElement(driver, By.XPath("//input[@name='submit']"), span3);
									while (true)
									{
										if (driver.FindElements(By.XPath("//input[@name='c']")).Count > 0)
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang lấy OTP mail...";
											if (type_mail == "Mailtm")
											{
												while (true)
												{
													text2 = mailtm.GetCodeMailTm(text3, text6, text);
													if (text2 != "")
													{
														break;
													}
													Sleep(1.0);
												}
											}
											else if (type_mail == "Hotmail")
											{
												while (true)
												{
													text2 = mail.Verify(text4, text5, "imap-mail.outlook.com", 993);
													if (text2 != "")
													{
														break;
													}
													Sleep(1.0);
												}
											}
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Đang xác minh OTP " + text2;
											xuanAction.SendKey(driver, By.XPath("//input[@name='c']"), span3, text2);
											while (driver.FindElements(By.XPath("//input[@name='submit[confirm]']")).Count <= 0)
											{
											}
											xuanAction.ClickElement(driver, By.XPath("//input[@name='submit[confirm]']"), span3);
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")   Kiểm tra trạng thái...";
											while (true)
											{
												if (driver.Url.Contains("gettingstarted"))
												{
													if (type_mail == "Mailtm")
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Xác minh thành công mailtm " + uid + "(" + text3 + ")";
														dataGridView2.Rows[i].Cells["emailclone"].Value = text3;
														dataGridView2.Rows[i].Cells["passmailclone"].Value = text6;
													}
													else if (type_mail == "Hotmail")
													{
														dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Xong]   Xác minh thành công hotmail " + uid + "(" + text4 + ")";
														dataGridView2.Rows[i].Cells["emailclone"].Value = text4;
														dataGridView2.Rows[i].Cells["passmailclone"].Value = text5;
													}
													empty3 = GetCookieCurrentChrome(driver);
													dataGridView2.Rows[i].Cells["cookieclone"].Value = empty3;
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Live";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Green;
													break;
												}
												if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												if (driver.Url.Contains("disabled"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Vô phương cứu chữa";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
												if (!driver.Url.Contains("gettingstarted") && driver.Url.Contains("checkpoint") && !driver.Url.Contains("282"))
												{
													dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint";
													dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
													dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
													break;
												}
											}
											break;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
										if (driver.Url.Contains("disabled"))
										{
											dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Vô phương cứu chữa";
											dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
											dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
											break;
										}
									}
									break;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("282"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản die 282";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (driver.Url.Contains("checkpoint") && driver.Url.Contains("956"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Tài khoản checkpoint 956";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
								if (driver.Url.Contains("disabled"))
								{
									dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   Vô phương cứu chữa";
									dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Disable";
									dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
									break;
								}
							}
							break;
						}
						break;
					}
				}
			end_IL_0077:;
			}
			catch (Exception ex)
			{
				dataGridView2.Rows[i].Cells["trangthai1"].Value = "(" + ip + ")[Lỗi]   (" + ex.Message + ")";
				dataGridView2.Rows[i].Cells["tinhtrang"].Value = "Die";
				dataGridView2.Rows[i].Cells["tinhtrang"].Style.ForeColor = Color.Red;
			}
			UpdateData(i);
			if (driver != null)
			{
				driver.Quit();
			}
			dataGridView2.Rows[i].Cells["chon"].Value = false;
			if (!cbaddview.Checked)
			{
				return;
			}
			try
			{
				Invoke((Action)delegate
				{
					flowLayoutPanel1.Controls.Remove(ptn2);
				});
			}
			catch
			{
			}
		}

		public bool DownloadImageServer(string uid, string proxy)
		{
			int index = comboimage.SelectedIndex - 1;
			string text = JsonConvert.SerializeObject(new DataDownloadImage
			{
				Index = index,
				License = RsaCryptor.Encrypt(DataManager.License),
				Token = RsaCryptor.Encrypt(DataManager.Token),
				Uid = RsaCryptor.Encrypt(uid),
				Proxy = RsaCryptor.Encrypt(proxy)
			});
			string text2 = RequestServer.PostServer(ServiceServer.GetApiImage(), text);
			bool flag = ((!(text2 == "null") && (!string.IsNullOrEmpty(text2) || !(text2 != "null"))) ? true : false);
			string text3 = (flag ? "SetText Clipboard" : "Error");
			if (flag)
			{
				string[] array = JsonConvert.DeserializeObject<string[]>(text2);
				byte[] array2 = Convert.FromBase64String(array[0].Replace("\"", ""));
				using (MemoryStream stream = new MemoryStream(array2, 0, array2.Length))
				{
					Image image = Image.FromStream(stream, useEmbeddedColorManagement: true);
					image.Save(Path_Tool + "\\Image\\" + uid + ".png");
				}
				string text5 = (DataManager.Token = array[1]);
				RequestServer.SetToken(DataManager.Token);
			}
			return flag;
		}

		public void Download_image_captcha()
		{
			WebClient webClient = new WebClient();
			Stream stream = webClient.OpenRead("https://mbasic.facebook.com/captcha/tfbimage.php?captcha_challenge_code=1672681553-8e02d1ca35df7d22d7bc615b11d42a1c&captcha_challenge_hash=AZnvQVbV_2qboQZLVGcDIA42MhY9cFVzfiDILE8qcF9kj6DWr1ZubHWuGpVDPqFhPY08se6gKCaUYQiwkKSpwLGGd1f8Y-24x_tr5SG3oTubJtmfvFaoTrrZdiFI-jfs9iERXsqvwJNkvbMnhF6Q8ZL9sV4yCi6KqPIY_XYQf2VgWHnRG6MOSGot2acEcnlgRBQ");
			new Bitmap(stream)?.Save(Path_Tool + "\\Image\\1.png");
			stream.Flush();
			stream.Close();
			webClient.Dispose();
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("chrome.exe", "https://www.facebook.com/haiphuong.nguyen.796");
			}
			catch
			{
				Process.Start("https://www.facebook.com/haiphuong.nguyen.796");
			}
		}

		public void LoadDanhMuc()
		{
			Invoke((Action)delegate
			{
				combo_DanhMuc.Items.Clear();
			});
			List<string> dm = SQLite.getlistdanhmuc("DM");
			int i;
			for (i = 0; i < dm.Count; i++)
			{
				Invoke((Action)delegate
				{
					combo_DanhMuc.Items.Add(dm[i]);
				});
			}
		}

		private void linkLabel4_Click(object sender, EventArgs e)
		{
			string text = "checktokenne";
			if (text != "")
			{
				AddDanhmuc addDanhmuc = new AddDanhmuc();
				addDanhmuc.ShowDialog();
				if (AddDanhmuc.FAceytQozKcOwUyPaYSsUFAcikakyh)
				{
					LoadDanhMuc();
					MessageBox.Show("Thêm Danh Mục Thành Công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadAccount(combo_DanhMuc.Text);
			Loc = false;
		}

		public void LoadAccount(string namefile)
		{
			dataGridView2.Rows.Clear();
			string text = SQLite.getlistac1(namefile);
			string[] array = text.Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			for (int j = 0; j < array.Length; j++)
			{
				if (!(array[j] != ""))
				{
					continue;
				}
				string[] arr = array[j].Split('|');
				int rowindex = dataGridView2.Rows.Count;
				dataGridView2.Rows.Add(true, rowindex + 1);
				int i2;
				for (i2 = 0; i2 < arr.Length; i2++)
				{
					try
					{
						Invoke((Action)delegate
						{
							dataGridView2.Rows[rowindex].Cells[i2 + 2].Value = arr[i2];
						});
					}
					catch
					{
					}
				}
				dataGridView2.DoubleBuffered(setting: true);
			}
			CountLiveDie(dataGridView2);
		}

		public void CountLiveDie(DataGridView dtg)
		{
			for (int i = 0; i < dtg.Rows.Count; i++)
			{
				try
				{
					dtg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
					if (dtg.Rows[i].Cells["Tinhtrang"].Value.ToString().Contains("Die") || dtg.Rows[i].Cells["Tinhtrang"].Value.ToString().ToLower().Contains("check") || dtg.Rows[i].Cells["Tinhtrang"].Value.ToString().Contains("LỖI"))
					{
						DataGridViewRow dataGridViewRow = dtg.Rows[i];
						dataGridViewRow.Cells["tinhtrang"].Style.ForeColor = Color.FromArgb(128, 0, 0);
					}
					else if (dtg.Rows[i].Cells["Tinhtrang"].Value.ToString().Contains("Live"))
					{
						DataGridViewRow dataGridViewRow2 = dtg.Rows[i];
						dataGridViewRow2.Cells["tinhtrang"].Style.ForeColor = Color.Green;
					}
					else
					{
						DataGridViewRow dataGridViewRow3 = dtg.Rows[i];
					}
				}
				catch (Exception ex)
				{
					SaveErrorLog(ex.ToString());
				}
			}
			int live = 0;
			int die = 0;
			foreach (DataGridViewRow item in (IEnumerable)dtg.Rows)
			{
				if (dtg.Rows[item.Index].Cells["Tinhtrang"].Value.ToString().ToLower() == "live")
				{
					live++;
				}
				else if (dtg.Rows[item.Index].Cells["Tinhtrang"].Value.ToString().ToLower() == "die" || dtg.Rows[item.Index].Cells["Tinhtrang"].Value.ToString().ToLower() == "checkpoint")
				{
					die++;
				}
			}
			Invoke((Action)delegate
			{
				lb_TongAcc.Text = "Tổng: " + dtg.Rows.Count;
				lb_Live.Text = "Live: " + live;
				lb_Die.Text = "Die: " + die;
			});
		}

		public void LocTinhTrang()
		{
			string text = cbb_LocTinhTrang.Text;
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				item.Visible = true;
			}
			if (text != "ALL")
			{
				foreach (DataGridViewRow item2 in (IEnumerable)dataGridView2.Rows)
				{
					if (!item2.Cells["tinhtrang"].Value.ToString().Contains(text))
					{
						item2.Visible = false;
					}
				}
			}
			int live = 0;
			int die = 0;
			foreach (DataGridViewRow item3 in (IEnumerable)dataGridView2.Rows)
			{
				if (dataGridView2.Rows[item3.Index].Cells["Tinhtrang"].Value.ToString().ToLower() == "live")
				{
					live++;
				}
				else if (dataGridView2.Rows[item3.Index].Cells["Tinhtrang"].Value.ToString().ToLower() == "die" || dataGridView2.Rows[item3.Index].Cells["Tinhtrang"].Value.ToString().ToLower() == "checkpoint")
				{
					die++;
				}
			}
			Invoke((Action)delegate
			{
				lb_TongAcc.Text = "Tổng: " + dataGridView2.Rows.Count;
				lb_Live.Text = "Live: " + live;
				lb_Die.Text = "Die: " + die;
			});
		}

		private void cbb_LocTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
		{
			LocTinhTrang();
			CountLiveDie(dataGridView2);
		}

		private void linkLabel5_Click(object sender, EventArgs e)
		{
			Chuyendulieu chuyendulieu = new Chuyendulieu();
			chuyendulieu.ShowDialog();
			if (Chuyendulieu.action)
			{
				string name = Chuyendulieu.name;
				SQLite.deletecateloge(name);
				SQLite.deleteuidincateloge(name);
				MessageBox.Show("Xóa DANH MỤC " + name + " thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				LoadDanhMuc();
			}
		}

		public void show1(string datas, string dinhdang)
		{
			string[] array = dinhdang.Replace(" ", "").Split('|');
			string[] array2 = "UID|PASS|2FA|COOKIE|TOKEN|EMAIL|PASSMAIL|UA|SINHNHAT|GENDER|FRIEND|GROUP|LIVE|GHICHU|LASTACTIVE|PROXY|TRANGTHAI".Split('|');
			string[] array3 = datas.Split('|');
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array2.Length; i++)
			{
				int num = 0;
				while (true)
				{
					if (num < array.Length)
					{
						if (array[num].Replace(" ", "") == array2[i].Replace(" ", ""))
						{
							if (num != array.Length - 1)
							{
								stringBuilder.Append(array3[num] + "|");
							}
							else
							{
								stringBuilder.Append(array3[num]);
							}
							break;
						}
						num++;
						continue;
					}
					if (i != array2.Length - 1)
					{
						stringBuilder.Append("|");
					}
					else
					{
						stringBuilder.Append("");
					}
					break;
				}
				Thread.Sleep(1);
			}
			lock (obj)
			{
				data.AppendLine(stringBuilder.ToString());
			}
		}

		public void NhapAccount(bool PasteClipBoard, string name)
		{
			if (combo_DinhDang.Text != "")
			{
				Invoke((Action)delegate
				{
					string[] array = null;
					if (PasteClipBoard)
					{
						array = Clipboard.GetText().Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
					}
					else
					{
						OpenFileDialog openFileDialog = new OpenFileDialog();
						DialogResult dialogResult = openFileDialog.ShowDialog();
						if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
						{
							array = File.ReadAllLines(openFileDialog.FileName).ToArray();
						}
					}
					int num = 0;
					string[] array2 = combo_DinhDang.Text.Split('|');
					string ty = combo_DinhDang.Text;
					data = new StringBuilder();
					Parallel.ForEach(array, delegate (string x)
					{
						show1(x, ty);
					});
					SQLite.insert(name, data.ToString());
					SQLite.createindex();
					MessageBox.Show("Nhập thành công " + (array.Length - num) + " Account! Trùng : " + num, "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				});
			}
			else
			{
				MessageBox.Show("Chưa chọn Định Dạng Nhập vào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void linkLabel6_Click(object sender, EventArgs e)
		{
			Chuyendulieu chuyendulieu = new Chuyendulieu();
			chuyendulieu.ShowDialog();
			if (Chuyendulieu.action)
			{
				string name = Chuyendulieu.name;
				NhapAccount(PasteClipBoard: false, name);
			}
		}

		private void linkLabel2_Click(object sender, EventArgs e)
		{
			try
			{
				IsRunning = false;
				Invoke((Action)delegate
				{
					linkLabel1.Enabled = true;
					linkLabel2.Enabled = false;
				});
				MessageBox.Show("Tool đã dừng, vui lòng chờ các luồng hoàn thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			catch
			{
				Environment.Exit(0);
			}
		}

		private void linkLabel7_Click(object sender, EventArgs e)
		{
			if (File.Exists("config.txt"))
			{
				File.Delete("config.txt");
			}
			string contents = comboip.SelectedIndex + "|" + richTextBox1.Text + "|" + txt_apiphone.Text + "|" + txt_apicaptcha.Text + "|" + combocaptcha.SelectedIndex + "|" + combomail.SelectedIndex + "|" + numericUpDown2.Value + "|" + numericUpDown3.Value + "|" + numericUpDown4.Value + "|" + cbgiuanh.Checked + "|" + cb2fa.Checked + "|" + cbquequan.Checked + "|" + cbnoisong.Checked + "|" + cbnghenghiep.Checked + "|" + cbavatar.Checked + "|" + cbcover.Checked + "|" + combologin.SelectedIndex + "|" + txt_avatar.Text + "|" + txt_cover.Text + "|" + cbgetcookiemoi.Checked + "|" + combophone.SelectedIndex + "|" + cbregkhongunlock.Checked + "|" + numericUpDown1.Value + "|" + comboten.SelectedIndex + "|" + txt_linkserver.Text + "|" + cbngonngu.Checked + "|" + comboimage.SelectedIndex + "|" + cbaddview.Checked + "|" + cbregkhongunlockkhongcaptcha.Checked + "|" + combongonngu.SelectedIndex + "|" + txt_proxyv6net.Text + "|" + cbverify.Checked + "|" + cb_addmail282.Checked + "|" + cb_ngonngureg.Checked + "|" + txt_folder_anh.Text + "|" + numericUpDown5.Value + "|" + numericUpDown6.Value + "|" + cb_180day.Checked + "|" + comboserver.Text + "|" + numericUpDown7.Value + "|" + combosex.Text + "|" + nbr_getphoneagain.Value;
			File.AppendAllText("config.txt", contents);
			MessageBox.Show("ĐÃ LƯU LẠI CÀI ĐẶT MỚI", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		 

		string key = Md5Encode(new DeviceIdBuilder().AddMachineName().AddProcessorId().AddMotherboardSerialNumber()
				.AddSystemDriveSerialNumber()
				.ToString()); // Md5 Encode 
		public static string Md5Encode(string string_0)
		{
			HashAlgorithm hashAlgorithm = MD5.Create();
			byte[] bytes = Encoding.ASCII.GetBytes(string_0);
			byte[] array = hashAlgorithm.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		
		
		private void Form1_Load(object sender, EventArgs e)
		{
			string days = "";
			string user = "";
			string machine_id = "****";
			string userkeyz = user + "-" + key.Substring(0, 32);

			string userkey = Md5Encode(userkeyz) + "-RegChrome"; 
			try
			{ 
				string get = (new WebClient().DownloadString("https://ltdsoftware.click/list/keyactive.php?key=" + userkey)); 
				if (get.Contains(userkey))
				{
					string[] array = get.Split('|');
					days = Convert.ToDateTime(array[2]).ToString("dd/MM/yyyy");
					user = array[0];
					machine_id = array[1].Substring(0, 10) + "****"; 
					lbl_User.Text = user;
					toolStripStatusLabel12.Text = user;
					toolStripStatusLabel8.Text = machine_id.Substring(0, 5) + "****";
					toolStripStatusLabel7.Text = machine_id.Substring(0, 5) + "****";
					toolStripStatusLabel3.Text = "Đã kích hoạt";
					toolStripStatusLabel4.Text = "Đã kích hoạt";
					toolStripStatusLabel15.Text = days;
					toolStripStatusLabel20.Text = days;
				}
				else
				{
					MessageBox.Show("License die! Đã copy key vui lòng gủi cho admin để kích hoạt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Clipboard.SetText(userkey);
					Environment.Exit(1);
				}
			}
			catch
			{
				MessageBox.Show("Vui lòng kiểm tra lại mạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(1);
			}
			Invoke((Action)delegate
			{
				lbupdate.Visible = false;
			});
			//try
			//{
			//	checkversion();
			//}
			//catch
			//{
			//}
			Invoke((Action)delegate
			{
				linkLabel2.Enabled = false;
				linkLabel8.Enabled = false;
			});
			LoadDanhMuc();
			Invoke((Action)delegate
			{
				combocaptcha.SelectedIndex = 0;
				comboip.SelectedIndex = 0;
			});
			timer1.Start();
			if (File.Exists("config.txt"))
			{
				string[] array = File.ReadAllText("config.txt").Split('|');
				try
				{
					comboip.SelectedIndex = Convert.ToInt32(array[0]);
					richTextBox1.Text = array[1];
					txt_apiphone.Text = array[2];
					txt_apicaptcha.Text = array[3];
					combocaptcha.SelectedIndex = Convert.ToInt32(array[4]);
					combomail.SelectedIndex = Convert.ToInt32(array[5]);
					numericUpDown2.Value = Convert.ToInt32(array[6]);
					numericUpDown3.Value = Convert.ToInt32(array[7]);
					numericUpDown4.Value = Convert.ToInt32(array[8]);
					cbgiuanh.Checked = Convert.ToBoolean(array[9]);
					cb2fa.Checked = Convert.ToBoolean(array[10]);
					cbquequan.Checked = Convert.ToBoolean(array[11]);
					cbnoisong.Checked = Convert.ToBoolean(array[12]);
					cbnghenghiep.Checked = Convert.ToBoolean(array[13]);
					cbavatar.Checked = Convert.ToBoolean(array[14]);
					cbcover.Checked = Convert.ToBoolean(array[15]);
					combologin.SelectedIndex = Convert.ToInt32(array[16]);
					txt_avatar.Text = array[17];
					txt_cover.Text = array[18];
					cbgetcookiemoi.Checked = Convert.ToBoolean(array[19]);
					combophone.SelectedIndex = Convert.ToInt32(array[20]);
					cbregkhongunlock.Checked = Convert.ToBoolean(array[21]);
					numericUpDown1.Value = Convert.ToInt32(array[22]);
					comboten.SelectedIndex = Convert.ToInt32(array[23]);
					txt_linkserver.Text = array[24];
					cbngonngu.Checked = Convert.ToBoolean(array[25]);
					comboimage.SelectedIndex = Convert.ToInt32(array[26]);
					cbaddview.Checked = Convert.ToBoolean(array[27]);
					cbregkhongunlockkhongcaptcha.Checked = Convert.ToBoolean(array[28]);
					combongonngu.SelectedIndex = Convert.ToInt32(array[29]);
					txt_proxyv6net.Text = array[30];
					cbverify.Checked = Convert.ToBoolean(array[31]);
					cb_addmail282.Checked = Convert.ToBoolean(array[32]);
					cb_ngonngureg.Checked = Convert.ToBoolean(array[33]);
					txt_folder_anh.Text = array[34];
					numericUpDown5.Value = Convert.ToInt32(array[35]);
					numericUpDown6.Value = Convert.ToInt32(array[36]);
					cb_180day.Checked = Convert.ToBoolean(array[37]);
					comboserver.Text = array[38];
					numericUpDown7.Value = Convert.ToInt32(array[39]); 
					combosex.Text = array[40];
					nbr_getphoneagain.Value = Convert.ToInt32(array[41]);
				}
				catch
				{
					Console.WriteLine("File Setting đã cũ. Chỉnh sửa hoặc Delete file cũ!");
				}
			}
		}

		[Obsolete]
		private void linkLabel9_Click(object sender, EventArgs e)
		{
			if (combonhiemvu.SelectedIndex != 0 && combonhiemvu.SelectedIndex != 1 && combonhiemvu.SelectedIndex != 2)
			{
				MessageBox.Show("Chưa chọn nhiệm vụ dể chạy list tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (combonhiemvu.SelectedIndex == 2 && combomail.SelectedIndex != 0 && combomail.SelectedIndex != 1)
			{
				MessageBox.Show("Chưa chọn site mail phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			IsRunning_login = true;
			if (!checkrow())
			{
				return;
			}
			Process[] processesByName = Process.GetProcessesByName("chromedriver");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
			}
			Exception ex;
			foreach (Thread item in ListThread_login)
			{
				try
				{
					item.Abort();
				}
				catch (Exception ex2)
				{
					ex = ex2;
					Invoke((Action)delegate
					{
						SaveErrorLog(ex.ToString());
					});
				}
			}
			Invoke((Action)delegate
			{
				linkLabel9.Enabled = false;
				linkLabel8.Enabled = true;
			});
			thread = new Thread(hguywervxcvs);
			thread.Start();
		}

		public bool checkrow()
		{
			queRow.Clear();
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				if (item.Cells["chon"].Value.Equals(true))
				{
					queRow.Enqueue(item);
				}
			}
			if (queRow.Count == 0)
			{
				return false;
			}
			return true;
		}

		public void UpdateData(int i)
		{
			try
			{
				string uID = dataGridView2.Rows[i].Cells["uidclone"].Value.ToString();
				string cateloge = dataGridView2.Rows[i].Cells["danhmuc"].Value.ToString();
				dataGridView2.Rows[i].Cells["lastactive"].Value = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
				string text = "";
				for (int j = 3; j < dataGridView2.Columns.Count; j++)
				{
					text = ((j != 3) ? ((j != dataGridView2.Columns.Count - 2) ? (text + "|" + dataGridView2.Rows[i].Cells[j].Value.ToString()) : (text + "|" + dataGridView2.Rows[i].Cells[j].Value.ToString())) : dataGridView2.Rows[i].Cells[j].Value.ToString());
				}
				SQLite.updateall(uID, cateloge, text);
			}
			catch (Exception ex)
			{
				SaveErrorLog(ex.ToString());
			}
		}

		private void cHỌNHÀNGBÔIĐENToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				dataGridView2.Rows[item.Index].Cells["CHON"].Value = false;
			}
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				dataGridView2.Rows[selectedRow.Index].Cells["CHON"].Value = true;
			}
		}

		private void cHỌNTẤTCẢToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				dataGridView2.Rows[item.Index].Cells["CHON"].Value = true;
			}
		}

		private void bỎCHỌNHÀNGBÔIĐENToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				dataGridView2.Rows[selectedRow.Index].Cells["CHON"].Value = false;
			}
		}

		private void bỎCHỌNTẤTCẢToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Vonglap = 0;
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				dataGridView2.Rows[item.Index].Cells["CHON"].Value = false;
			}
		}

		private void xÓADÒNGĐÃCHỌNToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn XÓA ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				if (item.Cells[1].Value.Equals(true))
				{
					stringBuilder.Append(item.Cells["uidclone"].Value.ToString() + "\r\n");
				}
			}
			SQLite.deleteuid(stringBuilder.ToString());
			for (int i = 0; i < dataGridView2.Rows.Count; i++)
			{
				if (dataGridView2.Rows[i].Cells[1].Value.Equals(true))
				{
					dataGridView2.Rows.RemoveAt(i);
					i--;
				}
			}
			CountLiveDie(dataGridView2);
			MessageBox.Show("Xóa Thành Công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void xÓATẤTCẢToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn XÓA ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				stringBuilder.Append(item.Cells["uidclone"].Value.ToString() + "\r\n");
			}
			SQLite.deleteuid(stringBuilder.ToString());
			CountLiveDie(dataGridView2);
			MessageBox.Show("Xóa Thành Công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void xÓADÒNGBÔIĐENToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn XÓA ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "\r\n");
			}
			SQLite.deleteuid(stringBuilder.ToString());
			foreach (DataGridViewRow selectedRow2 in dataGridView2.SelectedRows)
			{
				dataGridView2.Rows.RemoveAt(selectedRow2.Index);
			}
			CountLiveDie(dataGridView2);
			MessageBox.Show("Xóa Thành Công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Chuyendulieu chuyendulieu = new Chuyendulieu();
			chuyendulieu.ShowDialog();
			if (!Chuyendulieu.action)
			{
				return;
			}
			string name = Chuyendulieu.name;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				if (item.Cells["chon"].Value.Equals(true))
				{
					stringBuilder.Append(item.Cells["uidclone"].Value.ToString() + "|");
				}
			}
			SQLite.chuyendulieu(stringBuilder.ToString(), name);
			CountLiveDie(dataGridView2);
			MessageBox.Show("Chuyển dữ liệu sang Danh Mục \"" + name + "\" thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void rEFRESHDỮLIỆUToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadAccount(combo_DanhMuc.Text);
			CountLiveDie(dataGridView2);
		}

		private void cHỌNACCCHECKPOINTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				if (item.Cells["tinhtrang"].Value.ToString() == "Checkpoint" || item.Cells["tinhtrang"].Value.ToString() == "Die")
				{
					dataGridView2.Rows[item.Index].Cells["CHON"].Value = true;
				}
				else
				{
					dataGridView2.Rows[item.Index].Cells["CHON"].Value = false;
				}
			}
		}

		private void bỎCHỌNACCDIECHECKPOINTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in (IEnumerable)dataGridView2.Rows)
			{
				if (item.Cells["tinhtrang"].Value.ToString() == "Checkpoint" || item.Cells["tinhtrang"].Value.ToString() == "Die")
				{
					dataGridView2.Rows[item.Index].Cells["CHON"].Value = false;
				}
			}
		}

		private void sỬAGHICHÚToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddGhiChu addGhiChu = new AddGhiChu();
			addGhiChu.ShowDialog();
			if (!(AddGhiChu.noidung != ""))
			{
				return;
			}
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				dataGridView2.Rows[selectedRow.Index].Cells["ghichu"].Value = AddGhiChu.noidung;
				UpdateData(selectedRow.Index);
			}
			MessageBox.Show("Thêm ghi chú thành công !", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (!((e.RowIndex >= 0) & (e.ColumnIndex >= 0)))
			{
				return;
			}
			e.Handled = true;
			e.PaintBackground(e.CellBounds, cellsPaintSelectionBackground: true);
			string text = "[Xong]";
			while (!string.IsNullOrEmpty(text))
			{
				string text2 = e.FormattedValue.ToString();
				int num = text2.ToLower().IndexOf(text.ToLower());
				if (num >= 0)
				{
					Rectangle rect = default(Rectangle);
					rect.Y = e.CellBounds.Y + 1;
					rect.Height = e.CellBounds.Height - 5;
					string text3 = text2.Substring(0, num);
					string text4 = text2.Substring(num, text.Length);
					Size size = TextRenderer.MeasureText(e.Graphics, text3, e.CellStyle.Font, e.CellBounds.Size);
					Size size2 = TextRenderer.MeasureText(e.Graphics, text4, e.CellStyle.Font, e.CellBounds.Size);
					if (size.Width > 5)
					{
						rect.X = e.CellBounds.X + size.Width - 5;
						rect.Width = size2.Width;
					}
					else
					{
						rect.X = e.CellBounds.X;
						rect.Width = size2.Width;
					}
					SolidBrush solidBrush = null;
					if (text == "[Xong]")
					{
						solidBrush = new SolidBrush(Color.Green);
					}
					else if (text == "Lỗi")
					{
						solidBrush = new SolidBrush(Color.Red);
					}
					e.Graphics.FillRectangle(solidBrush, rect);
					solidBrush.Dispose();
					break;
				}
				if (!(text != "Lỗi"))
				{
					break;
				}
				text = "Lỗi";
			}
			e.PaintContent(e.CellBounds);
		}

		private void uIDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void cOOKIEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["cookieclone"].Value.ToString() + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void uIDPASSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "|" + selectedRow.Cells["passclone"].Value.ToString() + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void uIDPASS2FAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "|" + selectedRow.Cells["passclone"].Value.ToString() + "|" + selectedRow.Cells["ma2fa"].Value.ToString().Replace("\r", "").Replace("\n", "") + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void tabPage2_Click(object sender, EventArgs e)
		{
		}

		private void linkLabel8_Click(object sender, EventArgs e)
		{
			try
			{
				isstop = true;
				IsRunning_login = false;
				Invoke((Action)delegate
				{
					linkLabel9.Enabled = true;
					linkLabel8.Enabled = false;
				});
				MessageBox.Show("Tool đã dừng, vui lòng chờ các luồng chạy hoàn thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			catch
			{
				Environment.Exit(0);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("chromedriver");
				Process[] array = processesByName;
				foreach (Process process in array)
				{
					process.Kill();
				}
				CloseToken();
				Environment.Exit(0);
			}
			catch
			{
				CloseToken();
				Environment.Exit(0);
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("chromedriver");
				Process[] array = processesByName;
				foreach (Process process in array)
				{
					process.Kill();
				}
				CloseToken();
				Environment.Exit(0);
			}
			catch
			{
				CloseToken();
				Environment.Exit(0);
			}
		}

		private void CloseToken()
		{
			if (!string.IsNullOrEmpty(DataManager.Token) && !string.IsNullOrEmpty(DataManager.Status))
			{
				RequestServer.PostServer(ServiceServer.Parse(APIAuthentication.CloseToken), RsaCryptor.Encrypt(DataManager.Token));
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Invoke((Action)delegate
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					if (!folderBrowserDialog.SelectedPath.Contains(" "))
					{
						txt_avatar.Text = folderBrowserDialog.SelectedPath;
					}
					else
					{
						MessageBox.Show("Đường dẫn tới folder ảnh không được có dấu cách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			});
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Invoke((Action)delegate
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					if (!folderBrowserDialog.SelectedPath.Contains(" "))
					{
						txt_cover.Text = folderBrowserDialog.SelectedPath;
					}
					else
					{
						MessageBox.Show("Đường dẫn tới folder ảnh không được có dấu cách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			});
		}

		private void tabPage1_Click(object sender, EventArgs e)
		{
		}

		private void linkLabel10_Click(object sender, EventArgs e)
		{
			HashSet<string> hashSet = new HashSet<string>();
			HashSet<string> hashSet2 = new HashSet<string>();
			string result;
			while (emailQueue.TryDequeue(out result))
			{
			}
			string[] array = File.ReadAllLines("Data_Reg\\email_runned.txt");
			string[] array2 = array;
			string[] array3 = array2;
			foreach (string item in array3)
			{
				if (!hashSet.Contains(item))
				{
					hashSet.Add(item);
				}
			}
			string[] array4 = File.ReadAllLines("Data_Reg\\hotmail.txt");
			string[] array5 = array4;
			string[] array6 = array5;
			foreach (string item2 in array6)
			{
				if (!hashSet.Contains(item2))
				{
					hashSet2.Add(item2);
				}
			}
			foreach (string item3 in hashSet2)
			{
				if (item3.Contains("@"))
				{
					emailQueue.Enqueue(item3);
				}
			}
			Invoke((Action)delegate
			{
				linkLabel10.Text = "[ " + emailQueue.Count + " ]";
			});
		}

		private void linkLabel11_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("notepad.exe", "Data_Reg\\hotmail.txt");
			}
			catch
			{
				Process.Start("Data_Reg\\hotmail.txt");
			}
		}

		private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			tabControl1.SelectedIndex = 1;
			combonhiemvu.SelectedIndex = 1;
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "|" + selectedRow.Cells["passclone"].Value.ToString() + "|" + selectedRow.Cells["cookieclone"].Value.ToString() + "|" + selectedRow.Cells["token"].Value.ToString().Replace("\r", "").Replace("\n", "") + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void checkLiveUidToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (File.Exists("ErrorLog.txt"))
			{
				File.Delete("ErrorLog.txt");
			}
			if (dataGridView2.Rows.Count == 0)
			{
				MessageBox.Show("CHƯA CÓ DỮ LIỆU TRONG BẢNG !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Exception ex;
			foreach (Thread item in ListThread_Live_Uid)
			{
				try
				{
					item.Abort();
				}
				catch (Exception ex2)
				{
					ex = ex2;
					Invoke((Action)delegate
					{
						SaveErrorLog(ex.ToString());
					});
				}
			}
			Thread thread = new Thread((ThreadStart)delegate
			{
				IsRunning_live_uid = true;
				CheckLiveUID();
				IsRunning_live_uid = false;
			});
			thread.Start();
			thread.IsBackground = true;
		}

		public bool check_live(string new_user_id)
		{
			try
			{
				HttpRequest httpRequest = new HttpRequest();
				string text = httpRequest.Get("https://graph.facebook.com/" + new_user_id + "/picture?redirect=false").ToString();
				if (!string.IsNullOrEmpty(text))
				{
					if (text.Contains("height") && text.Contains("width"))
					{
						return true;
					}
					return false;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		private void CheckLiveUID()
		{
			new Thread((ThreadStart)delegate
			{
				List<DataGridViewRow> list = new List<DataGridViewRow>();
				for (int i = 0; i < dataGridView2.Rows.Count; i++)
				{
					if (dataGridView2.Rows[i].Cells["CHON"].Value.Equals(true))
					{
						list.Add(dataGridView2.Rows[i]);
					}
				}
				if (list.Count > 0)
				{
					int die = 0;
					int live = 0;
					Thread.Sleep(500);
					Parallel.ForEach(list, delegate (DataGridViewRow roww)
					{
						try
						{
							int index = roww.Index;
							bool flag = check_live(dataGridView2.Rows[index].Cells["uidclone"].Value.ToString());
							lock (this.obj)
							{
								if (flag)
								{
									live++;
									dataGridView2.Rows[index].Cells["tinhtrang"].Value = "Live";
									dataGridView2.Rows[index].Cells["tinhtrang"].Style.ForeColor = Color.Green;
								}
								else
								{
									die++;
									dataGridView2.Rows[index].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[index].DefaultCellStyle.ForeColor = Color.FromArgb(128, 0, 0);
								}
								dataGridView2.Rows[index].Cells["trangthai1"].Value = "[Xong]  Check Live Xong ! (" + DateTime.Now.ToString() + ")";
								UpdateData(index);
							}
						}
						catch
						{
						}
					});
					MessageBox.Show("Check UID XONG! " + live + " Live - " + die + " Die", "[Xong]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					IsRunning_live_uid = false;
				}
				else
				{
					MessageBox.Show("Chưa chọn Acc để check Live Uid", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}).Start();
		}

		 
		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "|" + selectedRow.Cells["passclone"].Value.ToString() + "|" + selectedRow.Cells["ma2fa"].Value.ToString() + "|" + selectedRow.Cells["cookieclone"].Value.ToString() + "|" + selectedRow.Cells["token"].Value.ToString().Replace("\r", "").Replace("\n", "") + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void uIDPASS2FAEMAILPASSMAILToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "|" + selectedRow.Cells["passclone"].Value.ToString() + "|" + selectedRow.Cells["ma2fa"].Value.ToString() + "|" + selectedRow.Cells["emailclone"].Value.ToString() + "|" + selectedRow.Cells["passmailclone"].Value.ToString().Replace("\r", "").Replace("\n", "") + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "|" + selectedRow.Cells["passclone"].Value.ToString() + "|" + selectedRow.Cells["ma2fa"].Value.ToString() + "|" + selectedRow.Cells["cookieclone"].Value.ToString() + "|" + selectedRow.Cells["token"].Value.ToString() + "|" + selectedRow.Cells["emailclone"].Value.ToString() + "|" + selectedRow.Cells["passmailclone"].Value.ToString().Replace("\r", "").Replace("\n", "") + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
			{
				stringBuilder.Append(selectedRow.Cells["uidclone"].Value.ToString() + "|" + selectedRow.Cells["passclone"].Value.ToString() + "|" + selectedRow.Cells["ma2fa"].Value.ToString() + "|" + selectedRow.Cells["cookieclone"].Value.ToString() + "|" + selectedRow.Cells["token"].Value.ToString() + "|" + selectedRow.Cells["emailclone"].Value.ToString() + "|" + selectedRow.Cells["passmailclone"].Value.ToString() + "|" + selectedRow.Cells["useragent"].Value.ToString().Replace("\r", "").Replace("\n", "") + "\r\n");
			}
			Clipboard.SetText(stringBuilder.ToString());
			MessageBox.Show("COPY Thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void linkLabel14_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("notepad.exe", "Data_Reg\\proxy_http.txt");
			}
			catch
			{
				Process.Start("Data_Reg\\proxy_http.txt");
			}
		}

		private void checkversion()
		{
			if (InternetConnection.IsConnectedToInternet())
			{
				WebClient webClient = new WebClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				webClient.DownloadFileCompleted += udcom;
				Uri address = new Uri(hostname + "update.ini");
				webClient.DownloadFileAsync(address, Application.StartupPath + "\\update\\update.ini");
			}
			else
			{
				MessageBox.Show("No internet connect.Please check your network!");
			}
		}

		private void udcom(object sender, AsyncCompletedEventArgs e)
		{
			try
			{
				IniFile iniFile = new IniFile("./update/update.ini");
				string text = iniFile.Read("Version", "facebook");
				double num = Convert.ToDouble(text.Replace(".", "").Insert(1, "."));
				IniFile iniFile2 = new IniFile("update.ini");
				string text2 = iniFile2.Read("Version", "facebook");
				double num2 = Convert.ToDouble(text2.Replace(".", "").Insert(1, "."));
				if (num > num2)
				{
					Invoke((Action)delegate
					{
						lbupdate.Visible = true;
					});
				}
				else
				{
					Invoke((Action)delegate
					{
						lbupdate.Visible = false;
					});
				}
			}
			catch
			{
				Invoke((Action)delegate
				{
					lbupdate.Visible = false;
				});
			}
		}

		public static string Authencation(string key)
		{
			try
			{
				key = key.Replace("\r", "").Replace("\n", "").Replace(" ", "")
					.ToString();
				WebClient webClient = new WebClient();
				string input = webClient.DownloadString("http://2fa.live/tok/" + key);
				return Regex.Match(input, "token\":\"(\\d+)\"").Groups[1].Value;
			}
			catch
			{
				return "";
			}
		}

		public string TurnOnAuthencation(string ACCOUNT, string proxy)
		{
			Request request = new Request(ACCOUNT.Split('|')[0], "", proxy);
			request.AddHeader("referer", "https://mbasic.facebook.com/security/2fac/setup/intro/metadata/?source=1");
			string value = "";
			string value2 = "";
			string input = request.RequestGet("https://mbasic.facebook.com/security/2fac/setup/intro/metadata/?source=1");
			string text = Regex.Match(input, "setup/qrcode(.*?)\"").Groups[1].ToString().Replace("amp;", "");
			string url = "https://mbasic.facebook.com/security/2fac/setup/qrcode" + text;
			string input2 = request.RequestGet(url);
			string url2 = request.Uri().Replace("m.facebook.com", "mbasic.facebook.com");
			string text2 = request.RequestGet(url2);
			if (text2.Contains("<title>Enter Password</title>") || text2.Contains("Nhập Mật khẩu"))
			{
				string value3 = Regex.Match(text2, "method=\"post\" action=\"(.*?)\"").Groups[1].Value;
				value = Regex.Match(text2, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
				value2 = Regex.Match(text2, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
				request.AddParam("fb_dtsg", value2);
				request.AddParam("jazoest", value);
				request.AddParam("pass", ACCOUNT.Split('|')[1]);
				request.AddParam("save", "Continue");
				input2 = request.RequestPost(value3);
			}
			string text3 = Regex.Match(input2, "secret=(.*?)&").Groups[1].ToString();
			if (!string.IsNullOrEmpty(text3))
			{
				string text4 = Authencation(text3);
				if (text4 != "")
				{
					request.AddParam("fb_dtsg", value2);
					request.AddParam("jazoest", value);
					request.AddParam("code_handler_type", "third_party_qr_auth");
					request.AddParam("confirmButton", "Continue");
					request.RequestPost("https://m.facebook.com/security/2fac/setup/type_code/");
					request.AddParam("fb_dtsg", value2);
					request.AddParam("jazoest", value);
					request.AddParam("code", text4);
					string text5 = request.RequestPost("https://m.facebook.com/security/2fac/setup/verify_code/");
					if (text5.Contains("Mã này không đúng. Vui lòng thử lại.") || text5.Contains("Please try again."))
					{
						return "";
					}
					if (text5.Contains("Lỗi") || (text5.Contains("Error") && !text5.Contains("factor authentication is on") && !text5.Contains("đang bật")))
					{
						return "";
					}
					string cookie = request.GetCookie();
					return text3 + "|" + cookie;
				}
				return "";
			}
			return "";
		}

		private void BAT2FA_REQUEST()
		{
			new Thread((ThreadStart)delegate
			{
				List<DataGridViewRow> list = new List<DataGridViewRow>();
				for (int i = 0; i < dataGridView2.Rows.Count; i++)
				{
					if (dataGridView2.Rows[i].Cells["CHON"].Value.Equals(true))
					{
						list.Add(dataGridView2.Rows[i]);
					}
				}
				if (list.Count > 0)
				{
					int die = 0;
					int live = 0;
					Thread.Sleep(500);
					Parallel.ForEach(list, delegate (DataGridViewRow roww)
					{
						try
						{
							int index = roww.Index;
							string aCCOUNT = dataGridView2.Rows[index].Cells["cookieclone"].Value.ToString() + "|" + dataGridView2.Rows[index].Cells["passclone"].Value.ToString();
							string text = TurnOnAuthencation(aCCOUNT, "");
							lock (this.obj)
							{
								if (text != "" && text.Split('|').Length != 0)
								{
									live++;
									dataGridView2.Rows[index].Cells["tinhtrang"].Value = "Live";
									dataGridView2.Rows[index].Cells["ma2fa"].Value = text.Split('|')[0];
									dataGridView2.Rows[index].Cells["cookieclone"].Value = text.Split('|')[1];
									dataGridView2.Rows[index].Cells["tinhtrang"].Style.ForeColor = Color.Green;
									dataGridView2.Rows[index].Cells["trangthai1"].Value = "[Xong]  Bật 2fa thành công ! (" + DateTime.Now.ToString() + ")";
								}
								else
								{
									die++;
									dataGridView2.Rows[index].Cells["ma2fa"].Value = "";
									dataGridView2.Rows[index].Cells["tinhtrang"].Value = "Die";
									dataGridView2.Rows[index].DefaultCellStyle.ForeColor = Color.FromArgb(128, 0, 0);
									dataGridView2.Rows[index].Cells["trangthai1"].Value = "[Lỗi]  Bật 2fa thất bại (" + DateTime.Now.ToString() + ")";
								}
								UpdateData(index);
							}
						}
						catch
						{
						}
					});
					MessageBox.Show("ĐÃ BẬT 2FA XONG!", "[Xong]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					IsRunning_2FA = false;
				}
				else
				{
					MessageBox.Show("Chưa chọn Acc để BẬT 2FA", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}).Start();
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			if (File.Exists("ErrorLog.txt"))
			{
				File.Delete("ErrorLog.txt");
			}
			if (dataGridView2.Rows.Count == 0)
			{
				MessageBox.Show("CHƯA CÓ DỮ LIỆU TRONG BẢNG !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Exception ex;
			foreach (Thread item in ListThread_2FA)
			{
				try
				{
					item.Abort();
				}
				catch (Exception ex2)
				{
					ex = ex2;
					Invoke((Action)delegate
					{
						SaveErrorLog(ex.ToString());
					});
				}
			}
			Thread thread = new Thread((ThreadStart)delegate
			{
				IsRunning_2FA = true;
				BAT2FA_REQUEST();
				IsRunning_2FA = false;
			});
			thread.Start();
			thread.IsBackground = true;
		}

		 

		private void button3_Click(object sender, EventArgs e)
		{
			Invoke((Action)delegate
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					if (!folderBrowserDialog.SelectedPath.Contains(" "))
					{
						txt_folder_anh.Text = folderBrowserDialog.SelectedPath;
					}
					else
					{
						MessageBox.Show("Đường dẫn tới folder ảnh không được có dấu cách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			});
		}

		private void comboimage_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboimage.Text == "Ảnh đã lưu trong folder Image")
			{
				txt_folder_anh.Enabled = true;
				button3.Enabled = true;
				txt_folder_anh.Enabled = true;
			}
			else
			{
				txt_folder_anh.Text = "không khả dụng";
				txt_folder_anh.Enabled = false;
				button3.Enabled = false;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		[System.Obsolete]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel12 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel13 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel14 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel15 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_tongreg = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbtongphone_buy = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.codedone = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel22 = new System.Windows.Forms.ToolStripStatusLabel();
            this.error_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel17 = new System.Windows.Forms.Button();
            this.lbupdate = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.linkLabel13 = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COOKIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASSMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIC = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel16 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_User = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel18 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel19 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel20 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_TongAcc = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_Live = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_Die = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel8 = new System.Windows.Forms.Button();
            this.linkLabel6 = new System.Windows.Forms.Button();
            this.linkLabel9 = new System.Windows.Forms.Button();
            this.linkLabel5 = new System.Windows.Forms.Button();
            this.linkLabel4 = new System.Windows.Forms.Button();
            this.combonhiemvu = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.combo_DinhDang = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbb_LocTinhTrang = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uidclone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passclone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma2fa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cookieclone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailclone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passmailclone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useragent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.friendcount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupcount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhtrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhmuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cHỌNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHỌNHÀNGBÔIĐENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHỌNTẤTCẢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHỌNACCCHECKPOINTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bỎCHỌNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bỎCHỌNHÀNGBÔIĐENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bỎCHỌNTẤTCẢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bỎCHỌNACCDIECHECKPOINTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xÓADÒNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xÓADÒNGBÔIĐENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xÓADÒNGĐÃCHỌNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xÓATẤTCẢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOPYACCOUNTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOOKIEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uIDPASSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.uIDPASS2FAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.uIDPASS2FAEMAILPASSMAILToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEFRESHDỮLIỆUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sỬAGHICHÚToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkLiveUidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combo_DanhMuc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabel7 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_folder_anh = new System.Windows.Forms.TextBox();
            this.cb_addmail282 = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.comboimage = new System.Windows.Forms.ComboBox();
            this.cbngonngu = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbgetcookiemoi = new System.Windows.Forms.CheckBox();
            this.txt_cover = new System.Windows.Forms.TextBox();
            this.txt_avatar = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.combologin = new System.Windows.Forms.ComboBox();
            this.cbcover = new System.Windows.Forms.CheckBox();
            this.cbavatar = new System.Windows.Forms.CheckBox();
            this.cbnghenghiep = new System.Windows.Forms.CheckBox();
            this.cbnoisong = new System.Windows.Forms.CheckBox();
            this.cbquequan = new System.Windows.Forms.CheckBox();
            this.cb2fa = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.combomail = new System.Windows.Forms.ComboBox();
            this.comboten = new System.Windows.Forms.ComboBox();
            this.cb_ngonngureg = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbverify = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.combongonngu = new System.Windows.Forms.ComboBox();
            this.cbgiuanh = new System.Windows.Forms.CheckBox();
            this.cbregkhongunlockkhongcaptcha = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbregkhongunlock = new System.Windows.Forms.CheckBox();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_apicaptcha = new System.Windows.Forms.TextBox();
            this.combocaptcha = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txt_apiphone = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboserver = new System.Windows.Forms.ComboBox();
            this.combophone = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel14 = new System.Windows.Forms.Button();
            this.linkLabel10 = new System.Windows.Forms.Button();
            this.linkLabel11 = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.cb_180day = new System.Windows.Forms.CheckBox();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_proxyv6net = new System.Windows.Forms.TextBox();
            this.cbaddview = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_linkserver = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboip = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.combosex = new System.Windows.Forms.ComboBox();
            this.nbr_getphoneagain = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbr_getphoneagain)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1310, 601);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.linkLabel17);
            this.tabPage1.Controls.Add(this.lbupdate);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.linkLabel13);
            this.tabPage1.Controls.Add(this.linkLabel2);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.linkLabel3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1302, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RegClone";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel10,
            this.toolStripStatusLabel11,
            this.toolStripStatusLabel12,
            this.toolStripStatusLabel13,
            this.toolStripStatusLabel14,
            this.toolStripStatusLabel15,
            this.toolStripLabel1,
            this.lb_tongreg,
            this.toolStripLabel2,
            this.lbtongphone_buy,
            this.toolStripLabel3,
            this.codedone,
            this.toolStripStatusLabel22,
            this.error_code});
            this.statusStrip1.Location = new System.Drawing.Point(3, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1296, 27);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(103, 21);
            this.toolStripStatusLabel2.Text = "Trạng thái:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Green;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(117, 21);
            this.toolStripStatusLabel4.Text = "Đang kiểm tra...";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(107, 21);
            this.toolStripStatusLabel6.Text = "Mã thiết bị:";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel8.ForeColor = System.Drawing.Color.Teal;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(62, 21);
            this.toolStripStatusLabel8.Text = "******";
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(55, 21);
            this.toolStripStatusLabel10.Text = "User:";
            // 
            // toolStripStatusLabel11
            // 
            this.toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            this.toolStripStatusLabel11.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatusLabel12
            // 
            this.toolStripStatusLabel12.Name = "toolStripStatusLabel12";
            this.toolStripStatusLabel12.Size = new System.Drawing.Size(64, 21);
            this.toolStripStatusLabel12.Text = "******";
            // 
            // toolStripStatusLabel13
            // 
            this.toolStripStatusLabel13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel13.IsLink = true;
            this.toolStripStatusLabel13.Name = "toolStripStatusLabel13";
            this.toolStripStatusLabel13.Size = new System.Drawing.Size(80, 21);
            this.toolStripStatusLabel13.Text = "Đăng xuất";
            // 
            // toolStripStatusLabel14
            // 
            this.toolStripStatusLabel14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel14.Name = "toolStripStatusLabel14";
            this.toolStripStatusLabel14.Size = new System.Drawing.Size(130, 21);
            this.toolStripStatusLabel14.Text = "Ngày hết hạn:";
            // 
            // toolStripStatusLabel15
            // 
            this.toolStripStatusLabel15.Name = "toolStripStatusLabel15";
            this.toolStripStatusLabel15.Size = new System.Drawing.Size(96, 21);
            this.toolStripStatusLabel15.Text = "20/10/2020";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(125, 21);
            this.toolStripLabel1.Text = "Tổng acc reg:";
            // 
            // lb_tongreg
            // 
            this.lb_tongreg.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tongreg.ForeColor = System.Drawing.Color.Blue;
            this.lb_tongreg.Name = "lb_tongreg";
            this.lb_tongreg.Size = new System.Drawing.Size(21, 21);
            this.lb_tongreg.Text = "0";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(118, 21);
            this.toolStripLabel2.Text = "Tổng phone:";
            // 
            // lbtongphone_buy
            // 
            this.lbtongphone_buy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtongphone_buy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbtongphone_buy.Name = "lbtongphone_buy";
            this.lbtongphone_buy.Size = new System.Drawing.Size(21, 21);
            this.lbtongphone_buy.Text = "0";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(130, 21);
            this.toolStripLabel3.Text = "Success code:";
            // 
            // codedone
            // 
            this.codedone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codedone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.codedone.Name = "codedone";
            this.codedone.Size = new System.Drawing.Size(21, 21);
            this.codedone.Text = "0";
            // 
            // toolStripStatusLabel22
            // 
            this.toolStripStatusLabel22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel22.Name = "toolStripStatusLabel22";
            this.toolStripStatusLabel22.Size = new System.Drawing.Size(92, 21);
            this.toolStripStatusLabel22.Text = "Fail code:";
            // 
            // error_code
            // 
            this.error_code.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error_code.ForeColor = System.Drawing.Color.Red;
            this.error_code.Name = "error_code";
            this.error_code.Size = new System.Drawing.Size(21, 21);
            this.error_code.Text = "0";
            // 
            // linkLabel17
            // 
            this.linkLabel17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel17.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel17.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel17.Location = new System.Drawing.Point(334, 12);
            this.linkLabel17.Name = "linkLabel17";
            this.linkLabel17.Size = new System.Drawing.Size(176, 34);
            this.linkLabel17.TabIndex = 10;
            this.linkLabel17.Text = "Close Chrome";
            this.linkLabel17.Click += new System.EventHandler(this.linkLabel17_Click);
            // 
            // lbupdate
            // 
            this.lbupdate.AutoSize = true;
            this.lbupdate.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbupdate.ForeColor = System.Drawing.Color.Red;
            this.lbupdate.Location = new System.Drawing.Point(732, 38);
            this.lbupdate.Name = "lbupdate";
            this.lbupdate.Size = new System.Drawing.Size(758, 29);
            this.lbupdate.TabIndex = 6;
            this.lbupdate.Text = "ĐÃ CÓ BẢN UPDATE, TẮT TOOL BẤM AUTOUPDATE RỒI MỞ LẠI";
            this.lbupdate.Visible = false;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(1078, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 35);
            this.button4.TabIndex = 9;
            this.button4.Text = "Update Chrome Driver";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // linkLabel13
            // 
            this.linkLabel13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel13.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel13.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel13.Location = new System.Drawing.Point(516, 11);
            this.linkLabel13.Name = "linkLabel13";
            this.linkLabel13.Size = new System.Drawing.Size(176, 35);
            this.linkLabel13.TabIndex = 9;
            this.linkLabel13.Text = "Close Chromedriver";
            this.linkLabel13.Click += new System.EventHandler(this.linkLabel13_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel2.Image")));
            this.linkLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel2.Location = new System.Drawing.Point(174, 11);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(154, 35);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.Text = "Dừng lại";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel2.UseVisualStyleBackColor = false;
            this.linkLabel2.Click += new System.EventHandler(this.linkLabel2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel1.Image")));
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.Location = new System.Drawing.Point(14, 10);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(154, 36);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.Text = "Bắt Đầu Reg";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.UseVisualStyleBackColor = false;
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.LinkColor = System.Drawing.SystemColors.Highlight;
            this.linkLabel3.Location = new System.Drawing.Point(818, 19);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(118, 19);
            this.linkLabel3.TabIndex = 4;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Liên hệ admin";
            this.linkLabel3.Visible = false;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox4.Location = new System.Drawing.Point(8, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1286, 490);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tài khoản";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TT,
            this.UID,
            this.PASS,
            this.COOKIE,
            this.EMAIL,
            this.PASSMAIL,
            this.STATUS,
            this.PIC});
            this.dataGridView1.Location = new System.Drawing.Point(6, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 460);
            this.dataGridView1.TabIndex = 0;
            // 
            // TT
            // 
            this.TT.HeaderText = "TT";
            this.TT.MinimumWidth = 6;
            this.TT.Name = "TT";
            this.TT.ReadOnly = true;
            this.TT.Width = 30;
            // 
            // UID
            // 
            this.UID.HeaderText = "UID";
            this.UID.MinimumWidth = 6;
            this.UID.Name = "UID";
            this.UID.ReadOnly = true;
            this.UID.Width = 125;
            // 
            // PASS
            // 
            this.PASS.HeaderText = "PASS";
            this.PASS.MinimumWidth = 6;
            this.PASS.Name = "PASS";
            this.PASS.ReadOnly = true;
            this.PASS.Width = 125;
            // 
            // COOKIE
            // 
            this.COOKIE.HeaderText = "COOKIE";
            this.COOKIE.MinimumWidth = 6;
            this.COOKIE.Name = "COOKIE";
            this.COOKIE.ReadOnly = true;
            this.COOKIE.Width = 125;
            // 
            // EMAIL
            // 
            this.EMAIL.HeaderText = "EMAIL";
            this.EMAIL.MinimumWidth = 6;
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.ReadOnly = true;
            this.EMAIL.Width = 125;
            // 
            // PASSMAIL
            // 
            this.PASSMAIL.HeaderText = "PASSMAIL";
            this.PASSMAIL.MinimumWidth = 6;
            this.PASSMAIL.Name = "PASSMAIL";
            this.PASSMAIL.ReadOnly = true;
            this.PASSMAIL.Width = 125;
            // 
            // STATUS
            // 
            this.STATUS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STATUS.HeaderText = "STATUS";
            this.STATUS.MinimumWidth = 6;
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            // 
            // PIC
            // 
            this.PIC.HeaderText = "PIC";
            this.PIC.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.PIC.MinimumWidth = 100;
            this.PIC.Name = "PIC";
            this.PIC.ReadOnly = true;
            this.PIC.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.statusStrip2);
            this.tabPage2.Controls.Add(this.linkLabel8);
            this.tabPage2.Controls.Add(this.linkLabel6);
            this.tabPage2.Controls.Add(this.linkLabel9);
            this.tabPage2.Controls.Add(this.linkLabel5);
            this.tabPage2.Controls.Add(this.linkLabel4);
            this.tabPage2.Controls.Add(this.combonhiemvu);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.combo_DinhDang);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.combo_DanhMuc);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1302, 571);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cập nhật thông tin";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel16,
            this.lbl_User,
            this.toolStripStatusLabel18,
            this.toolStripStatusLabel19,
            this.toolStripStatusLabel20,
            this.lb_TongAcc,
            this.lb_Live,
            this.lb_Die});
            this.statusStrip2.Location = new System.Drawing.Point(3, 541);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1296, 27);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 16;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 21);
            this.toolStripStatusLabel1.Text = "Trạng thái:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Green;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(117, 21);
            this.toolStripStatusLabel3.Text = "Đang kiểm tra...";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(107, 21);
            this.toolStripStatusLabel5.Text = "Mã thiết bị:";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel7.ForeColor = System.Drawing.Color.Teal;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(62, 21);
            this.toolStripStatusLabel7.Text = "******";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(55, 21);
            this.toolStripStatusLabel9.Text = "User:";
            // 
            // toolStripStatusLabel16
            // 
            this.toolStripStatusLabel16.Name = "toolStripStatusLabel16";
            this.toolStripStatusLabel16.Size = new System.Drawing.Size(0, 21);
            // 
            // lbl_User
            // 
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(64, 21);
            this.lbl_User.Text = "******";
            // 
            // toolStripStatusLabel18
            // 
            this.toolStripStatusLabel18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel18.IsLink = true;
            this.toolStripStatusLabel18.Name = "toolStripStatusLabel18";
            this.toolStripStatusLabel18.Size = new System.Drawing.Size(80, 21);
            this.toolStripStatusLabel18.Text = "Đăng xuất";
            // 
            // toolStripStatusLabel19
            // 
            this.toolStripStatusLabel19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel19.Name = "toolStripStatusLabel19";
            this.toolStripStatusLabel19.Size = new System.Drawing.Size(130, 21);
            this.toolStripStatusLabel19.Text = "Ngày hết hạn:";
            // 
            // toolStripStatusLabel20
            // 
            this.toolStripStatusLabel20.Name = "toolStripStatusLabel20";
            this.toolStripStatusLabel20.Size = new System.Drawing.Size(96, 21);
            this.toolStripStatusLabel20.Text = "20/10/2020";
            // 
            // lb_TongAcc
            // 
            this.lb_TongAcc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TongAcc.ForeColor = System.Drawing.Color.Blue;
            this.lb_TongAcc.Name = "lb_TongAcc";
            this.lb_TongAcc.Size = new System.Drawing.Size(110, 21);
            this.lb_TongAcc.Text = "Tổng Acc: 0";
            // 
            // lb_Live
            // 
            this.lb_Live.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Live.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lb_Live.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.lb_Live.Name = "lb_Live";
            this.lb_Live.Size = new System.Drawing.Size(67, 21);
            this.lb_Live.Text = "Live: 0";
            // 
            // lb_Die
            // 
            this.lb_Die.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Die.ForeColor = System.Drawing.Color.Red;
            this.lb_Die.Name = "lb_Die";
            this.lb_Die.Size = new System.Drawing.Size(60, 21);
            this.lb_Die.Text = "Die: 0";
            // 
            // linkLabel8
            // 
            this.linkLabel8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel8.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel8.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel8.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel8.Image")));
            this.linkLabel8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel8.Location = new System.Drawing.Point(170, 44);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(154, 35);
            this.linkLabel8.TabIndex = 15;
            this.linkLabel8.Text = "Dừng lại";
            this.linkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel8.UseVisualStyleBackColor = false;
            this.linkLabel8.Click += new System.EventHandler(this.linkLabel8_Click);
            // 
            // linkLabel6
            // 
            this.linkLabel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel6.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel6.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel6.Image")));
            this.linkLabel6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel6.Location = new System.Drawing.Point(1095, 44);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(154, 36);
            this.linkLabel6.TabIndex = 14;
            this.linkLabel6.Text = "Nhập tài khoản";
            this.linkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel6.UseVisualStyleBackColor = false;
            this.linkLabel6.Click += new System.EventHandler(this.linkLabel6_Click);
            // 
            // linkLabel9
            // 
            this.linkLabel9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel9.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel9.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel9.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel9.Image")));
            this.linkLabel9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel9.Location = new System.Drawing.Point(10, 43);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(154, 36);
            this.linkLabel9.TabIndex = 14;
            this.linkLabel9.Text = "Bắt đầu";
            this.linkLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel9.UseVisualStyleBackColor = false;
            this.linkLabel9.Click += new System.EventHandler(this.linkLabel9_Click);
            // 
            // linkLabel5
            // 
            this.linkLabel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel5.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel5.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel5.Image")));
            this.linkLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel5.Location = new System.Drawing.Point(935, 44);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(154, 36);
            this.linkLabel5.TabIndex = 13;
            this.linkLabel5.Text = "Xóa thư mục";
            this.linkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel5.UseVisualStyleBackColor = false;
            this.linkLabel5.Click += new System.EventHandler(this.linkLabel5_Click);
            // 
            // linkLabel4
            // 
            this.linkLabel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel4.Image")));
            this.linkLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel4.Location = new System.Drawing.Point(775, 44);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(154, 36);
            this.linkLabel4.TabIndex = 13;
            this.linkLabel4.Text = "Tạo mới";
            this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel4.UseVisualStyleBackColor = false;
            this.linkLabel4.Click += new System.EventHandler(this.linkLabel4_Click);
            // 
            // combonhiemvu
            // 
            this.combonhiemvu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combonhiemvu.ForeColor = System.Drawing.Color.Navy;
            this.combonhiemvu.FormattingEnabled = true;
            this.combonhiemvu.Items.AddRange(new object[] {
            "Cập nhật thông tin",
            "Mở khóa checkpoint 282",
            "Xác minh tài khoản"});
            this.combonhiemvu.Location = new System.Drawing.Point(612, 59);
            this.combonhiemvu.Name = "combonhiemvu";
            this.combonhiemvu.Size = new System.Drawing.Size(103, 26);
            this.combonhiemvu.TabIndex = 12;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label23.Location = new System.Drawing.Point(550, 63);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 17);
            this.label23.TabIndex = 11;
            this.label23.Text = "Action:";
            // 
            // combo_DinhDang
            // 
            this.combo_DinhDang.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_DinhDang.FormattingEnabled = true;
            this.combo_DinhDang.Items.AddRange(new object[] {
            "UID | PASS | UA",
            "UID | PASS | 2FA | UA",
            "UID | PASS | 2FA | COOKIE | TOKEN | UA",
            "UID | PASS | 2FA | COOKIE | UA",
            "UID | PASS | 2FA | COOKIE",
            "UID | PASS | 2FA | COOKIE | EMAIL | PASSMAIL | UA",
            "UID | PASS | COOKIE | TOKEN | UA",
            "UID | PASS | COOKIE | TOKEN",
            "UID | PASS | EMAIL | PASSMAIL | UA",
            "UID | PASS | COOKIE | UA",
            "UID | PASS | COOKIE",
            "UID | PASS | COOKIE | EMAIL | PASSMAIL | UA",
            "UID | PASS | COOKIE | EMAIL | PASSMAIL"});
            this.combo_DinhDang.Location = new System.Drawing.Point(448, 18);
            this.combo_DinhDang.Name = "combo_DinhDang";
            this.combo_DinhDang.Size = new System.Drawing.Size(267, 26);
            this.combo_DinhDang.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(349, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Định dạng:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.cbb_LocTinhTrang);
            this.groupBox5.Controls.Add(this.pictureBox3);
            this.groupBox5.Controls.Add(this.dataGridView2);
            this.groupBox5.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox5.Location = new System.Drawing.Point(7, 90);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1286, 448);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tài khoản";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(26, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 14);
            this.label11.TabIndex = 101;
            this.label11.Text = "LỌC TÌNH TRẠNG";
            // 
            // cbb_LocTinhTrang
            // 
            this.cbb_LocTinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbb_LocTinhTrang.BackColor = System.Drawing.Color.White;
            this.cbb_LocTinhTrang.ForeColor = System.Drawing.Color.Teal;
            this.cbb_LocTinhTrang.FormattingEnabled = true;
            this.cbb_LocTinhTrang.Items.AddRange(new object[] {
            "ALL",
            "Null",
            "Live",
            "Die",
            "Checkpoint"});
            this.cbb_LocTinhTrang.Location = new System.Drawing.Point(127, 421);
            this.cbb_LocTinhTrang.Name = "cbb_LocTinhTrang";
            this.cbb_LocTinhTrang.Size = new System.Drawing.Size(182, 25);
            this.cbb_LocTinhTrang.TabIndex = 102;
            this.cbb_LocTinhTrang.SelectedIndexChanged += new System.EventHandler(this.cbb_LocTinhTrang_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(3, 424);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 18);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 105;
            this.pictureBox3.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.stt,
            this.uidclone,
            this.passclone,
            this.ma2fa,
            this.cookieclone,
            this.token,
            this.emailclone,
            this.passmailclone,
            this.useragent,
            this.gender,
            this.birthday,
            this.friendcount,
            this.groupcount,
            this.tinhtrang,
            this.ghichu,
            this.lastactive,
            this.danhmuc,
            this.proxy,
            this.trangthai1});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dataGridView2.Location = new System.Drawing.Point(3, 17);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1280, 401);
            this.dataGridView2.TabIndex = 100;
            this.dataGridView2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
            // 
            // chon
            // 
            this.chon.HeaderText = "#";
            this.chon.MinimumWidth = 6;
            this.chon.Name = "chon";
            this.chon.ReadOnly = true;
            this.chon.Width = 30;
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            this.stt.Width = 30;
            // 
            // uidclone
            // 
            this.uidclone.HeaderText = "UID";
            this.uidclone.MinimumWidth = 6;
            this.uidclone.Name = "uidclone";
            this.uidclone.ReadOnly = true;
            this.uidclone.Width = 50;
            // 
            // passclone
            // 
            this.passclone.HeaderText = "Password";
            this.passclone.MinimumWidth = 6;
            this.passclone.Name = "passclone";
            this.passclone.ReadOnly = true;
            this.passclone.Width = 50;
            // 
            // ma2fa
            // 
            this.ma2fa.HeaderText = "2FA";
            this.ma2fa.MinimumWidth = 6;
            this.ma2fa.Name = "ma2fa";
            this.ma2fa.ReadOnly = true;
            this.ma2fa.Width = 50;
            // 
            // cookieclone
            // 
            this.cookieclone.HeaderText = "Cookie";
            this.cookieclone.MinimumWidth = 6;
            this.cookieclone.Name = "cookieclone";
            this.cookieclone.ReadOnly = true;
            this.cookieclone.Width = 50;
            // 
            // token
            // 
            this.token.HeaderText = "Token";
            this.token.MinimumWidth = 6;
            this.token.Name = "token";
            this.token.ReadOnly = true;
            this.token.Width = 50;
            // 
            // emailclone
            // 
            this.emailclone.HeaderText = "Email";
            this.emailclone.MinimumWidth = 6;
            this.emailclone.Name = "emailclone";
            this.emailclone.ReadOnly = true;
            this.emailclone.Width = 50;
            // 
            // passmailclone
            // 
            this.passmailclone.HeaderText = "Pass Mail";
            this.passmailclone.MinimumWidth = 6;
            this.passmailclone.Name = "passmailclone";
            this.passmailclone.ReadOnly = true;
            this.passmailclone.Width = 50;
            // 
            // useragent
            // 
            this.useragent.HeaderText = "UA";
            this.useragent.MinimumWidth = 6;
            this.useragent.Name = "useragent";
            this.useragent.ReadOnly = true;
            this.useragent.Width = 50;
            // 
            // gender
            // 
            this.gender.HeaderText = "Giới tính";
            this.gender.MinimumWidth = 6;
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Width = 50;
            // 
            // birthday
            // 
            this.birthday.HeaderText = "Sinh nhật";
            this.birthday.MinimumWidth = 6;
            this.birthday.Name = "birthday";
            this.birthday.ReadOnly = true;
            this.birthday.Width = 70;
            // 
            // friendcount
            // 
            this.friendcount.HeaderText = "Friend";
            this.friendcount.MinimumWidth = 6;
            this.friendcount.Name = "friendcount";
            this.friendcount.ReadOnly = true;
            this.friendcount.Width = 50;
            // 
            // groupcount
            // 
            this.groupcount.HeaderText = "Group";
            this.groupcount.MinimumWidth = 6;
            this.groupcount.Name = "groupcount";
            this.groupcount.ReadOnly = true;
            this.groupcount.Width = 50;
            // 
            // tinhtrang
            // 
            this.tinhtrang.HeaderText = "Live/Die";
            this.tinhtrang.MinimumWidth = 6;
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.ReadOnly = true;
            this.tinhtrang.Width = 50;
            // 
            // ghichu
            // 
            this.ghichu.HeaderText = "Ghi chú";
            this.ghichu.MinimumWidth = 6;
            this.ghichu.Name = "ghichu";
            this.ghichu.ReadOnly = true;
            this.ghichu.Width = 70;
            // 
            // lastactive
            // 
            this.lastactive.HeaderText = "Last Active";
            this.lastactive.MinimumWidth = 6;
            this.lastactive.Name = "lastactive";
            this.lastactive.ReadOnly = true;
            this.lastactive.Width = 70;
            // 
            // danhmuc
            // 
            this.danhmuc.HeaderText = "Danh mục";
            this.danhmuc.MinimumWidth = 6;
            this.danhmuc.Name = "danhmuc";
            this.danhmuc.ReadOnly = true;
            this.danhmuc.Width = 50;
            // 
            // proxy
            // 
            this.proxy.HeaderText = "Proxy";
            this.proxy.MinimumWidth = 6;
            this.proxy.Name = "proxy";
            this.proxy.ReadOnly = true;
            this.proxy.Width = 50;
            // 
            // trangthai1
            // 
            this.trangthai1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.trangthai1.HeaderText = "Trạng thái";
            this.trangthai1.MinimumWidth = 6;
            this.trangthai1.Name = "trangthai1";
            this.trangthai1.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cHỌNToolStripMenuItem,
            this.bỎCHỌNToolStripMenuItem,
            this.xÓADÒNGToolStripMenuItem,
            this.cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem,
            this.cOPYACCOUNTToolStripMenuItem,
            this.rEFRESHDỮLIỆUToolStripMenuItem,
            this.sỬAGHICHÚToolStripMenuItem,
            this.toolStripMenuItem4,
            this.checkLiveUidToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(322, 202);
            // 
            // cHỌNToolStripMenuItem
            // 
            this.cHỌNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cHỌNHÀNGBÔIĐENToolStripMenuItem,
            this.cHỌNTẤTCẢToolStripMenuItem,
            this.cHỌNACCCHECKPOINTToolStripMenuItem});
            this.cHỌNToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.cHỌNToolStripMenuItem.Name = "cHỌNToolStripMenuItem";
            this.cHỌNToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.cHỌNToolStripMenuItem.Text = "CHỌN";
            // 
            // cHỌNHÀNGBÔIĐENToolStripMenuItem
            // 
            this.cHỌNHÀNGBÔIĐENToolStripMenuItem.Name = "cHỌNHÀNGBÔIĐENToolStripMenuItem";
            this.cHỌNHÀNGBÔIĐENToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.cHỌNHÀNGBÔIĐENToolStripMenuItem.Text = "CHỌN HÀNG BÔI ĐEN";
            this.cHỌNHÀNGBÔIĐENToolStripMenuItem.Click += new System.EventHandler(this.cHỌNHÀNGBÔIĐENToolStripMenuItem_Click);
            // 
            // cHỌNTẤTCẢToolStripMenuItem
            // 
            this.cHỌNTẤTCẢToolStripMenuItem.Name = "cHỌNTẤTCẢToolStripMenuItem";
            this.cHỌNTẤTCẢToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.cHỌNTẤTCẢToolStripMenuItem.Text = "CHỌN TẤT CẢ";
            this.cHỌNTẤTCẢToolStripMenuItem.Click += new System.EventHandler(this.cHỌNTẤTCẢToolStripMenuItem_Click);
            // 
            // cHỌNACCCHECKPOINTToolStripMenuItem
            // 
            this.cHỌNACCCHECKPOINTToolStripMenuItem.Name = "cHỌNACCCHECKPOINTToolStripMenuItem";
            this.cHỌNACCCHECKPOINTToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.cHỌNACCCHECKPOINTToolStripMenuItem.Text = "CHỌN ACC DIE/CHECKPOINT";
            this.cHỌNACCCHECKPOINTToolStripMenuItem.Click += new System.EventHandler(this.cHỌNACCCHECKPOINTToolStripMenuItem_Click);
            // 
            // bỎCHỌNToolStripMenuItem
            // 
            this.bỎCHỌNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bỎCHỌNHÀNGBÔIĐENToolStripMenuItem,
            this.bỎCHỌNTẤTCẢToolStripMenuItem,
            this.bỎCHỌNACCDIECHECKPOINTToolStripMenuItem});
            this.bỎCHỌNToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.bỎCHỌNToolStripMenuItem.Name = "bỎCHỌNToolStripMenuItem";
            this.bỎCHỌNToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.bỎCHỌNToolStripMenuItem.Text = "BỎ CHỌN";
            // 
            // bỎCHỌNHÀNGBÔIĐENToolStripMenuItem
            // 
            this.bỎCHỌNHÀNGBÔIĐENToolStripMenuItem.Name = "bỎCHỌNHÀNGBÔIĐENToolStripMenuItem";
            this.bỎCHỌNHÀNGBÔIĐENToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.bỎCHỌNHÀNGBÔIĐENToolStripMenuItem.Text = "BỎ CHỌN HÀNG BÔI ĐEN";
            this.bỎCHỌNHÀNGBÔIĐENToolStripMenuItem.Click += new System.EventHandler(this.bỎCHỌNHÀNGBÔIĐENToolStripMenuItem_Click);
            // 
            // bỎCHỌNTẤTCẢToolStripMenuItem
            // 
            this.bỎCHỌNTẤTCẢToolStripMenuItem.Name = "bỎCHỌNTẤTCẢToolStripMenuItem";
            this.bỎCHỌNTẤTCẢToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.bỎCHỌNTẤTCẢToolStripMenuItem.Text = "BỎ CHỌN TẤT CẢ";
            this.bỎCHỌNTẤTCẢToolStripMenuItem.Click += new System.EventHandler(this.bỎCHỌNTẤTCẢToolStripMenuItem_Click);
            // 
            // bỎCHỌNACCDIECHECKPOINTToolStripMenuItem
            // 
            this.bỎCHỌNACCDIECHECKPOINTToolStripMenuItem.Name = "bỎCHỌNACCDIECHECKPOINTToolStripMenuItem";
            this.bỎCHỌNACCDIECHECKPOINTToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.bỎCHỌNACCDIECHECKPOINTToolStripMenuItem.Text = "BỎ CHỌN ACC DIE/CHECKPOINT";
            this.bỎCHỌNACCDIECHECKPOINTToolStripMenuItem.Click += new System.EventHandler(this.bỎCHỌNACCDIECHECKPOINTToolStripMenuItem_Click);
            // 
            // xÓADÒNGToolStripMenuItem
            // 
            this.xÓADÒNGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xÓADÒNGBÔIĐENToolStripMenuItem,
            this.xÓADÒNGĐÃCHỌNToolStripMenuItem,
            this.xÓATẤTCẢToolStripMenuItem});
            this.xÓADÒNGToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xÓADÒNGToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon;
            this.xÓADÒNGToolStripMenuItem.Name = "xÓADÒNGToolStripMenuItem";
            this.xÓADÒNGToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.xÓADÒNGToolStripMenuItem.Text = "XÓA DÒNG";
            // 
            // xÓADÒNGBÔIĐENToolStripMenuItem
            // 
            this.xÓADÒNGBÔIĐENToolStripMenuItem.Name = "xÓADÒNGBÔIĐENToolStripMenuItem";
            this.xÓADÒNGBÔIĐENToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.xÓADÒNGBÔIĐENToolStripMenuItem.Text = "XÓA DÒNG BÔI ĐEN";
            this.xÓADÒNGBÔIĐENToolStripMenuItem.Click += new System.EventHandler(this.xÓADÒNGBÔIĐENToolStripMenuItem_Click);
            // 
            // xÓADÒNGĐÃCHỌNToolStripMenuItem
            // 
            this.xÓADÒNGĐÃCHỌNToolStripMenuItem.Name = "xÓADÒNGĐÃCHỌNToolStripMenuItem";
            this.xÓADÒNGĐÃCHỌNToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.xÓADÒNGĐÃCHỌNToolStripMenuItem.Text = "XÓA DÒNG ĐÃ TICK CHỌN";
            this.xÓADÒNGĐÃCHỌNToolStripMenuItem.Click += new System.EventHandler(this.xÓADÒNGĐÃCHỌNToolStripMenuItem_Click);
            // 
            // xÓATẤTCẢToolStripMenuItem
            // 
            this.xÓATẤTCẢToolStripMenuItem.Name = "xÓATẤTCẢToolStripMenuItem";
            this.xÓATẤTCẢToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.xÓATẤTCẢToolStripMenuItem.Text = "XÓA TẤT CẢ";
            this.xÓATẤTCẢToolStripMenuItem.Click += new System.EventHandler(this.xÓATẤTCẢToolStripMenuItem_Click);
            // 
            // cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem
            // 
            this.cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem.Name = "cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem";
            this.cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem.Text = "CHUYỂN DỮ LIỆU SANG DANH MỤC KHÁC";
            this.cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem.Click += new System.EventHandler(this.cHUYỂNDỮLIỆUSANGDANHMỤCKHÁCToolStripMenuItem_Click);
            // 
            // cOPYACCOUNTToolStripMenuItem
            // 
            this.cOPYACCOUNTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uIDToolStripMenuItem,
            this.cOOKIEToolStripMenuItem,
            this.toolStripMenuItem1,
            this.uIDPASSToolStripMenuItem,
            this.toolStripMenuItem2,
            this.uIDPASS2FAToolStripMenuItem,
            this.toolStripMenuItem3,
            this.uIDPASS2FAEMAILPASSMAILToolStripMenuItem,
            this.uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem});
            this.cOPYACCOUNTToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.cOPYACCOUNTToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cOPYACCOUNTToolStripMenuItem.Name = "cOPYACCOUNTToolStripMenuItem";
            this.cOPYACCOUNTToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.cOPYACCOUNTToolStripMenuItem.Text = "COPY ACCOUNT";
            // 
            // uIDToolStripMenuItem
            // 
            this.uIDToolStripMenuItem.Name = "uIDToolStripMenuItem";
            this.uIDToolStripMenuItem.Size = new System.Drawing.Size(477, 26);
            this.uIDToolStripMenuItem.Text = "UID";
            this.uIDToolStripMenuItem.Click += new System.EventHandler(this.uIDToolStripMenuItem_Click);
            // 
            // cOOKIEToolStripMenuItem
            // 
            this.cOOKIEToolStripMenuItem.Name = "cOOKIEToolStripMenuItem";
            this.cOOKIEToolStripMenuItem.Size = new System.Drawing.Size(477, 26);
            this.cOOKIEToolStripMenuItem.Text = "COOKIE";
            this.cOOKIEToolStripMenuItem.Click += new System.EventHandler(this.cOOKIEToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(477, 26);
            this.toolStripMenuItem1.Text = "UID | PASS | COOKIE | TOKEN";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // uIDPASSToolStripMenuItem
            // 
            this.uIDPASSToolStripMenuItem.Name = "uIDPASSToolStripMenuItem";
            this.uIDPASSToolStripMenuItem.Size = new System.Drawing.Size(477, 26);
            this.uIDPASSToolStripMenuItem.Text = "UID | PASS";
            this.uIDPASSToolStripMenuItem.Click += new System.EventHandler(this.uIDPASSToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(477, 26);
            this.toolStripMenuItem2.Text = "UID | PASS | 2FA | COOKIE | TOKEN";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // uIDPASS2FAToolStripMenuItem
            // 
            this.uIDPASS2FAToolStripMenuItem.Name = "uIDPASS2FAToolStripMenuItem";
            this.uIDPASS2FAToolStripMenuItem.Size = new System.Drawing.Size(477, 26);
            this.uIDPASS2FAToolStripMenuItem.Text = "UID | PASS | 2FA";
            this.uIDPASS2FAToolStripMenuItem.Click += new System.EventHandler(this.uIDPASS2FAToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(477, 26);
            this.toolStripMenuItem3.Text = "UID | PASS | 2FA | COOKIE | TOKEN | EMAIL | PASSMAIL";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // uIDPASS2FAEMAILPASSMAILToolStripMenuItem
            // 
            this.uIDPASS2FAEMAILPASSMAILToolStripMenuItem.Name = "uIDPASS2FAEMAILPASSMAILToolStripMenuItem";
            this.uIDPASS2FAEMAILPASSMAILToolStripMenuItem.Size = new System.Drawing.Size(477, 26);
            this.uIDPASS2FAEMAILPASSMAILToolStripMenuItem.Text = "UID | PASS | 2FA | EMAIL | PASSMAIL";
            this.uIDPASS2FAEMAILPASSMAILToolStripMenuItem.Click += new System.EventHandler(this.uIDPASS2FAEMAILPASSMAILToolStripMenuItem_Click);
            // 
            // uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem
            // 
            this.uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem.Name = "uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem";
            this.uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem.Size = new System.Drawing.Size(477, 26);
            this.uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem.Text = "UID | PASS | 2FA | COOKIE | TOKEN | EMAIL | PASSMAIL | UA";
            this.uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem.Click += new System.EventHandler(this.uIDPASS2FACOOKIETOKENEMAILPASSMAILUAToolStripMenuItem_Click);
            // 
            // rEFRESHDỮLIỆUToolStripMenuItem
            // 
            this.rEFRESHDỮLIỆUToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.rEFRESHDỮLIỆUToolStripMenuItem.ForeColor = System.Drawing.Color.OliveDrab;
            this.rEFRESHDỮLIỆUToolStripMenuItem.Name = "rEFRESHDỮLIỆUToolStripMenuItem";
            this.rEFRESHDỮLIỆUToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.rEFRESHDỮLIỆUToolStripMenuItem.Text = "REFRESH DỮ LIỆU";
            this.rEFRESHDỮLIỆUToolStripMenuItem.Click += new System.EventHandler(this.rEFRESHDỮLIỆUToolStripMenuItem_Click);
            // 
            // sỬAGHICHÚToolStripMenuItem
            // 
            this.sỬAGHICHÚToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.sỬAGHICHÚToolStripMenuItem.Name = "sỬAGHICHÚToolStripMenuItem";
            this.sỬAGHICHÚToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.sỬAGHICHÚToolStripMenuItem.Text = "SỬA GHI CHÚ";
            this.sỬAGHICHÚToolStripMenuItem.Click += new System.EventHandler(this.sỬAGHICHÚToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem4.ForeColor = System.Drawing.Color.DarkOrange;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(321, 22);
            this.toolStripMenuItem4.Text = "BẬT 2FA REQUEST";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // checkLiveUidToolStripMenuItem
            // 
            this.checkLiveUidToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.checkLiveUidToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkLiveUidToolStripMenuItem.Name = "checkLiveUidToolStripMenuItem";
            this.checkLiveUidToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.checkLiveUidToolStripMenuItem.Text = "CHECK LIVE UID";
            this.checkLiveUidToolStripMenuItem.Click += new System.EventHandler(this.checkLiveUidToolStripMenuItem_Click);
            // 
            // combo_DanhMuc
            // 
            this.combo_DanhMuc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_DanhMuc.FormattingEnabled = true;
            this.combo_DanhMuc.Location = new System.Drawing.Point(448, 59);
            this.combo_DanhMuc.Name = "combo_DanhMuc";
            this.combo_DanhMuc.Size = new System.Drawing.Size(90, 26);
            this.combo_DanhMuc.TabIndex = 1;
            this.combo_DanhMuc.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(349, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Danh mục:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkLabel7);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label30);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1302, 571);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cấu hình Reg";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkLabel7
            // 
            this.linkLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(120)))), ((int)(((byte)(229)))));
            this.linkLabel7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel7.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel7.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel7.ForeColor = System.Drawing.Color.White;
            this.linkLabel7.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel7.Image")));
            this.linkLabel7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel7.Location = new System.Drawing.Point(624, 521);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(154, 36);
            this.linkLabel7.TabIndex = 46;
            this.linkLabel7.Text = "Lưu Cấu Hình";
            this.linkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel7.UseVisualStyleBackColor = false;
            this.linkLabel7.Click += new System.EventHandler(this.linkLabel7_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txt_folder_anh);
            this.groupBox3.Controls.Add(this.cb_addmail282);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.comboimage);
            this.groupBox3.Controls.Add(this.cbngonngu);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.cbgetcookiemoi);
            this.groupBox3.Controls.Add(this.txt_cover);
            this.groupBox3.Controls.Add(this.txt_avatar);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.combologin);
            this.groupBox3.Controls.Add(this.cbcover);
            this.groupBox3.Controls.Add(this.cbavatar);
            this.groupBox3.Controls.Add(this.cbnghenghiep);
            this.groupBox3.Controls.Add(this.cbnoisong);
            this.groupBox3.Controls.Add(this.cbquequan);
            this.groupBox3.Controls.Add(this.cb2fa);
            this.groupBox3.Location = new System.Drawing.Point(970, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 506);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cấu hình cập nhật thông tin và unlock 282";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(266, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 21);
            this.button3.TabIndex = 36;
            this.button3.Text = "Mở";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 387);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 17);
            this.label13.TabIndex = 34;
            this.label13.Text = "Folder ảnh:";
            // 
            // txt_folder_anh
            // 
            this.txt_folder_anh.Location = new System.Drawing.Point(99, 381);
            this.txt_folder_anh.Name = "txt_folder_anh";
            this.txt_folder_anh.Size = new System.Drawing.Size(161, 24);
            this.txt_folder_anh.TabIndex = 35;
            // 
            // cb_addmail282
            // 
            this.cb_addmail282.AutoSize = true;
            this.cb_addmail282.Location = new System.Drawing.Point(20, 286);
            this.cb_addmail282.Name = "cb_addmail282";
            this.cb_addmail282.Size = new System.Drawing.Size(247, 21);
            this.cb_addmail282.TabIndex = 33;
            this.cb_addmail282.Text = "Thêm mail khi unlock 282 từ file";
            this.cb_addmail282.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(17, 352);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(89, 17);
            this.label26.TabIndex = 31;
            this.label26.Text = "Image 282:";
            // 
            // comboimage
            // 
            this.comboimage.FormattingEnabled = true;
            this.comboimage.Items.AddRange(new object[] {
            "Ảnh đã lưu trong folder Image",
            "https://boredhumans.com/faces.php",
            "https://this-person-does-not-exist.com",
            "https://www.unrealperson.com",
            "https://fakeface.rest"});
            this.comboimage.Location = new System.Drawing.Point(99, 344);
            this.comboimage.Name = "comboimage";
            this.comboimage.Size = new System.Drawing.Size(218, 25);
            this.comboimage.TabIndex = 32;
            this.comboimage.SelectedIndexChanged += new System.EventHandler(this.comboimage_SelectedIndexChanged);
            // 
            // cbngonngu
            // 
            this.cbngonngu.AutoSize = true;
            this.cbngonngu.Location = new System.Drawing.Point(20, 39);
            this.cbngonngu.Name = "cbngonngu";
            this.cbngonngu.Size = new System.Drawing.Size(210, 21);
            this.cbngonngu.TabIndex = 30;
            this.cbngonngu.Text = "Đổi ngôn ngữ theo cài đặt";
            this.cbngonngu.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(266, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 21);
            this.button2.TabIndex = 27;
            this.button2.Text = "Chọn";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 21);
            this.button1.TabIndex = 26;
            this.button1.Text = "Chọn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbgetcookiemoi
            // 
            this.cbgetcookiemoi.AutoSize = true;
            this.cbgetcookiemoi.Location = new System.Drawing.Point(20, 246);
            this.cbgetcookiemoi.Name = "cbgetcookiemoi";
            this.cbgetcookiemoi.Size = new System.Drawing.Size(149, 21);
            this.cbgetcookiemoi.TabIndex = 25;
            this.cbgetcookiemoi.Text = "Get lại cookie mới";
            this.cbgetcookiemoi.UseVisualStyleBackColor = true;
            // 
            // txt_cover
            // 
            this.txt_cover.Location = new System.Drawing.Point(161, 203);
            this.txt_cover.Name = "txt_cover";
            this.txt_cover.Size = new System.Drawing.Size(99, 24);
            this.txt_cover.TabIndex = 24;
            // 
            // txt_avatar
            // 
            this.txt_avatar.Location = new System.Drawing.Point(161, 163);
            this.txt_avatar.Name = "txt_avatar";
            this.txt_avatar.Size = new System.Drawing.Size(99, 24);
            this.txt_avatar.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 426);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 17);
            this.label17.TabIndex = 21;
            this.label17.Text = "Login bằng:";
            // 
            // combologin
            // 
            this.combologin.FormattingEnabled = true;
            this.combologin.Items.AddRange(new object[] {
            "Uid|Pass",
            "Cookie"});
            this.combologin.Location = new System.Drawing.Point(99, 418);
            this.combologin.Name = "combologin";
            this.combologin.Size = new System.Drawing.Size(218, 25);
            this.combologin.TabIndex = 22;
            // 
            // cbcover
            // 
            this.cbcover.AutoSize = true;
            this.cbcover.Location = new System.Drawing.Point(20, 205);
            this.cbcover.Name = "cbcover";
            this.cbcover.Size = new System.Drawing.Size(135, 21);
            this.cbcover.TabIndex = 20;
            this.cbcover.Text = "Cập nhật cover";
            this.cbcover.UseVisualStyleBackColor = true;
            // 
            // cbavatar
            // 
            this.cbavatar.AutoSize = true;
            this.cbavatar.Location = new System.Drawing.Point(20, 165);
            this.cbavatar.Name = "cbavatar";
            this.cbavatar.Size = new System.Drawing.Size(141, 21);
            this.cbavatar.TabIndex = 19;
            this.cbavatar.Text = "Cập nhật avatar";
            this.cbavatar.UseVisualStyleBackColor = true;
            // 
            // cbnghenghiep
            // 
            this.cbnghenghiep.AutoSize = true;
            this.cbnghenghiep.Location = new System.Drawing.Point(20, 121);
            this.cbnghenghiep.Name = "cbnghenghiep";
            this.cbnghenghiep.Size = new System.Drawing.Size(183, 21);
            this.cbnghenghiep.TabIndex = 17;
            this.cbnghenghiep.Text = "Cập nhật nghề nghiệp";
            this.cbnghenghiep.UseVisualStyleBackColor = true;
            // 
            // cbnoisong
            // 
            this.cbnoisong.AutoSize = true;
            this.cbnoisong.Location = new System.Drawing.Point(161, 79);
            this.cbnoisong.Name = "cbnoisong";
            this.cbnoisong.Size = new System.Drawing.Size(156, 21);
            this.cbnoisong.TabIndex = 16;
            this.cbnoisong.Text = "Cập nhật nơi sống";
            this.cbnoisong.UseVisualStyleBackColor = true;
            // 
            // cbquequan
            // 
            this.cbquequan.AutoSize = true;
            this.cbquequan.Location = new System.Drawing.Point(20, 79);
            this.cbquequan.Name = "cbquequan";
            this.cbquequan.Size = new System.Drawing.Size(162, 21);
            this.cbquequan.TabIndex = 15;
            this.cbquequan.Text = "Cập nhật quê quán";
            this.cbquequan.UseVisualStyleBackColor = true;
            // 
            // cb2fa
            // 
            this.cb2fa.AutoSize = true;
            this.cb2fa.Location = new System.Drawing.Point(187, 246);
            this.cb2fa.Name = "cb2fa";
            this.cb2fa.Size = new System.Drawing.Size(80, 21);
            this.cb2fa.TabIndex = 14;
            this.cb2fa.Text = "Bật 2fa";
            this.cb2fa.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Location = new System.Drawing.Point(431, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 506);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình Reg - Unlock";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.nbr_getphoneagain);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.combosex);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label22);
            this.groupBox8.Controls.Add(this.combomail);
            this.groupBox8.Controls.Add(this.comboten);
            this.groupBox8.Controls.Add(this.cb_ngonngureg);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.cbverify);
            this.groupBox8.Controls.Add(this.numericUpDown2);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.numericUpDown3);
            this.groupBox8.Controls.Add(this.combongonngu);
            this.groupBox8.Controls.Add(this.cbgiuanh);
            this.groupBox8.Controls.Add(this.cbregkhongunlockkhongcaptcha);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.cbregkhongunlock);
            this.groupBox8.Controls.Add(this.numericUpDown4);
            this.groupBox8.Location = new System.Drawing.Point(20, 254);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(500, 255);
            this.groupBox8.TabIndex = 39;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Cấu hình Reg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Loại Email:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(29, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 17);
            this.label22.TabIndex = 21;
            this.label22.Text = "Tên reg:";
            // 
            // combomail
            // 
            this.combomail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combomail.FormattingEnabled = true;
            this.combomail.Items.AddRange(new object[] {
            "Mailtm",
            "Hotmail",
            "Emailfake.com"});
            this.combomail.Location = new System.Drawing.Point(115, 23);
            this.combomail.Name = "combomail";
            this.combomail.Size = new System.Drawing.Size(366, 26);
            this.combomail.TabIndex = 20;
            // 
            // comboten
            // 
            this.comboten.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboten.FormattingEnabled = true;
            this.comboten.Items.AddRange(new object[] {
            "Tên việt",
            "Tên ngoại"});
            this.comboten.Location = new System.Drawing.Point(115, 54);
            this.comboten.Name = "comboten";
            this.comboten.Size = new System.Drawing.Size(110, 26);
            this.comboten.TabIndex = 22;
            // 
            // cb_ngonngureg
            // 
            this.cb_ngonngureg.AutoSize = true;
            this.cb_ngonngureg.Location = new System.Drawing.Point(8, 215);
            this.cb_ngonngureg.Name = "cb_ngonngureg";
            this.cb_ngonngureg.Size = new System.Drawing.Size(130, 21);
            this.cb_ngonngureg.TabIndex = 33;
            this.cb_ngonngureg.Text = "Đổi ngôn ngữ:";
            this.cb_ngonngureg.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Delay reg:";
            // 
            // cbverify
            // 
            this.cbverify.AutoSize = true;
            this.cbverify.Location = new System.Drawing.Point(8, 188);
            this.cbverify.Name = "cbverify";
            this.cbverify.Size = new System.Drawing.Size(243, 21);
            this.cbverify.TabIndex = 32;
            this.cbverify.Text = "Verify mail nếu account reg live";
            this.cbverify.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(436, 107);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(45, 24);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(297, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(165, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Lấy code phone tối đa:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(436, 134);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(45, 24);
            this.numericUpDown3.TabIndex = 11;
            this.numericUpDown3.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // combongonngu
            // 
            this.combongonngu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combongonngu.FormattingEnabled = true;
            this.combongonngu.Items.AddRange(new object[] {
            "vi_VN",
            "en_US",
            "zh_TW",
            "es_LA",
            "fr_FR",
            "ko_KR",
            "pt_BR"});
            this.combongonngu.Location = new System.Drawing.Point(121, 213);
            this.combongonngu.Name = "combongonngu";
            this.combongonngu.Size = new System.Drawing.Size(171, 26);
            this.combongonngu.TabIndex = 25;
            // 
            // cbgiuanh
            // 
            this.cbgiuanh.AutoSize = true;
            this.cbgiuanh.Location = new System.Drawing.Point(9, 107);
            this.cbgiuanh.Name = "cbgiuanh";
            this.cbgiuanh.Size = new System.Drawing.Size(132, 21);
            this.cbgiuanh.TabIndex = 13;
            this.cbgiuanh.Text = "Giữ lại ảnh 282";
            this.cbgiuanh.UseVisualStyleBackColor = true;
            // 
            // cbregkhongunlockkhongcaptcha
            // 
            this.cbregkhongunlockkhongcaptcha.AutoSize = true;
            this.cbregkhongunlockkhongcaptcha.Location = new System.Drawing.Point(8, 161);
            this.cbregkhongunlockkhongcaptcha.Name = "cbregkhongunlockkhongcaptcha";
            this.cbregkhongunlockkhongcaptcha.Size = new System.Drawing.Size(307, 21);
            this.cbregkhongunlockkhongcaptcha.TabIndex = 23;
            this.cbregkhongunlockkhongcaptcha.Text = "Reg không unlock ( không giải captcha )";
            this.cbregkhongunlockkhongcaptcha.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(328, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "Lấy phone tối đa:";
            // 
            // cbregkhongunlock
            // 
            this.cbregkhongunlock.AutoSize = true;
            this.cbregkhongunlock.Location = new System.Drawing.Point(8, 134);
            this.cbregkhongunlock.Name = "cbregkhongunlock";
            this.cbregkhongunlock.Size = new System.Drawing.Size(251, 21);
            this.cbregkhongunlock.TabIndex = 17;
            this.cbregkhongunlock.Text = "Reg không unlock (giải captcha)";
            this.cbregkhongunlock.UseVisualStyleBackColor = true;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(436, 164);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(45, 24);
            this.numericUpDown4.TabIndex = 15;
            this.numericUpDown4.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.txt_apicaptcha);
            this.groupBox7.Controls.Add(this.combocaptcha);
            this.groupBox7.Location = new System.Drawing.Point(20, 148);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(500, 100);
            this.groupBox7.TabIndex = 38;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Captcha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Api captcha:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Captcha:";
            // 
            // txt_apicaptcha
            // 
            this.txt_apicaptcha.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_apicaptcha.Location = new System.Drawing.Point(131, 22);
            this.txt_apicaptcha.Name = "txt_apicaptcha";
            this.txt_apicaptcha.Size = new System.Drawing.Size(350, 26);
            this.txt_apicaptcha.TabIndex = 7;
            // 
            // combocaptcha
            // 
            this.combocaptcha.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combocaptcha.FormattingEnabled = true;
            this.combocaptcha.Items.AddRange(new object[] {
            "Anycaptcha",
            "Omocaptcha",
            "2Captcha"});
            this.combocaptcha.Location = new System.Drawing.Point(131, 60);
            this.combocaptcha.Name = "combocaptcha";
            this.combocaptcha.Size = new System.Drawing.Size(350, 26);
            this.combocaptcha.TabIndex = 9;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txt_apiphone);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.comboserver);
            this.groupBox6.Controls.Add(this.combophone);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Location = new System.Drawing.Point(20, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(500, 119);
            this.groupBox6.TabIndex = 37;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Phone";
            // 
            // txt_apiphone
            // 
            this.txt_apiphone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_apiphone.Location = new System.Drawing.Point(131, 31);
            this.txt_apiphone.Name = "txt_apiphone";
            this.txt_apiphone.Size = new System.Drawing.Size(350, 26);
            this.txt_apiphone.TabIndex = 1;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(297, 81);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(85, 17);
            this.label29.TabIndex = 36;
            this.label29.Text = "Server sim:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Api:";
            // 
            // comboserver
            // 
            this.comboserver.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboserver.FormattingEnabled = true;
            this.comboserver.Items.AddRange(new object[] {
            "Server việt",
            "Server ngoại"});
            this.comboserver.Location = new System.Drawing.Point(371, 78);
            this.comboserver.Name = "comboserver";
            this.comboserver.Size = new System.Drawing.Size(110, 26);
            this.comboserver.TabIndex = 35;
            // 
            // combophone
            // 
            this.combophone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combophone.FormattingEnabled = true;
            this.combophone.Items.AddRange(new object[] {
            "tempcode.co",
            "otp282.com",
            "codetext247",
            "sim24.cc",
            "viotp.com",
            "tempsms.co",
            "chothuesimcode.com",
            "bossotp.com",
            "test.bossotp.com",
            "2ndline.io",
            "trumotpvn.com",
            "winmail.shop",
            "hcotp.com",
            "sellotp.com",
            "supersim247.com",
            "goodotp.xyz",
            "atmteam",
            "good9.fun",
            "otpngon.com",
            "fb282.vn",
            "numberotp.co",
            "atmteam cũ",
            "sell282.xyz",
            "sellotpvn.com",
            "otpygo.com",
            "vutruotp.com",
			"ironsim.com"});
            this.combophone.Location = new System.Drawing.Point(131, 78);
            this.combophone.Name = "combophone";
            this.combophone.Size = new System.Drawing.Size(126, 26);
            this.combophone.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(32, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 17);
            this.label18.TabIndex = 18;
            this.label18.Text = "Site phone:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.linkLabel14);
            this.groupBox1.Controls.Add(this.linkLabel10);
            this.groupBox1.Controls.Add(this.linkLabel11);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.numericUpDown7);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.cb_180day);
            this.groupBox1.Controls.Add(this.numericUpDown6);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.numericUpDown5);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.txt_proxyv6net);
            this.groupBox1.Controls.Add(this.cbaddview);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.txt_linkserver);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.comboip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 506);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình chung";
            // 
            // linkLabel14
            // 
            this.linkLabel14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel14.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel14.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel14.Location = new System.Drawing.Point(153, 434);
            this.linkLabel14.Name = "linkLabel14";
            this.linkLabel14.Size = new System.Drawing.Size(116, 29);
            this.linkLabel14.TabIndex = 46;
            this.linkLabel14.Text = "Proxy HTTP";
            this.linkLabel14.UseVisualStyleBackColor = false;
            this.linkLabel14.Click += new System.EventHandler(this.linkLabel14_Click);
            // 
            // linkLabel10
            // 
            this.linkLabel10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel10.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel10.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel10.Location = new System.Drawing.Point(21, 469);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(119, 24);
            this.linkLabel10.TabIndex = 46;
            this.linkLabel10.Text = "Get Mail";
            this.linkLabel10.UseVisualStyleBackColor = false;
            this.linkLabel10.Click += new System.EventHandler(this.linkLabel10_Click);
            // 
            // linkLabel11
            // 
            this.linkLabel11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel11.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.linkLabel11.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.linkLabel11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel11.Location = new System.Drawing.Point(21, 435);
            this.linkLabel11.Name = "linkLabel11";
            this.linkLabel11.Size = new System.Drawing.Size(119, 28);
            this.linkLabel11.TabIndex = 46;
            this.linkLabel11.Text = "Add List Mail";
            this.linkLabel11.UseVisualStyleBackColor = false;
            this.linkLabel11.Click += new System.EventHandler(this.linkLabel11_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(223, 341);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(36, 17);
            this.label33.TabIndex = 45;
            this.label33.Text = "giây";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(153, 335);
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(64, 24);
            this.numericUpDown7.TabIndex = 44;
            this.numericUpDown7.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(8, 341);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(132, 17);
            this.label32.TabIndex = 43;
            this.label32.Text = "Delay mở chrome:";
            // 
            // cb_180day
            // 
            this.cb_180day.AutoSize = true;
            this.cb_180day.Location = new System.Drawing.Point(11, 410);
            this.cb_180day.Name = "cb_180day";
            this.cb_180day.Size = new System.Drawing.Size(201, 21);
            this.cb_180day.TabIndex = 42;
            this.cb_180day.Text = "Chỉ unlock 282 180 ngày";
            this.cb_180day.UseVisualStyleBackColor = true;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(238, 371);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(64, 24);
            this.numericUpDown6.TabIndex = 41;
            this.numericUpDown6.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(221, 377);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 17);
            this.label21.TabIndex = 40;
            this.label21.Text = "X";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(153, 371);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(64, 24);
            this.numericUpDown5.TabIndex = 39;
            this.numericUpDown5.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 377);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 17);
            this.label14.TabIndex = 38;
            this.label14.Text = "Sắp xếp chrome";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 225);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(123, 17);
            this.label27.TabIndex = 36;
            this.label27.Text = "Api proxyv6.net:";
            // 
            // txt_proxyv6net
            // 
            this.txt_proxyv6net.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_proxyv6net.Location = new System.Drawing.Point(153, 219);
            this.txt_proxyv6net.Name = "txt_proxyv6net";
            this.txt_proxyv6net.Size = new System.Drawing.Size(243, 26);
            this.txt_proxyv6net.TabIndex = 37;
            this.txt_proxyv6net.Text = "e3f86445-249f-49f2-80f8-1a9c9ce6ef74";
            // 
            // cbaddview
            // 
            this.cbaddview.AutoSize = true;
            this.cbaddview.Location = new System.Drawing.Point(223, 300);
            this.cbaddview.Name = "cbaddview";
            this.cbaddview.Size = new System.Drawing.Size(222, 21);
            this.cbaddview.TabIndex = 31;
            this.cbaddview.Text = "Thêm chrome vào màn hình";
            this.cbaddview.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 262);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(161, 17);
            this.label25.TabIndex = 13;
            this.label25.Text = "Link OCB/Mobi proxy:";
            // 
            // txt_linkserver
            // 
            this.txt_linkserver.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_linkserver.Location = new System.Drawing.Point(153, 256);
            this.txt_linkserver.Name = "txt_linkserver";
            this.txt_linkserver.Size = new System.Drawing.Size(243, 26);
            this.txt_linkserver.TabIndex = 14;
            this.txt_linkserver.Text = "http://115.77.46.36/";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(153, 298);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 24);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Luồng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại proxy:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Green;
            this.richTextBox1.Location = new System.Drawing.Point(11, 101);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(400, 104);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // comboip
            // 
            this.comboip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboip.FormattingEnabled = true;
            this.comboip.Items.AddRange(new object[] {
            "TINSOFT",
            "TMPROXY",
            "SHOPLIKEPROXY",
            "LISTPROXY",
            "WIFI",
            "MOBIPROXY",
            "OCBPROXY",
            "XPROXY",
            "MINPROXY",
            "PROXYV6.NET",
            "PROXYFB.COM"});
            this.comboip.Location = new System.Drawing.Point(90, 31);
            this.comboip.Name = "comboip";
            this.comboip.Size = new System.Drawing.Size(321, 26);
            this.comboip.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(8, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(486, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thả key tinsoft,tm,shoplike,minproxy bên dưới ( 1 key / luồng0 chrome )";
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label30.Location = new System.Drawing.Point(242, 546);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(1207, 19);
            this.label30.TabIndex = 33;
            this.label30.Text = "LƯU Ý: Ở ACTION: MỞ KHÓA CHECKPOINT 282 ĐỐI VỚI ACCOUNT DIE 282 NEW ( CHƯA MỞ LẦN" +
    " NÀO ) KHI UNLOCK KHÔNG ĐỔI ĐƯỢC NGÔN NGỮ";
            this.label30.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.flowLayoutPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1302, 571);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Form view chrome";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1288, 559);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(251, 62);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(69, 17);
            this.label34.TabIndex = 39;
            this.label34.Text = "Giới tính:";
            // 
            // combosex
            // 
            this.combosex.FormattingEnabled = true;
            this.combosex.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Random"});
            this.combosex.Location = new System.Drawing.Point(315, 54);
            this.combosex.Name = "combosex";
            this.combosex.Size = new System.Drawing.Size(166, 25);
            this.combosex.TabIndex = 40;
            // 
            // nbr_getphoneagain
            // 
            this.nbr_getphoneagain.Location = new System.Drawing.Point(442, 194);
            this.nbr_getphoneagain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nbr_getphoneagain.Name = "nbr_getphoneagain";
            this.nbr_getphoneagain.Size = new System.Drawing.Size(39, 24);
            this.nbr_getphoneagain.TabIndex = 42;
            this.nbr_getphoneagain.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(360, 200);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(103, 17);
            this.label35.TabIndex = 41;
            this.label35.Text = "Lấy lại phone:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1310, 601);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reg Clone Facebook v23.04.12";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbr_getphoneagain)).EndInit();
            this.ResumeLayout(false);

		}

		static Form1()
		{
			getWidthScreen = Screen.PrimaryScreen.WorkingArea.Width;
			getHeightScreen = Screen.PrimaryScreen.WorkingArea.Height;
			WS_VISIBLE = 268435456;
			Num_LuongProxyAPI = 1;
			ohguey = "WkFMTyBBRE1JTjogWzA4NTY0NjY4MjNd";
			ListAPI = new List<string>();
			//softname = "facebook";
			//hostname = "https://xtechsoftware.site/daoxuandang/" + softname + "/";
		}

		public bool method_42(string string_15, string string_16)
		{
			string requestUriString = "https://api.unrealperson.com/person";
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				if (string_16 != "")
				{
					if (string_16.Split(':').Length <= 2)
					{
						httpWebRequest.Proxy = new WebProxy(string_16);
					}
					else
					{
						httpWebRequest.Proxy = new WebProxy(string_16.Split(':')[0] + ":" + string_16.Split(':')[1]);
						httpWebRequest.Proxy.Credentials = new NetworkCredential(string_16.Split(':')[2], string_16.Split(':')[3]);
					}
				}
				httpWebRequest.KeepAlive = true;
				httpWebRequest.Host = "api.unrealperson.com";
				httpWebRequest.Headers["Origin"] = "https://www.unrealperson.com";
				httpWebRequest.Referer = "https://www.unrealperson.com/";
				httpWebRequest.Headers["sec-ch-ua"] = "\"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Google Chrome\";v=\"110\"";
				httpWebRequest.Headers["sec-ch-ua-mobile"] = "?0";
				httpWebRequest.Headers["sec-ch-ua-platform"] = "\"Windows\"";
				httpWebRequest.Headers["Sec-Fetch-Dest"] = "empty";
				httpWebRequest.Headers["Sec-Fetch-Mode"] = "cors";
				httpWebRequest.Headers["Sec-Fetch-Site"] = "same-site";
				httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36";
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
				string text = streamReader.ReadToEnd();
				if (!text.Contains("image_url"))
				{
					return false;
				}
				string value = Regex.Match(text, "image_url\":\"(.*?)\"").Groups[1].Value;
				if (!(value != "") || value == null)
				{
					return false;
				}
				string address = "https://api.unrealperson.com/image?name=" + value + "&type=tpdne";
				WebClient webClient = new WebClient();
				webClient.Headers["keep-alive"] = "true";
				webClient.Headers["Host"] = "api.unrealperson.com";
				webClient.Headers["Origin"] = "https://www.unrealperson.com";
				webClient.Headers["Referer"] = "https://www.unrealperson.com/";
				webClient.Headers["sec-ch-ua"] = "\"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Google Chrome\";v=\"110\"";
				webClient.Headers["sec-ch-ua-mobile"] = "?0";
				webClient.Headers["sec-ch-ua-platform"] = "\"Windows\"";
				webClient.Headers["Sec-Fetch-Dest"] = "empty";
				webClient.Headers["Sec-Fetch-Mode"] = "cors";
				webClient.Headers["Sec-Fetch-Site"] = "same-site";
				webClient.Headers["UserAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36";
				Stream stream = webClient.OpenRead(address);
				new Bitmap(stream)?.Save(string_12 + "\\Image\\" + string_15 + ".png");
				stream.Flush();
				stream.Close();
				webClient.Dispose();
			}
			catch
			{
				return false;
			}
			return true;
		}

		public bool method_43(string string_15)
		{
			string requestUriString = "https://fakeface.rest/face/json";
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36";
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
				string text = streamReader.ReadToEnd();
				if (!text.Contains("image_url"))
				{
					return false;
				}
				string value = Regex.Match(text, "image_url\":\"(.*?)\"").Groups[1].Value;
				if (!(value != "") || value == null)
				{
					return false;
				}
				WebClient webClient = new WebClient();
				Stream stream = webClient.OpenRead(value);
				new Bitmap(stream)?.Save(string_12 + "\\Image\\" + string_15 + ".png");
				stream.Flush();
				stream.Close();
				webClient.Dispose();
			}
			catch
			{
				return false;
			}
			return true;
		}

		public bool method_40(string string_15, string string_16)
		{
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://this-person-does-not-exist.com/en?new=1676973494005");
				if (string_16 != "")
				{
					if (string_16.Split(':').Length <= 2)
					{
						httpWebRequest.Proxy = new WebProxy(string_16);
					}
					else
					{
						httpWebRequest.Proxy = new WebProxy(string_16.Split(':')[0] + ":" + string_16.Split(':')[1]);
						httpWebRequest.Proxy.Credentials = new NetworkCredential(string_16.Split(':')[2], string_16.Split(':')[3]);
					}
				}
				httpWebRequest.Method = "GET";
				httpWebRequest.Headers["x-requested-with"] = "XMLHttpRequest";
				httpWebRequest.Referer = "https://this-person-does-not-exist.com/vi";
				httpWebRequest.Host = "this-person-does-not-exist.com";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				string text = streamReader.ReadToEnd();
				if (!text.Contains(".jpg"))
				{
					return false;
				}
				text = text.Replace("\\", "");
				string address = "https://this-person-does-not-exist.com" + Regex.Match(text, "src\":\"(.*?)\"").Groups[1].Value;
				WebClient webClient = new WebClient();
				Stream stream = webClient.OpenRead(address);
				new Bitmap(stream)?.Save(string_12 + "\\Image\\" + string_15 + ".png");
				stream.Flush();
				stream.Close();
				webClient.Dispose();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool method_41(string string_15, string string_16)
		{
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://boredhumans.com/api_faces2.php");
				if (string_16 != "")
				{
					if (string_16.Split(':').Length <= 2)
					{
						httpWebRequest.Proxy = new WebProxy(string_16);
					}
					else
					{
						httpWebRequest.Proxy = new WebProxy(string_16.Split(':')[0] + ":" + string_16.Split(':')[1]);
						httpWebRequest.Proxy.Credentials = new NetworkCredential(string_16.Split(':')[2], string_16.Split(':')[3]);
					}
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.Headers["x-requested-with"] = "XMLHttpRequest";
				httpWebRequest.Headers["origin"] = "https://boredhumans.com";
				httpWebRequest.Referer = "https://boredhumans.com/faces.php";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				string value = "stories=true";
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				string text = streamReader.ReadToEnd();
				if (text.Contains(".jpg"))
				{
					WebClient webClient = new WebClient();
					Stream stream = webClient.OpenRead(Regex.Match(text, "src=\"(.*?)\"").Groups[1].Value);
					new Bitmap(stream)?.Save(string_12 + "\\Image\\" + string_15 + ".png");
					stream.Flush();
					stream.Close();
					webClient.Dispose();
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}

		protected void method_11(double double_0)
		{
			Thread.Sleep((int)(1000.0 * double_0));
		}

		public void method_44(string string_15, string string_16)
		{
			WebClient webClient = new WebClient();
			Stream stream = webClient.OpenRead(string_16);
			new Bitmap(stream)?.Save(string_12 + "\\Image\\" + string_15 + ".png");
			stream.Flush();
			stream.Close();
			webClient.Dispose();
		}

		public void method_45()
		{
			WebClient webClient = new WebClient();
			Stream stream = webClient.OpenRead("https://mbasic.facebook.com/captcha/tfbimage.php?captcha_challenge_code=1672681553-8e02d1ca35df7d22d7bc615b11d42a1c&captcha_challenge_hash=AZnvQVbV_2qboQZLVGcDIA42MhY9cFVzfiDILE8qcF9kj6DWr1ZubHWuGpVDPqFhPY08se6gKCaUYQiwkKSpwLGGd1f8Y-24x_tr5SG3oTubJtmfvFaoTrrZdiFI-jfs9iERXsqvwJNkvbMnhF6Q8ZL9sV4yCi6KqPIY_XYQf2VgWHnRG6MOSGot2acEcnlgRBQ");
			new Bitmap(stream)?.Save(string_12 + "\\Image\\1.png");
			stream.Flush();
			stream.Close();
			webClient.Dispose();
		}

        private void linkLabel13_Click(object sender, EventArgs e)
        {
			try
			{
				Process[] processesByName = Process.GetProcessesByName("chromedriver");
				Process[] array = processesByName;
				foreach (Process process in array)
				{
					process.Kill();
				}
			}
			catch
			{
			}
			MessageBox.Show("Done kill", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

        private void linkLabel17_Click(object sender, EventArgs e)
        {
			try
			{
				Process[] processesByName = Process.GetProcessesByName("chrome");
				Process[] array = processesByName;
				foreach (Process process in array)
				{
					process.Kill();
				}
			}
			catch
			{
			}
			MessageBox.Show("Done kill", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void KillChromeDriver(string chromedriver)
        {
			try
			{
				string contents = "TASKKILL /F /IM " + chromedriver + ".exe /T";
				File.WriteAllText("kill.bat", contents);
				Process.Start("kill.bat");
			}
			catch
			{
			}
		}
		public static string GetInfoChrome()
		{
			string result = "";
			string newValue = "chrome.exe";
			object value = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\<executableFileName>".Replace("<executableFileName>", newValue), "", null);
			if (value == null)
			{
				value = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\<executableFileName>".Replace("<executableFileName>", newValue), "", null);
				if (value != null)
				{
					result = value.ToString();
				}
			}
			else
			{
				result = value.ToString();
			}
			return result;
		}
		
		public static string GetVersionInfo()
		{
			return FileVersionInfo.GetVersionInfo(GetInfoChrome().ToString()).FileVersion;
		}
		public static bool DeleteFile(string namefile)
		{
			try
			{
				File.Delete(namefile);
				return true;
			}
			catch
			{
			}
			return false;
		}
		public static string GetDirectoryFile()
		{
			return Path.GetDirectoryName(Application.ExecutablePath);
		}
		private void button4_Click(object sender, EventArgs e)
        {
			 
			try
			{
				KillChromeDriver("chromedriver");
				string text = GetVersionInfo().Split('.')[0];
				if (!(text == ""))
				{
					string input = new Helper("", "", "", 0).Request("https://chromedriver.chromium.org/downloads");
					string value = Regex.Match(input, "path=(" + text + "\\.0\\..*?)/").Groups[1].Value;
					if (!(value == ""))
					{
						DeleteFile(GetDirectoryFile() + "\\chromedriver.exe");
						string downzip = "https://chromedriver.storage.googleapis.com/" + value + "/chromedriver_win32.zip";
						Helper.DownloadForm(downzip);
						MessageBox.Show("Cập nhật ChromeDriver thành công!");
						return;
					}
				}
			}
			catch
			{
			}
			MessageBox.Show("Cập nhật ChromeDriver thất bại!");
		}
    }
}
