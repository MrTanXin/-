using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace 获取现在时间
{
    class GetWebApi
    {
        private string content;

        public string GetContent() => content;

        public GetWebApi(string url)
        {
            content = Get(url);
        }

        private static string Get(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            using (HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            string str = sr.ReadToEnd();
                            return str;
                        }
                    }

                }
                else
                {
                    return webResponse.StatusCode.ToString();
                }
            }
        }
    }

}
