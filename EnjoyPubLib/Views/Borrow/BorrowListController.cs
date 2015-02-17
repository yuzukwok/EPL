using System;
using System.Text;
using EnjoyPubLib.Util.ElementUtil;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using EnjoyPubLib.Util.View;
using Evernote;
using Evernote.EDAM.Type;
using Thrift.Transport;
using Thrift.Protocol;
using Evernote.EDAM.UserStore;
using Evernote.EDAM.NoteStore;
using Evernote.EDAM.Error;
using EnjoyPubLib.WebService;


namespace EnjoyPubLib.View
{
	public class BorrowListController:BaseDialogViewController
	{
		public BorrowListController ():base(false)
		{
			Title="索书列表";

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			createtable ();

		}

		public void createtable(){
			var bks = new dal ().QueryWishBowBooks (AppDelegate.Connection);
			StringBuilder str = new  StringBuilder ();
			if (bks!=null&&bks.Count>0) {
				var list = new Section (bks [0].BookLoction);
				foreach (var bk in bks) {

					EnjoyPubLib.Util.ElementUtil.StyledStringElement e = 
						new EnjoyPubLib.Util.ElementUtil.StyledStringElement (bk.BookName,bk.BookDesc,UITableViewCellStyle.Subtitle);

					str.AppendLine ("<en-todo/>"+bk.BookName + " <div style=\"font-weight:bold;color:red;\">" + bk.BookDesc+"</div>");
					//str.AppendLine("<br/>");
					list.Add (e);
				}

				Root.Add (list);
			}



			var btnshare = new UIBarButtonItem ("保存到印象笔记",UIBarButtonItemStyle.Plain, delegate {

				if (bks==null||bks.Count==0) {
					return;
				}

				//evttk
				var tk=new dal().getKV(AppDelegate.Connection, "EvernoteTK");
				Note note = new Note();
				note.Title = "借书趣"+DateTime.Now.ToString();

				note.Content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
					"<!DOCTYPE en-note SYSTEM \"http://xml.evernote.com/pub/enml2.dtd\">" +
					"<en-note>"+str.ToString()+
					"</en-note>";


				Uri userStoreUrl = new Uri(EvernoteUtil.evernotehost + "edam/user");
				TTransport userStoreTransport = new THttpClient(userStoreUrl);
				TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
				UserStore.Client userStore = new UserStore.Client(userStoreProtocol);

				// Get the URL used to interact with the contents of the user's account
				// When your application authenticates using OAuth, the NoteStore URL will
				// be returned along with the auth token in the final OAuth request.
				// In that case, you don't need to make this call.
				try {
					String noteStoreUrl = userStore.getNoteStoreUrl(tk);

					TTransport noteStoreTransport = new THttpClient(new Uri(noteStoreUrl));
					TProtocol noteStoreProtocol = new TBinaryProtocol(noteStoreTransport);
					NoteStore.Client noteStore = new NoteStore.Client(noteStoreProtocol);

					Note createdNote = noteStore.createNote(tk, note);
					UIAlertView v=new UIAlertView("提示","已保存到印象笔记",null,"OK",null);
					v.Show();

				} 
				catch (EDAMUserException e1) {

					// 重新授权
					NavigationController.PushViewController(new AddEvernoteAccountViewController(),true);

				}
				catch(Exception e2)
				{

				}

			});
			this.NavigationItem.RightBarButtonItem = btnshare;
			}



	}
}

