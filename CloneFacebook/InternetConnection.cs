using System.Runtime.InteropServices;

namespace CloneFacebook
{
	internal class InternetConnection
	{
		[DllImport("wininet.dll")]
		private static extern bool InternetGetConnectedState(out int description, int reservedValuine);

		public static bool IsConnectedToInternet()
		{
			int description;
			return InternetGetConnectedState(out description, 0);
		}
	}
}
