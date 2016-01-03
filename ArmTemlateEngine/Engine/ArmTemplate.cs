using System.Collections.Generic;
using ArmTemlateEngine.Engine.Resources;

namespace ArmTemlateEngine.Engine
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
