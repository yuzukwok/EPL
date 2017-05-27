using System;
using System.IO;
using Foundation;
using UIKit;
using MonoTouch.UIKit;

namespace EnjoyPubLib.ImagesUtil
{
	public static class Images
	{
		public static UIImage Help1 { get { return UIImage.FromBundle("/Images/help1"); } }
		public static UIImage Help2 { get { return UIImage.FromBundle("/Images/help2"); } }
		public static UIImage Help3 { get { return UIImage.FromBundle("/Images/help3"); } }
		public static UIImage Helpbackgroud { get { return UIImage.FromBundle("/Images/help4"); } }
		public static UIImage Wish { get { return UIImage.FromBundle("/Images/wish"); } }
		public static UIImage Borrow { get { return UIImage.FromBundle("/Images/borrow"); } }
		public static UIImage Feedback { get { return UIImage.FromBundle("/Images/Feedback"); } }
		public static UIImage Repo { get { return UIImage.FromBundle("/Images/repo"); } }
		public static UIImage Team { get { return UIImageHelper.FromFileAuto("Images/team"); } }
		public static UIImage Size { get { return UIImage.FromBundle("/Images/size"); } }
		public static UIImage Locked { get { return UIImage.FromBundle("/Images/locked"); } }
		public static UIImage Unlocked { get { return UIImage.FromBundle("/Images/unlocked"); } }
		public static UIImage Heart { get { return UIImage.FromBundle("/Images/heart"); } }
		public static UIImage Fork { get { return UIImage.FromBundle("/Images/fork"); } }
		public static UIImage Pencil { get { return UIImage.FromBundle("/Images/pencil"); } }
		public static UIImage Tag { get { return UIImage.FromBundle("/Images/tag"); } }
		public static UIImage Comments { get { return UIImage.FromBundle("/Images/comments"); } }
		public static UIImage BinClosed { get { return UIImage.FromBundle("/Images/bin_closed"); } }
		public static UIImage Milestone { get { return UIImage.FromBundle("/Images/milestone"); } }
		public static UIImage Script { get { return UIImage.FromBundle("/Images/script"); } }
		public static UIImage Commit { get { return UIImage.FromBundle("/Images/commit"); } }
		public static UIImage Following { get { return UIImage.FromBundle("/Images/following"); } }
		public static UIImage Eye { get { return UIImageHelper.FromFileAuto("Images/eye"); } }
		public static UIImage Hand { get { return UIImageHelper.FromFileAuto("Images/hand"); } }
		public static UIImage Folder { get { return UIImage.FromBundle("/Images/folder"); } }
		public static UIImage File { get { return UIImage.FromBundle("/Images/file"); } }
		public static UIImage Branch { get { return UIImage.FromBundle("/Images/branch"); } }
		public static UIImage Create { get { return UIImage.FromBundle("/Images/create"); } }
		public static UIImage Info { get { return UIImage.FromBundle("/Images/info"); } }
		public static UIImage Flag { get { return UIImage.FromBundle("/Images/flag"); } }
		public static UIImage User { get { return UIImage.FromBundle("/Images/user"); } }
		public static UIImage Explore { get { return UIImage.FromBundle("/Images/explore"); } }
		public static UIImage Group { get { return UIImage.FromBundle("/Images/group"); } }
		public static UIImage Event { get { return UIImage.FromBundle("/Images/events"); } }
		public static UIImage Person { get { return UIImage.FromBundle("/Images/person"); } }
		public static UIImage Cog { get { return UIImage.FromBundle("/Images/cog"); } }
		public static UIImage Star { get { return UIImage.FromBundle("/Images/star"); } }
		public static UIImage Star2 { get { return UIImage.FromBundle("/Images/star2"); } }
		public static UIImage News { get { return UIImage.FromBundle("/Images/news"); } }
		public static UIImage Public { get { return UIImage.FromBundle("/Images/public"); } }
		public static UIImage Notifications { get { return UIImage.FromBundle("/Images/notifications"); } }
		public static UIImage Priority { get { return UIImage.FromBundle("/Images/priority"); } }
		public static UIImage Anonymous { get { return UIImage.FromBundle("/Images/anonymous"); } }

		public static Uri GitHubRepoUrl
		{
			get { return new Uri(Path.Combine(NSBundle.MainBundle.ResourcePath, "Images/repository.png")); }
		}

		public static Uri GitHubRepoForkUrl
		{
			get { return new Uri(Path.Combine(NSBundle.MainBundle.ResourcePath, "Images/repository_fork.png")); }
		}

		public static class Logos
		{
			public static UIImage GitHub { get { return UIImage.FromFile("Images/Logos/github.png"); } }
		}

		public static class Buttons
		{
			public static UIImage BlackButton { get { return UIImageHelper.FromFileAuto("Images/Buttons/black_button"); } }
			public static UIImage GreyButton { get { return UIImageHelper.FromFileAuto("Images/Buttons/grey_button"); } }
		}

		public static class Gist
		{
			public static UIImage Share { get { return UIImageHelper.FromFileAuto("Images/Gist/share"); } }
			public static UIImage Star { get { return UIImageHelper.FromFileAuto("Images/Gist/star"); } }
			public static UIImage StarHighlighted { get { return UIImageHelper.FromFileAuto("Images/Gist/star_highlighted"); } }
			public static UIImage User { get { return UIImageHelper.FromFileAuto("Images/Gist/user"); } }
		}

//        public static class Notifications
//        {
//            public static UIImage Commit { get { return UIImageHelper.FromFileAuto("Images/Notifications/commit"); } }
//            public static UIImage PullRequest { get { return UIImageHelper.FromFileAuto("Images/Notifications/pull_request"); } }
//        }
	}
}

