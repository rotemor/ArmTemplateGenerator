using System.Collections.Generic;

namespace ArmTemlateEngine.Templates.Resources.Network
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
