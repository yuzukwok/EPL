using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.iAd;
using MonoTouch.CoreFoundation;

namespace EnjoyPubLib
{
	public partial class IADViewController : UIViewController
	{
		private UIViewController _anyVC;
		private MonoTouch.iAd.ADBannerView _ad;

		public IADViewController (UIViewController anyVC)
		{
			_anyVC = anyVC;

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.AddSubview (_anyVC.View);
		

			//if (Common.Device.Is6AtLeast && Social.IsiAdCountry) {

				try {
					_ad = new MonoTouch.iAd.ADBannerView (MonoTouch.iAd.ADAdType.Banner);
					_ad.Hidden = true;
					_ad.FailedToReceiveAd += HandleFailedToReceiveAd;
					_ad.AdLoaded += HandleAdLoaded;
					View.BackgroundColor = UIColor.Clear;
					_anyVC.View.Frame = View.Bounds;
					View.AddSubview (_ad);
				} catch {
				}
//			} else {
//				Resize ();
//			}
		}

		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate (fromInterfaceOrientation);
			Resize ();
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			Resize ();
		}

		void Resize ()
		{

			UIView.Animate (.25,
				() => {
					if (_ad !=null && _ad.Hidden == false) {
						_anyVC.View.Frame = new RectangleF (0, 0, this.View.Bounds.Width, this.View.Bounds.Height - _ad.Frame.Height);
					} else {
						_anyVC.View.Frame = View.Bounds;
					}
				});
			if(_ad!=null)
				_ad.Frame = new RectangleF (0, _anyVC.View.Bounds.Height, this.View.Bounds.Width, _ad.Frame.Height);
		}

		void HandleAdLoaded (object sender, EventArgs e)
		{
			if (_ad == null)
				return;
			_ad.Hidden = false;
			Resize ();
		}

		void HandleFailedToReceiveAd (object sender, AdErrorEventArgs e)
		{
			if (_ad == null)
				return;
			_ad.Hidden = true;
			Resize ();
		}
	}
}

