using System;
using System.Windows.Forms;

namespace CloneFacebook
{
	internal static class Program
	{
		[STAThread]
		[Obsolete]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new Form1(9999, "MrCr4ck"));
		}
	}
}
