using System.Text;

namespace Techpoint
{

    public class Codenames
    {
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
                    int index = z_indexes.FindIndex(e => e > y_index);
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
                        int y_index = y_indexes.FindIndex(e => e > x_index);
                        int z_index = z_indexes.FindIndex(e => e > x_index);

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

        public static HashSet<string> SuffixArray(string str)
        {
            int n = str.Length;
            HashSet<string> suffixes = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    // Не берем такую подстроку, т.к это слово целиком
                    if (i == 0 && j == n - 1)
                    {
                        continue;
                    }
                    string s = str.Substring(i, j - i + 1);
                    suffixes.Add(s);
                }
            }

            return suffixes;
        }

        public static string MostFrequentSubstr(string[] words, string blackWord, int blueWordsCount, int redWordsCount, out int maxDiffBetweenBlueAndRed)
        {
            HashSet<string> blackWordSuffixArray = SuffixArray(blackWord);
            blackWordSuffixArray.Add(blackWord);
            HashSet<string> wordsHash = new HashSet<string>(words);

            Dictionary<string, int> blue = new Dictionary<string, int>();
            Dictionary<string, int> red = new Dictionary<string, int>();
            Dictionary<string, int> white = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                HashSet<string> suffixArray = SuffixArray(word);
                suffixArray.RemoveWhere(e => blackWordSuffixArray.Contains(e) || wordsHash.Contains(e));
                if (i < blueWordsCount)
                {
                    foreach (string s in suffixArray)
                    {
                        blue.TryGetValue(s, out int count);
                        count++;
                        blue[s] = count;
                    }
                }
                else if (i >= blueWordsCount && i < blueWordsCount + redWordsCount)
                {
                    foreach (string s in suffixArray)
                    {
                        red.TryGetValue(s, out int count);
                        count++;
                        red[s] = count;
                    }
                }
                else
                {
                    foreach (string s in suffixArray)
                    {
                        white.TryGetValue(s, out int count);
                        count++;
                        white[s] = count;
                    }
                }
            }

            List<string> response = new List<string>();

            maxDiffBetweenBlueAndRed = 0;
            foreach (var blueItem in blue)
            {
                string subStr = blueItem.Key;
                int blueCount = blueItem.Value;
                red.TryGetValue(subStr, out int redCount);
                int diff = blueCount - redCount;
                if (diff < maxDiffBetweenBlueAndRed)
                {
                    continue;
                }
                if (diff > maxDiffBetweenBlueAndRed)
                {
                    maxDiffBetweenBlueAndRed = diff;
                    response.Clear();
                }
                response.Add(subStr);
            }
            response.Sort((a, b) => b.Length.CompareTo(a.Length));
            string mostFreqSubstr = response.FirstOrDefault();

            if (string.IsNullOrEmpty(mostFreqSubstr))
            {
                // Нет подходящих слов, нужно сгенерить
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    char randomChar = (char)random.Next(97, 123);
                    builder.Append(randomChar);
                }

                mostFreqSubstr = builder.ToString();
            }
            return mostFreqSubstr;
        }
    }
}