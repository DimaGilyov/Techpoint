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
            Alerts prigramm = new Alerts();
            string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\242");

            bool start = true;
            if (start)
            {
                DateTime startTime = DateTime.Now;
                foreach (string file in files)
                {
                    if (!file.EndsWith(".a"))
                    {
                        Console.WriteLine($"Run:{file}");
                        prigramm.Run(file);
                    }
                }
                Console.WriteLine(DateTime.Now - startTime);

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