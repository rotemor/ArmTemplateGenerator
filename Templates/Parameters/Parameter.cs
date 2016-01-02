using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Templates.Parameters
{
    public class Parameter
    {
       
        public dynamic type  { get; set; }
        public dynamic defaultValue { get; set; }

        public List<dynamic> allowedValues { get; set; }

        public metadata metadata { get; set; }


    }
    
}
