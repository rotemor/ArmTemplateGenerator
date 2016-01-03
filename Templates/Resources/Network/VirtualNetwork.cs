using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Templates.Resources.Network
{
   

    public class AddressSpace
    {
        public List<dynamic> addressPrefixes { get; set; }
    }

    public class VirtualNetwork
    {
        public AddressSpace addressSpace { get; set; }
    }
}
