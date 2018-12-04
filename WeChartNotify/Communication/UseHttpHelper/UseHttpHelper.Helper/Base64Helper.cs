using System;
using System.Text;

namespace UseHttpHelper.Helper
{
	public class Base64Helper
	{
		public static string Base64ToString(string strbase, Encoding encoding)
		{
			byte[] bytes = Convert.FromBase64String(strbase);
			return encoding.GetString(bytes);
		}

		public static string StringToBase64(byte[] bytebase)
		{
			return Convert.ToBase64String(bytebase);
		}

		public static string StringToBase64(string str, Encoding encoding)
		{
			byte[] bytes = encoding.GetBytes(str);
			return Convert.ToBase64String(bytes);
		}
	}
}
