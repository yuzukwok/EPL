
using System;
using CoreGraphics;

using Foundation;
using UIKit;
using BigTed;
using Epl.IOS.epls;
using System.Threading;
using EnjoyPubLib.Util.View;
using MonoTouch.Dialog;
using EnjoyPubLib.Util.ElementUtil;
using EnjoyPubLib.Util.ThemeUtil;

namespace EnjoyPubLib
{
	public partial class AddNotifyInfoShowViewController : BaseDialogViewController
	{
		private const string About = @"如果你想知道图书馆何时才能采购你想看的新书，加入监控，当图书馆采购此图书之后，你将在你的设备上得到推送的通知。 ";

		public AddNotifyInfoShowViewController (bool need,string  msg,string [] bookisbns,string[] booknames):base(true)
		{
			Msg=msg;
			Bookisbns = bookisbns;
			Booknames = booknames;
			Need = need;
			Title="查询结果";
		}
		public bool Need{ get; set;}
		public string Msg{ get; set;}
		public string[] Bookisbns{ get; set;}
		public string[] Booknames{ get; set;}
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var root = new RootElement ("");
			var section = new Section ("");
			var s = new MultilinedElement ("监控"); 

			

			section.Add (s);

			if (Need) {
				s.Value = Msg+"\n\n" +About;
				var e = new StringElement ("加入监控,耐心等待",delegate {
					//提交
					BTProgressHUD.Show ("提交中");

					ThreadPool.QueueUserWorkItem (new WaitCallback (delegate(object state) {

						if (!string.IsNullOrEmpty(AppDelegate.DTK)) {
							EnjoyPubLibService ser = new EnjoyPubLibService ();
							ser.SubmitMonitorWork (AppDelegate.DTK, Bookisbns, Booknames);
						}

						BTProgressHUD.Dismiss ();
						//NavigationController.PopToRootViewController(true);
						InvokeOnMainThread(delegate {
							this.NavigationController.PopToRootViewController(true);});

					}));
				});


				section.Add (e);
			} else {
				s.Value = Msg;
				var e = new StringElement ("完成",delegate {
					NavigationController.PopToRootViewController(true);

					});

				section.Add (e);
			}

			root.Add (section);
			root.UnevenRows = true;
			Root = root;

		}
	}
}

