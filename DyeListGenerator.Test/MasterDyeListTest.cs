using System.Collections.Generic;
using NUnit.Framework;

namespace DyeListGenerator.Test
{
    public class MasterDyeListTest
    {
        [Test]
        public void ExtractYarnCountsShouldReturnExpectedYarnCounts()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer("Birdhouse", new List<Yarn>()
                {
                    new Yarn() {NumberOfSkeins = 10, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"},
                    new Yarn() {NumberOfSkeins = 6, YarnType = YarnType.Smooshy, YarnTypeDescription = "Smooshy Sock Superwash Merino", Color = "6 of Everything"}
                }), 
                new Customer("Eat Sleep Knit", new List<Yarn>()
                {
                    new Yarn() {NumberOfSkeins = 10, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"},
                    new Yarn() {NumberOfSkeins = 6, YarnType = YarnType.SmooshyWCashmere, YarnTypeDescription = "Smooshy Cashmere (Mixed Lot)", Color = "Milky Spite"}
                })
            };
            
            Dictionary<Yarn, uint> yarnTotals = new Dictionary<Yarn, uint>()
            {
                
            };
        }
    }
}