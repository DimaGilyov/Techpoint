namespace Train.CorrectQueue
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

                // Переводим в буквы в числовое значение по таблице ASCII
                // x - 88
                // y - 89
                // z - 90
                //byte[] events = message.Select(c => (byte)c).ToArray();
                char[] events = message.ToCharArray();
                Dictionary<char, List<int>> keyValuePairs = new Dictionary<char, List<int>>();

                bool success = true;
                for (int j = 0; j < events.Length; j++)
                {
                    var @event = events[j];
                    if (!keyValuePairs.TryGetValue(@event, out List<int> indexes))
                    {
                        indexes = new List<int>();
                        keyValuePairs[@event] = indexes;
                    }

                    if (@event == 'X')
                    {
                        keyValuePairs.TryGetValue('Y', out List<int> y_indexes);
                        int index = -1;
                        if (y_indexes?.Count > 0)
                        {
                            index = y_indexes.FindIndex(e => e > j);
                        }
                        if (index >= 0)
                        {
                            y_indexes.RemoveAt(index);
                        }
                        else
                        {
                            indexes.Add(j);
                        }
                    }
                    else if (@event == 'Y')
                    {
                        keyValuePairs.TryGetValue('X', out List<int> x_indexes);
                        keyValuePairs.TryGetValue('Z', out List<int> z_indexes);
                        int index = -1;

                        if (x_indexes?.Count > 0)
                        {
                            index = x_indexes.FindIndex(e => e < j);
                            if (index >= 0)
                            {
                                x_indexes.RemoveAt(index);
                            }
                        }
                        if (index < 0 && z_indexes?.Count > 0)
                        {
                            index = z_indexes.FindIndex(e => e > j);
                        }
                        if (index >= 0)
                        {
                            z_indexes.RemoveAt(index);
                        }
                        else
                        {
                            indexes.Add(j);
                        }
                    }
                    else
                    {
                        keyValuePairs.TryGetValue('X', out List<int> x_indexes);
                        keyValuePairs.TryGetValue('Y', out List<int> y_indexes);

                        int index = -1;
                        if (x_indexes?.Count > 0)
                        {
                            index = x_indexes.FindIndex(e => e < j);
                            if (index >= 0)
                            {
                                x_indexes.RemoveAt(index);
                            }
                        }
                        if (index < 0 && y_indexes?.Count > 0)
                        {
                            index = y_indexes.FindIndex(e => e < j);
                            if (index >= 0)
                            {
                                y_indexes.RemoveAt(index);
                            }
                        }
                        if (index == -1)
                        {
                            indexes.Add(j);
                        }
                    }
                }

                foreach (var kv in keyValuePairs)
                {
                    if (kv.Value.Count > 0)
                    {
                        success = false;
                        break;
                    }
                }
                string response = success ? "Yes" : "No";
                output.WriteLine(response);
            }
        }
    }
}
