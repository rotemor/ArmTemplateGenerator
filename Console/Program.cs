﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using ArmTemlateEngine.Templates.Parameters;
using ArmTemlateEngine.Templates.Resources;
using ArmTemlateEngine.Templates.Resources.Storage;


namespace ArmTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            var arm = new Templates.ArmTemplate();
           
            var storageAccountName = new Parameter {
                type = "string",
                metadata = new metadata { description = "Give your storage account a name "},
            };

            var storageAccountType = new Parameter
            {
                type = "string",
                defaultValue = "Standard_LRS",
                allowedValues = new List<dynamic> { "Standard_LRS", "Standard_GRS", "Standard_ZRS" },
                metadata = new metadata { description = "Storage Account type" },
            };

            var location = new Parameter
            {
                type = "string",
                defaultValue = "North",
                allowedValues = new List<dynamic> { "North", "West", "East" },
                metadata = new metadata { description = "your datacenter location " },
            };


            arm.template["parameters"].Add("storageAccountName", storageAccountName);
            arm.template["parameters"].Add("storageAccountType", storageAccountType);
            arm.template["parameters"].Add("location", location);
            arm.template["variabels"].Add( "MaxSize", 100);

            var resource = new Resource(ResourceType.StorageAccounts)
            {
                name = "[variables('storageAccountName')]",
                location = "[variables('location')]",
                apiVersion = "[variables('apiVersion')]",
                properties = new StorageAccount("[parameters('storageAccountType')]")
            };
            arm.template["resources"].Add(resource);




            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var test = JsonConvert.SerializeObject(arm.template,settings);
            File.WriteAllText("jsonoutput.json", test);
            Console.WriteLine(test);

            Console.ReadLine()  ;

        }
    }
}