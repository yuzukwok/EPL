using System;
using EnjoyPubLib.Util.View;
using System.Collections;
using System.Collections.Generic;
using MonoTouch.Dialog;
using EnjoyPubLib.Util.ElementUtil;

namespace EnjoyPubLib
{
	public class BookSeekResultController:BaseDialogViewController
	{
		public BookSeekResultController ():base(true)
		{
		}
		IPACS.Mobile_iPacResponse bs;
		public BookSeekResultController (IPACS.Mobile_iPacResponse books):base(true)
		{
			bs = books;
		}

		void createElement ()
		{
			if (bs!=null) {
				var section = new Section ("搜索结果");
				if (bs.BookItem!=null) {
					foreach (var item in bs.BookItem) {
						//NewsFeedElement e = new NewsFeedElement (item.Name, "", item, null, null, null, null);
						MultilinedElement element = new MultilinedElement (item.title);

						element.Tapped += () => {
							var bvc=new BookInfoController(item);
							bvc.Root.UnevenRows=true;
							NavigationController.PushViewController(bvc,true);
						};
						section.Add (element);
					}
				}

				Root.Add (section);
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			createElement ();
		}
	}
}

