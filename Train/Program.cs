using Train.Alerts;
using Train.CompetitionResults;
using Train.Stickers;
using Train.Summator;

namespace Techpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CompetitionResults prigramm = new CompetitionResults();
            string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\236");

            bool start = true;
            if (start)
            {
                foreach (string file in files)
                {
                    if (!file.EndsWith(".a"))
                    {
                        Console.WriteLine($"Run:{file}");
                        prigramm.Run(file);
                    }
                }

                foreach (string file in files)
                {
                    if (file.EndsWith(".a"))
                    {
                        Test(file);
                    }
                }
            }
            else
            {
                foreach (string file in files)
                {
                    if (file.EndsWith(".Test"))
                    {
                        File.Delete(file);
                    }
                }
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }

        public static void Test(string inputFilePath)
        {
            string testPath = inputFilePath.Replace(".a", ".Test");
            string orig = File.ReadAllText(inputFilePath).Trim().Replace("\r\n", "\n");
            string myResult = File.ReadAllText(testPath).Trim().Replace("\r\n", "\n"); ;
            if (orig != myResult)
            {
                Console.WriteLine($"Test failed:{inputFilePath}");
            }
        }
    }
}