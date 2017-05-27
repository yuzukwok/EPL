using System;
using EnjoyPubLib.Util.View;
using MonoTouch.Dialog;
using MonoTouch;
using Foundation;
using EnjoyPubLib.Util.ElementUtil;
using EnjoyPubLib.Util;
using UIKit;

namespace EnjoyPubLib.View
{
	public class AboutViewController : BaseDialogViewController
	{
		private const string About = @"借书趣是一款方便用户在上海图书馆借书助手应用。通过扫描条码，导入豆瓣想读等手段可以方便管理想读想借的书目 " +
		                             "应用通过上图的接口和一些算法帮助用户生成借书单，规划用户可以去上图的哪个分馆可以借到最多想要阅读的图书。 " + 
		                              "\n\nyuzukwok && hhpih";

		public AboutViewController()
			: base (true)
		{
			Title = "关于".t();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var root = new RootElement(Title)
			{
				new Section
				{
					new MultilinedElement("借书趣".t()) { Value = About, CaptionColor = Theme.CurrentTheme.MainTitleColor, ValueColor = Theme.CurrentTheme.MainTextColor }
				},
//				new Section
//				{
//					new EnjoyPubLib.Util.ElementUtil.StyledStringElement("Source Code".t(), () => UIApplication.SharedApplication.OpenUrl(new NSUrl("https://github.com/thedillonb/CodeHub")))
//				},
				new Section(String.Empty, "感谢你的下载，欢迎使用")
				{
					new EnjoyPubLib.Util.ElementUtil.StyledStringElement("用户指南",()=>NavigationController.PushViewController(new UserGuideViewController(false),true)),
					new EnjoyPubLib.Util.ElementUtil.StyledStringElement("新浪微博".t(), () => UIApplication.SharedApplication.OpenUrl(new NSUrl("http://weibo.com/u/3967673629"))),
					new EnjoyPubLib.Util.ElementUtil.StyledStringElement("点赞".t(), () => UIApplication.SharedApplication.OpenUrl(new NSUrl("https://itunes.apple.com/cn/app/jie-shu-qu/id893625150?ls=1&mt=8"))),
					new EnjoyPubLib.Util.ElementUtil.StyledStringElement("应用程序版本".t(), NSBundle.MainBundle.InfoDictionary.ValueForKey(new NSString("CFBundleVersion")).ToString()),
					//new IAdHelper().Get()
				}
			};

			root.UnevenRows = true;
			Root = root;
		}
	}
}

