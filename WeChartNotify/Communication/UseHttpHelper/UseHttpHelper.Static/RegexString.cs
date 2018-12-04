using System;

namespace UseHttpHelper.Static
{
	internal class RegexString
	{
		internal static readonly string Alist = "<a[\\s\\S]+?href[=\"']([\\s\\S]+?)[\"'\\s+][\\s\\S]+?>([\\s\\S]+?)</a>";

		internal static readonly string ImgList = "<img[\\s\\S]*?src=[\"']([\\s\\S]*?)[\"'][\\s\\S]*?>([\\s\\S]*?)>";

		internal static readonly string Nscript = "<nscript[\\s\\S]*?>[\\s\\S]*?</nscript>";

		internal static readonly string Style = "<style[\\s\\S]*?>[\\s\\S]*?</style>";

		internal static readonly string Script = "<script[\\s\\S]*?>[\\s\\S]*?</script>";

		internal static readonly string Html = "<[\\s\\S]*?>";

		internal static readonly string NewLine = Environment.NewLine;

		internal static readonly string Enconding = "<meta[^<]*charset=([^<]*)[\"']";

		internal static readonly string AllHtml = "([\\s\\S]*?)";

		internal static readonly string HtmlTitle = "<title>([\\s\\S]*?)</title>";
	}
}
