// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace EnjoyPubLib
{
	[Register ("AddDoubanViewController")]
	partial class AddDoubanViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView web { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (web != null) {
				web.Dispose ();
				web = null;
			}
		}
	}
}
