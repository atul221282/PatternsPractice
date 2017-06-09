using System;
using System.Collections.Generic;
using System.Globalization;

namespace HCATest
{
    class Program
    {
        static void Main(string[] args)
        {
            var enumerator = GetCheckDigitNumber.GetMultiplicativeFactors().GetEnumerator();

            Console.WriteLine(enumerator);

            Console.ReadKey();

            PrintMessage("------Gross prices with 10% commision rate-------");

            //Wasn't sure about the percentage parameter format as it was not clear from the test spec
            //therefore created two methods
            foreach (var grossPrice in CalculateGrossPrice(10, new double[] { 27, 32.4, 108.765 }))
            {
                Console.WriteLine(grossPrice);
            }

            PrintMessage("------Method with string parameter-------");

            foreach (var grossPrice in CalculateGrossPrice("10%", new double[] { 27, 32.4, 108.765 }))
            {
                Console.WriteLine(grossPrice);
            }

            Console.ReadLine();
        }

        private static void PrintMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        private static IEnumerable<double> CalculateGrossPrice(int commissionRate, double[] netPrices)
        {
            //TODO: parameters validation
            var commisionPercent = (double)commissionRate / 100;

            foreach (var netPrice in netPrices)
            {
                yield return netPrice / (1 - commisionPercent);
            }
        }

        private static IEnumerable<double> CalculateGrossPrice(string commissionPercent, double[] netPrices)
        {
            //TODO: parameters validation
            commissionPercent = commissionPercent.Replace(CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");

            if (!int.TryParse(commissionPercent, out int commissionRate))
            {
                //some error handling
            }

            var commisionPercent = (double)commissionRate / 100;

            foreach (var netPrice in netPrices)
            {
                yield return netPrice / (1 - commisionPercent);
            }
        }
    }
}