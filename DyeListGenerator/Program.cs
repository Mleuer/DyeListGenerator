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
            String masterDyeListFilePath = args[1];
            var inputFile = new FileStream(csvFilePath, FileMode.Open);
            var dyeListData = new FileStream(masterDyeListFilePath, FileMode.Open);

            DyeListGenerator.GenerateDyeList(inputFile, dyeListData);
            return;
            
        }
    }
}
