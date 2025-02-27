using System;
using System.Reflection;
using System.Windows.Forms;

namespace CloneFacebook
{
	public static class ExtensionMethods
	{
		public static void DoubleBuffered(this DataGridView dgv, bool setting)
		{
			Type type = dgv.GetType();
			PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(dgv, setting, null);
		}
	}
}
