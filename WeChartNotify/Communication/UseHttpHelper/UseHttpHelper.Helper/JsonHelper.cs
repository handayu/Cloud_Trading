using Newtonsoft.Json;
using System;

namespace UseHttpHelper.Helper
{
	internal class JsonHelper
	{
		internal static object JsonToObject<T>(string jsonstr)
		{
			object result;
			try
			{
                //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                //result = javaScriptSerializer.Deserialize<T>(jsonstr);
                result = JsonConvert.DeserializeObject<T>(jsonstr);

            }
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		internal static string ObjectToJson(object obj)
		{
			string result;
			try
			{
                //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                //result = javaScriptSerializer.Serialize(obj);
                result = JsonConvert.SerializeObject(obj);

            }
			catch (Exception)
			{
				result = string.Empty;
			}
			return result;
		}
	}
}
