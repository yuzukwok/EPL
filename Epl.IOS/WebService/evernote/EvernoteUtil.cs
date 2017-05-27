using System;

namespace EnjoyPubLib.WebService
{

	public enum HostService
	{
		Production,
		Sandbox
	}
	public class EvernoteUtil
	{
		public EvernoteUtil ()
		{
		}

		public static string cousumerkey="yuzukwok-4676";
		public static string cousumerserct="d7fb19c59514c514";
		public static string evernotehost="https://app.yinxiang.com/";
		public static string requesturl="https://{0}/oauth";
	}
}

