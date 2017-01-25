using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace TheRealCookbook
{
    class SearchProxyClass
    {
        public async static Task<ProxyClass.RootObject> SearchObject(string search1)
        {
            var key = MainPage.KGetter();
            var http = new HttpClient();
            var response = await http.GetAsync(String.Format("http://food2fork.com/api/search?key={0}&q={1}", key, search1));
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(ProxyClass.RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (ProxyClass.RootObject)serializer.ReadObject(ms);
            return data;



        }
        public class ProxyClass
        {
            [DataContract]
            public class Recipe
            {
                [DataMember]
                public string publisher { get; set; }
                [DataMember]
                public string f2f_url { get; set; }
                [DataMember]
                public string title { get; set; }
                [DataMember]
                public string source_url { get; set; }
                [DataMember]
                public string recipe_id { get; set; }
                [DataMember]
                public string image_url { get; set; }
                [DataMember]
                public double social_rank { get; set; }
                [DataMember]
                public string publisher_url { get; set; }
            }
            [DataContract]
            public class RootObject
            {
                [DataMember]
                public int count { get; set; }
                [DataMember]
                public List<Recipe> recipes { get; set; }
            }


        }
    }
}





