using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiesApi.Common.Https
{
    public class HttpsHelper
    {
        public static string HttpsPost(string url, string postData, Dictionary<string, string> HeaderKeyValuePairs = null)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            //添加Header
            if (HeaderKeyValuePairs != null)
                HeaderKeyValuePairs.ToList().ForEach(item => { request.Headers.Add(item.Key, item.Value); });
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 10000;
            Stream dataStream;

            try
            {
                dataStream = request.GetRequestStream();
            }
            catch (Exception)
            {
                throw;
            }
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();

            string res;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    res = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch
            {
                throw;
            }
            return res;
        }

        public static HttpStatusCode HttpsPostTest(string url, string postData, Dictionary<string, string> HeaderKeyValuePairs = null)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            //添加Header
            if (HeaderKeyValuePairs != null)
                HeaderKeyValuePairs.ToList().ForEach(item => { request.Headers.Add(item.Key, item.Value); });
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 10000;
            Stream dataStream;

            try
            {
                dataStream = request.GetRequestStream();
            }
            catch (Exception)
            {
                throw;
            }
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();

            try
            {
                return ((HttpWebResponse)request.GetResponse()).StatusCode;
            }
            catch
            {
                throw;
            }
        }

        public static string HttpsGet(string url, Dictionary<string, string> HeaderKeyValuePairs = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            //添加Header
            if (HeaderKeyValuePairs != null)
                HeaderKeyValuePairs.ToList().ForEach(item => { request.Headers.Add(item.Key, item.Value); });
            request.Method = "Get";
            request.ContentType = "application/json";
            request.Timeout = 300000;

            string res;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    res = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch
            {
                throw;
            }
            return res;
        }

        public static HttpStatusCode HttpsGetTest(string url, Dictionary<string, string> HeaderKeyValuePairs = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            //添加Header
            if (HeaderKeyValuePairs != null)
                HeaderKeyValuePairs.ToList().ForEach(item => { request.Headers.Add(item.Key, item.Value); });
            request.Method = "Get";
            request.ContentType = "application/json";
            request.Timeout = 300000;

            string res;
            try
            {
                return ((HttpWebResponse)request.GetResponse()).StatusCode;
            }
            catch
            {
                throw;
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}