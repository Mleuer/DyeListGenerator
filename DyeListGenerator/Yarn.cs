using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace DyeListGenerator
{
    public class Yarn
    {
        public double NumberOfSkeins { get; }
        public YarnType YarnType { get; }
        public String YarnTypeDescription { get; }

        public bool IsMiniSkein
        {
            get
            {
                return YarnTypeDescription.Any(char.IsDigit);
            }
        }

        public Yarn(double numberOfSkeins, YarnType yarnType, String yarnTypeDescription)
        {
            NumberOfSkeins = numberOfSkeins;
            YarnType = yarnType;
            YarnTypeDescription = yarnTypeDescription;
        }
        public static Yarn CreateYarnFromText(string inputText)
        {
            //,5,BSK,Bobby BFL
            inputText = inputText.TrimStart(',');
            String[] inputs = inputText.Split(',');

            double quantity = double.Parse(inputs[0]);
            YarnType yarnType = YarnTypeFactory.CreateYarnTypeCodeFromText(inputs[1]);
            String yarnTypeDescription = inputs[2];

            (yarnType, quantity) = YarnTypeFactory.ModifyValuesForMiniSkeins(yarnTypeDescription, quantity, yarnType);
            
            Yarn yarn = new Yarn(quantity, yarnType, yarnTypeDescription);
            
            return yarn;
        }

    }

    
}