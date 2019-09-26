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

        [Test]
        public void AddingTwoYarnTogetherShouldSumTheQuantitiesWhenTheyHaveTheSameProperties()
        {
            Yarn yarn1 = new Yarn() {NumberOfSkeins = 10, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"};
            Yarn yarn2 = new Yarn() {NumberOfSkeins = 15, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"};

            Yarn totalYarn = yarn1 + yarn2;
            
            Assert.AreEqual(25, totalYarn.NumberOfSkeins);
        }
        
        [Test]
        public void AddingTwoYarnTogetherShouldNotSumTheQuantitiesWhenTheyDoNotHaveTheSameProperties()
        {
            var yarn1 = new Yarn() {NumberOfSkeins = 10, YarnType = YarnType.Classy, YarnTypeDescription = "lassy S.W. Merino Worsted", Color = "A Little Night Music"};
            var yarn2 = new Yarn() {NumberOfSkeins = 15, YarnType = YarnType.Classy, YarnTypeDescription = "Classy S.W. Merino Worsted", Color = "A Little Night Music"};


            Assert.Throws<ArgumentException>(() =>
            {
                Yarn totalYarn = yarn1 + yarn2;
            });
        }
    }
}