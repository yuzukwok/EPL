using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using MonoTouch.Dialog.Utilities;
using MonoTouch.Foundation;

namespace EnjoyPubLib.Util.ElementUtil
{
	/// <summary>
	///   A version of the StringElement that can be styled with a number of formatting 
	///   options and can render images or background images either from UIImage parameters 
	///   or by downloading them from the net.
	/// </summary>
	public class StyledStringElement : StringElement, IImageUpdated, IColorizeBackground {
		public static UIFont  DefaultTitleFont = UIFont.BoldSystemFontOfSize(15f);
		public static UIFont  DefaultDetailFont = UIFont.SystemFontOfSize(15f);
		public static UIColor DefaultTitleColor = UIColor.FromRGB(41, 41, 41);
		public static UIColor DefaultDetailColor = UIColor.FromRGB(120, 120, 120);
		public static UIColor BgColor = UIColor.White;

		static NSString [] skey = { new NSString (".1"), new NSString (".2"), new NSString (".3"), new NSString (".4") };

		public StyledStringElement (string caption) : base (caption) 
		{
			Init();
		}

		public StyledStringElement (string caption, NSAction tapped) : base (caption, tapped) 
		{
			Accessory = UITableViewCellAccessory.DisclosureIndicator;
			Init();
		}

		public StyledStringElement (string caption, NSAction tapped, UIImage image) : base (caption, tapped) 
		{
			Accessory = UITableViewCellAccessory.DisclosureIndicator;
			Init();
			Image = image;
		}


		public StyledStringElement (string caption, string value) : base (caption, value) 
		{
			style = UITableViewCellStyle.Value1;
			Init();
		}
		public StyledStringElement (string caption, string value, UITableViewCellStyle style) : base (caption, value) 
		{ 
			this.style = style;
			Init();
		}

		protected UITableViewCellStyle style;
		public event NSAction AccessoryTapped;
		public UIFont Font;
		public UIFont SubtitleFont;
		public UIColor TextColor;
		public UILineBreakMode LineBreakMode = UILineBreakMode.WordWrap;
		public int Lines = 1;
		public UITableViewCellAccessory Accessory = UITableViewCellAccessory.None;

		private void Init()
		{
			Font = DefaultTitleFont;
			SubtitleFont = DefaultDetailFont;
			BackgroundColor = BgColor;
			TextColor = DefaultTitleColor;
			DetailColor = DefaultDetailColor;
			LineBreakMode = UILineBreakMode.TailTruncation;
		}

		// To keep the size down for a StyleStringElement, we put all the image information
		// on a separate structure, and create this on demand.
		ExtraInfo extraInfo;

		class ExtraInfo {
			public UIImage Image; // Maybe add BackgroundImage?
			public UIColor BackgroundColor, DetailColor;
			public Uri Uri, BackgroundUri;
		}

		ExtraInfo OnImageInfo ()
		{
			if (extraInfo == null)
				extraInfo = new ExtraInfo ();
			return extraInfo;
		}

		// Uses the specified image (use this or ImageUri)
		public UIImage Image {
			get {
				return extraInfo == null ? null : extraInfo.Image;
			}
			set {
				OnImageInfo ().Image = value;
				extraInfo.Uri = null;
			}
		}

		// Loads the image from the specified uri (use this or Image)
		public Uri ImageUri {
			get {
				return extraInfo == null ? null : extraInfo.Uri;
			}
			set {
				OnImageInfo ().Uri = value;
				extraInfo.Image = null;
			}
		}

		// Background color for the cell (alternative: BackgroundUri)
		public UIColor BackgroundColor {
			get {
				return extraInfo == null ? null : extraInfo.BackgroundColor;
			}
			set {
				OnImageInfo ().BackgroundColor = value;
				extraInfo.BackgroundUri = null;
			}
		}

		public UIColor DetailColor {
			get {
				return extraInfo == null ? null : extraInfo.DetailColor;
			}
			set {
				OnImageInfo ().DetailColor = value;
			}
		}

