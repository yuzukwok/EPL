using System;
using MonoTouch.Dialog;
using MonoTouch;
using UIKit;
using MonoTouch.Dialog.Utilities;
using CoreGraphics;
using Foundation;

namespace EnjoyPubLib.Util.ElementUtil
{

	public  class MultilineWithChineseWordElement : MonoTouch.Dialog.StringElement, MonoTouch.Dialog.IElementSizing {
		public MultilineWithChineseWordElement (string caption) : base (caption)
		{
		}

		public MultilineWithChineseWordElement (string caption, string value) : base (caption, value)
		{
		}

		public MultilineWithChineseWordElement (string caption, Action tapped) : base (caption, tapped)
		{
		}

		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = base.GetCell (tv);				
			var tl = cell.TextLabel;
			tl.LineBreakMode = UILineBreakMode.CharacterWrap;
			tl.Lines = 0;

			return cell;
		}

		public virtual nfloat GetHeight (UITableView tableView, NSIndexPath indexPath)
		{

//			float margin = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? 40f : 110f;
//			CGSize size = new CGSize (tableView.Bounds.Width - margin, float.MaxValue);
//			UIFont font = UIFont.BoldSystemFontOfSize (17);
//			string c = Caption;
//			// ensure the (single-line) Value will be rendered inside the cell
//			if (String.IsNullOrEmpty (c) && !String.IsNullOrEmpty (Value))
//				c = " ";
//
//			return tableView.StringSize (c, font, size, UILineBreakMode.WordWrap).Height + 10;
			//TODO miss
			return 30;
		}
	}


	public class MultilinedElement : CustomElement
	{
		private const float PaddingY = 12f;
		private const float PaddingX = 15f;

		private string _value;

		public string Value
		{
			get { return _value; }
			set
			{
				_value = value;
				var root = GetImmediateRootElement();
				if (root != null)
				{
					root.Reload(this, UITableViewRowAnimation.None);
				}
			}
		}


		public UIFont CaptionFont { get; set; }
		public UIFont ValueFont { get; set; }
		public UIColor CaptionColor { get; set; }
		public UIColor ValueColor { get; set; }

		public MultilinedElement(string caption, string value)
			: this(caption)
		{
			Value = value;
		}

		public MultilinedElement(string caption)
			: base(UITableViewCellStyle.Default, "multilinedelement")
		{
			Caption = caption;
			BackgroundColor = UIColor.White;
			CaptionFont = UIFont.SystemFontOfSize(15f);
			ValueFont = UIFont.SystemFontOfSize(13f);
			CaptionColor = ValueColor = UIColor.FromRGB(41, 41, 41);
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = base.GetCell(tv);
			cell.SeparatorInset = UIEdgeInsets.Zero;
			return cell;
		}

		public override void Draw(CGRect bounds, CoreGraphics.CGContext context, UIView view)
		{
			view.BackgroundColor = UIColor.White;
			CaptionColor.SetColor();
			var width = bounds.Width - PaddingX * 2;
			//var textHeight = Caption.MonoStringHeight(CaptionFont, width);
			//TODO miss
//			view.DrawString(Caption, new CGRect(PaddingX, PaddingY, width, bounds.Height - PaddingY * 2), CaptionFont, UILineBreakMode.WordWrap);
//
//			if (Value != null)
//			{
//				ValueColor.SetColor();
//				var valueOrigin = new CGPoint(PaddingX, PaddingY + textHeight + 6f);
//				var valueSize = new CGSize(width, bounds.Height - valueOrigin.Y);
//				view.DrawString(Value, new CGRect(valueOrigin, valueSize), ValueFont, UILineBreakMode.WordWrap);
//			}
		}

		public override float Height(CGRect bounds)
		{
			var width = bounds.Width - PaddingX * 2;
			if (IsTappedAssigned)
				width -= 20f;
			//TODO miss
			return 20f;
//			var textHeight = Caption.MonoStringHeight(CaptionFont, width);
//
//			if (Value != null)
//			{
//				textHeight += 6f;
//				textHeight += Value.MonoStringHeight(ValueFont, width);
//			}
//
//			return (int)Math.Ceiling(textHeight + PaddingY * 2) + 1;
		}
	}
}

