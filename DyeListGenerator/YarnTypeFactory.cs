using System;

namespace DyeListGenerator
{
    public static class YarnTypeFactory
    {
        public static YarnType createYarnTypeFromText(string input)
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
                case "CM":
                    return YarnType.Custom;
                default:
                    throw new ArgumentException("Yarn Type Does Not Exist");
            }
        }
    }
    
    public enum YarnType
    {
        Classy,
        ClassyWCashmere,
        Smooshy,
        SmooshyWCashmere,
        Jilly,
        JillyWCashmere,
        JillyLaceCashmere,
        Cosette,
        City,
        Mohair,
        BFL2Ply,
        BFLSock,
        BFLDK,
        Custom
    }
}