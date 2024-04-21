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
                for (int j = 0; j < wordsCount; j++)
                {
                    string word = input.ReadLine(); ;
                    if (j == blackWordIndex)
                    {
                        blackWord = word;
                    }
                    else
                    {
                        words[j] = word;
                    }
                }


                string w = MostFrequentSubstr(words, blackWord, blueWordsCount, redWordsCount, out int maxDiffBetweenBlueAndRed);

                int a = 0;
            }
        }

        public List<string> SuffixArray(string str)
        {
            int n = str.Length;
            List<string> suffixes = new List<string>();

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

            List<string> blackWordSuffixArray = SuffixArray(blackWord);
            blackWordSuffixArray.Add(blackWord);
            string[][] matrix = new string[words.Length][];

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                List<string> suffixArray = SuffixArray(word);
                List<string> fildered = suffixArray.FindAll(x => !blackWordSuffixArray.Contains(x));
                matrix[i] = fildered.ToArray();
            }

            maxDiffBetweenBlueAndRed = 0;
            string mostFreqSubstr = string.Empty;



            return mostFreqSubstr;
        }
    }
}
