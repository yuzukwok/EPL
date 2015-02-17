
using System;
using MonoTouch;
using MonoTouch.Dialog;
using MonoTouch.iAd;

namespace EnjoyPubLib
{
	public class IAdHelper
	{
		ADBannerView _ad;
		public  UIViewElement Get ()
		{
			_ad = new MonoTouch.iAd.ADBannerView (MonoTouch.iAd.ADAdType.Banner);
			_ad.Hidden = true;
			_ad.FailedToReceiveAd += HandleFailedToReceiveAd;
			_ad.AdLoaded += HandleAdLoaded;

			UIViewElement s = new UIViewElement ("欢迎使用借书趣", _ad, false);

			return s;
		}

				void HandleAdLoaded (object sender, EventArgs e)
				{
					if (_ad == null)
						return;
					_ad.Hidden = false;
					
				}

				void HandleFailedToReceiveAd (object sender, AdErrorEventArgs e)
				{
					if (_ad == null)
						return;
					_ad.Hidden = true;
					
				}
	}
}

