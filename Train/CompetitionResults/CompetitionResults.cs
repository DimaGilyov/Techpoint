namespace Train.CompetitionResults
{
    internal class CompetitionResults
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            int t = int.Parse(input.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(input.ReadLine());
                (int number, int time)[] dataSet = new (int, int)[n];
                string[] setStr = input.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    int time = int.Parse(setStr[j]);
                    dataSet[j] = (j, time);
                }

                Array.Sort(dataSet, (a, b) => a.time.CompareTo(b.time));

                int a = 0;
            }
        }
    }
}
