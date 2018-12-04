using UseHttpHelper.Base;
using UseHttpHelper.Enum;
using UseHttpHelper.Helper;
using System;
using System.Drawing;

namespace UseHttpHelper.BaseBll
{
    internal class HttpHelperBll : IDisposable
	{
		private HttphelperBase httpbase = new HttphelperBase();

		internal HttpResult GetHtml(HttpItem item)
		{
			HttpResult result;
			if (item.Allowautoredirect && item.AutoRedirectCookie)
			{
				HttpResult httpResult = null;
				for (int i = 0; i < 100; i++)
				{
					item.Allowautoredirect = false;
					httpResult = this.httpbase.GetHtml(item);
					if (string.IsNullOrWhiteSpace(httpResult.RedirectUrl))
					{
						break;
					}
					item.URL = httpResult.RedirectUrl;
					item.Method = "GET";
					if (item.ResultCookieType == ResultCookieType.String)
					{
						item.Cookie += httpResult.Cookie;
					}
					else
					{
						item.CookieCollection.Add(httpResult.CookieCollection);
					}
				}
				result = httpResult;
			}
			else
			{
				result = this.httpbase.GetHtml(item);
			}
			return result;
		}

		internal Image GetImage(HttpItem item)
		{
			item.ResultType = ResultType.Byte;
			return ImageHelper.ByteToImage(this.GetHtml(item).ResultByte);
		}

		internal HttpResult FastRequest(HttpItem item)
		{
			return this.httpbase.FastRequest(item);
		}

        #region 垃圾清理
        private bool IsDisposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool Disposing)
        {
            if (!IsDisposed)
            {
                if (Disposing)
                {
                    //清理托管资源
                    if (httpbase != null)
                    {
                        httpbase.Dispose();
                        httpbase = null;
                    }
                }
                //清理非托管资源
            }
            IsDisposed = true;
        }
        ~HttpHelperBll()
        {
            Dispose(false);
        }
        #endregion
	}
}
