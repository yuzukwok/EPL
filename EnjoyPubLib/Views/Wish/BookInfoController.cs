using System;
using EnjoyPubLib.Util.View;
using System.Collections;
using System.Collections.Generic;
using MonoTouch.Dialog;
using EnjoyPubLib.Util.ElementUtil;
using MonoTouch.UIKit;
using System.Drawing;
using EnjoyPubLib.WebService;
using MonoTouch.Dialog.Utilities;
using EnjoyPubLib.ImagesUtil;
namespace EnjoyPubLib
{
	public class BookInfoController:BaseDialogViewController
	{
		public BookInfoController ():base(true)
		{
		}
		IPACS.Mobile_iPacResponseBookItem bs;
		public BookInfoController (IPACS.Mobile_iPacResponseBookItem bk):base(true)
		{
			bs = bk;
			mpicurl = "";
		}
		string mpicurl="";
	



		string title;
				Section section;
		void createElement ()
		{
			if (bs != null) {
				title = bs.title;
				 section = new Section (title);

				if (!string.IsNullOrEmpty(bs.isbn)) {
					//load pic
					var m= IpacHelper.GetBookCover (bs.isbn);
					mpicurl = m.PicUri;

					EnjoyPubLib.Util.ElementUtil.StyledStringElement ep = new EnjoyPubLib.Util.ElementUtil.StyledStringElement (title);
					ep.ImageUri = new Uri (m.PicUri);

					section.Add (ep);
				}
				StringElement e1 = new StringElement ("作者："+bs.author);
				StringElement e2 = new StringElement ("索书号:"+bs.callno);


				StringElement e4 = new StringElement ("出版社:"+bs.publisher);

				StringElement e6 = new StringElement ("年份:"+bs.date);
				StringElement e7 = new StringElement ("ISBN:"+bs.isbn);

						
				section.Add (e1);
				section.Add (e2);

				section.Add (e4);

				section.Add (e6);
				section.Add (e7);

				if (!string.IsNullOrEmpty(bs.content)) {
					MultilineElement e3 = new MultilineElement("简介:"+bs.content);
					section.Add (e3);
				}



				var section2 = new Section ("操作");
				EnjoyPubLib.Util.ElementUtil.StyledStringElement e = new EnjoyPubLib.Util.ElementUtil.StyledStringElement ("加入想借清单");
				e.Tapped += () => {

					//保存图书
					//以ipacId为主键查找是否存在
					dal d=new dal();
					d.AddNewBookIntoWish(AppDelegate.Connection,bs,mpicurl);


					//return
					NavigationController.PopViewControllerAnimated(true);
				};
				e.Alignment = UITextAlignment.Center;
				e.Font = UIFont.SystemFontOfSize (20);
				section2.Add (e);

				Root.Add (section);
				Root.Add (section2);
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			createElement ();
		}
	}
}

