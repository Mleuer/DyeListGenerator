using System;
using System.Collections.Generic;
using System.IO;

namespace DyeListGenerator
{
    public static class DyeListGenerator
    {
        public static void GenerateDyeList(Stream csvData, Stream masterDyeListFile)
        {
            List<Customer> customers = Customer.GenerateCustomers(csvData);

            MasterDyeList masterDyeList = new MasterDyeList(masterDyeListFile);

            Console.WriteLine();

        }
    }
}