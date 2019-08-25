using System;
using NUnit.Framework;


namespace DyeListGenerator.Test
{
    public class YarnTest
    {
        [Test]
        public void createYarnFromTextShouldCreateNewYarnObjectFromString()
        {
            var expectedYarn = new Yarn(5, YarnType.BFLSock, "Bobby BFL");
            String CommaSeparatedString = ",5,BSK,Bobby BFL";

            var actualYarn = Yarn.CreateYarnFromText(CommaSeparatedString);
            
            Assert.AreEqual(expectedYarn.NumberOfSkeins, actualYarn.NumberOfSkeins);
            Assert.AreEqual(expectedYarn.YarnType, actualYarn.YarnType);
            Assert.AreEqual(expectedYarn.YarnTypeDescription, actualYarn.YarnTypeDescription);
        }
        [Test]
        public void CreateYarnFromTextShouldCreateNewMiniYarnObjectFromString()
        {
            String CommaSeparatedString = ",5,BSK,5- mini Bobby BFL";
            var actualYarn = Yarn.CreateYarnFromText(CommaSeparatedString);
            
            var expectedYarn = new Yarn(20, YarnType.MiniBFLSock, "5- mini Bobby BFL");
            
            Assert.AreEqual(expectedYarn.NumberOfSkeins, actualYarn.NumberOfSkeins);
            Assert.AreEqual(expectedYarn.YarnType, actualYarn.YarnType);
            Assert.AreEqual(expectedYarn.YarnTypeDescription, actualYarn.YarnTypeDescription);
        }
        [Test]
        public void IsMiniSkeinShouldReturnFalseWhenDescriptionDoesNotContainNumber()
        {
            Yarn yarn = new Yarn(5, YarnType.Classy, "Classy S.W. Merino Worsted");
            
            Assert.False(yarn.IsMiniSkein);
        }
        [Test]
        public void IsMiniSkeinShouldReturnTrueWhenDescriptionContainsANumber()
        {
            Yarn yarn = new Yarn(5, YarnType.Classy, "Classy 5- 50yd.minis @ $2.90 per skein");
            
            Assert.True(yarn.IsMiniSkein);
        }
    }
}