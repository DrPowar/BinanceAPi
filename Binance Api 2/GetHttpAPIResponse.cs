using System;
using System.Net;
using System.IO;

namespace Binance_Api_2
{
    class GetHttpAPIResponse : CryptoAPIInfo
    {
        HttpWebRequest webRequest;
        private string _url; //зміна яка зберігає адрес запиту
        public GetHttpAPIResponse(string url)
        {
            _url = url;
        }

        public void Run() /* метод для надсилання запиту та отримання відповіді*/
        {
            webRequest = (HttpWebRequest)WebRequest.Create(_url);
            webRequest.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
