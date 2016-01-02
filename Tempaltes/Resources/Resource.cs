using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmTemplate.Tempaltes.Resources;  

namespace ArmTemplate.Tempaltes
{
    public class Resource : IJson
    {
        public Resource(string resourceType)
        {
            type = resourceType;
        }
        public string type { get; }
        public string name { get; set; }
        public string apiVersion { get; set; }
        public string location { get; set; }

        public IJson properties { get; set; }

        public string ToJson()
        {
            var json = ToJObject();

            return json.ToString();


        }
        public JObject ToJObject()
        {
            dynamic json = new JObject();
            json.type = type;
            json.name = name;
            json.apiVersion = apiVersion;
            json.location = location.ToString();
            json.Properties = properties.ToJObject();

            return json;


        }
    }
}
