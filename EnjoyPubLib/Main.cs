using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using EnjoyPubLib.Util;
namespace EnjoyPubLib
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			Theme.Setup ();
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
