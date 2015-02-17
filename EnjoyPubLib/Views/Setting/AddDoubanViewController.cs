using System;
using EnjoyPubLib.Util.View;
using MonoTouch.Dialog;
using EnjoyPubLib.Util;
using EnjoyPubLib.Service.Douban;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
namespace EnjoyPubLib
{
	public partial class AddDoubanViewController : UIViewController
	{
		public AddDoubanViewController () : base ("AddDoubanViewController", null)
		{
			Title="添加豆瓣帐号";
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			Create ();
		}
		void Create ()
		{
			UriBuilder ub = new UriBuilder(Common.AUTHGETCODE);
			EnjoyPubLib.Service.Douban.Utilities.AddParam(ref ub, "client_id", Contans.DoubanApiKey);
			EnjoyPubLib.Service.Douban.Utilities.AddParam(ref ub, "redirect_uri", Contans.DoubanRedirectUri);
			EnjoyPubLib.Service.Douban.Utilities.AddParam(ref ub, "response_type", Common.RESPONSETYPE);

			string url = ub.ToString();



			web.LoadRequest(new NSUrlRequest(new Uri(url)));
			web.LoadFinished += (s, e) => {

				var str = web.Request.Url.AbsoluteString;
				if (str.Contains(Contans.DoubanRedirectUri)) {

					if (str.Contains("code")) {
						Common.AuthCode =	str.Split('=')[1];
						var tk=DoubanAPI.AuthGetToken();
						var user =DoubanAPI.UsrGetMe();
						dal d=new dal();
						d.setKV(AppDelegate.Connection,Contans.DefaultDoubanAuthKey,tk.Token);
						d.setKV(AppDelegate.Connection,Contans.DefaultDoubanUserName,user.Name);
						d.setKV(AppDelegate.Connection,Contans.DefaultDoubanAvatar,user.Avatar);
						NavigationController.PopViewControllerAnimated(true);
					}else
					{
						UIAlertView v=new UIAlertView("信息","未能成功授权，请重试",null,"OK",null);
						v.Show();
						NavigationController.PopViewControllerAnimated(true);
					}
				}

			};

			this.Add (web);


		}
	}
}

