using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace DyeListGenerator.Test
{
    public class CustomerTest
    {
        [Test]
        public void GenerateCustomersShouldCreateListOfCustomers()
        {
            String yarnData =
                Environment.NewLine +
                "\"Dream in Color, Inc.\"" + Environment.NewLine +
                "2020 E. 13th Street" + Environment.NewLine +
                "\"Tucson, AZ 85719\"" + Environment.NewLine + Environment.NewLine +

                "Sales [Customer Detail]" + Environment.NewLine + Environment.NewLine +

                "December 2018 through December 2019" + Environment.NewLine +
                "8/23/19,Page 1" + Environment.NewLine +
                "9:42:43 AM" + Environment.NewLine +
                ",Quantity,Item/Acct,Description,Job Name" + Environment.NewLine + Environment.NewLine +

                "Birdhouse Yarns,AZ8515" + Environment.NewLine +
                ",5,BSK,Bobby BFL" + Environment.NewLine +
                ",1.25,BSK,Bobby BFL" + Environment.NewLine +
                ",3,CS,Cosette Dk Merino Cashmere Nylon,Shiny Moss" + Environment.NewLine +
                ",3,CS,Cosette Dk Merino Cashmere Nylon,Jessamyn" + Environment.NewLine +
                ",3,CS,Cosette Dk Merino Cashmere Nylon,Fable" + Environment.NewLine + Environment.NewLine +

                "Birdhouse Yarns Total:" + Environment.NewLine;
            
            List<Customer> customers = Customer.GenerateCustomers(Util.CreateStreamFromString(yarnData));
            List<Customer> expectedCustomer = customers.FindAll((Customer customer) =>
            {
                return (customer.Name == "Birdhouse Yarns");
            });
            
            Assert.True(expectedCustomer.Count == 1);
        }

        [Test]
        public void IsTotalLineReturnsTrueWhenLineEndsWithTotal()
        {
            String totalLine = "Birdhouse Yarns Total:";

            Assert.True(Customer.IsTotalLine(totalLine));
        }
        
        [Test]
        public void IsTotalLineReturnsFalseWhenLineDoesNotEndWithTotal()
        {
            String totalLine = "Birdhouse Yarns";

            Assert.False(Customer.IsTotalLine(totalLine));
        }
    }
}