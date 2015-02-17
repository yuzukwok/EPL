using System;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace EnjoyPubLib.Service.Douban
{
	public static class Utilities
	{
		public static HttpWebResponse GetResponse(string url, string data)
		{
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				req.Proxy = null;
				req.Headers.Add(Common.AuthHeader);
				req.Accept = Common.ACCEPT;
				req.ContentType = Common.CONTENTTYPE;
				req.UserAgent = Common.USERAGGENT;
				req.Referer = Common.REFERER_SELF;
				req.Method = "POST";
				data = Uri.EscapeUriString(data);
				req.ContentLength = data.Length;
				using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
					sw.Write(data);
				return (HttpWebResponse)req.GetResponse();
			}
			catch (WebException e)
			{
				Common.LastError = new Error(e);
				return null;
			}
		}

		private static string Request(string url, string method, string data = null, bool addAuth = false)
		{
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				req.Proxy = null;
				if (addAuth) req.Headers.Add(Common.AuthHeader);
				req.Accept = Common.ACCEPT;
				req.ContentType = Common.CONTENTTYPE;
				req.UserAgent = Common.USERAGGENT;
				req.Referer = Common.REFERER_SELF;
				req.Method = method;
				if (data != null)
				{
					data = Uri.EscapeUriString(data);
					req.ContentLength = data.Length;
					using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
						sw.Write(data);
				}
				using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
				{
					using (StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
						return sr.ReadToEnd();
				}
			}
			catch (WebException e)
			{
				Common.LastError = new Error(e);
				return string.Empty;
			}
		}

		public static string RequestGet(string url, bool addAuth = false)
		{
			return Request(url, "GET", addAuth: addAuth);
		}

		public static string RequestPost(string url, string data = null)
		{
			return Request(url, "POST", data, true);
		}

		public static string RequestPut(string url, string data = null)
		{
			return Request(url, "PUT", data, true);
		}

		public static string RequestDelete(string url)
		{
			return Request(url, "DELETE", addAuth: true);
		}

		public static string RequestFile(string method, string url, byte[] data)
		{
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				req.Proxy = null;
				req.Headers.Add(Common.AuthHeader);
				req.Accept = Common.ACCEPT;
				req.ContentType = Common.CONTENTTYPEFORM;
				req.UserAgent = Common.USERAGGENT;
				req.Referer = Common.REFERER_SELF;
				req.Method = method;
				req.ContentLength = data.Length;
				using (Stream requestStream = req.GetRequestStream())
					requestStream.Write(data, 0, data.Length);
				using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
				{
					using (StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
						return sr.ReadToEnd();
				}
			}
			catch (WebException e)
			{
				Common.LastError = new Error(e);
				return string.Empty;
			}
		}

		internal static string RequestPostFile(string url, byte[] data)
		{
			return RequestFile("POST", url, data);
		}

		public static string RequestPutFile(string url, byte[] data)
		{
			return RequestFile("PUT", url, data);
		}

		public static T JsonDeserialize<T>(string json) where T : new()
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

		public static string JsonSerializer(object o)
		{
			return JsonConvert.SerializeObject(o);
		}

		public static UriBuilder CreateUB(string path, string value = null)
		{
			if (value != null)
			{
				if (path.Contains(":id")) path = path.Replace(":id", value);
				else if (path.Contains(":name")) path = path.Replace(":name", value);
			}
			UriBuilder ub = new UriBuilder(Common.SCHEME, Common.HOST, Common.PORT, path);
			return AddAPIKey(ref ub);
		}

		public static UriBuilder CreateUB(string path, string value1, string value2)
		{
			path = path.Replace(":id1", value1);
			path = path.Replace(":id2", value2);
			UriBuilder ub = new UriBuilder(Common.SCHEME, Common.HOST, Common.PORT, path);
			return AddAPIKey(ref ub);
		}

		public static string CreateUrl(string path, string value = null)
		{
			return CreateUB(path, value).ToString();
		}

		public static string CreateUrl(string path, string value1, string value2)
		{
			return CreateUB(path, value1, value2).ToString();
		}

		public static void AddParam(ref UriBuilder ub, string name, object value)
		{
			if (value != null)
			{
				name = Uri.EscapeDataString(name);
				string valueStr = Uri.EscapeDataString(value.ToString());
				if (ub.Query == string.Empty) ub.Query = String.Concat(ub.Query, name, "=", valueStr);
				else ub.Query = String.Concat(ub.Query.Remove(0, 1), "&", name, "=", valueStr);
			}
		}

		public static UriBuilder AddAPIKey(ref UriBuilder ub)
		{
			AddParam(ref ub, "apikey", Contans.DoubanApiKey);
			return ub;
		}

		public static StringBuilder Append(this StringBuilder builder, string name, object value)
		{
			if (value != null)
			{
				if (builder.Length != 0) return builder.Append(String.Concat("&", name, "=", value));
				else return builder.Append(String.Concat(name, "=", value));
			}
			return builder;
		}
	}
}

