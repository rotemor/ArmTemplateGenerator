using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Tempaltes
{
    public class Resource
    {
        public ResourceType type { get; set; }
        public string name { get; set; }
        public string apiVersion { get; set; }
        public Location location { get; set; }
     
    }
}
