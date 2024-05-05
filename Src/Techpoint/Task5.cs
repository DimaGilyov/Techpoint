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
        }
    }
}
