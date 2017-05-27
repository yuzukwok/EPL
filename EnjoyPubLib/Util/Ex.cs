using System;
using MonoTouch;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Net;
using CoreFoundation;
using SystemConfiguration;

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

