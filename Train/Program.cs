using Train.Alerts;
using Train.Cards;
using Train.Codenames;
using Train.CompetitionResults;
using Train.DoctorsAppointments;
using Train.Stickers;
using Train.Summator;
using Train.VirusFile;

namespace Techpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Codenames prigramm = new Codenames();
            string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\237");

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
            //string orig = File.ReadAllText(inputFilePath).Trim().Replace("\r\n", "\n");
            //string myResult = File.ReadAllText(testPath).Trim().Replace("\r\n", "\n");
            //if (orig != myResult)
            //{
            //    Console.WriteLine($"Test failed:{inputFilePath}");
            //}

            string[] orig = File.ReadAllLines(inputFilePath);
            string[] test = File.ReadAllLines(testPath);
            for (int i = 0; i < orig.Length; i++)
            { 
                string origLine  = orig[i].Split()[1];
                string testLine = test[i].Split()[1]; ;
                if (origLine != testLine)
                {
                    Console.WriteLine($"Test failed:{inputFilePath} {i}, origLine={origLine}, testLine={testLine}");
                }
            }
        }
    }
}