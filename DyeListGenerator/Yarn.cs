using System;
using System.Linq;
using System.Numerics;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace DyeListGenerator
{
    public class Yarn
    {
        public double NumberOfSkeins { get; }
        public YarnType TypeCode { get; }
        public String YarnTypeDescription { get; }

        public Yarn(double numberOfSkeins, YarnType typeCode, String yarnTypeDescription)
        {
            NumberOfSkeins = numberOfSkeins;
            TypeCode = typeCode;
            YarnTypeDescription = yarnTypeDescription;
        }
        
        public static bool IsMiniSkein(Yarn yarn)
        {
            return yarn.YarnTypeDescription.Any(char.IsDigit);
        }
        public static Yarn CreateYarnFromText(string inputText)
        {
            //,5,BSK,Bobby BFL
            inputText = inputText.TrimStart(',');
            String[] inputs = inputText.Split(',');

            double quantity = double.Parse(inputs[0]);
            YarnType yarnTypeCode = YarnTypeFactory.CreateYarnTypeCodeFromText(inputs[1]);
            String yarnTypeDescription = inputs[2];
            Yarn yarn = new Yarn(quantity, yarnTypeCode, yarnTypeDescription);

            if (IsMiniSkein(yarn))
            {
                YarnTypeFactory.ConvertToMiniSkeinType(yarn);
                return yarn;
            }
            return yarn;
        }
    
        
    }

    
}