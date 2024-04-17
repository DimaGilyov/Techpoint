namespace Train.Alerts
{
    internal class Alerts
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            string[] data = input.ReadLine().Split();
            int n = int.Parse(data[0]);
            int q = int.Parse(data[1]);

            int[] response = new int[n + 1]; 
            int msgNumber = 0;
            for (int i = 0; i < q; i++)
            {
                string[] query = input.ReadLine().Split();

                int t = int.Parse(query[0]);
                int id = int.Parse(query[1]);

                if (t == 1)
                {
                    msgNumber++;
                    if (id == 0)
                    {
                        Array.Fill(response, msgNumber);
                    }
                    else
                    {
                        response[id] = msgNumber;
                    }
                }
                else
                {
                    output.WriteLine(response[id]);
                }
            }
        }
    }
}