using System;
using System.Web.Configuration;
using System.Web.Security;

namespace UseHttpHelper.Helper
{
	internal class MD5Helper
	{
		internal static string ToMD5_32(string str)
		{
			string passwordFormat = FormsAuthPasswordFormat.MD5.ToString();
			return FormsAuthentication.HashPasswordForStoringInConfigFile(str, passwordFormat);
		}

		internal static string ToSHA1(string str)
		{
			string passwordFormat = FormsAuthPasswordFormat.SHA1.ToString();
			return FormsAuthentication.HashPasswordForStoringInConfigFile(str, passwordFormat);
		}
	}
}
