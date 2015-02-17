using System;
using MonoTouch;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace EnjoyPubLib.Util.ElementUtil
{
	public class MyRadioElement : RadioElement {
		public MyRadioElement (string s) : base (s) {}

		public override void Selected (DialogViewController dvc, UITableView tableView, NSIndexPath path)
		{
			base.Selected (dvc, tableView, path);
			var selected = OnSelected;
			if (selected != null)
				selected (this, EventArgs.Empty);
		}

		 public event EventHandler<EventArgs> OnSelected;
	}
}

