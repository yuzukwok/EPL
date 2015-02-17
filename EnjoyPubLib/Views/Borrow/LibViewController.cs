using System;
using EnjoyPubLib.Util.View;
using MonoTouch.Dialog;
using MonoTouch.MapKit;
using System.Drawing;
using MonoTouch.CoreLocation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace EnjoyPubLib
{
	public class LibViewController:BaseDialogViewController
	{
		public LibViewController (LibInfo lib):base(true)
		{
			Dto = lib;
			Title = Dto.LibName;

		}
		public LibInfo  Dto{get;set;}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			createTable ();
		}
		Section section;
		void createTable ()
		{
			if (Dto != null) {

				section = new Section (Dto.LibName);


				MultilineElement e1 = new MultilineElement ("地址:"+Dto.Address);
				MultilineElement e2 = new MultilineElement ("电话:"+Dto.Telephone);

				e2.Tapped +=	delegate {

					//拨打电话，功能要细化
					try {
						UIApplication.SharedApplication.OpenUrl (new NSUrl ("tel://" + Dto.Telephone));
					} catch (Exception ex) {
						
					}

				};

				var map = new MKMapView(new  RectangleF(0,0,400,400));
				map.ZoomEnabled = true;
				map.ScrollEnabled = true;

				var center = new CLLocationCoordinate2D ((double)Dto.Latitude, (double)Dto.Longtitude);
				map.AddAnnotation (new MKPointAnnotation (){
					Title=Dto.LibName,
					Coordinate = center
				});
				map.SetRegion (new MKCoordinateRegion (center,new MKCoordinateSpan(0.01,0.01)), true);
				UIViewElement element = new UIViewElement ("", map, false);
			


				section.Add (e1);
				section.Add (e2);
				section.Add (element);
			

				Root.Add (section);
			 
			}
		}
	}
}

