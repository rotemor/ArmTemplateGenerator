using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Tempaltes
{
    public class Resource : IJson
    {
        public ResourceType type { get; set; }
        public string name { get; set; }
        public string apiVersion { get; set; }
        public Location location { get; set; }

        public string ToJson()
        {
            dynamic json = new JObject();
            json.type = type.ToString();
            json.name = name;
            json.apiVersion = apiVersion;
            json.location = location.ToString();


        }
    }
}
