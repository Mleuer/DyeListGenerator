using System;
using System.Collections.Generic;
using System.IO;

namespace DyeListGenerator
{
    public class Customer
    {
        public String Name { get; private set; } 
        public List<Yarn> Order { get; private set; }
        
    }
    
}