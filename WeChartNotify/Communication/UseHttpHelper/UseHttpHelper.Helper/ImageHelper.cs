using System;
using System.Drawing;
using System.IO;

namespace UseHttpHelper.Helper
{
	internal class ImageHelper
	{
		internal static Image ByteToImage(byte[] b)
		{
			Image result;
			try
			{
				MemoryStream stream = new MemoryStream(b);
				result = Image.FromStream(stream, true);
			}
			catch
			{
				result = null;
			}
			return result;
		}
	}
}
