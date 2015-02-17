using System;
using MonoTouch.Dialog;
using EnjoyPubLib.Util.View;


namespace EnjoyPubLib.View
{
	public class SettingsViewController : BaseDialogViewController
	{
		public SettingsViewController():base(true)
		{
			Title = "设置";
		}

		public override void ViewWillAppear(bool animated)
		{
		
			CreateTable();
			base.ViewWillAppear(animated);
		}

		private void CreateTable()
		{

			//关联帐号
			var setAccountView = new StyledStringElement("关联帐号".t(), "", MonoTouch.UIKit.UITableViewCellStyle.Value1)
			{ 
				Accessory = MonoTouch.UIKit.UITableViewCellAccessory.DisclosureIndicator,
			};
			setAccountView.Tapped += () => {
				NavigationController.PushViewController(new AddAccountViewController(),true);
			};


			//Assign the root
			var root = new RootElement(Title);
			root.Add(new Section ("基本设置") {  setAccountView });


			Root = root;

		}
	}
}

