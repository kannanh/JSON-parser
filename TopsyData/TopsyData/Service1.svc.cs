using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;


namespace TopsyData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {


        public TweetData getTwitterData(string username, int page)
        {
            string url = "http://otter.topsy.com/search.txt?q=from%3A"+username+"&apikey=APIKEY&mintime=1230768000&maxtime=1293839999&format=json&perpage=100&page="+page;
            TweetData tweetList = new TweetData();
            try
            {
                Uri URI = new Uri(url);
                WebClient proxy = new WebClient();
                byte[] responses = proxy.DownloadData(URI);
                string s = Encoding.UTF8.GetString(responses);
                s=s.Replace("<pre>", "");
                s = s.Replace("</pre>", "");
                byte[] resp = new byte[s.Length * sizeof(char)];
                System.Buffer.BlockCopy(s.ToCharArray(), 0, resp, 0, resp.Length);
                MemoryStream mstream = new MemoryStream(resp);
                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                settings.UseSimpleDictionaryFormat = true;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TweetData),settings);
                tweetList = (TweetData)serializer.ReadObject(mstream);
               
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception!");
            }
                return tweetList;
           
            
        }
    }
}
