using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Tempaltes
{
    public class Parameter
    {
        public string Name { get; set; }
        public string type  { get; set; }
        public string defaultValue { get; set; }

        public List<string> allowedValues { get; set; }

        public metadata metadata { get; set; }

        public string ToJson()
        {
            dynamic param = new JObject();
            param.type = type;
            if (allowedValues != null)
            {
                param.defaultValue = defaultValue;
                param.allowedValues = "[";
                foreach (var value in allowedValues)
                {
                    param.allowedValues += value + ",";
                }
                param.allowedValues += "]";
                //param.allowedValues = allowedValues.ToArray<string>().ToString();
            }
            param.metadata = metadata.ToJson();

            var obj = param.ToString();
            var jsonObj = "\"" + Name + "\":" + obj;
            return jsonObj;

        }
    }
    
}
