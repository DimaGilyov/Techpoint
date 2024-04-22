using System;

namespace Train.CorrectQueue
{
    internal class CorrectQueue
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);
            if (outputFilePath.EndsWith("13.Test"))
            {
                int a = 0;
            }
            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            int t = int.Parse(input.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(input.ReadLine());// количество сообщений в очереди
                string message = input.ReadLine();


                List<char> events = message.ToList();

                // 1. Сгенерируем карту событий и интекстов
                Dictionary<char, List<int>> map = new Dictionary<char, List<int>>();
                map['X'] = new List<int>();
                map['Y'] = new List<int>();
                map['Z'] = new List<int>();

                List<int> x_indexes = map['X'];
                List<int> y_indexes = map['Y'];
                List<int> z_indexes = map['Z'];

                for (int j = 0; j < events.Count; j++)
                {
                    var @event = events[j];
                    List<int> indexes = map[@event];
                    indexes.Add(j);
                }

                // 2. Удалим все YZ события
                int xCount = x_indexes.Count;
                int remMax = (n - xCount) / 2;
                int remCount = 0;
                //int yCount = y_indexes.Count;
                //int zCount = z_indexes.Count;
                for (int j = 0; j < y_indexes.Count; j++)
                {
                    if (remCount == remMax)
                    {
                        break;
                    }
                    int y_index = y_indexes[j];
                    int index = z_indexes.FindIndex(e => e > y_index);
                    if (index >= 0)
                    {
                        y_indexes.RemoveAt(j);
                        z_indexes.RemoveAt(index);
                        remCount++;
                    }
                }

                // 3. Пробуем собрать все XY и XZ события
                bool success = true;
                for (int j = 0; j < x_indexes.Count; j++)
                {
                    int x_index = x_indexes[j];
                    int y_index = y_indexes.FindIndex(e => e > x_index);
                    if (y_index >= 0)
                    {
                        x_indexes.RemoveAt(j);
                        y_indexes.RemoveAt(y_index);
                    }
                    else 
                    {
                        int z_index = z_indexes.FindIndex(e => e > x_index);
                        if (z_index >= 0)
                        {
                            x_indexes.RemoveAt(j);
                            z_indexes.RemoveAt(z_index);
                        }
                        else
                        {
                            success = false;
                            break;
                        }
                    }
                }

                string response = success ? "Yes" : "No";
                output.WriteLine(response);
            }
        }
    }
}
