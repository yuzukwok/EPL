using System;
using EnjoyPubLib.Util.View;
using System.Collections.Generic;
using MonoTouch.Dialog;
using EnjoyPubLib.Dto;
using MonoTouch.Dialog.Utilities;
using EnjoyPubLib.ImagesUtil;
using UIKit;
using Foundation;
using EnjoyPubLib.WebService;
using System.Linq;
using EnjoyPubLib.View;

namespace EnjoyPubLib
{
	public class WishBookListController:BaseDialogViewController
	{
		public WishBookListController ():base(false)
		{
			Title = "";
		}

		// This is our subclass of the fixed-size Source that allows editing
		public class EditingSource : DialogViewController.Source {
			public EditingSource (DialogViewController dvc) : base (dvc) {}

			public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Trivial implementation: we let all rows be editable, regardless of section or row
				return true;
			}

			public override string TitleForDeleteConfirmation (UITableView tableView, NSIndexPath indexPath)
			{
				// NOTE: Don't call the base implementation on a Model class
				// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
				return "删除";
			}



			public override UITableViewCellEditingStyle EditingStyleForRow (UITableView tableView, NSIndexPath indexPath)
			{
				// trivial implementation: show a delete button always
				return UITableViewCellEditingStyle.Delete;
			}

			public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
			{
				// NOTE: Don't call the base implementation on a Model class
				// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
				return false;
			}



			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				//
				// In this method, we need to actually carry out the request
				//
				var section = Container.Root [indexPath.Section];
				var element = section [indexPath.Row];
				section.Remove (element);

