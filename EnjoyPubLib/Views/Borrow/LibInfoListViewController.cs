using System;
using EnjoyPubLib.Util.View;
using MonoTouch.Dialog;
using UIKit;
using EnjoyPubLib.Util.ElementUtil;

namespace EnjoyPubLib
{
	public class LibInfoListViewController:BaseDialogViewController
	{
		public LibInfoListViewController ():base(true)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			CreateTable ();
		}

		void CreateTable ()
		{
			var libs = new dal ().QueryLibs (AppDelegate.InfoDbConnection);

			if (libs!=null&&libs.Count>0) {
				var list = new Section ("图书馆清单");
				foreach (var l in libs) {

					MultilinedElement element = new MultilinedElement (l.LibName);
					//element.Value = l.Address;
					element.Tapped += () => {
						var bvc=new LibViewController(l);
						bvc.Root.UnevenRows=true;
						NavigationController.PushViewController(bvc,true);
					};
					list.Add (element);

				}
				Root.UnevenRows = true;
				Root.Add (list);
			}
		}
	}
}

