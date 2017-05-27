using System;
using MonoTouch.Dialog;
using UIKit;
using EnjoyPubLib.Util.View;
using EnjoyPubLib.ImagesUtil;
using EnjoyPubLib.View;

namespace EnjoyPubLib
{
	public class MenuView : MenuBaseViewController
	{
		private MenuElement _notifications;
		private Section _favoriteRepoSection;

		public MenuElement wantbooklistmenu;

		protected override void CreateMenuRoot()
		{
			var username = "借书趣";
			Title = username;
			var root = new RootElement(username);
			//want read book count
			 wantbooklistmenu = new MenuElement ("想借清单".t (), () => NavPush (new WishBookListController ()), Images.Wish);
			var c = new dal ().QueryWishBooksCount (AppDelegate.Connection);
			wantbooklistmenu.NotificationNumber = c;
			//想看
			var wishseciton = new Section() { HeaderView = new MenuSectionView("想借".t()) };
			root.Add(wishseciton);
			wishseciton.Add(new MenuElement("新增想借".t(), () => NavPush(new BookSeekController()), Images.Wish));
			wishseciton.Add(wantbooklistmenu);
			//想借
			var borrowsection = new Section() { HeaderView = new MenuSectionView("可借".t()) };
			root.Add(borrowsection);
			borrowsection.Add(new MenuElement("图书馆".t(), ()=>NavPush(new LibInfoListViewController()),Images.Wish));
			borrowsection.Add(new MenuElement("索书列表".t(), ()=>NavPush(new BorrowListController()),Images.Borrow));
			//设置
			var settingsection = new Section() { HeaderView = new MenuSectionView("设置".t()) };
			root.Add(settingsection);
			settingsection.Add(new MenuElement("设置".t(), ()=>NavPush(new SettingsViewController()),Images.Cog));
			//settingsection.Add(new MenuElement("反馈论坛".t(), PresentUserVoice , Images.Info));
			settingsection.Add(new MenuElement("关于".t(), () => NavPush(new AboutViewController()), Images.Info));
			Root = root;

		}


//		private void PresentUserVoice()
//		{
//			            var config = new UserVoice.UVConfig() {
//				Key = "e9dbxWDWKo5H5f9aZgjIPw",
//				Secret = "bEjt3KHndHURipaUZBGqMA63jNwgSxS6oz6l7qGzpc",
//			                Site = "enjoypublib.uservoice.com",
//			                ShowContactUs = true,
//			                ShowForum = true,
//			                ShowPostIdea = true,
//			                ShowKnowledgeBase = true,
//				         
//			            };
//			            UserVoice.UserVoice.Initialize(config);
//			            UserVoice.UserVoice.PresentUserVoiceInterfaceForParentViewController(this);
//		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			TableView.SeparatorInset = UIEdgeInsets.Zero;
			TableView.SeparatorColor = UIColor.FromRGB(51, 153, 255);
			var av = new dal().getKV (AppDelegate.Connection,Contans.DefaultDoubanAvatar);
			if (!string.IsNullOrEmpty(av)) {
				ProfileButton.Uri = new System.Uri(av);
			}



		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return base.GetCell (tableView, indexPath);
		}



		public override DialogViewController.Source CreateSizingSource(bool unevenRows)
		{
			return new EditSource(this);
		}

		private class EditSource : SizingSource
		{
			private readonly MenuView _parent;
			public EditSource(MenuView dvc) 
				: base (dvc)
			{
				_parent = dvc;
			}

			public override bool CanEditRow(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				if (_parent._favoriteRepoSection == null)
					return false;
				if (_parent.Root[indexPath.Section] == _parent._favoriteRepoSection)
					return true;
				return false;
			}

			public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				if (_parent._favoriteRepoSection != null && _parent.Root[indexPath.Section] == _parent._favoriteRepoSection)
					return UITableViewCellEditingStyle.Delete;
				return UITableViewCellEditingStyle.None;
			}

			public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
			{
				switch (editingStyle)
				{
				case UITableViewCellEditingStyle.Delete:
					var section = _parent.Root[indexPath.Section];
					var element = section[indexPath.Row];
					//_parent.DeletePinnedRepo(element as PinnedRepoElement);
					break;
				}
			}
		}
	}
}

