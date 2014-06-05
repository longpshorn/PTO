using PTO.Service.Renweb;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace PTO.Service.Renweb
{
    public class SoapService : ISoapService
    {
        public string CallSoapService(string url, string action)
        {
            //var _url = "http://xxxxxxxxx/Service1.asmx";
            //var _action = "http://xxxxxxxx/Service1.asmx?op=HelloWorld";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateSoapRequest(url, action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                //Console.Write(soapResult);
            }
            return soapResult;
        }

        private static HttpWebRequest CreateSoapRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            StringBuilder soapPayload = new StringBuilder();
            soapPayload.Append(@"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">");
            soapPayload.Append(@"<soap:Header></soap:Header>");
            soapPayload.Append(@"<soap:Body xmlns:ns0=""http://www.renweb.com/webservices/pwSchool/directory/"">");

            // build soap request content here

            soapPayload.Append(@"</soap:Body>");
            soapPayload.Append(@"</soap:Envelope>");

            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(soapPayload.ToString());
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
