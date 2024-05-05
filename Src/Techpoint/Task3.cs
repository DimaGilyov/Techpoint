namespace Techpoint
{
    internal class Task3 : ITask
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
                string line = input.ReadLine();
                if (line.Length < 2)
                {
                    output.WriteLine("YES");
                }
                else
                {
                    Dictionary<char, int> lettersCount= new Dictionary<char, int>();
                    foreach (char c in line)
                    {
                        if (!lettersCount.TryGetValue(c, out int count))
                        {
                            lettersCount[c] = 0;
                        }

                        lettersCount[c]++;
                    }

                    char chr = lettersCount.OrderByDescending(x => x.Value).First().Key;
                    bool canAnother = true;
                    bool result = true;
                    for (int j = 0; j < line.Length; j++)
                    {
                        char c = line[j];
                        if (c == chr)
                        {
                            canAnother = true;
                        }
                        else if (canAnother && j != line.Length - 1)
                        {
                            canAnother = false;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }

                    string res = result ? "YES" : "NO";
                    output.WriteLine(res);
                }
            }

        }
    }
}
