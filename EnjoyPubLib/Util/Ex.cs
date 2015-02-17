using System;
using MonoTouch;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using System.Net;
using MonoTouch.CoreFoundation;
using MonoTouch.SystemConfiguration;

namespace EnjoyPubLib
{
	public static class Ex
	{
		public static string t(this string translate)
		{
			return NSBundle.MainBundle.LocalizedString(translate,"","");
		}
	}
}

