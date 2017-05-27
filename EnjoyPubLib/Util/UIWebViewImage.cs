using System;
using MonoTouch;
using UIKit;
using Foundation;
using CoreGraphics;

namespace EnjoyPubLib
{
	public partial class UIWebImageView : UIImageView
	{
		NSMutableData imageData;
		UIActivityIndicatorView indicatorView;

		public UIWebImageView (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public UIWebImageView (NSCoder coder) : base(coder)
		{
			Initialize ();
		}


		void Initialize ()
		{
			indicatorView = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
			indicatorView.HidesWhenStopped = true;
			var width  = (this.Frame.Width-20)/2;
			var height = (this.Frame.Height-20)/2;
			indicatorView.Frame = new CGRect(width, height,20,20);
			this.AddSubview(indicatorView);
		}

		public UIWebImageView(CGRect frame){
			Initialize();

			indicatorView.Frame = new CGRect (
				frame.Size.Width/2,
				frame.Size.Height/2,
				indicatorView.Frame.Size.Width,
				indicatorView.Frame.Size.Height);

		}

		public UIWebImageView(CGRect frame, string url):base(frame){
			Initialize();
			Frame = frame;
			DownloadImage(url);
		}

		public void DownloadImage(string url){
			indicatorView.StartAnimating();
			NSUrlRequest request = new NSUrlRequest(new NSUrl(url));

			new NSUrlConnection(request, new ConnectionDelegate(this), true);
		}

		class ConnectionDelegate : NSUrlConnectionDelegate {

			UIWebImageView _view;

			public ConnectionDelegate(UIWebImageView view){
				_view = view;
			}



			//TODO miss method
//			public override void ReceivedData (NSUrlConnection connection, NSData data)
//			{
//				if (_view.imageData==null)
//					_view.imageData = new NSMutableData();
//
//				_view.imageData.AppendData(data);	
//			}
//
//			public override void FinishedLoading (NSUrlConnection connection)
//			{
//				_view.indicatorView.StopAnimating();
//				UIImage downloadedImage = UIImage.LoadFromData(_view.imageData);
//				_view.imageData = null;
//				_view.Image = downloadedImage;
//			}
		}
	}
}

