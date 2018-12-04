using UseHttpHelper.Enum;
using UseHttpHelper.Static;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace UseHttpHelper.Base
{
	internal class HttphelperBase :IDisposable
	{
		private Encoding encoding = Encoding.Default;

		private Encoding postencoding = Encoding.Default;

		private HttpWebRequest request = null;

		private HttpWebResponse response = null;

		private IPEndPoint _IPEndPoint = null;

		internal HttpResult GetHtml(HttpItem item)
		{
			HttpResult httpResult = new HttpResult(); 
			HttpResult result;
			try
			{
				this.SetRequest(item);
			}
			catch (Exception ex)
			{
				result = new HttpResult
				{
					Cookie = string.Empty,
					Header = null,
					Html = ex.Message,
					StatusDescription = "配置参数时出错：" + ex.Message
				};
				return result;
			}
			try
			{
				using (this.response = (HttpWebResponse)this.request.GetResponse())
				{
					this.GetData(item, httpResult);
				}
			}
			catch (WebException ex2)
			{
				if (ex2.Response != null)
				{
					using (this.response = (HttpWebResponse)ex2.Response)
					{
						this.GetData(item, httpResult);
					}
				}
				else
				{
					httpResult.Html = ex2.Message;
				}
			}
			catch (Exception ex)
			{
				httpResult.Html = ex.Message;
			}
			if (item.IsToLower)
			{
				httpResult.Html = httpResult.Html.ToLower();
			}
			result = httpResult;
			return result;
		}

		internal HttpResult FastRequest(HttpItem item)
		{
			HttpResult httpResult = new HttpResult();
			HttpResult result;
			try
			{
				this.SetRequest(item);
			}
			catch (Exception ex)
			{
				result = new HttpResult
				{
					Cookie = (this.response.Headers["set-cookie"] != null) ? this.response.Headers["set-cookie"] : string.Empty,
					Header = null,
					Html = ex.Message,
					StatusDescription = "配置参数时出错：" + ex.Message
				};
				return result;
			}
			try
			{
				using (this.response = (HttpWebResponse)this.request.GetResponse())
				{
					result = new HttpResult
					{
						Cookie = (this.response.Headers["set-cookie"] != null) ? this.response.Headers["set-cookie"] : string.Empty,
						Header = this.response.Headers,
						StatusCode = this.response.StatusCode,
						StatusDescription = this.response.StatusDescription
					};
					return result;
				}
			}
			catch (WebException ex2)
			{
				using (this.response = (HttpWebResponse)ex2.Response)
				{
					result = new HttpResult
					{
						Cookie = (this.response.Headers["set-cookie"] != null) ? this.response.Headers["set-cookie"] : string.Empty,
						Header = this.response.Headers,
						StatusCode = this.response.StatusCode,
						StatusDescription = this.response.StatusDescription
					};
					return result;
				}
			}
			catch (Exception ex)
			{
				httpResult.Html = ex.Message;
			}
			if (item.IsToLower)
			{
				httpResult.Html = httpResult.Html.ToLower();
			}
			result = httpResult;
			return result;
		}

		private void GetData(HttpItem item, HttpResult result)
		{
			if (this.response != null)
			{
				result.StatusCode = this.response.StatusCode;
				result.ResponseUri = this.response.ResponseUri.ToString();
				result.StatusDescription = this.response.StatusDescription;
				result.Header = this.response.Headers;
				if (this.response.Cookies != null)
				{
					result.CookieCollection = this.response.Cookies;
				}
				if (this.response.Headers["set-cookie"] != null)
				{
					result.Cookie = this.response.Headers["set-cookie"];
				}
				byte[] @byte = this.GetByte();
				if (@byte != null && @byte.Length > 0)
				{
					this.SetEncoding(item, result, @byte);
					result.Html = this.encoding.GetString(@byte);
				}
				else
				{
					result.Html = string.Empty;
				}
			}
		}

		private void SetEncoding(HttpItem item, HttpResult result, byte[] ResponseByte)
		{
			if (item.ResultType == ResultType.Byte)
			{
				result.ResultByte = ResponseByte;
			}
			if (this.encoding == null)
			{
				Match match = Regex.Match(Encoding.Default.GetString(ResponseByte), RegexString.Enconding, RegexOptions.IgnoreCase);
				string text = string.Empty;
				if (match != null && match.Groups.Count > 0)
				{
					text = match.Groups[1].Value.ToLower().Trim();
				}
				string text2 = string.Empty;
				if (!string.IsNullOrWhiteSpace(this.response.CharacterSet))
				{
					text2 = this.response.CharacterSet.Trim().Replace("\"", "").Replace("'", "");
				}
				if (text.Length > 2)
				{
					try
					{
						this.encoding = Encoding.GetEncoding(text.Replace("\"", string.Empty).Replace("'", "").Replace(";", "").Replace("iso-8859-1", "gbk").Trim());
					}
					catch
					{
						if (string.IsNullOrEmpty(text2))
						{
							this.encoding = Encoding.UTF8;
						}
						else
						{
							this.encoding = Encoding.GetEncoding(text2);
						}
					}
				}
				else if (string.IsNullOrEmpty(text2))
				{
					this.encoding = Encoding.UTF8;
				}
				else
				{
					this.encoding = Encoding.GetEncoding(text2);
				}
			}
		}

		private byte[] GetByte()
		{
			byte[] result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (this.response.ContentEncoding != null && this.response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
				{
					new GZipStream(this.response.GetResponseStream(), CompressionMode.Decompress).CopyTo(memoryStream, 10240);
				}
				else
				{
					this.response.GetResponseStream().CopyTo(memoryStream, 10240);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		private void SetRequest(HttpItem item)
		{
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.CheckValidationResult);
			this.request = (HttpWebRequest)WebRequest.Create(item.URL);
			if (item.IPEndPoint != null)
			{
				this._IPEndPoint = item.IPEndPoint;
				this.request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(this.BindIPEndPointCallback);
			}
			this.request.AutomaticDecompression = item.AutomaticDecompression;
			this.SetCer(item);
			this.SetCerList(item);
			if (item.Header != null && item.Header.Count > 0)
			{
				string[] allKeys = item.Header.AllKeys;
				for (int i = 0; i < allKeys.Length; i++)
				{
					string name = allKeys[i];
					this.request.Headers.Add(name, item.Header[name]);
				}
			}
			this.SetProxy(item);
			if (item.ProtocolVersion != null)
			{
				this.request.ProtocolVersion = item.ProtocolVersion;
			}
			this.request.ServicePoint.Expect100Continue = item.Expect100Continue;
			this.request.Method = item.Method;
			this.request.Timeout = item.Timeout;
			this.request.KeepAlive = item.KeepAlive;
			this.request.ReadWriteTimeout = item.ReadWriteTimeout;
			if (!string.IsNullOrWhiteSpace(item.Host))
			{
				this.request.Host = item.Host;
			}
			if (item.IfModifiedSince.HasValue)
			{
				this.request.IfModifiedSince = Convert.ToDateTime(item.IfModifiedSince);
			}
			this.request.Accept = item.Accept;
			this.request.ContentType = item.ContentType;
			this.request.UserAgent = item.UserAgent;
			this.encoding = item.Encoding;
			this.request.Credentials = item.ICredentials;
			this.SetCookie(item);
			this.request.Referer = item.Referer;
			this.request.AllowAutoRedirect = item.Allowautoredirect;
			if (item.MaximumAutomaticRedirections > 0)
			{
				this.request.MaximumAutomaticRedirections = item.MaximumAutomaticRedirections;
			}
			this.SetPostData(item);
			if (item.Connectionlimit > 0)
			{
				this.request.ServicePoint.ConnectionLimit = item.Connectionlimit;
			}
		}

		private void SetCer(HttpItem item)
		{
			if (!string.IsNullOrWhiteSpace(item.CerPath))
			{
				if (!string.IsNullOrWhiteSpace(item.CerPwd))
				{
					this.request.ClientCertificates.Add(new X509Certificate(item.CerPath, item.CerPwd));
				}
				else
				{
					this.request.ClientCertificates.Add(new X509Certificate(item.CerPath));
				}
			}
		}

		private void SetCerList(HttpItem item)
		{
			if (item.ClentCertificates != null && item.ClentCertificates.Count > 0)
			{
				foreach (X509Certificate current in item.ClentCertificates)
				{
					this.request.ClientCertificates.Add(current);
				}
			}
		}

		private void SetCookie(HttpItem item)
		{
			if (!string.IsNullOrEmpty(item.Cookie))
			{
				this.request.Headers[HttpRequestHeader.Cookie] = item.Cookie;
			}
			if (item.ResultCookieType == ResultCookieType.CookieCollection)
			{
				this.request.CookieContainer = new CookieContainer();
				if (item.CookieCollection != null && item.CookieCollection.Count > 0)
				{
					this.request.CookieContainer.Add(item.CookieCollection);
				}
			}
		}

		private void SetPostData(HttpItem item)
		{
			if (!this.request.Method.Trim().ToLower().Contains("get"))
			{
				if (item.PostEncoding != null)
				{
					this.postencoding = item.PostEncoding;
				}
				byte[] array = null;
				if (item.PostDataType == PostDataType.Byte && item.PostdataByte != null && item.PostdataByte.Length > 0)
				{
					array = item.PostdataByte;
				}
				else if (item.PostDataType == PostDataType.FilePath && !string.IsNullOrWhiteSpace(item.Postdata))
				{
					StreamReader streamReader = new StreamReader(item.Postdata, this.postencoding);
					array = this.postencoding.GetBytes(streamReader.ReadToEnd());
					streamReader.Close();
				}
				else if (!string.IsNullOrWhiteSpace(item.Postdata))
				{
					array = this.postencoding.GetBytes(item.Postdata);
				}
				if (array != null)
				{
					this.request.ContentLength = (long)array.Length;
					this.request.GetRequestStream().Write(array, 0, array.Length);
				}
			}
		}

		private void SetProxy(HttpItem item)
		{
			bool flag = false;
			if (!string.IsNullOrWhiteSpace(item.ProxyIp))
			{
				flag = item.ProxyIp.ToLower().Contains("ieproxy");
			}
			if (!string.IsNullOrWhiteSpace(item.ProxyIp) && !flag)
			{
				if (item.ProxyIp.Contains(":"))
				{
					string[] array = item.ProxyIp.Split(new char[]
					{
						':'
					});
					WebProxy webProxy = new WebProxy(array[0].Trim(), Convert.ToInt32(array[1].Trim()));
					webProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
					this.request.Proxy = webProxy;
				}
				else
				{
					WebProxy webProxy = new WebProxy(item.ProxyIp, false);
					webProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
					this.request.Proxy = webProxy;
				}
			}
			else if (!flag)
			{
				this.request.Proxy = item.WebProxy;
			}
		}

		private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true;
		}

		public IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
		{
			return this._IPEndPoint;
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
                    if (request != null)
                    {
                        request.Abort();
                        request = null;
                    }
                    response = null;
                    encoding = null;
                    postencoding = null;
                    _IPEndPoint = null;
                }
                //清理非托管资源
            }
            IsDisposed = true;
        }
        ~HttphelperBase()
        {
            Dispose(false);
        }
        #endregion
	}
}
