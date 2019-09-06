using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using MissingFieldException = CsvHelper.MissingFieldException;


namespace DyeListGenerator
{
    public class Customer
    {
        public String Name { get; private set; } 
        public List<Yarn> Order { get; private set; }

        public Customer()
        {
            Order = new List<Yarn>();
        }

        public Customer(String name, List<Yarn> order)
        {
            Name = name;
            Order = order;
        }


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
                            Yarn yarn;
                            try
                            {
                                double quantity = csv.GetField<double>(1);
                                YarnType yarntype = YarnFactory.CreateYarnTypeFromText(csv.GetField<String>(2));
                                String yarnTypeDescription = csv.GetField<String>(3);
                                yarn = new Yarn(quantity, yarntype, yarnTypeDescription);
                                
                                if (csv.TryGetField<String>(4, out String colorName))
                                {
                                    yarn.Color = colorName;
                                }
                                currentCustomer.Order.Add(yarn);
                            }
                            
                            catch (MissingFieldException exception)
                            {
                                Console.WriteLine(exception);
                                continue;
                            }
                        }
                        
                    }
                }
            }
            return customers;
        }
        
    }
    
}