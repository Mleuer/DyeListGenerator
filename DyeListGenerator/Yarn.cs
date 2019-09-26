using System;
using System.Linq;
using CsvHelper;
using OfficeOpenXml.FormulaParsing.Excel.Operators;
using MissingFieldException = System.MissingFieldException;

namespace DyeListGenerator
{
    public class Yarn
    {
        public double NumberOfSkeins { get; set; }
        public YarnType YarnType { get; set; }
        public String YarnTypeDescription { get; set; }
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
        public Yarn() {}

        public static bool AreEquivalent(Yarn yarn1, Yarn yarn2)
        {
            return (yarn1.IsMiniSkein == yarn2.IsMiniSkein &&
                    yarn1.YarnType == yarn2.YarnType &&
                    yarn1.YarnTypeDescription == yarn2.YarnTypeDescription &&
                    yarn1.Color == yarn2.Color);
        }

        public static Yarn operator +(Yarn yarn, Yarn addend)
        {
            if (AreEquivalent(yarn, addend))
            {
                double sum = yarn.NumberOfSkeins + addend.NumberOfSkeins;
                Yarn newYarn = new Yarn() {NumberOfSkeins = sum, YarnType = yarn.YarnType, YarnTypeDescription = yarn.YarnTypeDescription, Color = yarn.Color};
                return newYarn;
            }
            throw new ArgumentException("Yarn are different types");
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
        
        public static Yarn CreateYarnFromCSV(CsvReader csv)
        {
            Yarn yarn;
            try
            {
                double quantity = csv.GetField<double>(1);
                YarnType yarntype = YarnFactory.CreateYarnTypeFromText(csv.GetField<String>(2));
                String yarnTypeDescription = csv.GetField<String>(3);
                yarn = new Yarn(quantity, yarntype, yarnTypeDescription);

                if (csv.TryGetField<String>(4, out String colorName))
                {
                    yarn.Color = colorName;
                }

                return yarn;
            }

            catch (MissingFieldException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
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