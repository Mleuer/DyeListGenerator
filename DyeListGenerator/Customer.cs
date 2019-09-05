using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;


namespace DyeListGenerator
{
    public class Customer
    {
        public String Name { get; private set; } 
        public List<Yarn> Order { get; private set; }


        public static List<Customer> GenerateCustomers(Stream stream)
        {
            var customers = new List<Customer>();
            
            using (var reader = new StreamReader(stream))
            {
                using (var csv = new CsvReader(reader))
                {
                    bool yarnDataParsable = false;
                    Customer currentCustomer = null;

                    while (csv.Read())
                    {
                        String[] line = csv.Parser.Context.Record;
                        if (line.Contains("Quantity"))
                        {
                            csv.ReadHeader();
                            yarnDataParsable = true;
                        }

                        if (yarnDataParsable)
                        {
                            var customerName = csv.Parser.Context.Record[0];
                            if ( customerName != String.Empty)
                            {
                                currentCustomer = new Customer() {Name = customerName};
                                customers.Add(currentCustomer);
                                continue;
                            }
                        }

                        if (currentCustomer != null)
                        {
                            double quantity = csv.GetField<double>(1);
                            YarnType yarntype = YarnFactory.CreateYarnTypeFromText(csv.GetField<String>(2));
                            csv.GetField(3);
                            csv.GetField(4);
                        }


//                        var customer = new Customer
//                        {
//                            
//                            Name = csv.GetField<int>("Id"),
//                            Order = { }csv.GetField("Name")
//                        };
//                        customers.Add(customer);
                    }
                }
            }
            
            

            return customers;
        }
        
    }
    
}