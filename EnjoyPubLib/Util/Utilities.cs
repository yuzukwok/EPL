using System;
using UIKit;
using MonoTouch;
using Foundation;

namespace EnjoyPubLib.Util
{
	public class Utilities
	{ /// <summary>
		///   A shortcut to the main application
		/// </summary>
		public static UIApplication MainApp = UIApplication.SharedApplication;
		static readonly object NetworkLock = new object ();
		static int _active;

		public static void PushNetworkActive ()
		{
			lock (NetworkLock){
				_active++;
				MainApp.NetworkActivityIndicatorVisible = true;
			}
		}

		public static void PopNetworkActive ()
		{
			lock (NetworkLock){
				if (_active == 0)
					return;

				_active--;
				if (_active == 0)
					MainApp.NetworkActivityIndicatorVisible = false;
			}
		}

		public static NSUserDefaults Defaults = NSUserDefaults.StandardUserDefaults;

		public static void LogException (string text, Exception e)
		{
			Console.WriteLine (String.Format ("On {0}, message: {1}\nException:\n{2}", DateTime.Now, text, e));
			//Analytics.TrackException(false, e.Message + " - " + e.StackTrace);
		}

		public static void LogException (Exception e)
		{
			Console.WriteLine (String.Format ("On {0} Exception:\n{1}", DateTime.Now, e));
			//Analytics.TrackException(false, e.Message + " - " + e.StackTrace);
		}
	}
}

