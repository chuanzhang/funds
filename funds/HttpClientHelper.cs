using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace funds
{
    public class HttpClientHelper
    {
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResponse(string url, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        public static string RestfulGet(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            // Get response
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output
                return reader.ReadToEnd();
                
            }
        }

        public static String GetResponse(string url,String charSet)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.Add("Content-type", "text/html;charset=UTF-8");
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            String result = "";

            if (response.IsSuccessStatusCode)
            {
                Task<byte[]> t = response.Content.ReadAsByteArrayAsync();

                t.Wait();

                if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                {
                    result = System.Text.Encoding.GetEncoding(charSet).GetString(UnZip(t.Result));
                }
                else {
                    result = System.Text.Encoding.GetEncoding(charSet).GetString(t.Result);
                }

                
            }
            return result;
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData">post数据</param>
        /// <returns></returns>
        public static string PostResponse(string url, string postData, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";

            HttpClient httpClient = new HttpClient();
            //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }

        /// <summary>
        /// 发起post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="postData">post数据</param>
        /// <returns></returns>
        public static String PostResponse<T>(string url, string postData)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            String result = "";

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                result = t.Result;

            }
            return result;
        }


        /// <summary>
        /// 反序列化Xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xmlString)
            where T : class, new()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                using (StringReader reader = new StringReader(xmlString))
                {
                    return (T)ser.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("XmlDeserialize发生异常：xmlString:" + xmlString + "异常信息：" + ex.Message);
            }

        }

        public static string PostResponse(string url, string postData, string token, string appId, string serviceURL, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";

            httpContent.Headers.Add("token", token);
            httpContent.Headers.Add("appId", appId);
            httpContent.Headers.Add("serviceURL", serviceURL);


            HttpClient httpClient = new HttpClient();
            //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }

        /// <summary>
        /// 修改API
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string KongPatchResponse(string url, string postData)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "PATCH";

            byte[] btBodys = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return responseContent;
        }

        /// <summary>
        /// 创建API
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string KongAddResponse(string url, string postData)
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") { CharSet = "utf-8" };
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>
        /// 删除API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool KongDeleteResponse(string url)
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// 修改或者更改API        
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string KongPutResponse(string url, string postData)
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") { CharSet = "utf-8" };

            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>
        /// 检索API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string KongSerchResponse(string url)
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }


        /// <summary>
        /// Gzip格式解压缩
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] UnZip(byte[] byteArray)
        {
            
            //Prepare for decompress
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray);
            System.IO.Compression.GZipStream gZip= new System.IO.Compression.GZipStream(ms,
              System.IO.Compression.CompressionMode.Decompress);
            //Reset variable to collect uncompressed result

            MemoryStream source = new MemoryStream();

            //从压缩流中读出所有数据
            byte[] tmpByteArray = new byte[1024];
            int n;
            while ((n = gZip.Read(tmpByteArray, 0, tmpByteArray.Length)) != 0)
            {
                source.Write(tmpByteArray, 0, n);
            }


            gZip.Close();
            ms.Close();
            gZip.Dispose();
            ms.Dispose();
            return source.ToArray();
        }
    }

}


