using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace EnjoyPubLib.WebService
{
	public class oAuthEvernote : oAuthBase
	{
		//
		// Static Fields
		//
		public const string USER_AGENT = "MoreProductiveNow";

		public const string CALLBACK = "http://115.29.166.9";

		//
		// Fields
		//
		private string _tokenSecret = "";

		private string _token = "";

		public string ACCESS_TOKEN;

		public string AUTHORIZE;

		public string REQUEST_TOKEN;

		private HostService _service;

		private string _consumerKey;

		private string _consumerSecret;

		private string _windowTitle;

		//
		// Properties
		//
		public string AuthorizationLink {
			get {
				return this.AUTHORIZE + "?oauth_token=" + this.Token;
			}
		}

		public string CALLBACK_URL {
			get {
				return CALLBACK;
			}
		}

		public string ConsumerKey {
			get {
				return this._consumerKey;
			}
			set {
				this._consumerKey = value;
			}
		}

		public string ConsumerSecret {
			get {
				return this._consumerSecret;
			}
			set {
				this._consumerSecret = value;
			}
		}

		public string Token {
			get {
				return this._token;
			}
			set {
				this._token = value;
			}
		}

		public string TokenSecret {
			get {
				return this._tokenSecret;
			}
			set {
				this._tokenSecret = value;
			}
		}

		//
		// Constructors
		//
		public oAuthEvernote (HostService service, string consumerKey, string consumerSecret)
		{
			this._service = service;
			this._consumerKey = consumerKey;
			this._consumerSecret = consumerSecret;

			if (service == HostService.Production) {
				this.REQUEST_TOKEN = " https://app.yinxiang.com/oauth";
				this.AUTHORIZE = " https://app.yinxiang.com/OAuth.action";
				this.ACCESS_TOKEN = " https://app.yinxiang.com/oauth";
				return;
			}
			this.REQUEST_TOKEN = "https://sandbox.evernote.com/oauth";
			this.AUTHORIZE = "https://sandbox.evernote.com/OAuth.action";
			this.ACCESS_TOKEN = "https://sandbox.evernote.com/oauth";
		}

		//
		// Methods
		//
		public string APIWebRequest (string method, string url, string postData)
		{
//			Uri url2 = new Uri (url);
//			string text = this.GenerateNonce ();
//			string text2 = this.GenerateTimeStamp ();
//			string text3;
//			string text4;
//			string str = base.GenerateSignature (url2, this.ConsumerKey, this.ConsumerSecret, this.Token, this.TokenSecret, method, text2, text, null, out text3, out text4);
//			HttpWebRequest httpWebRequest = System.Net.WebRequest.Create (url) as HttpWebRequest;
//			httpWebRequest.Method = method;
//			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
//			httpWebRequest.AllowWriteStreamBuffering = true;
//			httpWebRequest.PreAuthenticate = true;
//			httpWebRequest.ServicePoint.Expect100Continue = false;
//			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
//			httpWebRequest.Headers.Add ("Authorization", string.Concat (new string[] {
//				"OAuth realm="http://api.linkedin.com/",oauth_consumer_key="",
//				this.ConsumerKey,
//				"",oauth_token="",
//				this.Token,
//				"",oauth_signature_method="HMAC-SHA1",oauth_signature="",
//				HttpUtility.UrlEncode (str),
//				"",oauth_timestamp="",
//				text2,
//				"",oauth_nonce="",
//				text,
//				"",oauth_verifier="",
//				base.Verifier,
//				"", oauth_version="1.0""
//			}));
//			if (postData != null) {
//				byte[] bytes = Encoding.UTF8.GetBytes (postData);
//				httpWebRequest.ContentLength = (long)bytes.Length;
//				Stream requestStream = httpWebRequest.GetRequestStream ();
//				requestStream.Write (bytes, 0, bytes.Length);
//				requestStream.Close ();
//			}
			//return this.WebResponseGet (httpWebRequest);
			return null;
		}

		public string authorizeToken (string windowTitle)
		{
			if (string.IsNullOrEmpty (this.Token)) {
				Exception ex = new Exception ("The request token is not set");
				throw ex;
			}
			//LoginForm loginForm = new LoginForm (this, windowTitle);
			//loginForm.ShowDialog ();
			//this.Token = loginForm.Token;
			//base.Verifier = loginForm.Verifier;
			//if (!string.IsNullOrEmpty (base.Verifier)) {
			//	return this.Token;
			//}
			return null;
		}

		public NameValueCollection getAccessToken ()
		{
			if (string.IsNullOrEmpty (this.Token) || string.IsNullOrEmpty (base.Verifier)) {
				Exception ex = new Exception ("The request token and verifier were not set");
				throw ex;
			}
			string text = this.oAuthWebRequest (oAuthEvernote.Method.POST, this.ACCESS_TOKEN, string.Empty);
			NameValueCollection result = null;
			if (text.Length > 0) {
				result = HttpUtility.ParseQueryString (text);
			}
			return result;
		}



		public string getRequestToken ()
		{
			string result = null;
			string text = oAuthWebRequest (oAuthEvernote.Method.GET, this.REQUEST_TOKEN, string.Empty);
			if (text.Length > 0) {
				NameValueCollection nameValueCollection = HttpUtility.ParseQueryString (text);
				if (nameValueCollection ["oauth_token"] != null) {
					this.Token = nameValueCollection ["oauth_token"];
					this.TokenSecret = nameValueCollection ["oauth_token_secret"];
					result = this.Token;
				}
			}
			return result;
		}

		public string oAuthWebRequest (oAuthEvernote.Method method, string url, string postData)
		{
			string str = "";
			string text = "";
			string result = "";
			if (method == oAuthEvernote.Method.POST && postData.Length > 0) {
				NameValueCollection nameValueCollection = HttpUtility.ParseQueryString (postData);
				postData = "";
				string[] allKeys = nameValueCollection.AllKeys;
				for (int i = 0; i < allKeys.Length; i++) {
					string text2 = allKeys [i];
					if (postData.Length > 0) {
						postData += "&";
					}
					nameValueCollection [text2] = HttpUtility.UrlDecode (nameValueCollection [text2]);
					nameValueCollection [text2] = base.UrlEncode (nameValueCollection [text2]);
					postData = postData + text2 + "=" + nameValueCollection [text2];
				}
				if (url.IndexOf ("?") > 0) {
					url += "&";
				}
				else {
					url += "?";
				}
				url += postData;
			}
			Uri url2 = new Uri (url);
			string nonce = this.GenerateNonce ();
			string timeStamp = this.GenerateTimeStamp ();
			string callback = "";
			if (url.ToString ().Contains (this.REQUEST_TOKEN)) {
				callback = CALLBACK_URL;
			}
			string str2 = base.GenerateSignature (url2, this.ConsumerKey, this.ConsumerSecret, this.Token, this.TokenSecret, method.ToString (), timeStamp, nonce, callback, out str, out text);
			text = text + "&oauth_signature=" + HttpUtility.UrlEncode (str2);
			if (method == oAuthEvernote.Method.POST) {
				postData = text;
				text = "";
			}
			if (text.Length > 0) {
				str += "?";
			}
			if (method == oAuthEvernote.Method.POST || method == oAuthEvernote.Method.GET) {
				result = this.WebRequest (method, str + text, postData);
			}
			return result;
		}

		public string WebRequest (oAuthEvernote.Method method, string url, string postData)
		{
			HttpWebRequest httpWebRequest = null;
			StreamWriter streamWriter = null;
			httpWebRequest = (System.Net.WebRequest.Create (url) as HttpWebRequest);
			httpWebRequest.Method = method.ToString ();
			httpWebRequest.ServicePoint.Expect100Continue = false;
			httpWebRequest.UserAgent = "MoreProductiveNow";
			httpWebRequest.Timeout = 20000;
			if (method == oAuthEvernote.Method.POST) {
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				streamWriter = new StreamWriter (httpWebRequest.GetRequestStream ());
				try {
					streamWriter.Write (postData);
				}
				catch {
					throw;
				}
				finally {
					streamWriter.Close ();
					streamWriter = null;
				}
			}
			string result = this.WebResponseGet (httpWebRequest);
			httpWebRequest = null;
			return result;
		}

		public string WebResponseGet (HttpWebRequest webRequest)
		{
			StreamReader streamReader = null;
			string result = "";
			try {
				streamReader = new StreamReader (webRequest.GetResponse ().GetResponseStream ());
				result = streamReader.ReadToEnd ();
			}
			catch (Exception ex) {
				throw ex;
			}
			finally {
				webRequest.GetResponse ().GetResponseStream ().Close ();
				streamReader.Close ();
				streamReader = null;
			}
			return result;
		}

		//
		// Nested Types
		//
		public enum Method
		{
			GET,
			POST,
			PUT,
			DELETE
		}
	}
}

