using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmTemplate.Templates.Resources.Network
{
    class IpAddress
    {
        public string publicIPAllocationMethod { get; set; }
        public DnsSettings dnsSettings { get; set; }
    }

    
}
