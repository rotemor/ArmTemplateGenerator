using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

namespace ArmTemplate.Tempaltes
{
    public class metadata :IJson
    {
        public string description { get; set; }

        public string ToJson()
        {
            var jobj = ToJObject();

            return jobj.ToString();
        }

        public JObject ToJObject()
        {
            dynamic jobj = new JObject();
            jobj.description = description;
            return jobj;
        }
    }
}