				//更新数据库
				var v = Container as WishBookListController;
				if (v!=null) {
					WishBookListItem b = v.sl [indexPath.Row];
					new dal ().DelWishBookId (AppDelegate.Connection,b.Id);
					v.sl.Remove (b);
				}

			}

//			public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
//			{
//				// NOTE: Don't call the base implementation on a Model class
//				// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
//				var section = Container.Root [sourceIndexPath.Section];
//				var source = section [sourceIndexPath.Row];
//				section.Remove (source);
//				section.Insert (destinationIndexPath.Row, source);
//			}
		}

		void ConfigEdit (DialogViewController dvc)
		{
			var s1 = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);
			var s2 = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

			var btnedit = new UIBarButtonItem ("整理",UIBarButtonItemStyle.Plain, delegate {
				// Activate editing
				if (Wantreadlist!=null&&Wantreadlist.Count>0) {
				dvc.TableView.SetEditing (true, true);
					ConfigDone (dvc);}
			});
			var btnset = new UIBarButtonItem ("设置",UIBarButtonItemStyle.Plain, delegate {

			});
			var btndel = new UIBarButtonItem ("删除",UIBarButtonItemStyle.Plain, delegate {
				if (Wantreadlist==null||Wantreadlist.Count==0) {return;}
				UIAlertView v=new UIAlertView("确认","是否从想借清单中删除所选图书",null,"取消","确认");
				v.Show();
				v.Clicked+=(o,e)=>{
					if (e.ButtonIndex==0) {
						
					}else	{
						if (Wantreadlist!=null&&Wantreadlist.Count>0) {

							IList<int> removeId=new List<int>();
							for (int i = 0, sectionElementsCount = Wantreadlist.Elements.Count; i < sectionElementsCount; i++) {
								var a1=Wantreadlist[i] as EnjoyPubLib.Util.ElementUtil.StyledStringElement;
								if (a1.Accessory==UITableViewCellAccessory.Checkmark) {

								WishBookListItem b = sl.ElementAt(i);
									new dal ().DelWishBookId (AppDelegate.Connection,b.Id);
								//sl.Remove (b);
									removeId.Add(b.Id);}

							}
							// 删除
							for (int i = sl.Count - 1; i >= 0; i--) {
								if (removeId.Contains(sl[i].Id)) {
									sl.RemoveAt(i);
								}
							}
							//del element
							for (int a = Wantreadlist.Count - 1; a >= 0; a--) {
								var a1=Wantreadlist[a] as EnjoyPubLib.Util.ElementUtil.StyledStringElement;
								if (a1.Accessory==UITableViewCellAccessory.Checkmark) {
									Wantreadlist.Remove(a1);
								}
							}

							Root.Reload(Wantreadlist,UITableViewRowAnimation.None);
						}
					}
				};

			});
			var btngen = new UIBarButtonItem ("生成索书列表", UIBarButtonItemStyle.Plain, delegate {
				//Gen

				//判断网络是否正常
				if(Reachability.InternetConnectionStatus()!= NetworkStatus.NotReachable){
				if (Wantreadlist==null||Wantreadlist.Count==0) {return;}
					GenBorBokList(Wantreadlist);}
			});
			dvc.NavigationItem.RightBarButtonItems = new UIBarButtonItem[]{  btngen };
			dvc.NavigationController.ToolbarHidden = false;
			dvc.ToolbarItems = new UIBarButtonItem[]{ btnedit,s1,btndel };

		}

		void GenBorBokList(Section section){
			if (section!=null) {

				IList<string> isbn = new List<string> (); 
				IList<string> names = new List<string> (); 
				for (int i = 0, sectionElementsCount = section.Elements.Count; i < sectionElementsCount; i++) {
					var item = section.Elements [i];
					var e = item as EnjoyPubLib.Util.ElementUtil.StyledStringElement;
					if (e != null && e.Accessory == UITableViewCellAccessory.Checkmark) 
					{
						isbn.Add (sl [i].Isbn);
						names.Add (sl [i].BookName);
					}
				}

				List<BookCollectionDetailResponseCollectionDetailItem> booksreturn = new List<BookCollectionDetailResponseCollectionDetailItem> ();
				if (isbn.Count>0) {

					//查询数据，生成借书单
					for (int i = 0; i < isbn.Count; i++) {
						var item = isbn [i];
						var bs=IpacHelper.GetBookCollectionDetail (item);
						if (bs.CollectionDetailItem!=null&& bs.CollectionDetailItem.Length>0) {

							foreach (var ditem in bs.CollectionDetailItem) {

								if (ditem.BookItemStatus=="归还"&&ditem.BookItype!="保存资料"
									&&ditem.BookItype!="仅供阅览资料"&&ditem.BookItype!="处理中") {

									//复本不算
									if (booksreturn.Where(p=>p.BookName==ditem.BookName&&p.BookCollection==ditem.BookCollection).Count()==0) {
										ditem.BookName = names [i];

										booksreturn.Add (ditem);
									}

								}
							}
						}

					}

					//分组生成对象

					var bg=	booksreturn.GroupBy (p => p.BookLocation).ToDictionary (p => p.Key, p => p);

					CanBowList c = new CanBowList ();

					foreach (var cl in bg) {

						c.dictList.Add (cl.Key, cl.Value.ToList());


					}


					if (c.dictList.Count > 0) {
						NavigationController.PushViewController (new BorrowPVListController (c),false);
					} else {
						UIAlertView v = new UIAlertView ("信息", "当前无可借副本", null, "OK", null);
						v.Show ();
					}




				}
			}
		}

		void ConfigDone (DialogViewController dvc)
		{
			dvc.NavigationController.ToolbarHidden = true;
			dvc.NavigationItem.RightBarButtonItem = new UIBarButtonItem ("完成",UIBarButtonItemStyle.Plain, delegate {
				// Deactivate editing
				dvc.TableView.SetEditing (false, true);
				ConfigEdit (dvc);
			});
		}
		public override void ViewDidLoad ()
		{

			base.ViewDidLoad ();
			ConfigEdit (this);
			CreateTable ();


		}
		IList<WishBookListItem> sl{ get; set;}
		Section Wantreadlist;
		private void CreateTable ()
		{
			//query
			dal d = new dal ();
			sl = d.QueryWishBooks (AppDelegate.Connection);
			string str = "";
			if (Wantreadlist != null && Wantreadlist.Count > 0) {
				str = "请通过[新增想借]增加想借图书";
			}else	{str="如此次不想借,请清除勾选";}
			Wantreadlist = new Section ("想借清单（"+str+"）");

			for (int i = 0; i < sl.Count; i++) {
				var item = sl [i];
				EnjoyPubLib.Util.ElementUtil.StyledStringElement e = new EnjoyPubLib.Util.ElementUtil.StyledStringElement (item.BookName, item.Author, UITableViewCellStyle.Subtitle);
				if (!string.IsNullOrEmpty (item.Url)) {
					e.ImageUri = new Uri (item.Url);
				}
				//默认只勾选5本
				if (i<=5) {
					e.Accessory = UITableViewCellAccessory.Checkmark;
				}

				//e.Value = item.Author;
				e.Tapped += delegate {
					if (e.Accessory == UITableViewCellAccessory.None) {
						e.Accessory = UITableViewCellAccessory.Checkmark;
					}
					else
						if (e.Accessory == UITableViewCellAccessory.Checkmark) {
							e.Accessory = UITableViewCellAccessory.None;
						}
					Root.Reload (Wantreadlist, UITableViewRowAnimation.None);
				};
				Wantreadlist.Add (e);
			}

			Root.Add (Wantreadlist);

		}



		public override DialogViewController.Source CreateSizingSource (bool unevenRows)
		{
			if (unevenRows)
				throw new NotImplementedException ("You need to create a new SourceSizing subclass, this sample does not have it");
			return new EditingSource (this);
		}

	}

}

