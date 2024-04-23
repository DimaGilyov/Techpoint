namespace Techpoint
{

    public class CorrectQueue
    {
        public static int FindIndex(List<int> indexes, int targetIndex)
        {
            if (indexes.Count == 0)
            {
                return -1;
            }

            int maxVal = indexes.LastOrDefault();
            if (maxVal < targetIndex)
            {
                return -1;
            }

            int middleIndex = indexes.Count / 2;
            int middleVal = indexes[middleIndex];
            int startIndex = 0;
            if (middleVal < targetIndex)
            {
                startIndex = middleIndex;
            }

            int index = indexes.FindIndex(startIndex, e => e > targetIndex);
            return index;
        }

        public static void Main(string[] args)
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());

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

                int xCount = x_indexes.Count;
                int yCount = y_indexes.Count;
                int zCount = z_indexes.Count;

                // 2. Удалим все YZ события
                for (int j = 0; j < y_indexes.Count; j++)
                {
                    xCount = x_indexes.Count;
                    yCount = y_indexes.Count;
                    zCount = z_indexes.Count;
                    if (xCount == yCount + zCount)
                    {
                        // Прекращаем удалять пары YZ, т.к остались Y и Z что бы собрать пары XY и XZ
                        break;
                    }
                    int y_index = y_indexes[j];
                    int index = FindIndex(z_indexes, y_index);
                    //FindIndex
                    if (index >= 0)
                    {
                        y_indexes.RemoveAt(j);
                        z_indexes.RemoveAt(index);
                        j--;
                    }
                }



                // 3. Пробуем собрать все XY и XZ события
                bool success = true;

                xCount = x_indexes.Count;
                yCount = y_indexes.Count;
                zCount = z_indexes.Count;
                if (xCount == yCount + zCount)
                {
                    for (int j = 0; j < x_indexes.Count; j++)
                    {
                        int x_index = x_indexes[j];
                        int y_index = FindIndex(y_indexes, x_index);
                        int z_index = FindIndex(z_indexes, x_index);

                        int y_val = -1;
                        int z_val = -1;
                        if (y_index >= 0)
                        {
                            y_val = y_indexes[y_index];
                        }
                        if (z_index >= 0)
                        {
                            z_val = z_indexes[z_index];
                        }

                        bool yFirst = y_val >= 0 && z_val >= 0 && y_val < z_val || z_val == -1;

                        if (yFirst && y_index >= 0)
                        {
                            x_indexes.RemoveAt(j);
                            y_indexes.RemoveAt(y_index);
                            j--;
                        }
                        else if (z_index >= 0)
                        {
                            x_indexes.RemoveAt(j);
                            z_indexes.RemoveAt(z_index);
                            j--;
                        }
                        else
                        {
                            success = false;
                            break;
                        }
                    }
                    if (y_indexes.Count > 0 || z_indexes.Count > 0)
                    {
                        success = false;
                    }
                }
                else
                {
                    success = false;
                }


                string response = success ? "Yes" : "No";
                output.WriteLine(response);
            }
        }
    }
}