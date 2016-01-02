using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmTemplate.Templates.Parameters;
using ArmTemplate.Templates.Resources;

namespace ArmTemplate.Templates
{
    public class ArmTemplate
    {
        public Dictionary<string, dynamic> template = new Dictionary<string, dynamic>();

        public ArmTemplate()
        {
 
            template.Add("$schema", "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#");
            template.Add("contentVersion", "1.0.0.0");
            template.Add("parameters", new Dictionary<string, dynamic>());
            template.Add("variabels", new Dictionary<string, dynamic>());
            template.Add("resources", new List<Resource>());
        }
    }

}
