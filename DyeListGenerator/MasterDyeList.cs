using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;


namespace DyeListGenerator
{
    public class MasterDyeList
    {
        public ExcelPackage Package;

        public MasterDyeList(Stream dyeListData)
        {
            Package = new ExcelPackage();
            Package.Load(dyeListData);
        }

        ~MasterDyeList()
        {
            Package.Dispose();
        }

        public void Write(List<Customer> customers)
        {
            
        }

        public static Dictionary<Yarn, uint> ExtractYarnCounts(List<Customer> customers)
        {
            return null;
        }
    }
}