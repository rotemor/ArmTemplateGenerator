﻿using System.Collections.Generic;

namespace ArmTemlateEngine.Engine.Parameters
{
    public class Parameter
    {
       
        public dynamic type  { get; set; }
        public dynamic defaultValue { get; set; }

        public List<dynamic> allowedValues { get; set; }

        public metadata metadata { get; set; }


    }
    
}
