using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using EnjoyPubLib.Util.ElementUtil;

namespace EnjoyPubLib.Util
{
    public partial class NewsCellView : UITableViewCell
    {
        public static readonly UINib Nib = UINib.FromName("NewsCellView", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("NewsCellView");
		public static readonly UIEdgeInsets EdgeInsets = new UIEdgeInsets(0, 48f, 0, 0);

		public class Link
		{
			public NSRange Range;
			public Action Callback;
			public int Id;
		}

        public NewsCellView(IntPtr handle) : base(handle)
        {
        }

		public void Set(string name, UIImage img, string writer)
		{
			this.Image.Image = img;
			this.Title.Text = name;
			//	this.Writer.Text = writer;



		}



        public static NewsCellView Create()
        {
			var cell = (NewsCellView)Nib.Instantiate(null, null)[0];
		
			cell.SeparatorInset = EdgeInsets;
			//cell.Header.CenterVertically = true;
			return cell;
        }
    }
}

