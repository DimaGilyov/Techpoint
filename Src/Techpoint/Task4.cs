using System.Collections.Generic;

namespace Techpoint
{
    internal class Task4 : ITask
    {
        public void Run(string file)
        {
            string outputFilePath = $"{file}.Test";
            using var input = new StreamReader(file);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            int testsCount = int.Parse(input.ReadLine());
            Dictionary<string, List<double[]>> currencyPairs = new Dictionary<string, List<double[]>>
            {
                { "RUB/USD", new  List<double[]>()},
                { "RUB/EUR", new  List<double[]>()},
                { "USD/RUB", new  List<double[]>()},
                { "USD/EUR", new  List<double[]>()},
                { "EUR/RUB", new  List<double[]>()},
                { "EUR/USD", new  List<double[]>()},
            };

            List<string> currencyPairsList = new List<string>()
            {
                "RUB/USD",
                "RUB/EUR",
                "USD/RUB",
                "USD/EUR",
                "EUR/RUB",
                "EUR/USD",
            };

            for (int i = 0; i < testsCount; i++)
            {
                for (int j = 0; j < currencyPairs.Count; j++)
                {
                    int banksCount = 3;
                    for (int k = 0; k < banksCount; k++)
                    {
                        double[] rate = Array.ConvertAll(input.ReadLine().Split(), double.Parse);
                        string pair = currencyPairsList[j];
                        var list = currencyPairs[pair];
                        list.Add(rate);

                    }
                }
            }

            double answer = FindBestUsd(currencyPairsList, currencyPairs, new List<int>(), "RUB", 1);
            int a = 0;
            //output.WriteLine(answer);
        }

        private double FindBestUsd(List<string> currencyPairsList, Dictionary<string, List<double[]>> currencyPairs, List<int> usedBanks, string currency, double amount)
        {
            double best = 0;
            if (usedBanks.Count == 3)
            { 
                return best;
            }
            

            return best;
        }
    }
}
