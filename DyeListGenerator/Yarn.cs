using System;
using System.Linq;

namespace DyeListGenerator
{
    public class Yarn
    {
        public double NumberOfSkeins { get; }
        public YarnType YarnType { get; }
        public String YarnTypeDescription { get; }
        public String Color { get; set; }

        public bool IsMiniSkein
        {
            get { return YarnTypeDescription.Any(char.IsDigit); }
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
            YarnType yarnType = YarnFactory.CreateYarnTypeFromText(inputs[1]);
            String yarnTypeDescription = inputs[2];

            (yarnType, quantity) = YarnFactory.ModifyValuesForMiniSkeins(yarnTypeDescription, quantity, yarnType);

            Yarn yarn = new Yarn(quantity, yarnType, yarnTypeDescription);

            return yarn;
        }
    }

    public enum YarnType
    {
        [YarnTypeProperties(5, MiniClassy)] Classy,

        [YarnTypeProperties(5, MiniClassyWCashmere)]
        ClassyWCashmere,
        [YarnTypeProperties(4, MiniSmooshy)] Smooshy,

        [YarnTypeProperties(4, MiniSmooshyWCashmere)]
        SmooshyWCashmere,
        [YarnTypeProperties(4, MiniJilly)] Jilly,

        [YarnTypeProperties(4, MiniJillyWCashmere)]
        JillyWCashmere,

        [YarnTypeProperties(4, MiniJillyLaceCashmere)]
        JillyLaceCashmere,
        [YarnTypeProperties(4, MiniCosette)] Cosette,
        [YarnTypeProperties(5, MiniCity)] City,
        Mohair,
        [YarnTypeProperties(4, MiniBFL2Ply)] BFL2Ply,
        [YarnTypeProperties(4, MiniBFLSock)] BFLSock,
        [YarnTypeProperties(4, MiniBFLDK)] BFLDK,
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
}