using System;
using System.Collections.Generic;
using CoreGraphics;
using System.Linq;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using MonoTouch.Dialog.Utilities;
using EnjoyPubLib.Util;
using EnjoyPubLib.Util.ThemeUtil;

namespace EnjoyPubLib.Util.ElementUtil
{
	public class NewsFeedElement : Element, IElementSizing, IColorizeBackground, IImageUpdated
    {
		private readonly string _name;
		private readonly string _time;
		private readonly Uri _imageUri;
		private UIImage _image;
		private readonly UIImage _actionImage;
		private readonly int _bodyBlocks;
		private readonly Action _tapped;



		public static UIColor LinkColor = EnjoyPubLib.Util.Theme.CurrentTheme.MainTitleColor;
		public static UIFont LinkFont = UIFont.BoldSystemFontOfSize(13f);

        private UIImage LittleImage { get; set; }



        public class TextBlock
        {
            public string Value;
			public Action Tapped;
            public UIFont Font;
			public UIColor Color;

            public TextBlock()
            {
            }

            public TextBlock(string value)
            {
                Value = value;
            }

			public TextBlock(string value, Action tapped = null)
                : this (value)
            {
                Tapped = tapped;
            }

			public TextBlock(string value, UIFont font = null, UIColor color = null, Action tapped = null)
                : this(value, tapped)
            {
                Font = font; 
                Color = color;
            }
        }
		//BItem _item;
		public NewsFeedElement(string name, string imageUrl, IEnumerable<TextBlock> headerBlocks, IEnumerable<TextBlock> bodyBlocks, UIImage littleImage, Action tapped)
			: base(null)
        {
			_name = name;
			//_item = item;
			_imageUri = new Uri(imageUrl);
			//_time = time.ToDaysAgo();
			_actionImage = littleImage;
			_tapped = tapped;

		}
		public NewsFeedElement (string name, string imageUrl) : base (null)
		{
			_name = name;

			_imageUri = new Uri (imageUrl);

		}



	

		private static nfloat CharacterHeight = "A".MonoStringHeight(UIFont.SystemFontOfSize(13f), 1000);

		public nfloat GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
//			if (_attributedBody.Length > 0)
//			{
//				var rec = _attributedBody.GetBoundingRect(new SizeF(tableView.Bounds.Width - 56, 10000), NSStringDrawingOptions.UsesLineFragmentOrigin | NSStringDrawingOptions.UsesFontLeading, null);
//				var height = rec.Height;
//
//				if (_bodyBlocks == 1 && height > (CharacterHeight * 4))
//					height = CharacterHeight * 4;
//
//				var descCalc = 66f + height;
//				var ret = ((int)Math.Ceiling(descCalc)) + 1f + 8f;
//				return ret;
//			}
			return 66f;
		}

		private bool IsHeaderMultilined(UITableView tableView)
		{
			return true;
		
		}

		protected override NSString CellKey {
			get {
				return new NSString("NewsCellView");
			}
		}

		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = tv.DequeueReusableCell(CellKey) as NewsCellView ?? NewsCellView.Create();
			return cell;
		}

		public override void Selected(DialogViewController dvc, UITableView tableView, NSIndexPath path)
		{
			base.Selected(dvc, tableView, path);
			if (_tapped != null)
				_tapped();
			tableView.DeselectRow (path, true);
		}

		void IColorizeBackground.WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			var c = cell as NewsCellView;
			if (c == null)
				return;

			if (_image == null && _imageUri != null)
				_image = ImageLoader.DefaultRequestImage(_imageUri, this);


			c.Set(_name, _image, _name);
		}

		#region IImageUpdated implementation

		public void UpdatedImage(Uri uri)
		{
			var img = ImageLoader.DefaultRequestImage(uri, this);
			if (img == null)
				return;
			_image = img;

			if (uri == null)
				return;
			var root = GetImmediateRootElement ();
			if (root == null || root.TableView == null)
				return;
			root.TableView.ReloadRows (new [] { IndexPath }, UITableViewRowAnimation.None);
		}

		#endregion
    }
}