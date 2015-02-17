using System;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Net;
using System.Text;

namespace EnjoyPubLib.Service.Douban
{
	/// <summary>
	/// 错误信息
	/// </summary>
	public class Error
	{
		#region Properties
		[JsonProperty("msg")]
		public string Message { get; private set; }
		[JsonProperty("code")]
		public int Code { get; private set; }
		[JsonProperty("request")]
		public string Request { get; private set; }
		public DateTime Date { get; private set; }
		public string Url { get; private set; }
		public string Status { get; private set; }
		#endregion

		#region Constructors
		public Error()
		{ }

		public Error(WebException e)
		{
			Error error = new Error();
			this.Date = DateTime.Now;
			this.Url = e.Response.ResponseUri.AbsoluteUri;
			this.Status = e.Message;
			using (StreamReader sr = new StreamReader(e.Response.GetResponseStream(), Encoding.UTF8))
				error = (Error)Utilities.JsonDeserialize<Error>(sr.ReadToEnd());
			this.Message = error.Message;
			this.Code = error.Code;
			this.Request = error.Request;
		}
		#endregion
	}

	public static class Common
	{
		#region Pool
		public delegate void ErrorEventHandler(Error error);
		public static event ErrorEventHandler ErrorCatched;
		private static Error _LastError;
		public static Error LastError
		{
			get { return _LastError; }
			set
			{
				_LastError = value;
				if (ErrorCatched != null)
				{
					ErrorCatched(_LastError);
				}
			}
		}
		public static string AuthCode { get; set; }
		public static string Token { get; set; }
		public static string RefreshToken { get; set; }
		public static string AuthHeader { get { return String.Concat("Authorization: Bearer ", Token); } }
		public static string UserId { get; set; }
		public static int SingleUserRemain { get; set; }
		public static int SingleIPRemain { get; set; } 
		#endregion

		#region HttpWebRequest
		public const string ACCEPT = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
		public const string CONTENTTYPE = "application/x-www-form-urlencoded";
		public const string USERAGGENT = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11";
		public const string REFERER = "http://www.douban.com/";
		public const string REFERER_SELF = "http://www.yuzu.com/";
		public const string CONTENTTYPEFORM = "multipart/form-data; boundary=----yuzu";
		public const string BOUNDARYSTART = "------yuzu";
		public const string BOUNDARYEND = "------yuzu";
		#endregion

		#region UriBuilder
		public const string SCHEME = "https";
		public const string HOST = "api.douban.com";
		public const int PORT = 443;
		#endregion

		#region Authenticate
		public const string AUTHGETCODE = "https://www.douban.com/service/auth2/auth";
		public const string AUTHTOKENOP = "https://www.douban.com/service/auth2/token";
		public const string RESPONSETYPE = "code";
		public const string GRANTTYPE_GETCODE = "authorization_code";
		public const string GRANTTYPE_REFRESH = "refresh_token";
		#endregion

		#region User
		public const string USRINFO = "/v2/user/:name";
		public const string USRME = "/v2/user/~me";
		public const string USRSEARCH = "/v2/user";
		#endregion

		#region Book
		public const string BKINFO_ID = "/v2/book/:id";
		public const string BKINFO_NAME = "/v2/book/isbn/:name";
		public const string BKSEARCH = "/v2/book/search";
		public const string BKTOPTAGS_ID = "/v2/book/:id/tags";
		public const string BKUSERTAGS_NAME = "/v2/book/user/:name/tags";
		public const string BKUSERCOLS_NAME = "/v2/book/user/:name/collections";
		public const string BKUSERCOL_ID = "/v2/book/:id/collection";
		public const string BKUSERANNOS_NAME = "/v2/book/user/:name/annotations";
		public const string BKANNOS_ID = "/v2/book/:id/annotations";
		public const string BKANNO_ID = "/v2/book/annotation/:id";

		public const string BKCOLOP_ID = "/v2/book/:id/collection";
		public const string BKPOSTANNO_ID = "/v2/book/:id/annotations";
		public const string BKANNOOP_ID = "/v2/book/annotation/:id";

		public const string BKPOSTREVIEW = "/v2/book/reviews";
		public const string BKREVIEWOP_ID = "/v2/book/review/:id";
		#endregion

		#region Movie
		public const string MOVINFO_ID = "/v2/movie/:id";
		public const string MOVINFO_IMDB = "/v2/movie/imdb/:name";
		public const string MOVSEARCH = "/v2/movie/search";
		public const string MOVTOPTAGS_ID = "/v2/movie/:id/tags";

		public const string MOVPOSTREVIEW = "/v2/movie/reviews";
		public const string MOVREVIEWOP_ID = "/v2/movie/review/:id";
		public const string MOVUSERTAGS_ID = "/v2/movie/user_tags/:id";
		#endregion

