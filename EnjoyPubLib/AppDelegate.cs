using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Foundation;
using UIKit;
using EnjoyPubLib.Util.View;
using EnjoyPubLib.View;
using EnjoyPubLib.Service;
using SQLite;
using Epl.IOS.epls;

namespace EnjoyPubLib
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		//walkshanghaiViewController viewController;
		public static SlideoutNavigationViewController Menu { get; private set; }

		public static string DTK{ get; set;}

		public MenuView menuleft{ get; set;}


			//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{

			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(104, 165, 188);
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White, Font = UIFont.SystemFontOfSize(18f) });

		
			InitializeDatabase ();

			//判断是否第一次运行
			string buildno = NSBundle.MainBundle.InfoDictionary.ValueForKey (new NSString ("CFBundleVersion")).ToString ();
			var t=NSUserDefaults.StandardUserDefaults.StringForKey("KeyFirstLaunch");



			window = new UIWindow (UIScreen.MainScreen.Bounds);
			Menu = new  SlideoutNavigationViewController();

			menuleft = new MenuView ();

			Menu.MenuViewLeft = menuleft;
			if (t != buildno) {
				Menu.TopView = new UserGuideViewController (true);
				NSUserDefaults.StandardUserDefaults.SetString(buildno,"KeyFirstLaunch");

			} else {
//				if (UIApplication.SharedApplication.ApplicationIconBadgeNumber > 0) {
//					Menu.TopView = new NotifyViewController ();
//				} else {
					Menu.TopView = new BookSeekController ();
				//}

			}



			window.RootViewController = Menu;
			window.MakeKeyAndVisible ();

			//清空通知
			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;

			//Register for remote notifications
			UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(UIRemoteNotificationType.Alert
				| UIRemoteNotificationType.Badge
				| UIRemoteNotificationType.Sound);

			return true;

		}

		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			//TODO miss method
			var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

			//There's probably a better way to do this
			var strFormat = new NSString("%@");
//			var dt = new NSString(ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr(new ObjCRuntime.Class("NSString").Handle, new ObjCRuntime.Selector("stringWithFormat:").Handle, strFormat.Handle, deviceToken.Handle));
//			var newDeviceToken = dt.ToString().Replace("<", "").Replace(">", "").Replace(" ", "");
//
//			if (string.IsNullOrEmpty(oldDeviceToken) || !deviceToken.Equals(newDeviceToken))
//			{
//				if (Reachability.InternetConnectionStatus () != NetworkStatus.NotReachable) {
//					try {
//						EnjoyPubLibService ser = new EnjoyPubLibService ();
//						ser.UpdateUserNotify (newDeviceToken, oldDeviceToken, false);
//					} catch (Exception ex) {
//						//   服务异常，网络不同无法调用
//					}
//				}
//
//			}

			//Save device token now
			//NSUserDefaults.StandardUserDefaults.SetString(newDeviceToken, "PushDeviceToken");
			//DTK = newDeviceToken;
			//Console.WriteLine("Device Token: " + newDeviceToken);
		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application, NSError error)
		{
			//new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
			Console.WriteLine("Failed to register for notifications");
		}

		public override void ReceivedRemoteNotification (UIApplication application, NSDictionary userInfo)
		{
			//Console.WriteLine("Received Remote Notification!");
			//显示消息更新通知按钮


		}


		public static SQLiteConnection Connection { get; private set; }

		public static SQLiteConnection InfoDbConnection { get; private set; }

		protected void InitializeDatabase()
		{
			//Synchronous connection
			Connection = new SQLiteConnection(DbName);
			InfoDbConnection = new SQLiteConnection (InfoDbName);
		

			//Create Tables

			Connection.CreateTable<BookItem>();
			Connection.CreateTable<WantRead>();
			//Connection.CreateTable<WantBow>();
			Connection.CreateTable<WantBowBook>();
			//Connection.CreateTable<MonitorBook>();
			Connection.CreateTable<ConfigInfo>();

			InfoDbConnection.CreateTable<LibInfo> ();
		}

		public string DbName
		{
			get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "epl.db"); }
		}

		public string InfoDbName
		{
			get { return Path.Combine(Environment.CurrentDirectory, "eplinfodb.sqlite"); }
		}
	}
}

