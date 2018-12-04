using System;
using System.Text;

namespace UseHttpHelper.Helper
{
	internal class EncodingHelper
	{
		internal static string ByteToString(byte[] b, Encoding e = null)
		{
			if (e == null)
			{
				e = Encoding.Default;
			}
			return e.GetString(b);
		}

		internal static byte[] StringToByte(string s, Encoding e = null)
		{
			if (e == null)
			{
				e = Encoding.Default;
			}
			return e.GetBytes(s);
		}
	}
}
