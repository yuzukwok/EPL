using System;
using EnjoyPubLib.Util.View;
using MonoTouch.Dialog;
using EnjoyPubLib.Util.ElementUtil;
using UIKit;
using EnjoyPubLib.Util;
using EnjoyPubLib.Service.Douban;
using System.Collections;
using System.Collections.Generic;
using EnjoyPubLib.Service.Douban;
using EnjoyPubLib.IPACS;
using EnjoyPubLib.WebService;
using System.Linq;
namespace EnjoyPubLib
{
	public class DouWishListViewController:BaseDialogViewController
	{
		public DouWishListViewController (IList<BkCollection> bk):base(false)
		{
			Title = "我的豆瓣想读";
			_bks = bk;
		}
		IList<BkCollection> _bks;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			CreateElement ();
		}

		void CreateElement ()
		{


			var section = new Section ("来自豆瓣（最近15本）");
			foreach (var item in _bks) {
				NewsFeedElement e = new NewsFeedElement (item.Book.Title,item.Book.Image);
				section.Add (e);
			}
			var section2 = new Section ("操作");
			EnjoyPubLib.Util.ElementUtil.StyledStringElement e2 =
				new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("查询下列图书的馆藏并加入想借");
			e2.Alignment = UITextAlignment.Center;
			e2.Font = UIFont.SystemFontOfSize (20);
			e2.Tapped += () => {
				bool Need = true;
				IList<string> isbns=new List<string>();
				IList<string> bknames=new List<string>();
				//保存图书
				//以ipacId为主键查找是否存在
				dal d=new dal();
				string msg="已添加";
				int count=0;
				foreach (var item in _bks) {
					var books=  IpacHelper.Sreach(IPACS.Mobile_iPacType.ISBN,item.Book.ISBN13);

					//add
					if (books.Result.MaxRows > 0) {
						d.AddNewBookIntoWish(AppDelegate.Connection, books.Result.BookItem[0],item.Book.Image);
						count++;
					}else
					{
						isbns.Add(item.Book.ISBN13);
						bknames.Add(item.Book.Title);
					}

				}
				if (_bks.Count==count) {
					Need=false;
				}
				this.InvokeOnMainThread(() => {

					//通知界面

					if (Need) {
						msg=msg+count+"本到想借清单，其他图书馆无馆藏";
						NavigationController.PushViewController(new AddNotifyInfoShowViewController(Need,msg,isbns.ToArray(),bknames.ToArray()),true);
					}else{
						msg=msg+count+"本到想借清单";
						NavigationController.PopToRootViewController(true);
					}

				});
				//return
				//NavigationController.PopViewControllerAnimated(true);
			};
			section2.Add (e2);
			Root.Add (section2);
			Root.Add (section);

		}
	}
}