		#region Music
		public const string MUSINFO_ID = "/v2/music/:id";
		public const string MUSSEARCH = "/v2/music/search";
		public const string MUSTOPTAGS_ID = "/v2/music/:id/tags";

		public const string MUSPOSTREVIEW = "/v2/music/reviews";
		public const string MUSREVIEWOP_ID = "/v2/music/review/:id";
		public const string MUSUSERTAGS_ID = "/v2/music/user_tags/:id";
		#endregion

		#region Event
		public const string EVTINFO_ID = "/v2/event/:id";
		public const string EVTPARTUSERS_ID = "/v2/event/:id/participants";
		public const string EVTWISHUSERS_ID = "/v2/event/:id/wishers";
		public const string EVTUSERCREATE_ID = "/v2/event/user_created/:id";
		public const string EVTUSERPART_ID = "/v2/event/user_participated/:id";
		public const string EVTUSERWISH_ID = "/v2/event/user_wished/:id";
		public const string EVTLIST = "/v2/event/list";
		public const string EVTCITY_ID = "/v2/loc/:id";
		public const string EVTCITIES = "/v2/loc/list";

		public const string EVTPARTOP_ID = "/v2/event/:id/participants";
		public const string EVTWISHOP_ID = "/v2/event/:id/wishers";
		#endregion

		#region Shuo
		public const string SHUOPOST = "shuo/v2/statuses/";
		public const string SHUOHOMESHUOS = "shuo/v2/statuses/home_timeline";
		public const string SHUOUSERSHUOS_ID = "shuo/v2/statuses/user_timeline/:id";
		public const string SHUOOP_ID = "shuo/v2/statuses/:id";
		public const string SHUOCOMMENTSOP_ID = "shuo/v2/statuses/:id/comments";
		public const string SHUOCOMMENTOP_ID = "shuo/v2/statuses/comment/:id";
		public const string SHUORESHAREOP_ID = "shuo/v2/statuses/:id/reshare";
		public const string SHUOLIKEOP_ID = "shuo/v2/statuses/:id/like";

		public const string SHUOUSERFOLLOWS_ID = "shuo/v2/users/:id/following";
		public const string SHUOFOLLOWUSERS_ID = "shuo/v2/users/:id/followers";
		public const string SHUOFOLLOWINCOMMONS_ID = "shuo/v2/users/:id/follow_in_common";
		public const string SHUOUSERINFOLLOWS_ID = "shuo/v2/users/:id/following_followers_of";
		public const string SHUOSEARCHUSERS = "shuo/v2/users/search";
		public const string SHUOBLOCKUSER_ID = "shuo/v2/users/:id/block";

		public const string SHUOPOSTFOLLOW = "shuo/v2/friendships/create";
		public const string SHUODELETEFOLLOW = "shuo/v2/friendships/destroy";
		public const string SHUOFRIENDSHIP = "shuo/v2/friendships/show";
		#endregion

		#region Mail
		public static string MAILINFO_ID = "/v2/doumail/:id";
		public static string MAILINBOX = "/v2/doumail/inbox";
		public static string MAILOUTBOX = "/v2/doumail/outbox";
		public static string MAILUNREAD = "/v2/doumail/inbox/unread";

		public static string MAILPOSTMAIL = "/v2/doumails";
		public static string MAILMARKREAD_ID = "/v2/doumail/:id";
		public static string MAILMARKREAD = "/v2/doumail/read";
		public static string MAILDELETEMAIL_ID = "/v2/doumail/:id";
		public static string MAILDELETEMAILS = "/v2/doumail/delete";
		#endregion

		#region Note
		public static string NOTEPOSTNOTE = "/v2/notes";
		public static string NOTEOP_ID = "/v2/note/:id";
		public static string NOTELIKEOP_ID = "/v2/note/:id/like";
		public static string NOTEUSERCREATES_ID = "/v2/note/user_created/:id";
		public static string NOTEUSERLIKES_ID = "/v2/note/user_liked/:id";
		public static string NOTEUSERGUESSES_ID = "/v2/note/people_notes/:id/guesses";

		public static string NOTECOMMENTSOP_ID = "/v2/note/:id/comments";
		public static string NOTECOMMENTOP_ID = "/v2/note/:id1/comment/:id2";
		#endregion

		#region Photo
		public static string PHOALBUMOP_ID = "/v2/album/:id";
		public static string PHOLIST_ID = "/v2/album/:id/photos";
		public static string PHOOP_ID = "/v2/photo/:id";
		public static string PHOCOMMENTSOP_ID = "/v2/photo/:id/comments";
		public static string PHOCOMMENTOP_ID = "/v2/photo/:id1/comment/:id2";

