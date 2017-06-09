using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wasn't sure about the percentage parameter format as it was not clear from the test spec
            //therefore created two methods
            foreach (var grossPrice in CalculateGrossPrice(10, new double[] { 27, 32.4, 108.765 }))
            {
                Console.WriteLine(grossPrice);
            }

            foreach (var grossPrice in CalculateGrossPrice("10%", new double[] { 27, 32.4, 108.765 }))
            {
                Console.WriteLine(grossPrice);
            }
            Console.ReadKey();
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















//Console.WriteLine("I am producer");

//using (var manager = new RabbitMqManager())
//{
//    manager.SendRegisterOrderCommand(new RegisterOrderCommand());
//    Console.ReadKey();
//}