using System;
using System.Numerics;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace DyeListGenerator
{
    public class Yarn
    {
        public YarnType Type { get; }
        public int NumberOfSkeins { get; }

        public Yarn(YarnType type, int numberOfSkeins)
        {
            Type = type;
            NumberOfSkeins = numberOfSkeins;
        }

        public static Yarn CreateYarnFromText(String inputText)
        {
            //,5,BSK,Bobby BFL
            inputText = inputText.TrimStart(',');
            String[] inputs = inputText.Split(',');

            YarnType yarnType = YarnTypeFactory.createYarnTypeFromText(inputs[1]);
            int quantity = int.Parse(inputs[0]);

            Yarn yarn = new Yarn(yarnType, quantity);
            return yarn;
        }
    }

    
}