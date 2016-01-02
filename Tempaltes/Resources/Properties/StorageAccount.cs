using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArmTemplate.Tempaltes.Resources.Properties
{
    public class StorageAccount : IJson
    {
        public string accountType { get; set; }

        public string ToJson()
        {
            var json = ToJObject();
            return json.ToString();
        }
        public JObject ToJObject()
        {
            dynamic jobj = new JObject();
            jobj.accountType = ResourceConstatnts.StorageAccounts;
            return jobj;
        }
    }
   
}
