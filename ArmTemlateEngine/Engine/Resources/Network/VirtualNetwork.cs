using System.Collections.Generic;

namespace ArmTemlateEngine.Engine.Resources.Network
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
