using System;
using NUnit.Framework;

namespace DyeListGenerator.Test
{
    public class YarnTypeFactoryTest
    {
        [Test]
        public void CreateYarnTypeCodeFromTextShouldReturnYarnTypeCodeAsBFLSock()
        {
            String typeCode = "BSK";

            YarnType yarnType = YarnTypeFactory.CreateYarnTypeCodeFromText(typeCode);
            
            Assert.AreEqual(YarnType.BFLSock, yarnType);

        }
        [Test]
        public void ModifyValuesForMiniSkeinsShouldModifyValuesWhenDescriptionContainsANumber()
        {
            string yarnDescription = "Classy 5- 50yd.minis @ $2.90 per skein";
            double quantity = 2;
            YarnType yarnType = YarnType.Classy;
            
           (YarnType updatedYarnType, double updatedQuantity) = YarnTypeFactory.ModifyValuesForMiniSkeins(yarnDescription, quantity, yarnType);
           
           Assert.AreEqual(YarnType.MiniClassy, updatedYarnType);
           Assert.AreEqual(10, updatedQuantity);

        }
        
        [Test]
        public void ModifyValuesForMiniSkeinsShouldNotModifyValuesWhenDescriptionDoesNotContainANumber()
        {
            string yarnDescription = "Classy S.W. Merino Worsted";
            double quantity = 2;
            YarnType yarnType = YarnType.Classy;
            
            (YarnType updatedYarnType, double updatedQuantity) = YarnTypeFactory.ModifyValuesForMiniSkeins(yarnDescription, quantity, yarnType);
           
            Assert.AreEqual(YarnType.Classy, updatedYarnType);
            Assert.AreEqual(2, updatedQuantity);

        }
    }
}