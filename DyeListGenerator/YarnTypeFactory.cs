using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DyeListGenerator
{
    public static class YarnTypeFactory
    {
        public static YarnType CreateYarnTypeCodeFromText(string input)
        {
            String upperInput = input.ToUpper();
            switch (upperInput)
            {
                case "VM":
                    return YarnType.Classy;
                case "CC":
                    return YarnType.ClassyWCashmere;
                case "VS":
                    return YarnType.Smooshy;
                case "VC":
                    return YarnType.SmooshyWCashmere;
                case "JY":
                    return YarnType.Jilly;
                case "JC":
                    return YarnType.JillyWCashmere;
                case "JLC":
                    return YarnType.JillyLaceCashmere;
                case "CS":
                    return YarnType.Cosette;
                case "CT":
                    return YarnType.City;
                case "SL":
                    return YarnType.Mohair;
                case "B2":
                    return YarnType.BFL2Ply;
                case "BSK":
                    return YarnType.BFLSock;
                case "BDK":
                    return YarnType.BFLDK;
                default:
                    throw new ArgumentException("Yarn Type Does Not Exist");
            }
        }

        public static (YarnType, double) ModifyValuesForMiniSkeins(string yarnDescription, double quantity, YarnType yarnType)
        {
            if (yarnDescription.Any(char.IsDigit))
            {
                double conversionConstant = yarnType.GetMiniConversionConstant();
                quantity *= conversionConstant;
                YarnType miniType = yarnType.GetCorrespondingMiniType();
                return (miniType, quantity);
            }
            return (yarnType, quantity);
        }
    }
    
    public enum YarnType
    {
        [YarnTypeProperties(5, MiniClassy)]
        Classy,
        [YarnTypeProperties(5, MiniClassyWCashmere)]
        ClassyWCashmere,
        [YarnTypeProperties(4, MiniSmooshy)]
        Smooshy,
        [YarnTypeProperties(4, MiniSmooshyWCashmere)]
        SmooshyWCashmere,
        [YarnTypeProperties(4, MiniJilly)]
        Jilly,
        [YarnTypeProperties(4, MiniJillyWCashmere)]
        JillyWCashmere,
        [YarnTypeProperties(4, MiniJillyLaceCashmere)]
        JillyLaceCashmere,
        [YarnTypeProperties(4, MiniCosette)]
        Cosette,
        [YarnTypeProperties(5, MiniCity)]
        City,
        Mohair,
        [YarnTypeProperties(4, MiniBFL2Ply)]
        BFL2Ply,
        [YarnTypeProperties(4, MiniBFLSock)]
        BFLSock,
        [YarnTypeProperties(4, MiniBFLDK)]
        BFLDK,
        MiniClassy,
        MiniClassyWCashmere,
        MiniSmooshy,
        MiniSmooshyWCashmere,
        MiniJilly,
        MiniJillyWCashmere,
        MiniJillyLaceCashmere,
        MiniCosette,
        MiniCity,
        MiniMohair,
        MiniBFL2Ply,
        MiniBFLSock,
        MiniBFLDK
    }
    
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class YarnTypePropertiesAttribute : Attribute
    {
        public double MiniConversionConstant { get; }
        public YarnType CorrespondingMiniType { get; }

        public YarnTypePropertiesAttribute(double miniConversionConstant, YarnType miniType)
        {
            MiniConversionConstant = miniConversionConstant;
            CorrespondingMiniType = miniType;
        }
        
    }

    public static class YarnTypeExtension
    {
        public static double GetMiniConversionConstant(this YarnType yarnType)
        {
            YarnTypePropertiesAttribute yarnTypePropertiesAttribute = GetYarnTypeProperties(yarnType);
            double conversionConstant = yarnTypePropertiesAttribute.MiniConversionConstant;
            return conversionConstant;
        }

        public static YarnType GetCorrespondingMiniType(this YarnType yarnType)
        {
            YarnTypePropertiesAttribute yarnTypePropertiesAttribute = GetYarnTypeProperties(yarnType);
            YarnType miniType = yarnTypePropertiesAttribute.CorrespondingMiniType;
            return miniType;
        }

        private static YarnTypePropertiesAttribute GetYarnTypeProperties(YarnType yarnType)
        {
            Type type = yarnType.GetType();

            string name = Enum.GetName(type, yarnType);

            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    YarnTypePropertiesAttribute yarnTypeProperties =
                        Attribute.GetCustomAttribute(field, typeof(YarnTypePropertiesAttribute)) as YarnTypePropertiesAttribute;
                    if (yarnTypeProperties != null)
                    {
                        return yarnTypeProperties;
                    }
                }
            }
            throw new ArgumentException();
        }
}
}