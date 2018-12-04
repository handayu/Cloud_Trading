using System;
using System.Reflection;

namespace UseHttpHelper.Helper
{
	internal class ExecJsHelper
	{
		private static Type type = Type.GetTypeFromProgID("ScriptControl");

		internal static string JavaScriptEval(string strJs, string main)
		{
			object scriptControl = ExecJsHelper.GetScriptControl();
			ExecJsHelper.SetScriptControlType(strJs, scriptControl);
			return ExecJsHelper.type.InvokeMember("Eval", BindingFlags.InvokeMethod, null, scriptControl, new object[]
			{
				main
			}).ToString();
		}

		private static Type SetScriptControlType(string strJs, object obj)
		{
			ExecJsHelper.type.InvokeMember("Language", BindingFlags.SetProperty, null, obj, new object[]
			{
				"JScript"
			});
			ExecJsHelper.type.InvokeMember("AddCode", BindingFlags.InvokeMethod, null, obj, new object[]
			{
				strJs
			});
			return ExecJsHelper.type;
		}

		private static object GetScriptControl()
		{
			return Activator.CreateInstance(ExecJsHelper.type);
		}
	}
}
