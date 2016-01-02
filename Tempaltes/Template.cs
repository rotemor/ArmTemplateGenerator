using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Tempaltes
{
    public static class Template 
    {
       
           
       
        public static List<Parameter> Parameters = new List<Parameter>();
        public static List<Variabe> Variabels = new List<Variabe>();
        public static List<Resource> Resources =  new List<Resource>();

        public static string ToJson()
        {
            //top 
           var template = "{\n\"";

            // schema
            template += "$schema\": \"" + @"https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#" + "\",\n" +
                         "\"contentVersion\" : \"1.0.0.0\",";
            // Parameters
            template += getParameters();

            //variables
            template += getVariables();

            //resources
            template += geResources();


            //bottom
            template += "}";

            return template;

            var obj = JsonConvert.DeserializeObject(template);
        }

        public static  string getVariables()
        {
            var template = "\"variables\" : {\n";
            var varCount = Variabels.Count();
            for (int i = 0; i < varCount; i++)
            {
                if (i == varCount)
                    template += Variabels[i].ToJson();
                else
                    template += Variabels[i].ToJson() + ",\n";
            }

            template += "}";
            return template;
        }

        public static string geResources()
        {
           
            return "";
        }
        public static string getParameters() {
            var res = "\n" + "\"parameters\" : {\n";
            var paramCount = Parameters.Count();
            for (int i = 0; i < paramCount; i++)
            {
                if (i == paramCount)
                    res += Parameters[i].ToJson();
                else
                    res += Parameters[i].ToJson() + ",\n";
            }
            res += "},\n";

            return res;
        }
    }

}
