using MonoTouch.Dialog;
using System;
using UIKit;


namespace MonoTouch.Dialog
{
	public class TrueFalseElement : BooleanElement
	{
		public TrueFalseElement(string caption, bool value, Action<BooleanElement> changeAction = null)
			: base(caption, value)
		{
			if (changeAction != null)
				this.ValueChanged += (object sender, EventArgs e) => changeAction(this);
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = base.GetCell(tv);
			cell.BackgroundColor =EnjoyPubLib.Util.ElementUtil.StyledStringElement.BgColor;
			cell.TextLabel.Font = EnjoyPubLib.Util.ElementUtil.StyledStringElement.DefaultTitleFont;
			cell.TextLabel.TextColor = EnjoyPubLib.Util.ElementUtil.StyledStringElement.DefaultTitleColor;
			return cell;
		}
	}
}

