using System;
using UIKit;
using BigTed;

namespace EnjoyPubLib.Util
{
	public class Hud : IHud
	{
		public static UIColor BackgroundTint;
		public Hud(UIView window)
		{
		}

		public void Show(string text)
		{
			ProgressHUD.Shared.HudBackgroundColour = BackgroundTint;
			BTProgressHUD.Show(text, maskType: ProgressHUD.MaskType.Black);
		}

		public static void ShowSuccess(string text)
		{
			BTProgressHUD.ShowSuccessWithStatus(text);
		}

		public static void ShowFailure(string text)
		{
			BTProgressHUD.ShowErrorWithStatus(text);
		}

		public void Hide()
		{
			BTProgressHUD.Dismiss();
		}
	}

	public interface IHud
	{
		void Show(string text);

		void Hide();
	}
}

