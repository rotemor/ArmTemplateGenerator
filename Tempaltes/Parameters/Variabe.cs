using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Tempaltes
{
    public class Variabe
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }

        public string ToJson()
        {
            var json = "\"" + Name +"\" : \"" + Value +"\"" ;
            return json; 
        }
    }
}
