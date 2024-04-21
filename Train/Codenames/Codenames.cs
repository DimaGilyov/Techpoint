namespace Train.Codenames
{
    internal class Codenames
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            int t = int.Parse(input.ReadLine()); //количество наборов входных данны
            for (int i = 0; i < t; i++)
            {
                int[] data = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
                int n = data[0]; //количество слов на поле
                int b = data[1]; //количество синих слов
                int r = data[2]; //количество красных слов
                int f = data[3]; //номер чёрного слова

                string[] words = new string[n];
                for (int j = 0; j < n; j++)
                {
                    words[j] = input.ReadLine();
                }

                int a = 0;
            }
        }
    }
}
