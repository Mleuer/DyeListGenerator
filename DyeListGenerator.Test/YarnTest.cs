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
            Assert.AreEqual(expectedYarn.TypeCode, actualYarn.TypeCode);
            Assert.AreEqual(expectedYarn.YarnTypeDescription, actualYarn.YarnTypeDescription);
        }
        [Test]
        public void IsMiniSkeinShouldReturnFalseWhenDescriptionDoesNotContainNumber()
        {
            Yarn yarn = new Yarn(5, YarnType.Classy, "Classy S.W. Merino Worsted");
            
            Assert.False(Yarn.IsMiniSkein(yarn));
        }
        [Test]
        public void IsMiniSkeinShouldReturnTrueWhenDescriptionContainsANumber()
        {
            Yarn yarn = new Yarn(5, YarnType.Classy, "Classy 5- 50yd.minis @ $2.90 per skein");
            
            Assert.True(Yarn.IsMiniSkein(yarn));
        }
    }
}