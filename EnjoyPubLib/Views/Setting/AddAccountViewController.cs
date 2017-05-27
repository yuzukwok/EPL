using System;
using EnjoyPubLib.Util.View;
using MonoTouch.Dialog;
using EnjoyPubLib.Util;
namespace EnjoyPubLib.View
{
	public class AddAccountViewController:BaseDialogViewController
	{
		public AddAccountViewController ():base(false)
		{
			Title="关联帐号";
		}



		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			CreateTable ();
		}
		Section section;
		void CreateTable ()
		{

			if (section == null) {
				section = new Section ("网站");
			} else {
				section.Clear ();
			}



			 
			dal d = new dal ();

			#region 豆瓣
			var tk=d.getKV(AppDelegate.Connection,Contans.DefaultDoubanAuthKey);
			var name = d.getKV (AppDelegate.Connection,Contans.DefaultDoubanUserName);
			var av = d.getKV (AppDelegate.Connection,Contans.DefaultDoubanAvatar);
			if (!string.IsNullOrEmpty(tk)&&!string.IsNullOrEmpty(name)) {
				var logout=new  EnjoyPubLib.Util.ElementUtil.StyledStringElement ("注销豆瓣帐号-" + name);
				if (!string.IsNullOrEmpty(av)) {
					logout.ImageUri = new Uri (av);	
				}

				logout.Tapped += () => {
					//注销
					d.setKV(AppDelegate.Connection,Contans.DefaultDoubanAuthKey,"");
					d.setKV(AppDelegate.Connection,Contans.DefaultDoubanUserName,"");
					d.setKV(AppDelegate.Connection,Contans.DefaultDoubanAvatar,"");

					CreateTable();
				};
				section.Add (logout);

			}else
			{
				var doubansign = new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("关联豆瓣帐号");
				doubansign.Tapped += () => {
					NavigationController.PushViewController(new AddDoubanViewController(),true);
				};
				section.Add (doubansign);
			}
		
			#endregion

			#region Evernote
			var evtk=d.getKV(AppDelegate.Connection, "EvernoteTK");
			var evname = d.getKV (AppDelegate.Connection,"EvernoteUser");
			if (!string.IsNullOrEmpty(evtk)&&!string.IsNullOrEmpty(evname)) {
				var logout2=new  EnjoyPubLib.Util.ElementUtil.StyledStringElement ("注销印象笔记帐号-" + evname);
//				if (!string.IsNullOrEmpty(av)) {
//					logout2.ImageUri = new Uri (av);	
//				}

				logout2.Tapped += () => {
					//注销
					d.setKV(AppDelegate.Connection,"EvernoteTK","");
					d.setKV(AppDelegate.Connection,"EvernoteUser","");

					CreateTable();
				};
				section.Add (logout2);

			}else
			{
				var evernotesign = new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("关联印象笔记帐号");
				evernotesign.Tapped += () => {
					NavigationController.PushViewController(new AddEvernoteAccountViewController(),true);
				};
				section.Add (evernotesign);
			}

			#endregion

			if (Root.Count == 0) {
				Root.Add (section);
			} else {
				Root.Reload (section, UIKit.UITableViewRowAnimation.None);
			}



		}
	}
}

