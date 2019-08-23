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
        
    }
}