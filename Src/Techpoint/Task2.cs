namespace Techpoint
{
    internal class Task2 : ITask
    {
        public void Run(string file)
        {
            string outputFilePath = $"{file}.Test";
            using var input = new StreamReader(file);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());
            int[] data = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
            int wordsCount = data[0];
            int testsCount = data[1];
            List<string> letters = input.ReadLine().Split().ToList();
            for (int i = 0; i < testsCount; i++)
            {
                string password = input.ReadLine();
                if (password.Length != letters.Count)
                {
                    output.WriteLine("NO");
                }
                else
                {
                    bool result  = true;
                    string temp = password;
                    foreach (var c in letters)
                    {
                        int index = temp.IndexOf(c);
                        if (index == -1)
                        { 
                            result = false;
                            break;
                        }

                        temp = temp.Remove(index, 1);
                    }

                    string r = result ? "YES": "NO";
                    output.WriteLine(r);
                }
            }

            int a = 0;
        }
    }
}
