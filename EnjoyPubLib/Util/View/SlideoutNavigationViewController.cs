using System;
using MTControl.Menu;
using MonoTouch.UIKit;

namespace EnjoyPubLib.Util.View
{
	public class SlideoutNavigationViewController : SlideoutNavigationController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CodeFramework.Controllers.SlideoutNavigationController" />
		///   class.
		/// </summary>
		public SlideoutNavigationViewController()
		{
			//Setting the height to a large amount means that it will activate the slide pretty much whereever your finger is on the screen.
			SlideHeight = 9999f;
			LayerShadowing = true;
			ShadowOpacity = 0.3f;
		}

		protected override UIBarButtonItem CreateLeftMenuButton()
		{
			return new UIBarButtonItem(Theme.CurrentTheme.ThreeLinesButton, UIBarButtonItemStyle.Plain, (s, e) => ShowMenuLeft());
		}
	}
}

