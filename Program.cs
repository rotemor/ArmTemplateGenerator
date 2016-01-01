using ArmTemplate.Tempaltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ArmTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var main = new Template();
            var param = new Parameter {
                type = "string",
                Name = "storageName",
                defaultValue = "",
                metadata = new metadata { description = "Give your storage account a name "},
            };

           // var s = prop.ToJson();
            main.Parameters.Add(param);

            param = new Parameter
            {
                type = "string",
                Name = "location",
                defaultValue = "North",

                allowedValues = new List<string> { "North", "West", "East" },
        
                metadata = new metadata { description = "your datacenter location " },
            };
            main.Parameters.Add(param);

            var varbl = new Variabe();
            varbl.Name = "MaxSize";
            varbl.Value = 100;

            main.Variabels.Add(varbl);

            var armTemplate = main.ToJson();

            Console.WriteLine(armTemplate);

            //File.WriteAllText("jsonoutput.json",json.ToString());
            Console.WriteLine("Done:)");
            Console.ReadKey();
        }
    }
}
