
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using Epl.IOS.epls;
using BigTed;

namespace EnjoyPubLib
{
	public partial class NotifyViewController : DialogViewController
	{
		public NotifyViewController () : base (UITableViewStyle.Grouped, null)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			createTable ();
		}

		void createTable ()
		{
			//查询
			BTProgressHUD.Show("加载中");

			ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state) {

				EnjoyPubLibService ser=new EnjoyPubLibService();
				if (!string.IsNullOrEmpty(AppDelegate.DTK)) {
					var list=ser.GetBookISBNList(AppDelegate.DTK);
					BTProgressHUD.Dismiss();
					InvokeOnMainThread(delegate {

						var section=new Section("新到书籍");
						if (list!=null) {
							foreach (var item in list) {
								StringElement e=new StringElement(item);
								section.Add(e);
							}
						}

						Root = new RootElement ("推送通知") {
							section
						};

					});
				}

			}));



			}
		}
}

