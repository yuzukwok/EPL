using System;
using System.Collections.Generic;
using EnjoyPubLib.Util.View;
using MonoTouch.Dialog;
using EnjoyPubLib.Util;
using System.Threading.Tasks;
using System.Threading;
using EnjoyPubLib.Service;
using BigTed;
using EnjoyPubLib.WebService;
using EnjoyPubLib.Service.Douban;
using EnjoyPubLib.ImagesUtil;
using UIKit;
using ZXing;
using ZXing.Mobile;
using iAd;

namespace EnjoyPubLib.View
{
	public class BookSeekController:BaseDialogViewController
	{
		public BookSeekController () : base (false)
		{
			Title = "新增想借";
		}
		MobileBarcodeScanner scanner;
		public override void ViewDidLoad ()
		{
			//Create a new instance of our scanner
			scanner = new MobileBarcodeScanner(this.NavigationController);
			var btnscan = new UIBarButtonItem (UIBarButtonSystemItem.Camera);
			btnscan.Clicked+=  async delegate(object sender, EventArgs e) {

						//Tell our scanner to use the default overlay
						scanner.UseCustomOverlay = false;
						//We can customize the top and bottom text of the default overlay
						scanner.TopText = "请保持相机稳定";
						scanner.BottomText = "条码会自动扫描";
						scanner.CancelButtonText = "取消";
						scanner.FlashButtonText = "闪光灯";

						//Start scanning
						var result = await scanner.Scan ();

						HandleScanResult (result);
					};
			UIBarButtonItem[] items = new UIBarButtonItem[]
			{
				btnscan
			};
			NavigationItem.RightBarButtonItems = items;
			CreateTable ();
			base.ViewDidLoad ();
		}

		void HandleScanResult(ZXing.Result result)
		{
			string msg = "";
			string isbn = "";
			string name = "None";
			bool found = false;
			if (result != null && !string.IsNullOrEmpty(result.Text))
				msg = "找到条码: " + result.Text;
			else
				msg = "取消!";
			//query 
			if (result!=null&&result.Text!=null) {
				isbn = result.Text;
				var books=  IpacHelper.Sreach(IPACS.Mobile_iPacType.ISBN,result.Text);

				//add
				if (books.Result.MaxRows > 0) {
					//add


					msg +=Environment.NewLine+books.Result.BookItem[0].title+ "已加入想借清单";

					dal d = new dal ();
					string url = "";
					if (string.IsNullOrEmpty(books.Result.BookItem [0].isbn)) {

						var m= IpacHelper.GetBookCover (books.Result.BookItem [0].isbn);
						url = m.PicUri;

					}
					d.AddNewBookIntoWish (AppDelegate.Connection,books.Result.BookItem [0],url);
					found = true;
				} else {
					msg += "但图书馆没找到库存，未添加";
				}
			}



			this.InvokeOnMainThread(() => {

				NavigationController.PushViewController(new AddNotifyInfoShowViewController(!found,msg,new string[]{isbn},new string[]{name}),true);
				//var av = new UIAlertView("条码扫描结果", msg, null, "OK", null);
				//av.Show();
			});
		}



		void Sreach (IPACS.Mobile_iPacType subject, string value)
		{


			this.DoWorkAsync ("查询中...", async () => {

				//query
				var books= await IpacHelper.Sreach(subject,value);
				//show

				NavigationController.PushViewController(new BookSeekResultController(books),true);


			});

		}

		void AddMoreSreach (LoadMoreElement loadm)
		{
			secitonbtn.Add (new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("按ISBN搜索", () => {
				Sreach (IPACS.Mobile_iPacType.ISBN, entry.Value);
			}));
			secitonbtn.Add (new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("按ISRC搜索", () => {
				Sreach (IPACS.Mobile_iPacType.ISSN, entry.Value);
			}));
//			secitonbtn.Add (new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("按主题搜索", () => {
//				Sreach (EnjoyPubLib.IPACS.Mobile_iPacType.subject, entry.Value);
//			}));

			//remove load more
			secitonbtn.Remove (2);
			loadm.Animating = false;
		}

		Section secitonbtn;
		EntryElement entry;

		void CreateTable ()
		{
			var secitonbtn = new Section ("搜索");
			entry = new EntryElement ("", "请输入检索关键词", "");
			secitonbtn.Add (entry);

			//secitonbtn = new Section ("");
			secitonbtn.Add (new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("按题名搜索", () => {
				if (string.IsNullOrEmpty(entry.Value)) {
					UIAlertView v=new UIAlertView("信息","请输入查询关键词",null,"OK",null);
					v.Show();
				}else{
					Sreach (IPACS.Mobile_iPacType.title, entry.Value);}
			}));
			secitonbtn.Add (new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("按著者搜索", () => {
				if (string.IsNullOrEmpty(entry.Value)) {
					UIAlertView v=new UIAlertView("信息","请输入查询关键词",null,"OK",null);
					v.Show();
				}else{
					Sreach (IPACS.Mobile_iPacType.author, entry.Value);}
			}));
			secitonbtn.Add (new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("按ISBN搜索", () => {
				if (string.IsNullOrEmpty(entry.Value)) {
					UIAlertView v=new UIAlertView("信息","请输入查询关键词",null,"OK",null);
					v.Show();
				}else{

					Sreach (IPACS.Mobile_iPacType.ISBN, entry.Value);}
			}));
//			secitonbtn.Add (new  LoadMoreElement ("其他搜索选项", "加载中", (loadm) => {
//				AddMoreSreach (loadm);
//			}));


			var sectionimport = new Section ("导入");
			sectionimport.Add (new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("导入豆瓣想读", () => {
				//判断是否已经关联豆瓣
				dal d=new dal();
				var tk=d.getKV(AppDelegate.Connection,Contans.DefaultDoubanAuthKey);
				if (!string.IsNullOrEmpty(tk)) {
					//导入想读
					Common.Token=tk;

					var user=DoubanAPI.UsrGetMe();
					if (user ==null) {
						//重新授权

							this.NavigationController.PushViewController(new AddDoubanViewController(),true);
					}else{

						BTProgressHUD.Show("导入中");

						ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state) {



							//判断Lasterror
							var cols=	DoubanAPI.BkGetUserCols(user.Uid,"wish",null,null,null,null,null,15);
							BTProgressHUD.Dismiss();
							InvokeOnMainThread(delegate {
								this.NavigationController.PushViewController(new DouWishListViewController(cols.Collections),true);});
						}));

					}

				

				}else
				{
					//去关联豆瓣帐号
					this.NavigationController.PushViewController(new AddDoubanViewController(),true);

				}
			},Images.Wish));
			//Root.Add (section);
			//sectionimport.Add (new IAdHelper ().Get ());

			Root.Add (secitonbtn);
			Root.Add (sectionimport);

			Root.UnevenRows = true;
		}
				
	}
}

