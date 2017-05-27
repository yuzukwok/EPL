using System;
using MonoTouch;
using UIKit;
using EnjoyPubLib.WebService;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using CoreGraphics;
using Foundation;
using MonoTouch.Dialog;
using Thrift.Transport;
using Thrift.Protocol;
using Evernote.EDAM.UserStore;


namespace EnjoyPubLib
{

	public  class AddEvernoteAccountViewController:UIViewController
	{

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public AddEvernoteAccountViewController ()
		{
			Title="印象笔记";
		}
		oAuthEvernote evernoteoauth;
		UIWebView web;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			web = new UIWebView (View.Bounds);

			
			evernoteoauth = new oAuthEvernote (HostService.Production, EvernoteUtil.cousumerkey, EvernoteUtil.cousumerserct);
			string rtoken = evernoteoauth.getRequestToken ();
			string _token = "";
			string _verifier = "";


			web.LoadRequest(new NSUrlRequest(
				new Uri(evernoteoauth.AuthorizationLink)));
			web.LoadFinished += (s, e) => {

				var str = web.Request.Url.AbsoluteString;
				if (str.Contains(Contans.DoubanRedirectUri)) {
					string query = web.Request.Url.Query;
					if (query.Length > 0) {
						NameValueCollection nameValueCollection = HttpUtility.ParseQueryString (query);
						if (nameValueCollection ["oauth_token"] != null) {
							_token = nameValueCollection ["oauth_token"];
						}
						if (nameValueCollection ["oauth_verifier"] != null) {
							evernoteoauth.Verifier = nameValueCollection ["oauth_verifier"];
						}

						try {
							NameValueCollection accessToken = evernoteoauth.getAccessToken ();
							evernoteoauth.Token = accessToken ["oauth_token"];
							//						evernoteoauth.NoteStoreUrl = accessToken ["edam_noteStoreUrl"];
							string UserId = accessToken ["edam_userId"];
							//						evernoteoauth.Expires = Convert.ToInt64 (accessToken ["edam_expires"]);
							//						evernoteoauth.WebApiUrlPrefix = accessToken ["edam_webApiUrlPrefix"];
							dal d=new dal();


							Uri userStoreUrl = new Uri(EvernoteUtil.evernotehost +"edam/user");
							TTransport userStoreTransport = new THttpClient(userStoreUrl);
							TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
							UserStore.Client userStore = new UserStore.Client(userStoreProtocol);
							var user =userStore.getUser(evernoteoauth.Token);

							d.setKV(AppDelegate.Connection,"EvernoteTK",evernoteoauth.Token);
							d.setKV(AppDelegate.Connection,"EvernoteUser",user.Username);
						} catch (Exception ex) {
							
						}

						NavigationController.PopViewController(true);
					}				
				}else
				{

				}

			};
			View.AddSubview(web);



		}
	}
}

