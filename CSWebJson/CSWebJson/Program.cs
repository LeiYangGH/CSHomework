using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSWebJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = GetJson();
            Console.WriteLine(json);
            Express exp = JsonConvert.DeserializeObject<Express>(json);
            Console.WriteLine("-----------------");
            Console.WriteLine(exp.message);
            Console.WriteLine(exp.data.Count());
            foreach (Route r in exp.data)
            {
                Console.WriteLine(r.context);
            }
            Console.ReadLine();
        }


        static string GetJson()
        {
#if true
            string url = @"http://www.kuaidi100.com/query";
            NameValueCollection queryStrings = new NameValueCollection();
            queryStrings.Add("type", "jd");
            queryStrings.Add("postid", "50460919160");
            queryStrings.Add("id", "1");
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.QueryString = queryStrings;
                string json = client.DownloadString(url);
                return json;
            }
#else
            string fn = Path.Combine(Environment.CurrentDirectory, @"Json.txt");
            return File.ReadAllText(fn, Encoding.UTF8);
#endif
        }
    }

    public class Express
    {
        public string message { get; set; }
        public Route[] data { get; set; }
    }

    public class Route
    {
        public string context { get; set; }
    }
}
