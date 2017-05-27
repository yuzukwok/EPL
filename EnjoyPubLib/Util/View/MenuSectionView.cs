using System;
using UIKit;
using CoreGraphics;

namespace EnjoyPubLib
{
	public class MenuSectionView : UIView
	{
		public MenuSectionView(string caption)
			: base(new CGRect(0, 0, 320, 27))
		{
			//var background = new UIImageView(Theme.CurrentTheme.MenuSectionBackground);
			//background.Frame = this.Frame; 

			this.BackgroundColor = UIColor.FromRGB(47, 131, 163);

			var label = new UILabel(); 
			label.BackgroundColor = UIColor.Clear;
			label.Opaque = false; 
			label.TextColor =UIColor.FromRGB(255,255,255); 
			label.Font =  UIFont.BoldSystemFontOfSize(12.5f);
			label.Frame = new CGRect(8,1,200,23); 
			label.Text = caption; 
//            label.ShadowColor = UIColor.FromRGB(0, 0, 0); 
//            label.ShadowOffset = new SizeF(0, -1); 

			//this.AddSubview(background); 
			this.AddSubview(label); 
		}
	}
}

