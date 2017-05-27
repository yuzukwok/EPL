using System;
using EnjoyPubLib.Util.View;
using EnjoyPubLib.Dto;
using MonoTouch.Dialog;
using UIKit;
using System.Linq;
using EnjoyPubLib.Util.ElementUtil;
using EnjoyPubLib.WebService;
using System.Collections.Generic;

namespace EnjoyPubLib.View
{
	public class BorrowPVListController:BaseDialogViewController
	{
		public BorrowPVListController (CanBowList c):base(false)
		{
			Title="检索结果";
			dto = c;
		}
		CanBowList dto;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			CreateTable ();
		}
		Section resultlist;
		RootElement rgroot;
		private void CreateTable ()
		{
			//query
		
			var	rlist = new Section ("结果");

			var gpsection = new Section ();
			string loc = "";
			var lnamelist = dto.dictList.Keys.ToList ();
			foreach (var lname in lnamelist) {

				if (string.IsNullOrEmpty(loc)) {
					loc = lname;
				}
				var mr = new MyRadioElement (lname);
				mr.OnSelected += delegate {
					if (rgroot!=null) {
						//System.Diagnostics.Debug.Print(	rgroot.RadioSelected.ToString());
						//更新
						resultlist.Clear();
						var t=gpsection.Elements[rgroot.RadioSelected];
						var dict2=dto.dictList[t.Caption];
						AddInto(dict2,resultlist);
						Root.Reload(resultlist,UITableViewRowAnimation.Automatic);
						//回退
						NavigationController.PopToViewController(this,true);
					}
				};
					gpsection.Add(mr);
			}
				var index = lnamelist.IndexOf ("上海图书馆");
			if (index==-1) {
				index = 0;
			}
			rgroot = new RootElement ("筛选馆址", new RadioGroup (index)){ gpsection };
			rlist.Add(rgroot);
			var btnsave = new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("保存到索书列表");
			btnsave.Alignment = UITextAlignment.Center;
			btnsave.Font = UIFont.SystemFontOfSize (20);
			rlist.Add (btnsave);
			btnsave.Tapped += delegate {
				//保存数据；

				if (resultlist.Elements.Count>0) {
					var d=new dal();
					d.ClearBowList(AppDelegate.Connection);
					foreach (var item in resultlist.Elements) {
						var si=item  as EnjoyPubLib.Util.ElementUtil.StyledStringElement;
						d.AddNewBookIntoBow(AppDelegate.Connection,si.Caption,si.Value,gpsection.Elements[rgroot.RadioSelected].Caption);

						//NavigationController.PopToRootViewController(true);
					}
					UIAlertView v=new UIAlertView("信息","保存成功，返回查看[索书列表]",null,"OK",null);
					v.Show();
				}
			};

			if (dto.dictList.ContainsKey("上海图书馆")) {
				loc="上海图书馆";
			}
			if (dto.dictList.Count>0) {
				var dict = dto.dictList[loc];

				resultlist = new Section ("列表");
				AddInto (dict, resultlist);
			}


			Root.Add (rlist);
			Root.Add (resultlist);


		}

		public void AddInto(IList<BookCollectionDetailResponseCollectionDetailItem> dict,Section resultlist)
		{
			foreach (var i in dict) {

				EnjoyPubLib.Util.ElementUtil.StyledStringElement e = 
					new EnjoyPubLib.Util.ElementUtil.StyledStringElement 
					(i.BookName,i.BookCallReconst+" "+i.BookCollection+" "+i.BookItype,UITableViewCellStyle.Subtitle);


				resultlist.Add (e);
			}
		}
	}
}

