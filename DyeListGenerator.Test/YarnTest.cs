using System;
using NUnit.Framework;


namespace DyeListGenerator.Test
{
    public class YarnTest
    {
        [Test]
        public void createYarnFromTextShouldCreateNewYarnObjectFromString()
        {
            var expectedYarn = new Yarn(YarnType.BFLSock, 5);
            String CommaSeparatedString = ",5,BSK,Bobby BFL";

            var actualYarn = Yarn.CreateYarnFromText(CommaSeparatedString);
            
            Assert.AreEqual(expectedYarn.Type, actualYarn.Type);
            Assert.AreEqual(expectedYarn.NumberOfSkeins, actualYarn.NumberOfSkeins);
        }
    }
}