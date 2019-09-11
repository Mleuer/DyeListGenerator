using System;
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
    }
}