using System.Text;
using System.Text.Json;

namespace Techpoint
{
    internal class Task5 : ITask
    {
        public void Run(string file)
        {
            string outputFilePath = $"{file}.Test";
            using var input = new StreamReader(file);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());
            int testsCount = int.Parse(input.ReadLine());
            for (int i = 0; i < testsCount; i++)
            {
                int linesCount = int.Parse(input.ReadLine());
                for (int j = 0; j < linesCount; j++)
                {
                    //jsonStr.Append(input.ReadLine());
                }
                //object root = JsonSerializer.Deserialize<object>(jsonStr.ToString());
                int a = 0;

            }
        }
    }
}