		public static string PHOCREATEALBUM = "/v2/albums";
		public static string PHOALBUMLIKEOP_ID = "/v2/album/:id/like";
		public static string PHOLIKEOP_ID = "/v2/photo/:id/like";
		public static string PHOUSERCREATEALBS_ID = "/v2/album/user_created/:id";
		public static string PHOUSERLIKEALBS_ID = "/v2/album/user_liked/:id";
		#endregion

		#region Online
		public static string ONLOP_ID = "/v2/online/:id";
		public static string ONLPARTOP_ID = "/v2/online/:id/participants";
		public static string ONLDISCOP_ID = "/v2/online/:id/discussions";
		public static string ONLLISTOP = "/v2/onlines";

		public static string ONLLIKEOP_ID = "/v2/online/:id/like";
		public static string ONLPHOTOOP_ID = "/v2/online/:id/photos";
		public static string ONLUSERPARTS_ID = "/v2/online/user_participated/:id";
		public static string ONLUSERCREATES_ID = "/v2/online/user_created/:id";
		#endregion

		#region Discussion
		public static string DISCOP_ID = "/v2/discussion/:id";
		public static string DISCCOMMENTSOP_ID = "/v2/discussion/:id/comments";
		public static string DISCCOMMENTOP_ID = "/v2/discussion/:id1/comment/:id2";
		#endregion
	}

	/// <summary>
	/// 搜索结果
	/// </summary>
	public abstract class SearchResult
	{
		[JsonProperty("count")]
		internal int Count { get; private set; }
		[JsonProperty("start")]
		internal int Start { get; private set; }
		[JsonProperty("total")]
		internal int Total { get; private set; }
	}

	internal class FormData
	{
		private MemoryStream ms;

		public FormData()
		{
			ms = new MemoryStream();
		}

		public void AddParam(string key, object value)
		{
			if (value != null)
			{
				StringBuilder builder = new StringBuilder();
				builder.Append(Common.BOUNDARYSTART);
				builder.Append("\r\n");
				builder.Append(String.Format("Content-Disposition: form-data; name=\"{0}\"", key));
				builder.Append("\r\n\r\n");
				builder.Append(value.ToString());
				builder.Append("\r\n");
				byte[] buf = Encoding.UTF8.GetBytes(builder.ToString());
				ms.Write(buf, 0, buf.Length);
			}
		}

		public void AddParam(string key, string contentType, string path)
		{
			if (path != null)
			{
				StringBuilder builder = new StringBuilder();
				builder.Append(Common.BOUNDARYSTART);
				builder.Append("\r\n");
				builder.Append(String.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", key, path));
				builder.Append("\r\n");
				builder.Append(String.Concat("Content-Type: ", contentType));
				builder.Append("\r\n\r\n");
				byte[] buf1 = Encoding.UTF8.GetBytes(builder.ToString());
				ms.Write(buf1, 0, buf1.Length);
				byte[] buf2;
				using (FileStream fs = new FileStream(path, FileMode.Open))
				{
					buf2 = new byte[fs.Length];
					fs.Read(buf2, 0, (int)fs.Length);
				}
				ms.Write(buf2, 0, buf2.Length);
				byte[] buf3 = Encoding.UTF8.GetBytes("\r\n");
				ms.Write(buf3, 0, buf3.Length);
			}
		}

		public byte[] GetBytes()
		{
			byte[] buf = Encoding.UTF8.GetBytes(String.Concat(Common.BOUNDARYEND, "\r\n"));
			ms.Write(buf, 0, buf.Length);
			byte[] buffer = new byte[ms.Length];
			ms.Seek(0, SeekOrigin.Begin);
			ms.Read(buffer, 0, (int)ms.Length);
			ms.Close();
			return buffer;
		}
	}

	/// <summary>
	/// 评分
	/// </summary>
	public class Rating
	{
		[JsonProperty("max")]
		internal int Max { get; private set; }
		[JsonProperty("min")]
		internal int Min { get; private set; }
		[JsonProperty("value")]
		internal string Value { get; private set; }
	}

	/// <summary>
	/// 整体评分
	/// </summary>
	public class RatingItem
	{
		[JsonProperty("max")]
		internal int Max { get; private set; }
		[JsonProperty("numRaters")]
		internal int NumRaters { get; private set; }
		[JsonProperty("average")]
		internal string Average { get; private set; }
		[JsonProperty("min")]
		internal int Min { get; private set; }
	}

	/// <summary>
	/// 作者
	/// </summary>
	public class Author
	{
		[JsonProperty("name")]
		internal string Name { get; private set; }
	}
}

