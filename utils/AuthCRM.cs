using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utils
{
    class CrmAuth
    {      
            public string user_token { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string login { get; set; }
            public string email { get; set; }
            public string avatar { get; set; }            
            [JsonProperty(PropertyName = "0")]
            public string token { get; set; }        
    }
}
