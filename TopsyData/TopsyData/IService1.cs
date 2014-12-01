using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TopsyData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
   
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            TweetData getTwitterData(string username,int page);

        }

        [DataContract]
        public class TweetData
        {
            [DataMember(Name="response")]
            public ResponseList response;
        }

        [DataContract]
        public class ResponseList
        {
            [DataMember(Name = "list")]
            public List<Tweet> list;

            [DataMember(Name = "total")]
            public int total { get; set; }
        }
        [DataContract]
        public class Tweet
        {
            [DataMember(Name="content")]
            public string content { get; set; }

            [DataMember(Name = "trackback_author_nick")]
            public string trackback_author_nick { get; set; }

            [DataMember(Name = "trackback_date")]
            public int trackback_date { get; set; }
        }   

    }



