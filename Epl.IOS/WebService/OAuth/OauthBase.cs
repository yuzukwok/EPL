using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EnjoyPubLib.WebService
{
	public class oAuthBase
	{
		//
		// Static Fields
		//
		protected const string HMACSHA1SignatureType = "HMAC-SHA1";

		protected const string OAuthTimestampKey = "oauth_timestamp";

		protected const string OAuthNonceKey = "oauth_nonce";

		protected const string OAuthTokenKey = "oauth_token";

		protected const string oAauthVerifier = "oauth_verifier";

		protected const string OAuthTokenSecretKey = "oauth_token_secret";

		protected const string PlainTextSignatureType = "PLAINTEXT";

		protected const string RSASHA1SignatureType = "RSA-SHA1";

		protected const string OAuthSignatureKey = "oauth_signature";

		protected const string OAuthVersion = "1.0";

		protected const string OAuthParameterPrefix = "oauth_";

		protected const string OAuthConsumerKeyKey = "oauth_consumer_key";

		protected const string OAuthCallbackKey = "oauth_callback";

		protected const string OAuthVersionKey = "oauth_version";

		protected const string OAuthSignatureMethodKey = "oauth_signature_method";

		//
		// Fields
		//
		protected Random random = new Random ();

		protected string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

		private string oauth_verifier;

		//
		// Properties
		//
		public string Verifier {
			get {
				return this.oauth_verifier;
			}
			set {
				this.oauth_verifier = value;
			}
		}

		//
		// Methods
		//
		private string ComputeHash (HashAlgorithm hashAlgorithm, string data)
		{
			if (hashAlgorithm == null) {
				throw new ArgumentNullException ("hashAlgorithm");
			}
			if (string.IsNullOrEmpty (data)) {
				throw new ArgumentNullException ("data");
			}
			byte[] bytes = Encoding.ASCII.GetBytes (data);
			byte[] inArray = hashAlgorithm.ComputeHash (bytes);
			return Convert.ToBase64String (inArray);
		}

		public virtual string GenerateNonce ()
		{
			return this.random.Next (123400, 9999999).ToString ();
		}

		public string GenerateSignature (Uri url, string consumerKey, string consumerSecret, string token, string tokenSecret, string httpMethod, string timeStamp, string nonce, string callback, out string normalizedUrl, out string normalizedRequestParameters)
		{
			return this.GenerateSignature (url, consumerKey, consumerSecret, token, tokenSecret, httpMethod, timeStamp, nonce, callback, oAuthBase.SignatureTypes.PLAINTEXT, out normalizedUrl, out normalizedRequestParameters);
		}

		public string GenerateSignature (Uri url, string consumerKey, string consumerSecret, string token, string tokenSecret, string httpMethod, string timeStamp, string nonce, string callback, oAuthBase.SignatureTypes signatureType, out string normalizedUrl, out string normalizedRequestParameters)
		{
			normalizedUrl = null;
			normalizedRequestParameters = null;
			switch (signatureType) {
			case oAuthBase.SignatureTypes.HMACSHA1: {
					string signatureBase = this.GenerateSignatureBase (url, consumerKey, token, tokenSecret, httpMethod, timeStamp, nonce, callback, "HMAC-SHA1", out normalizedUrl, out normalizedRequestParameters);
					return this.GenerateSignatureUsingHash (signatureBase, new HMACSHA1 {
						Key = Encoding.ASCII.GetBytes (string.Format ("{0}&{1}", this.UrlEncode (consumerSecret), string.IsNullOrEmpty (tokenSecret) ? "" : this.UrlEncode (tokenSecret)))
					});
				}
			case oAuthBase.SignatureTypes.PLAINTEXT:
				this.GenerateSignatureBase (url, consumerKey, token, tokenSecret, httpMethod, timeStamp, nonce, callback, "PLAINTEXT", out normalizedUrl, out normalizedRequestParameters);
				return HttpUtility.UrlEncode (string.Format ("{0}&{1}", consumerSecret, tokenSecret));
			case oAuthBase.SignatureTypes.RSASHA1:
				throw new NotImplementedException ();
			default:
				throw new ArgumentException ("Unknown signature type", "signatureType");
			}
		}

		public string GenerateSignatureBase (Uri url, string consumerKey, string token, string tokenSecret, string httpMethod, string timeStamp, string nonce, string callback, string signatureType, out string normalizedUrl, out string normalizedRequestParameters)
		{
			if (token == null) {
				token = string.Empty;
			}
			if (tokenSecret == null) {
				tokenSecret = string.Empty;
			}
			if (string.IsNullOrEmpty (consumerKey)) {
				throw new ArgumentNullException ("consumerKey");
			}
			if (string.IsNullOrEmpty (httpMethod)) {
				throw new ArgumentNullException ("httpMethod");
			}
			if (string.IsNullOrEmpty (signatureType)) {
				throw new ArgumentNullException ("signatureType");
			}
			normalizedUrl = null;
			normalizedRequestParameters = null;
			List<oAuthBase.QueryParameter> queryParameters = this.GetQueryParameters (url.Query);
			queryParameters.Add (new oAuthBase.QueryParameter ("oauth_consumer_key", consumerKey));
			queryParameters.Add (new oAuthBase.QueryParameter ("oauth_signature_method", signatureType));
			queryParameters.Add (new oAuthBase.QueryParameter ("oauth_timestamp", timeStamp));
			queryParameters.Add (new oAuthBase.QueryParameter ("oauth_nonce", nonce));
			if (!string.IsNullOrEmpty (callback)) {
				queryParameters.Add (new oAuthBase.QueryParameter ("oauth_callback", this.UrlEncode (callback)));
			}
			if (!string.IsNullOrEmpty (token)) {
				queryParameters.Add (new oAuthBase.QueryParameter ("oauth_token", token));
			}
			if (!string.IsNullOrEmpty (this.oauth_verifier)) {
				queryParameters.Add (new oAuthBase.QueryParameter ("oauth_verifier", this.oauth_verifier));
			}
			normalizedUrl = string.Format ("{0}://{1}", url.Scheme, url.Host);
			if ((!(url.Scheme == "http") || url.Port != 80) && (!(url.Scheme == "https") || url.Port != 443)) {
				normalizedUrl = normalizedUrl + ":" + url.Port;
			}
			normalizedUrl += url.AbsolutePath;
			normalizedRequestParameters = this.NormalizeRequestParameters (queryParameters);
			StringBuilder stringBuilder = new StringBuilder ();
			stringBuilder.AppendFormat ("{0}&", httpMethod.ToUpper ());
			stringBuilder.AppendFormat ("{0}&", this.UrlEncode (normalizedUrl));
			stringBuilder.AppendFormat ("{0}", this.UrlEncode (normalizedRequestParameters));
			return stringBuilder.ToString ();
		}

		public string GenerateSignatureUsingHash (string signatureBase, HashAlgorithm hash)
		{
			return this.ComputeHash (hash, signatureBase);
		}

		public virtual string GenerateTimeStamp ()
		{
			return Convert.ToInt64 ((DateTime.UtcNow - new DateTime (1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString ();
		}

		private List<oAuthBase.QueryParameter> GetQueryParameters (string parameters)
		{
			if (parameters.StartsWith ("?")) {
				parameters = parameters.Remove (0, 1);
			}
			List<oAuthBase.QueryParameter> list = new List<oAuthBase.QueryParameter> ();
			if (!string.IsNullOrEmpty (parameters)) {
				string[] array = parameters.Split (new char[] {
					'&'
				});
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++) {
					string text = array2 [i];
					if (!string.IsNullOrEmpty (text) && !text.StartsWith ("oauth_")) {
						if (text.IndexOf ('=') > -1) {
							string[] array3 = text.Split (new char[] {
								'='
							});
							list.Add (new oAuthBase.QueryParameter (array3 [0], array3 [1]));
						}
						else {
							list.Add (new oAuthBase.QueryParameter (text, string.Empty));
						}
					}
				}
			}
			return list;
		}

		protected string NormalizeRequestParameters (IList<oAuthBase.QueryParameter> parameters)
		{
			StringBuilder stringBuilder = new StringBuilder ();
			for (int i = 0; i < parameters.Count; i++) {
				oAuthBase.QueryParameter queryParameter = parameters [i];
				stringBuilder.AppendFormat ("{0}={1}", queryParameter.Name, queryParameter.Value);
				if (i < parameters.Count - 1) {
					stringBuilder.Append ("&");
				}
			}
			return stringBuilder.ToString ();
		}

		public string UrlEncode (string value)
		{
			StringBuilder stringBuilder = new StringBuilder ();
			for (int i = 0; i < value.Length; i++) {
				char c = value [i];
				if (this.unreservedChars.IndexOf (c) != -1) {
					stringBuilder.Append (c);
				}
				else {
					stringBuilder.Append ('%' + string.Format ("{0:X2}", (int)c));
				}
			}
			return stringBuilder.ToString ();
		}

		//
		// Nested Types
		//
		protected class QueryParameter
		{
			private string name;

			private string value;

			public string Name {
				get {
					return this.name;
				}
			}

			public string Value {
				get {
					return this.value;
				}
			}

			public QueryParameter (string name, string value)
			{
				this.name = name;
				this.value = value;
			}
		}

		protected class QueryParameterComparer : IComparer<oAuthBase.QueryParameter>
		{
			public int Compare (oAuthBase.QueryParameter x, oAuthBase.QueryParameter y)
			{
				if (x.Name == y.Name) {
					return string.Compare (x.Value, y.Value);
				}
				return string.Compare (x.Name, y.Name);
			}
		}

		public enum SignatureTypes
		{
			HMACSHA1,
			PLAINTEXT,
			RSASHA1
		}
	}
}

