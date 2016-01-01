using Newtonsoft.Json;
using System;

namespace ArmTemplate.Tempaltes
{
    public class metadata :IJson
    {
        public string description { get; set; }

        public string ToJson()
        {
            var res = JsonConvert.SerializeObject(this);
            return res;
        }
    }
}