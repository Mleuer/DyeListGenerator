using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace DyeListGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            String csvFilePath = args[0];
            var inputFile = new FileStream(csvFilePath, FileMode.Open);
            List<Customer> customers = Customer.GenerateCustomers(inputFile);
            return;
            
        }
    }
}
