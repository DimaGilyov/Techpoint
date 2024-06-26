﻿namespace Train.Alerts
{
    internal class Alerts
    {
        public void Run(string inputFilePath = "")
        {
            //string outputFilePath = $"{inputFilePath}.Test";
            //using var input = new StreamReader(inputFilePath);
            //using var output = new StreamWriter(outputFilePath);

            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());

            int[] data = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
            int n = data[0];
            int q = data[1];

            //int[] response = new int[n + 1]; 
            int msgNumber = 0;
            int globalMsgNumber = 0;
            Dictionary<int, int> messages = new Dictionary<int, int>();
            for (int i = 0; i < q; i++)
            {
                int[] query = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
                int t = query[0];
                int id = query[1];

                if (t == 1)
                {
                    msgNumber++;
                    if (id == 0)
                    {
                        globalMsgNumber = msgNumber;
                        messages.Clear();
                    }
                    else
                    {
                        messages[id] = msgNumber;
                    }
                }
                else
                {
                    int resp = 0;
                    if (!messages.TryGetValue(id, out resp))
                    {
                        resp = globalMsgNumber;
                    }
                    output.WriteLine(resp);
                }
            }
        }
    }
}