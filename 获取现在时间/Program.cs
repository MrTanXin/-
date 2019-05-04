using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace 获取现在时间
{
    class Program
    {
        public static void ToTime(long JstimeStamp)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime dateTime = startTime.AddMilliseconds(JstimeStamp);
            Console.WriteLine(dateTime.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        static void Main(string[] args)
        {
            GetWebApi getWebApi = new GetWebApi("http://api.m.taobao.com/rest/api3.do?api=mtop.common.getTimestamp");

            string JsonText = getWebApi.GetContent();

            JsonText = JsonText.Replace("[\"SUCCESS::接口调用成功\"]", "\"OK\"");
            JsonText = JsonText.Replace(":{\"t\":\"", ":\"");
            JsonText = JsonText.Replace("}}", "}");

            //Console.WriteLine(JsonText);

            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(JsonText);

            long TimeStamp = long.Parse(rootObject.data);
            ToTime( TimeStamp);
        }
    }

    public class RootObject
    {
        public string api;
        public string v;
        public string ret;
        public string data;//time Stamp
    }

}
