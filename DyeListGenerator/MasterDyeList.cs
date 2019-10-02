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

        public static ISet<Yarn> ExtractYarnCounts(List<Customer> customers)
        {
            HashSet<Yarn> yarnTotal = new HashSet<Yarn>();
            List<Yarn> combinedYarnOrders = extractListOfYarn(customers);
            
            for (var i = 0; i < combinedYarnOrders.Count; i++)
            {
                var yarn1 = combinedYarnOrders[i];
                for (var j = i + 1; j < combinedYarnOrders.Count; j++)
                { 
                    var yarn2 = combinedYarnOrders[j];

                    if (!ReferenceEquals(yarn1, yarn2))
                    {
                        if (Yarn.AreEquivalent(yarn1, yarn2))
                        {
                            yarn1 += yarn2;
                            combinedYarnOrders.RemoveAt(j);
                        }
                    }
                }
                yarnTotal.Add(yarn1);
            }

//            for (var i = 0; i < combinedYarnOrders.Count; i++)
//            {
//                var yarn1 = combinedYarnOrders[i];
//                Yarn combinedYarn = yarn1;
//
//                for (var j = i + 1; j < combinedYarnOrders.Count; j++)
//                {
//                    var yarn2 = combinedYarnOrders[j];
//                    if (!Object.ReferenceEquals(yarn1, yarn2))
//                    {
//                        if (Yarn.AreEquivalent(yarn1, yarn2))
//                        {
//                            combinedYarn += yarn2;
//                        }
//                    }
//                }
//                yarnTotal.Add(combinedYarn);
//            }
//
            return yarnTotal;
        }

        private static List<Yarn> extractListOfYarn(List<Customer> customers)
        {
            List<Yarn> combinedYarn = new List<Yarn>();
            foreach (var customer in customers)
            {
                foreach (var yarn in customer.Order)
                {
                    combinedYarn.Add(yarn);
                }
            }

            return combinedYarn;
        }
    }
}