using ArmTemplate.Tempaltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using ArmTemplate.Tempaltes;
using ArmTemplate.Tempaltes.Resources.Properties;
using Newtonsoft.Json.Linq;

namespace ArmTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
          
           
            var param = new Parameter {
                type = "string",
                Name = "storageAccountName",
                defaultValue = "",
                metadata = new metadata { description = "Give your storage account a name "},
            };

           // var s = prop.ToJson();
            Template.Parameters.Add(param.Name, param);

            param = new Parameter
            {
                type = "string",
                Name = "location",
                defaultValue = "North",

                allowedValues = new List<string> { "North", "West", "East" },
        
                metadata = new metadata { description = "your datacenter location " },
            };
            Template.Parameters.Add(param.Name,param);

            var varbl = new Variabe();
            varbl.Name = "MaxSize";
            varbl.Value = 100;

            Template.Variabels.Add(varbl.Name,varbl);

            var resource = new Resource(ResourceConstatnts.StorageAccounts);
            resource.name = "[variables('storageAccountName')]";
            resource.location = "[variables('location')]";
            resource.apiVersion = "[variables('apiVersion')]";
            resource.properties = new StorageAccount();
            Template.Resources.Add(resource);

            var armTemplate = Template.ToJson();

            Console.WriteLine(armTemplate);

            //File.WriteAllText("jsonoutput.json",json.ToString());
            Console.WriteLine("Done:)");

            var dictionary = new Dictionary<string, StorageAccount>();
            dictionary.Add("abc", new StorageAccount());
            dictionary.Add("eee", new StorageAccount());
            dictionary.Add("awewerbc", new StorageAccount());
            dictionary.Add("wertr", new StorageAccount());
            dictionary.Add("ghghjghj", new StorageAccount());

            var test = JsonConvert.SerializeObject(dictionary);
            Console.WriteLine(test);

            Console.ReadKey();

        }
    }
}
