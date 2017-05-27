
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using MonoTouch.Dialog;
using EnjoyPubLib.ImagesUtil;
using EnjoyPubLib.View;


namespace EnjoyPubLib
{
	public  class UserGuideViewController : UIViewController
	{
		public UserGuideViewController (bool first):base()
		{
			IsFirst = first;
		}
		public bool IsFirst=false;
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}
		public UIScrollView helpsrcView;
		public UIPageControl pageCtrl;
		public override void ViewDidLoad ()
		{

			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;

			//View.
			NavigationController.NavigationBarHidden = true;
			var bouds=View.Frame;
			UIImageView img = new UIImageView (bouds);
			img.Image = Images.Helpbackgroud;


			UIButton btnentry = new UIButton (UIButtonType.System);
			btnentry.SetTitle ("立即体验", UIControlState.Normal);
			btnentry.Frame = new CoreGraphics.CGRect (bouds.Location.X+bouds.Size.Width*3-130, bouds.Location.Y+bouds.Size.Height-100,100 ,100 );
			btnentry.TouchUpInside += new EventHandler (delegate(object sender, EventArgs e) {
				NavigationController.NavigationBarHidden=false;

				NavigationController.PopToRootViewController(true);
				if (IsFirst) {
					AppDelegate.Menu.TopView = new BookSeekController ();
				}
			});
			UIImageView imageView1 = new UIImageView (new CoreGraphics.CGRect(bouds.Location.X,bouds.Location.Y,bouds.Size.Width,bouds.Size.Height));
			imageView1.Image = Images.Help1;
			//imageView1.Alpha = 0.5f;

			UIImageView imageView2 =  new UIImageView (new CoreGraphics.CGRect(bouds.Location.X+bouds.Size.Width,bouds.Location.Y,bouds.Size.Width,bouds.Size.Height));
			imageView2.Image = Images.Help2;
			//imageView2.Alpha = 0.5f;

			UIImageView imageView3 =  new UIImageView (new CoreGraphics.CGRect(bouds.Location.X+bouds.Size.Width*2,bouds.Location.Y,bouds.Size.Width,bouds.Size.Height));
			imageView3.Image = Images.Help3;
			//imageView3.Alpha = 0.5f;

			helpsrcView= new UIScrollView (bouds);
			helpsrcView.CanCancelContentTouches = false;
			helpsrcView.ContentSize = new CoreGraphics.CGSize (bouds.Size.Width * 3, bouds.Size.Height);
			helpsrcView.PagingEnabled = true;
			helpsrcView.Bounces = false;
			helpsrcView.Delegate = new UIScroll (this);
			helpsrcView.ShowsVerticalScrollIndicator = false;
		
			helpsrcView.ShowsHorizontalScrollIndicator = false;
			helpsrcView.AddSubview (imageView1);
			helpsrcView.AddSubview (imageView2);
			helpsrcView.AddSubview (imageView3);
			View.AddSubview (img);
			helpsrcView.Add (btnentry);
			View.AddSubview (helpsrcView);

			pageCtrl=new UIPageControl(new CoreGraphics.CGRect(
				0,bouds.Size.Height-30,bouds.Size.Width,30));
			pageCtrl.CurrentPage = 0;
			pageCtrl.Pages = 3;
			pageCtrl.TouchUpInside += new EventHandler (delegate(object sender, EventArgs e) {
				//update
				var p = sender as UIPageControl;
				var vsize = helpsrcView.Frame.Size;
				var rect = new CoreGraphics.CGRect (p.CurrentPage * vsize.Width,
					          0,
					          vsize.Width,
					          vsize.Height);
				helpsrcView.ScrollRectToVisible (rect, true);
			});
			View.AddSubview (pageCtrl);


		}
		public class UIScroll:UIScrollViewDelegate
		{
			public UIScroll (UserGuideViewController v)
			{
				s=v;
			}
			UserGuideViewController s;
			public override void DecelerationEnded (UIScrollView scrollView)
			{
				// NOTE: Don't call the base implementation on a Model class
				// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
				var offset = scrollView.ContentOffset;
				var bouds = scrollView.Frame;
				s.pageCtrl.CurrentPage = (int)(offset.X / bouds.Size.Width);
			}




		}
	}


}
