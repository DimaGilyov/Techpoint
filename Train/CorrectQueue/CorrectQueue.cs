﻿namespace Train.CorrectQueue
{
    internal class CorrectQueue
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
                int n = int.Parse(input.ReadLine());// количество сообщений в очереди
                string message = input.ReadLine();


                char[] events = message.ToCharArray();
                bool success = true;
                for (int j = 0; j < events.Length; j++)
                {
                    var @event = events[j];
                  
                }

                string response = success ? "Yes" : "No";
                output.WriteLine(response);
            }
        }
    }
}
