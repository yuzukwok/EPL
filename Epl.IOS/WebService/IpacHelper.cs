
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using System.Threading;
using System.Threading.Tasks;
namespace EnjoyPubLib.WebService
{

    public enum ipacmethod 
    {
		bookCollectionInfo,
		doubanbookCoverinfo
    }
  public  class IpacHelper
    {

      public static string Host="218.1.116.104:8080";
      public static string  AcceptEncoding="gzip, deflate";
      public static string ContentType="text/xml; charset=utf-8";
      public static  string AcceptLanguage="zh-cn";
      public static string  Accept="*/*";
      public static string UserAgent="SHLibrary/2.31 CFNetwork/672.1.12 Darwin/14.0.0";
      public static string urlbookcollectioninfo="/axis2/services/bookCollectionInfo";
		public static string urldoubanbookinfo="/axis2/services/LibMobWS_DouBan";

      private static string WebServiceCall(ipacmethod methodName, string body)
      {
          string url="";
          
          switch (methodName)
	        {
              case ipacmethod.bookCollectionInfo:
                  {
                      url=urlbookcollectioninfo;

                      break;
                  }
			case ipacmethod.doubanbookCoverinfo:
				{
					url = urldoubanbookinfo;
					break;
				}
		        default:break;
	        }
          WebRequest webRequest = WebRequest.Create("http://"+Host+url);
          HttpWebRequest httpRequest = (HttpWebRequest)webRequest;
          httpRequest.Method = "POST";
          httpRequest.Host=Host;
          httpRequest.Headers["AcceptEncoding"]=AcceptEncoding;
          httpRequest.AutomaticDecompression= DecompressionMethods.GZip;
           httpRequest.ContentType =ContentType;
          httpRequest.Headers["AcceptLanguage"]=AcceptLanguage;
          httpRequest.Accept=Accept;
          httpRequest.UserAgent=UserAgent;
          httpRequest.ContentType =ContentType;
          
          //httpRequest.Headers.Add("SOAPAction: http://tempuri.org/" + methodName);
          httpRequest.ProtocolVersion = HttpVersion.Version11;
         // httpRequest.Credentials = CredentialCache.DefaultCredentials;
          Stream requestStream = httpRequest.GetRequestStream();
          //Create Stream and Complete Request             
          StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.ASCII);

          StringBuilder soapRequest = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
             soapRequest.AppendLine("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\">");
          soapRequest.Append("<soapenv:Header/> ");
          soapRequest.Append("<soapenv:Body>");
          soapRequest.Append(body);
          soapRequest.Append("</soapenv:Body></soapenv:Envelope>");

          streamWriter.Write(soapRequest.ToString());
          streamWriter.Close();
          //Get the Response    
          HttpWebResponse wr = (HttpWebResponse)httpRequest.GetResponse();
          StreamReader srd = new StreamReader(wr.GetResponseStream());
          string resulXmlFromWebService = srd.ReadToEnd();
          return resulXmlFromWebService;
      }

		public static BookCollectionDetailResponse GetBookCollectionDetail(string  isbn) 
      {
			var dataxml = IpacHelper.WebServiceCall(ipacmethod.bookCollectionInfo, BodyBuilder.GetBookCollectionDetail(isbn));
          BookCollectionDetailResponse oObject = new BookCollectionDetailResponse();
          XmlSerializer oXmlSerializer = new XmlSerializer(oObject.GetType());
          //除去其他字符
         dataxml= dataxml.Replace("</soapenv:Body>", "");
         dataxml=dataxml.Replace("<soapenv:Body>", "");
         dataxml=dataxml.Replace("</soapenv:Envelope>", "");
         dataxml=dataxml.Replace("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\">", "");
			dataxml = dataxml.Replace("xmlns:ns1=\"http://library.sh.cn/bookCollectionInfo/\"", "");
			dataxml = dataxml.Replace("ns1:", "");
         try
         {
             oObject = (BookCollectionDetailResponse)oXmlSerializer.Deserialize(new StringReader(dataxml));
         }
         catch (Exception ex)
         {
             
             throw;
         }


      
          return oObject;       
      }

		public static GetBookCoverResponse GetBookCover(string isbn)
		{
			var dataxml = IpacHelper.WebServiceCall (ipacmethod.doubanbookCoverinfo, BodyBuilder.GetBookCover (isbn));
			GetBookCoverResponse oObject= new GetBookCoverResponse ();
			XmlSerializer oXmlSerializer = new XmlSerializer(oObject.GetType());
			//除去其他字符
			dataxml= dataxml.Replace("</soapenv:Body>", "");
			dataxml=dataxml.Replace("<soapenv:Body>", "");
			dataxml=dataxml.Replace("</soapenv:Envelope>", "");
			dataxml=dataxml.Replace("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\">", "");
			dataxml = dataxml.Replace("xmlns:ns1=\"http://www.example.org/LibMobWS_DouBan/\"", "");
			dataxml = dataxml.Replace("ns1:", "");
			try
			{
				oObject = (GetBookCoverResponse)oXmlSerializer.Deserialize(new StringReader(dataxml));
			}
			catch (Exception ex)
			{

				throw;
			}
			return oObject;
		}


		public static  async Task<IPACS.Mobile_iPacResponse> Sreach(IPACS.Mobile_iPacType type,string text)
		{
			IPACS.Shlib_Mobile_WS_Solr server = new EnjoyPubLib.IPACS.Shlib_Mobile_WS_Solr ();
			IPACS.Mobile_iPac m = new EnjoyPubLib.IPACS.Mobile_iPac ();
			m.PageSize = "20";
			m.StartRow = "0";
			m.KeyWord = text;
			m.Type = type;
			var data=server.Mobile_iPac (m);
			return data;
		}
     






    }

  public class BodyBuilder
  {
		public static string GetBookCollectionDetail(string isbn)
      {
          return @"<BookCollectionDetail>
      <ISBN>" + isbn + @"</ISBN> </BookCollectionDetail>";
      }

		public static string GetBookInfo(string isbn){
			return @"<GetBookInfo>
      <ISBN>"+isbn+"</ISBN></GetBookInfo>";
		}
					public static string GetBookCover(string isbn){
						return @"<GetBookCover>
      <ISBN>"+isbn+"</ISBN></GetBookCover>";
					}


  }

}