		// Uri for a Background image (alternatiev: BackgroundColor)
		public Uri BackgroundUri {
			get {
				return extraInfo == null ? null : extraInfo.BackgroundUri;
			}
			set {
				OnImageInfo ().BackgroundUri = value;
				extraInfo.BackgroundColor = null;
			}
		}

		protected virtual string GetKey (int style)
		{
			return skey [style];
		}

		protected virtual void OnCellCreated(UITableViewCell cell)
		{
		}

		protected virtual UITableViewCell CreateTableViewCell(UITableViewCellStyle style, string key)
		{
			return new UITableViewCell (style, key);
		}

		public override UITableViewCell GetCell (UITableView tv)
		{
			var key = GetKey ((int) style);
			var cell = tv.DequeueReusableCell (key);
			if (cell == null){
				cell = CreateTableViewCell(style, key);
				OnCellCreated(cell);
				cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			}
			PrepareCell (cell);
			return cell;
		}

		protected void PrepareCell (UITableViewCell cell)
		{
			cell.Accessory = Accessory;
			var tl = cell.TextLabel;
			tl.Text = Caption;
			tl.TextAlignment = Alignment;
			tl.TextColor = TextColor ?? UIColor.Black;
			tl.Font = Font ?? UIFont.BoldSystemFontOfSize (17);
			tl.LineBreakMode = LineBreakMode;
			tl.Lines = Lines;	

			// The check is needed because the cell might have been recycled.
			if (cell.DetailTextLabel != null)
				cell.DetailTextLabel.Text = Value == null ? "" : Value;

			if (extraInfo == null){
				ClearBackground (cell);
			} else {
				var imgView = cell.ImageView;
				UIImage img;

				if (imgView != null) {
					if (extraInfo.Uri != null)
						img = ImageLoader.DefaultRequestImage (extraInfo.Uri, this);
					else if (extraInfo.Image != null)
						img = extraInfo.Image;
					else 
						img = null;
					imgView.Image = img;
				}

				if (cell.DetailTextLabel != null)
					cell.DetailTextLabel.TextColor = extraInfo.DetailColor ?? UIColor.Gray;
			}

			if (cell.DetailTextLabel != null){
				cell.DetailTextLabel.Lines = Lines;
				cell.DetailTextLabel.LineBreakMode = LineBreakMode;
				cell.DetailTextLabel.Font = SubtitleFont ?? UIFont.SystemFontOfSize (14);
				cell.DetailTextLabel.TextColor = (extraInfo == null || extraInfo.DetailColor == null) ? UIColor.Gray : extraInfo.DetailColor;
			}
		}	

		void ClearBackground (UITableViewCell cell)
		{
			cell.BackgroundColor = UIColor.White;
			cell.TextLabel.BackgroundColor = UIColor.Clear;

			if (cell.DetailTextLabel != null)
				cell.DetailTextLabel.BackgroundColor = UIColor.Clear;
		}

		void IColorizeBackground.WillDisplay (UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			ClearBackground (cell);

			if (extraInfo == null)
				return;


			if (extraInfo.BackgroundColor != null){
				cell.BackgroundColor = extraInfo.BackgroundColor;
				cell.TextLabel.BackgroundColor = UIColor.Clear;
			} else if (extraInfo.BackgroundUri != null){
				var img = ImageLoader.DefaultRequestImage (extraInfo.BackgroundUri, this);
				cell.BackgroundColor = img == null ? UIColor.White : UIColor.FromPatternImage (img);
				cell.TextLabel.BackgroundColor = UIColor.Clear;
			} 
		}

		void IImageUpdated.UpdatedImage (Uri uri)
		{
			if (uri == null || extraInfo == null)
				return;
			var root = GetImmediateRootElement ();
			if (root == null || root.TableView == null)
				return;
			root.TableView.ReloadRows (new NSIndexPath [] { IndexPath }, UITableViewRowAnimation.None);
		}	

		internal void AccessoryTap ()
		{
			NSAction tapped = AccessoryTapped;
			if (tapped != null)
				tapped ();
		}
	}
}

