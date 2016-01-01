using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Tempaltes
{
    public class Main : IJson
    {
        public Main()
        {
            Parameters = new List<Parameter>();
            Variabels = new List<Variabe>();
            Resources = new List<Resource>();
        }
        public List<Parameter> Parameters { get; set; }
        public List<Variabe> Variabels { get; set; }
        public List<Resource> Resources { get; set; }

        public string ToJson()
        {

           var top = "{\n\"$schema\": \""  + @"https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#" + "\",\n" +
                         "\"contentVersion\" : \"1.0.0.0\",";


            var res = top +"\n" + "\"parameters\" : {\n";
            var paramCount = Parameters.Count();
            for (int i = 0; i < paramCount; i++)
            {
                if (i == paramCount)
                    res += Parameters[i].ToJson();
                else
                    res += Parameters[i].ToJson() + ",\n";
            }
            res += "},\n";



            res += "\"variables\" : {\n";
            var varCount = Variabels.Count();
            for (int i = 0; i < varCount; i++)
            {
                if (i == varCount)
                    res += Variabels[i].ToJson();
                else
                    res += Variabels[i].ToJson() + ",\n";
            }
         
            res += "}";
            //bottom
            res += "}";

            return res;

            var obj = JsonConvert.DeserializeObject(res);
        }
    }
}
