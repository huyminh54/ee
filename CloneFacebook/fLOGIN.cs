using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CloneFacebook.Server;
using CloneFacebook.Server.DataPost;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PHUONGDOAN;
using Xuan.Properties;

namespace CloneFacebook
{
	public class fLOGIN : Form
	{
		private IContainer components = null;

		private LinkLabel linkLabel2;

		private Panel panel5;

		private PictureBox pictureBox5;

		private TextBox txt_mamay;

		private PictureBox pictureBox4;

		private Label label3;

		private Label label8;

		private LinkLabel linkLabel1;

		private Label label7;

		private Button button3;

		private Button button2;

		private Button button1;

		private Label label2;

		private Label label1;

		private PictureBox pictureBox1;

		private Panel panel1;

		private Panel panel2;

		[Obsolete]
		public fLOGIN()
		{
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
			if (string.IsNullOrEmpty(Settings.Default.License))
			{
				string text = DeviceID().Replace("}", "").Replace("{", "");
				text += "_REG_UNLOCK";
				text = CryptorHelper.CreateMD5(text);
				Settings.Default.License = text;
				Settings.Default.Save();
			}
			txt_mamay.Text = Settings.Default.License;
			DataManager.License = txt_mamay.Text;
		}

		public static string MD5Hash(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = mD5CryptoServiceProvider.ComputeHash(new UTF8Encoding().GetBytes(input));
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		public string DeviceID()
		{
			try
			{
				RegistryKey registryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Environment.MachineName, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
				registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\SQMClient", writable: false);
				if (registryKey == null)
				{
					return string.Empty;
				}
				return registryKey.GetValue("MachineId").ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(txt_mamay.Text);
			MessageBox.Show(string.Format("Đã sao chép mã thiết bị", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk));
		}

		private void fLOGIN_Load(object sender, EventArgs e)
		{
			RequestServer.InitParameterServer();
		}

		[Obsolete]
		public void CheckKey(string key)
		{
			try
			{
				RequestXNet requestXNet = new RequestXNet();
				string[] array = requestXNet.RequestGet("https://xtechsoftware.site/check-key.php?key=" + key).ToString().Split('|');
				if (array[0].Contains(Convert.ToString("expired")))
				{
					MessageBox.Show("KEY HẾT HẠN!! LIÊN HỆ ADMIN ĐỂ GIA HẠN THÊM!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else if (array[0].Contains(Convert.ToString(key)))
				{
					DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
					DateTime dateTime2 = Convert.ToDateTime(array[1]);
					int days = (dateTime2 - dateTime).Days;
					Hide();
					Form1 f = new Form1(days, array[2].Replace(" ", ""));
					Invoke((Action)delegate
					{
						f.ShowDialog();
					});
				}
				else
				{
					MessageBox.Show("CHƯA KÍCH HOẠT !!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("LỖI " + ex.Message + "!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("chrome.exe", "https://www.facebook.com/100055769371149");
			}
			catch
			{
				Process.Start("https://www.facebook.com/100055769371149");
			}
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("chrome.exe", "https://www.facebook.com/100055769371149");
			}
			catch
			{
				Process.Start("https://www.facebook.com/100055769371149");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("chrome.exe", "https://www.facebook.com/100055769371149");
			}
			catch
			{
				Process.Start("https://www.facebook.com/100055769371149");
			}
		}

		[Obsolete]
		private void button2_Click(object sender, EventArgs e)
		{
			RequestServer.SetLicense(txt_mamay.Text);
			string cipherText = JsonConvert.SerializeObject(new DataAuthentication
			{
				Text = txt_mamay.Text
			});
			string text = RequestServer.PostServer(ServiceServer.Parse(APIAuthentication.Login), RsaCryptor.Encrypt(cipherText));
			JObject jObject = JObject.Parse(text);
			if (text.Contains("Success"))
			{
				DataManager.Status = jObject["Status"]!.ToString();
				DataManager.Token = jObject["Token"]!.ToString();
				DataManager.Expired = jObject["Expired"]!.ToString();
				RequestServer.SetToken(DataManager.Token);
				int num = 0;
				try
				{
					DateTimeOffset timeZoneInfo = TimeZoneHelper.GetTimeZoneInfo();
					num = Convert.ToInt32(DateTimeOffset.ParseExact(DataManager.Expired.Split(new string[1] { " " }, StringSplitOptions.None)[0], "d", null).Subtract(timeZoneInfo).TotalDays);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					num = 10000;
				}
				Hide();
				Form1 f = new Form1(num, "username");
				Invoke((Action)delegate
				{
					f.ShowDialog();
				});
			}
			else
			{
				MessageBox.Show(jObject["Status"]!.ToString(), "Application");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(DataManager.Token) && !string.IsNullOrEmpty(DataManager.Status))
			{
				RequestServer.PostServer(ServiceServer.Parse(APIAuthentication.CloseToken), RsaCryptor.Encrypt(DataManager.Token));
			}
			Application.Exit();
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void fLOGIN_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!string.IsNullOrEmpty(DataManager.Token) && !string.IsNullOrEmpty(DataManager.Status))
			{
				RequestServer.PostServer(ServiceServer.Parse(APIAuthentication.CloseToken), RsaCryptor.Encrypt(DataManager.Token));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloneFacebook.fLOGIN));
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.txt_mamay = new System.Windows.Forms.TextBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label7 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.linkLabel2.LinkColor = System.Drawing.Color.Navy;
			this.linkLabel2.Location = new System.Drawing.Point(284, 351);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(135, 13);
			this.linkLabel2.TabIndex = 13;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "beyonhosa011@gmail.com";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			this.panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel5.Controls.Add(this.pictureBox5);
			this.panel5.Controls.Add(this.txt_mamay);
			this.panel5.Controls.Add(this.pictureBox4);
			this.panel5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel5.Location = new System.Drawing.Point(6, 111);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(450, 45);
			this.panel5.TabIndex = 16;
			this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox5.Image = (System.Drawing.Image)resources.GetObject("pictureBox5.Image");
			this.pictureBox5.Location = new System.Drawing.Point(388, 8);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(38, 30);
			this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox5.TabIndex = 6;
			this.pictureBox5.TabStop = false;
			this.pictureBox5.Click += new System.EventHandler(pictureBox5_Click);
			this.txt_mamay.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.txt_mamay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txt_mamay.ForeColor = System.Drawing.Color.Maroon;
			this.txt_mamay.Location = new System.Drawing.Point(75, 11);
			this.txt_mamay.Name = "txt_mamay";
			this.txt_mamay.ReadOnly = true;
			this.txt_mamay.Size = new System.Drawing.Size(307, 26);
			this.txt_mamay.TabIndex = 5;
			this.pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new System.Drawing.Point(11, 8);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(32, 30);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox4.TabIndex = 2;
			this.pictureBox4.TabStop = false;
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(114, 275);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 15);
			this.label3.TabIndex = 15;
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.White;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = System.Drawing.Color.Gray;
			this.label8.Location = new System.Drawing.Point(75, 350);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(201, 15);
			this.label8.TabIndex = 12;
			this.label8.Text = "Mọi thắc mắc xin liên hệ qua email:";
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.linkLabel1.LinkColor = System.Drawing.Color.Navy;
			this.linkLabel1.Location = new System.Drawing.Point(308, 328);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(37, 13);
			this.linkLabel1.TabIndex = 11;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "XUÂN";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.White;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = System.Drawing.Color.Gray;
			this.label7.Location = new System.Drawing.Point(75, 327);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(231, 15);
			this.label7.TabIndex = 10;
			this.label7.Text = "Sản phẩm JREG thuộc quyền sở hữu của";
			this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
			this.button3.Location = new System.Drawing.Point(236, 170);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(152, 40);
			this.button3.TabIndex = 9;
			this.button3.Text = "FORGOT PASSWORD ?";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(button3_Click);
			this.button2.BackColor = System.Drawing.Color.FromArgb(71, 128, 185);
			this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Verdana", 8.25f);
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(78, 170);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(152, 40);
			this.button2.TabIndex = 8;
			this.button2.Text = "LOGIN";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(button2_Click);
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(71, 128, 185);
			this.button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			this.button1.Location = new System.Drawing.Point(429, 1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(30, 29);
			this.button1.TabIndex = 0;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(button1_Click);
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.Desktop;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(62, 300);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 29);
			this.label2.TabIndex = 5;
			this.label2.Text = "Unlock 282";
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Desktop;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(48, 245);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(178, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login Auto Reg";
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(53, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(186, 213);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(291, 377);
			this.panel1.TabIndex = 6;
			this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel2.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel2.BackgroundImage");
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.linkLabel2);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.linkLabel1);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Location = new System.Drawing.Point(318, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(462, 375);
			this.panel2.TabIndex = 7;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(782, 377);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "fLOGIN";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fLOGIN";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(fLOGIN_FormClosed);
			base.Load += new System.EventHandler(fLOGIN_Load);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
