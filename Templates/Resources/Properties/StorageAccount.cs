using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmTemplate.Templates.enums;
using Newtonsoft.Json.Linq;

namespace ArmTemplate.Templates.Resources.Properties
{
    public class StorageAccount
    {

        public StorageAccount(string _accountType)
        {
            accountType = _accountType;
        }
        public string accountType { get; set; }

    }
   
}
