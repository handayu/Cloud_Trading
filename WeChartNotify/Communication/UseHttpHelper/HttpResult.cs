using System;
using System.Linq;
using System.Net;

namespace UseHttpHelper
{
	public class HttpResult:IDisposable
	{
		public string Cookie
		{
			get;
			set;
		}

		public CookieCollection CookieCollection
		{
			get;
			set;
		}

		public string Html
		{
			get;
			set;
		}

		public byte[] ResultByte
		{
			get;
			set;
		}

		public WebHeaderCollection Header
		{
			get;
			set;
		}

		public string StatusDescription
		{
			get;
			set;
		}

		public HttpStatusCode StatusCode
		{
			get;
			set;
		}

		public string ResponseUri
		{
			get;
			set;
		}

		public string RedirectUrl
		{
			get
			{
				string result;
				try
				{
					if (this.Header != null && this.Header.Count > 0)
					{
						if (this.Header.AllKeys.Any((string k) => k.ToLower().Contains("location")))
						{
							string text = this.Header["location"].ToString().Trim();
							string text2 = text.ToLower();
							if (!string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.StartsWith("http://") && !text2.StartsWith("https://"))
								{
									text = new Uri(new Uri(this.ResponseUri), text).AbsoluteUri;
								}
							}
							result = text;
							return result;
						}
					}
				}
				catch
				{
				}
				result = string.Empty;
				return result;
			}
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
                    Cookie = null;
                    Html = null;
                    StatusDescription = null;
                    ResponseUri = null;
                    if (CookieCollection != null)
                    {
                        CookieCollection = null;
                    }
                    if (ResultByte != null)
                    {
                        ResultByte = null;
                    }
                    if (Header != null)
                    {
                        Header.Clear();
                        Header = null;
                    }
                }
                //清理非托管资源
            }
            IsDisposed = true;
        }
        ~HttpResult()
        {
            Dispose(false);
        }
        #endregion
	}
}
