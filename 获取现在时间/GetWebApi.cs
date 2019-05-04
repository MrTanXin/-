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
            try
            {
                content = Get(url);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private static string Get(string url)
        {
            try
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
            catch (WebException e)
            {
                throw e;
            }
            finally
            { }
        }
    }

}
