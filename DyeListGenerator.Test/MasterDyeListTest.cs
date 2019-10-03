using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using OfficeOpenXml;

namespace DyeListGenerator.Test
{
    public class MasterDyeListTest
    {
        private List<Customer> Customers;

        [SetUp]
        public void Setup()
        {
            Customers = new List<Customer>
            {
                new Customer("Birdhouse", new List<Yarn>()
                {
                    new Yarn() {NumberOfSkeins = 10, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"},
                    new Yarn() {NumberOfSkeins = 6, YarnType = YarnType.Smooshy, YarnTypeDescription = "Smooshy Sock Superwash Merino", Color = "6 of Everything"}
                }), 
                new Customer("Eat Sleep Knit", new List<Yarn>()
                {
                    new Yarn() {NumberOfSkeins = 20, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"},
                    new Yarn() {NumberOfSkeins = 3, YarnType = YarnType.SmooshyWCashmere, YarnTypeDescription = "Smooshy Cashmere (Mixed Lot)", Color = "Milky Spite"}
                }),
                new Customer("Baa Baa Sheep", new List<Yarn>()
                {
                    new Yarn() {NumberOfSkeins = 5, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"},
                    new Yarn() {NumberOfSkeins = 10, YarnType = YarnType.Classy, YarnTypeDescription = "Classy Merino Worsted", Color = "A Little Night Music"},
                    new Yarn() {NumberOfSkeins = 3, YarnType = YarnType.SmooshyWCashmere, YarnTypeDescription = "Smooshy Cashmere (Mixed Lot)", Color = "Milky Spite"}
                })
            };
        }

        [Test]
        public void ExtractYarnCountsShouldReturnExpectedYarnCounts()
        {
            ISet<Yarn> yarnTotals = new HashSet<Yarn>()
            {
                new Yarn() {NumberOfSkeins = 35, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"},
                new Yarn() {NumberOfSkeins = 6, YarnType = YarnType.Smooshy, YarnTypeDescription = "Smooshy Sock Superwash Merino", Color = "6 of Everything"},
                new Yarn() {NumberOfSkeins = 6, YarnType = YarnType.SmooshyWCashmere, YarnTypeDescription = "Smooshy Cashmere (Mixed Lot)", Color = "Milky Spite"},
                new Yarn() {NumberOfSkeins = 10, YarnType = YarnType.Classy, YarnTypeDescription = "Classy Merino Worsted", Color = "A Little Night Music"},
            };

            ISet<Yarn> actualYarnTotals = MasterDyeList.ExtractYarnCounts(Customers);
            
            Assert.AreEqual(yarnTotals, actualYarnTotals);
        }

        [Test]

        public void Write()
        {
            var masterDyeListData = typeof(MasterDyeListTest).Assembly.GetManifestResourceStream(typeof(MasterDyeListTest), "Resources.MasterDyeList.xlsx");

            MasterDyeList masterDyeList = new MasterDyeList(masterDyeListData);
            masterDyeList.Write(Customers);
            
        }
    }
}









