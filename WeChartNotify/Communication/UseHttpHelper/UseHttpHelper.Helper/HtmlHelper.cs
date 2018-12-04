using UseHttpHelper.Enum;
using UseHttpHelper.Item;
using UseHttpHelper.Static;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UseHttpHelper.Helper
{
	internal class HtmlHelper
	{
		internal static List<AItem> GetAList(string html)
		{
			List<AItem> list = null;
			string alist = RegexString.Alist;
			if (Regex.IsMatch(html, alist, RegexOptions.IgnoreCase))
			{
				list = new List<AItem>();
				foreach (Match match in Regex.Matches(html, alist, RegexOptions.IgnoreCase))
				{
					AItem aItem = null;
					try
					{
						aItem = new AItem
						{
							Href = match.Groups[1].Value,
							Text = match.Groups[2].Value,
							Html = match.Value,
							Type = AType.Text
						};
						List<ImgItem> imgList = HtmlHelper.GetImgList(aItem.Text);
						if (imgList != null && imgList.Count > 0)
						{
							aItem.Type = AType.Img;
							aItem.Img = imgList[0];
						}
					}
					catch
					{
						aItem = null;
					}
					if (aItem != null)
					{
						list.Add(aItem);
					}
				}
			}
			return list;
		}

		internal static List<ImgItem> GetImgList(string html)
		{
			List<ImgItem> list = null;
			string imgList = RegexString.ImgList;
			if (Regex.IsMatch(html, imgList, RegexOptions.IgnoreCase))
			{
				list = new List<ImgItem>();
				foreach (Match match in Regex.Matches(html, imgList, RegexOptions.IgnoreCase))
				{
					ImgItem imgItem = null;
					try
					{
						imgItem = new ImgItem
						{
							Src = match.Groups[1].Value,
							Html = match.Value
						};
					}
					catch
					{
						imgItem = null;
					}
					if (imgItem != null)
					{
						list.Add(imgItem);
					}
				}
			}
			return list;
		}

		internal static string StripHTML(string html)
		{
			html = Regex.Replace(html, RegexString.Nscript, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			html = Regex.Replace(html, RegexString.Style, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			html = Regex.Replace(html, RegexString.Script, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			html = Regex.Replace(html, RegexString.Html, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			return html;
		}

		internal static string ReplaceNewLine(string html)
		{
			return Regex.Replace(html, RegexString.NewLine, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

		internal static string GetBetweenHtml(string html, string s, string e)
		{
			string pattern = string.Format("{0}{1}{2}", s, RegexString.AllHtml, e);
			string result;
			if (Regex.IsMatch(html, pattern, RegexOptions.IgnoreCase))
			{
				Match match = Regex.Match(html, pattern, RegexOptions.IgnoreCase);
				if (match != null && match.Groups.Count > 0)
				{
					result = match.Groups[1].Value.Trim();
					return result;
				}
			}
			result = string.Empty;
			return result;
		}

		internal static string GetHtmlTitle(string html)
		{
			string result;
			if (Regex.IsMatch(html, RegexString.HtmlTitle))
			{
				result = Regex.Match(html, RegexString.HtmlTitle).Groups[1].Value.Trim();
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}
	}
}
