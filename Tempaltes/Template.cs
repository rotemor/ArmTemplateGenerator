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
       
           
       
        public static Dictionary<string ,Parameter> Parameters = new Dictionary<string ,Parameter>();
        public static Dictionary<string, Variabe> Variabels = new Dictionary<string, Variabe>();
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
           
            var count = 0;
            foreach (var key in Variabels.Keys)
            {
                if (count != varCount)
                    template += Variabels[key].ToJson() + ",\n";
                else

                    template += Variabels[key].ToJson();
            }

            template += "},";
            return template;
        }

        public static string geResources()
        {

            var template = "\"resources\" : [\n";
            var resCount = Resources.Count();

            for (int i = 0; i < resCount; i++)
            {
                if (i != resCount)
                    template += Resources[i].ToJson() + ",\n";
                else
                    // the end of the list
                    template += Resources[i].ToJson() + "}\n";
            }

            template += "]";
            return template;

        }



        public static string getParameters() {
            var res = "\n" + "\"parameters\" : {\n";
            var paramCount = Parameters.Count();
            var count = 0;
            foreach (var key in Parameters.Keys)
            {
                if (count != paramCount)
                    res += Parameters[key].ToJson() + ",\n";
                else
                    // the end of the list
                    res += Parameters[key].ToJson() + "},\n"; 

                count++;
            }

           return res;
        }
    }

}
