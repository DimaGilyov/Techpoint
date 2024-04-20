namespace Train.DoctorsAppointments
{
    internal class DoctorsAppointments
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            int t = int.Parse(input.ReadLine());
        }
    }
}
