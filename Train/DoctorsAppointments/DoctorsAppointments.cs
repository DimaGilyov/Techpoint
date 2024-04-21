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

            int t = int.Parse(input.ReadLine()); //количество наборов входных данных

            for (int i = 0; i < t; i++)
            {
                int[] inputData = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
                int n = inputData[0]; //количество окон приёма у врача
                int m = inputData[1]; //количество записанных пациентов

                int[] w = Array.ConvertAll(input.ReadLine().Split(), int.Parse); // номер окна, на которое записаны пациенты

                
            }
        }
    }
}
