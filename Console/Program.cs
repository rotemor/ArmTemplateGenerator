using System.IO;
using ArmTemlateEngine.Engine.Parameters;
using ArmTemlateEngine.Engine.Resources;
using ArmTemlateEngine.Engine.Resources.Network;
using ArmTemlateEngine.Engine.Resources.Storage;
using ArmTemlateEngine.Engine;
using Newtonsoft.Json;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var arm = BasicTemplate();


            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var test = JsonConvert.SerializeObject(arm.template,settings);
            File.WriteAllText("jsonoutput.json", test);
            System.Console.WriteLine(test);

            System.Console.ReadLine()  ;

        }

        private static ArmTemplate BasicTemplate()
        {
            var arm = new ArmTemlateEngine.Engine.ArmTemplate();

            var storageAccountName = new Parameter
            {
                type = "string",
                metadata = new metadata {description = "Give your storage account a name "},
            };

            var dnsLabelPrefix = new Parameter
            {
                type = "string",
                metadata =
                    new metadata
                    {
                        description =
                            "DNS Label for the Public IP. Must be lowercase. It should match with the following regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$ or it will raise an error."
                    },
            };


            // Add Parameters
            arm.template["parameters"].Add("storageAccountName", storageAccountName);
            arm.template["parameters"].Add("dnsLabelPrefix", dnsLabelPrefix);


            // Add Variables
            arm.template["variabels"].Add("location", "[resourceGroup().location]");
            arm.template["variabels"].Add("storageAccountName", "[concat(uniquestring(resourceGroup().id), 'storage')]");
            arm.template["variabels"].Add("publicIPAddressName", "[concat('myPublicIp', uniquestring(resourceGroup().id))]");
            arm.template["variabels"].Add("publicIPAddressType", "Dynamic");
            arm.template["variabels"].Add("apiVersion", "2015-06-15");

            var storageResource = new Resource(ResourceType.StorageAccounts)
            {
                name = "[variables('storageAccountName')]",
                location = "[variables('location')]",
                apiVersion = "[variables('apiVersion')]",
                properties = new StorageAccount("[parameters('storageAccountType')]")
            };

            var ipAddressResource = new Resource(ResourceType.PublicIPAddresses)
            {
                name = "[variables('publicIPAddressName')]",
                location = "[variables('location')]",
                apiVersion = "[variables('apiVersion')]",
                properties = new IpAddress
                {
                    publicIPAllocationMethod = "[variables('publicIPAddressType')]",
                    dnsSettings = new DnsSettings
                    {
                        domainNameLabel = "[parameters('dnsLabelPrefix')]"
                    }
                }
            };
            arm.template["resources"].Add(storageResource);
            arm.template["resources"].Add(ipAddressResource);
            return arm;
        }
    }
}
