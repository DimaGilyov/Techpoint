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
                int[] data = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
                int wordsCount = data[0];
                int blueWordsCount = data[1];
                int redWordsCount = data[2];
                int blackWordIndex = data[3] - 1;
                int whiteWordsCount = wordsCount - blueWordsCount - redWordsCount - 1;

                string blackWord = string.Empty;
                string[] words = new string[wordsCount - 1];
                int k = 0;
                for (int j = 0; j < wordsCount; j++)
                {
                    string word = input.ReadLine(); ;
                    if (j == blackWordIndex)
                    {
                        blackWord = word;
                    }
                    else
                    {
                        words[k] = word;
                        k++;
                    }
                }


                string w = MostFrequentSubstr(words, blackWord, blueWordsCount, redWordsCount, out int maxDiffBetweenBlueAndRed);
                output.WriteLine($"{w} {maxDiffBetweenBlueAndRed}");
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