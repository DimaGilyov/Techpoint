using System.Collections;

namespace Train.Codenames
{
    internal class Codenames
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            int t = int.Parse(input.ReadLine()); //количество наборов входных данны
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

                int a = 0;
            }
        }

        public HashSet<string> SuffixArray(string str)
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

        public string MostFrequentSubstr(string[] words, string blackWord, int blueWordsCount, int redWordsCount, out int maxDiffBetweenBlueAndRed)
        {

            HashSet<string> blackWordSuffixArray = SuffixArray(blackWord);
            blackWordSuffixArray.Add(blackWord);
            string[][] matrix = new string[words.Length][];

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                HashSet<string> suffixArray = SuffixArray(word);
                suffixArray.RemoveWhere(e => blackWordSuffixArray.Contains(e));
                matrix[i] = suffixArray.ToArray();
            }

            maxDiffBetweenBlueAndRed = 0;
            string mostFreqSubstr = string.Empty;

            Dictionary<string, int> blue = new Dictionary<string, int>();
            for (int i = 0; i < blueWordsCount; i++)
            {
                string[] subs = matrix[i];
                foreach (string s in subs)
                {
                    blue.TryGetValue(s, out int count);
                    count++;
                    blue[s] = count;
                }
            }

            Dictionary<string, int> red = new Dictionary<string, int>();
            for (int i = blueWordsCount; i < blueWordsCount + redWordsCount; i++)
            {
                string[] subs = matrix[i];
                foreach (string s in subs)
                {
                    red.TryGetValue(s, out int count);
                    count++;
                    red[s] = count;
                }
            }

            return mostFreqSubstr;
        }
    }
}
